$(document).ready(function () {

    /* Fill Coins Data While Page Loading */
    const COINS_KEY = 'top100_cryptos';
    const SELECT_BOX_ID = 'Crypto-Select';
    const COINGECKO_API = 'https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=100&page=1&sparkline=false';

    function fetchCrypto() {
        try {
            const response = fetch(COINGECKO_API);
            if (!response.ok) throw new Error('API fetch failed');
            const coins = response.json();
            localStorage.setItem(COINS_KEY, JSON.stringify(coins));
            return coins;
        } catch (error) {
            console.error('Error fetching data from CoinGecko:', error);
            return [];
        }
    }

    function populateSelectBox(coins) {
        const selectBox = document.getElementById(SELECT_BOX_ID);
        selectBox.innerHTML = '<option value="">Select a coin</option>';
        coins.forEach(coin => {
            const option = document.createElement('option');
            option.value = coin.id;
            option.textContent = `${coin.name} (${coin.symbol.toUpperCase()})`;
            selectBox.appendChild(option);
        });
    }

    function Initialize_Crypto() {
        let coins = [];

        const cached = localStorage.getItem(COINS_KEY);
        if (cached) {
            try {
                coins = JSON.parse(cached);
            } catch (e) {
                coins = fetchCrypto();
            }
        } else {
            coins = fetchCrypto();
        }

        if (coins.length > 0) {
            populateSelectBox(coins);
        }
    }

    Initialize_Crypto();

    // 🛠️ UTILS
    const API_BASE = 'https://api.coingecko.com/api/v3';
    const VS_CURRENCY = 'usd';

    // --- IndexedDB Utility ---
    const DB_NAME = 'CryptoWhisperCacheDB';
    const STORE_NAME = 'MarketDataStore';
    const DB_VERSION = 1;
    const CACHE_DURATION_MS = 10 * 60 * 1000; // 10 Minutes
    const MAX_CACHE_ENTRIES = 500;

    function openDB() {
        return new Promise((resolve, reject) => {
            const request = indexedDB.open(DB_NAME, DB_VERSION);
            request.onupgradeneeded = (event) => {
                const db = event.target.result;
                if (!db.objectStoreNames.contains(STORE_NAME)) {
                    const store = db.createObjectStore(STORE_NAME, { keyPath: 'key' });
                    store.createIndex('timestamp', 'timestamp', { unique: false });
                }
            };
            request.onsuccess = (event) => resolve(event.target.result);
            request.onerror = (event) => reject(event.target.error);
        });
    }

    async function getCachedData(key) {
        const db = await openDB();
        return new Promise((resolve, reject) => {
            const tx = db.transaction(STORE_NAME, 'readonly');
            const store = tx.objectStore(STORE_NAME);
            const req = store.get(key);
            req.onsuccess = () => resolve(req.result ? req.result.value : null);
            req.onerror = () => reject(req.error);
        });
    }

    async function setCachedData(key, value) {
        const db = await openDB();
        return new Promise((resolve, reject) => {
            const tx = db.transaction(STORE_NAME, 'readwrite');
            const store = tx.objectStore(STORE_NAME);
            const req = store.put({ key, value, timestamp: Date.now() });
            req.onsuccess = () => resolve(true);
            req.onerror = () => reject(req.error);
        });
    }

    async function cleanupCache() {
        const db = await openDB();
        return new Promise((resolve, reject) => {
            const tx = db.transaction(STORE_NAME, 'readwrite');
            const store = tx.objectStore(STORE_NAME);
            const index = store.index('timestamp');
            const entries = [];
            const request = index.openCursor(null, 'prev'); // Newest first

            request.onsuccess = (event) => {
                const cursor = event.target.result;
                if (cursor) {
                    entries.push(cursor);
                    if (entries.length > MAX_CACHE_ENTRIES) {
                        store.delete(cursor.primaryKey);
                    }
                    cursor.continue();
                } else {
                    resolve(true);
                }
            };
            request.onerror = () => reject(request.error);
        });
    }

    async function fetchWithCache(url, cacheKey) {
        try {
            const cached = await getCachedData(cacheKey);
            if (cached && (Date.now() - cached.timestamp < CACHE_DURATION_MS)) {
                return cached.data;
            }
        } catch {
            // Ignore cache errors
        }

        const response = await fetch(url);
        if (!response.ok) throw new Error('Network error');

        const data = await response.json();

        try {
            await setCachedData(cacheKey, { data, timestamp: Date.now() });
            cleanupCache(); // fire-and-forget
        } catch {
            // Ignore cache write/cleanup errors
        }

        return data;
    }

    async function getCachedTradeSuggestion(indicators) {
        const cacheKey = btoa(unescape(encodeURIComponent(JSON.stringify(indicators))));

        try {
            const cached = await getCachedData(cacheKey);
            if (cached && (Date.now() - cached.timestamp < CACHE_DURATION_MS)) {
                return cached.value;
            }
        } catch {
            // ignore cache read errors
        }

        const suggestion = getMockTradeSuggestion(indicators); // assume sync

        try {
            await setCachedData(cacheKey, suggestion);
            await cleanupCache();
        } catch {
            // ignore cache write errors
        }

        return suggestion;
    }


    // 💡 1. Smart Market Behavior
    // --- Technical indicator helpers ---
    function calculateRSI(prices, period = 14) {
        if (prices.length < period + 1) return null;
        let gains = 0, losses = 0;
        for (let i = 1; i <= period; i++) {
            const diff = prices[i] - prices[i - 1];
            if (diff >= 0) gains += diff;
            else losses -= diff;
        }
        let avgGain = gains / period;
        let avgLoss = losses / period;
        if (avgLoss === 0) return 100;
        let rs = avgGain / avgLoss;
        let rsi = 100 - (100 / (1 + rs));
        for (let i = period + 1; i < prices.length; i++) {
            const diff = prices[i] - prices[i - 1];
            let gain = diff > 0 ? diff : 0;
            let loss = diff < 0 ? -diff : 0;
            avgGain = (avgGain * (period - 1) + gain) / period;
            avgLoss = (avgLoss * (period - 1) + loss) / period;
            if (avgLoss === 0) rsi = 100;
            else {
                rs = avgGain / avgLoss;
                rsi = 100 - (100 / (1 + rs));
            }
        }
        return rsi;
    }

    function calculateEMA(data, period) {
        const k = 2 / (period + 1);
        let emaArray = [];
        let ema = data.slice(0, period).reduce((a, b) => a + b, 0) / period;
        emaArray[period - 1] = ema;
        for (let i = period; i < data.length; i++) {
            ema = data[i] * k + ema * (1 - k);
            emaArray[i] = ema;
        }
        return emaArray;
    }

    function calculateMACD(prices, fastPeriod = 12, slowPeriod = 26, signalPeriod = 9) {
        if (prices.length < slowPeriod + signalPeriod) return null;
        const emaFast = calculateEMA(prices, fastPeriod);
        const emaSlow = calculateEMA(prices, slowPeriod);
        let macdLine = [];
        for (let i = 0; i < prices.length; i++) {
            if (emaFast[i] !== undefined && emaSlow[i] !== undefined) {
                macdLine[i] = emaFast[i] - emaSlow[i];
            } else {
                macdLine[i] = undefined;
            }
        }
        const validMacdLine = macdLine.filter(x => x !== undefined);
        const signalLineArray = calculateEMA(validMacdLine, signalPeriod);
        const lastMacd = macdLine[macdLine.length - 1];
        const lastSignal = signalLineArray[signalLineArray.length - 1];
        if (lastMacd === undefined || lastSignal === undefined) return null;
        const histogram = lastMacd - lastSignal;
        return { macd: lastMacd, signal: lastSignal, histogram };
    }

    function calculateSMA(data, period) {
        if (data.length < period) return null;
        const smaArray = [];
        for (let i = 0; i <= data.length - period; i++) {
            const sum = data.slice(i, i + period).reduce((a, b) => a + b, 0);
            smaArray.push(sum / period);
        }
        return smaArray;
    }

    function calculateBollingerBands(prices, period = 20, stdDevMultiplier = 2) {
        if (prices.length < period) return null;
        const sma = calculateSMA(prices, period);
        let bands = [];
        for (let i = 0; i < sma.length; i++) {
            const slice = prices.slice(i, i + period);
            const mean = sma[i];
            const variance = slice.reduce((sum, val) => sum + Math.pow(val - mean, 2), 0) / period;
            const stdDev = Math.sqrt(variance);
            bands.push({
                middle: mean,
                upper: mean + stdDevMultiplier * stdDev,
                lower: mean - stdDevMultiplier * stdDev
            });
        }
        return bands;
    }

    async function getSmartMarketBehavior(coinId) {
        const ohlcURL = `https://api.coingecko.com/api/v3/coins/${coinId}/ohlc?vs_currency=usd&days=30`;
        const chartURL = `https://api.coingecko.com/api/v3/coins/${coinId}/market_chart?vs_currency=usd&days=1`;

        // Fetch with caching
        const [ohlcData, oneDayData] = await Promise.all([
            fetchWithCache(ohlcURL, `${coinId}_ohlc`),
            fetchWithCache(chartURL, `${coinId}_chart`)
        ]);

        if (!ohlcData || !ohlcData.length || !oneDayData?.prices?.length || !oneDayData?.total_volumes?.length) {
            return null;
        }

        // Extract price data for indicators
        const pricesFull = ohlcData.map(candle => candle[4]);
        const highs = ohlcData.map(candle => candle[2]);
        const lows = ohlcData.map(candle => candle[3]);
        const pricesOneDay = oneDayData.prices;
        const volumesOneDay = oneDayData.total_volumes;

        // Existing price-volume calculations
        const priceStart = pricesOneDay[0][1];
        const priceEnd = pricesOneDay.at(-1)[1];
        const volumeStart = volumesOneDay[0][1];
        const volumeEnd = volumesOneDay.at(-1)[1];

        const priceChange = priceEnd - priceStart;
        const volumeChange = volumeEnd - volumeStart;

        const pricePctChange = (priceChange / priceStart) * 100;
        const volumePctChange = (volumeChange / volumeStart) * 100;

        const smallPriceMove = 0.5;
        const largePriceMove = 5;
        const smallVolumeMove = 10;
        const largeVolumeMove = 60;

        const priceTrend = pricePctChange > smallPriceMove ? '↑' : pricePctChange < -smallPriceMove ? '↓' : '-';
        const volumeTrend = volumePctChange > smallVolumeMove ? '↑' : volumePctChange < -smallVolumeMove ? '↓' : '-';
        const combo = `PRICE ${getTrendWord(priceTrend)} - VOLUME ${getTrendWord(volumeTrend)}`;

        const isPriceStrongUp = pricePctChange > largePriceMove;
        const isPriceStrongDown = pricePctChange < -largePriceMove;
        const isVolumeStrongUp = volumePctChange > largeVolumeMove;
        const isVolumeStrongDown = volumePctChange < -largeVolumeMove;

        // === Simple, user-friendly text ===
        let label = '', meaning = '', insight = '', trap = '', forecast = '';

        if (priceTrend === '↑' && volumeTrend === '↑') {
            if (isPriceStrongUp && isVolumeStrongUp) {
                label = 'Price and trading are rising fast.';
                meaning = 'Many people are buying. Price is going up quickly.';
                insight = 'This is a strong uptrend.';
                trap = 'Low risk. Trend may keep going up.';
                forecast = 'Price may keep rising.';
            } else if (isPriceStrongUp && !isVolumeStrongUp) {
                label = 'Price is up, but not many are trading.';
                meaning = 'Price is rising, but not many people are buying.';
                insight = 'This uptrend is weak.';
                trap = 'Be careful. Price may fall if trading does not increase.';
                forecast = 'Price may stop rising soon.';
            } else if (!isPriceStrongUp && isVolumeStrongUp) {
                label = 'Trading is up, but price is flat.';
                meaning = 'A lot of trading, but price is not moving much.';
                insight = 'People may be getting ready to buy or sell.';
                trap = 'Watch for a big move soon.';
                forecast = 'Price may change direction soon.';
            } else {
                label = 'Price and trading are slowly going up.';
                meaning = 'Market is healthy and growing.';
                insight = 'This is a good sign.';
                trap = 'Risk is low.';
                forecast = 'Price may keep going up.';
            }
        }
        else if (priceTrend === '↓' && volumeTrend === '↑') {
            if (isPriceStrongDown && isVolumeStrongUp) {
                label = 'Many people are selling fast.';
                meaning = 'Price is dropping quickly. Lots of selling.';
                insight = 'This is a strong downtrend.';
                trap = 'High risk. Price may bounce back later.';
                forecast = 'Price may rise if selling slows down.';
            } else if (!isPriceStrongDown && isVolumeStrongUp) {
                label = 'More people are selling than buying.';
                meaning = 'Selling is increasing. Price is going down.';
                insight = 'Downtrend may be starting.';
                trap = 'Watch support levels.';
                forecast = 'Price may keep falling.';
            } else {
                label = 'Price is going down a little.';
                meaning = 'Price is down, but not by much.';
                insight = 'Market is a bit weak.';
                trap = 'Wait for a clear trend.';
                forecast = 'Price may fall slowly.';
            }
        }
        else if (priceTrend === '↑' && volumeTrend === '↓') {
            if (isPriceStrongUp && !isVolumeStrongDown) {
                label = 'Price is up, but not many are buying.';
                meaning = 'Price is rising, but trading is low.';
                insight = 'This uptrend is weak.';
                trap = 'Be careful. Price may fall soon.';
                forecast = 'Price may go down.';
            } else {
                label = 'Price is up, but not strong.';
                meaning = 'Price is rising slowly. Not many buyers.';
                insight = 'Trend is weak.';
                trap = 'Price may fall.';
                forecast = 'Price may move sideways or drop.';
            }
        }
        else if (priceTrend === '↓' && volumeTrend === '↓') {
            if (isPriceStrongDown && isVolumeStrongDown) {
                label = 'Price and trading are falling fast.';
                meaning = 'Market is losing interest quickly.';
                insight = 'Downtrend is strong.';
                trap = 'Price may bounce back soon.';
                forecast = 'Price may go sideways or up.';
            } else {
                label = 'Not much is happening.';
                meaning = 'Price and trading are both going down slowly.';
                insight = 'Market is quiet.';
                trap = 'No big moves expected.';
                forecast = 'Price may stay flat.';
            }
        }
        else if (priceTrend === '-' && volumeTrend === '↑') {
            label = 'People are slowly buying.';
            meaning = 'Price is flat, but trading is up.';
            insight = 'Buyers are getting ready.';
            trap = 'Good sign if it continues.';
            forecast = 'Price may go up soon.';
        }
        else if (priceTrend === '-' && volumeTrend === '-') {
            label = 'Market is quiet.';
            meaning = 'No big changes in price or trading.';
            insight = 'Nothing much is happening.';
            trap = 'Wait for a clear trend.';
            forecast = 'Price may stay flat.';
        }
        else if (priceTrend === '-' && volumeTrend === '↓') {
            label = 'Less trading, price is flat.';
            meaning = 'Not many people are trading. Price is not moving.';
            insight = 'Market is slow.';
            trap = 'Low activity. Be careful.';
            forecast = 'Price may not move much.';
        }
        else {
            label = 'Market is unclear.';
            meaning = 'Price and trading are not showing a clear trend.';
            insight = 'Wait for a better signal.';
            trap = 'Do not rush.';
            forecast = 'Wait and watch.';
        }

        // === Indicator calculations ===
        const rsi = calculateRSI(pricesFull);
        const macd = calculateMACD(pricesFull);
        const bb = calculateBollingerBands(pricesFull);
        const ma50 = calculateSMA(pricesFull, 50);
        const ma200 = calculateSMA(pricesFull, 200);

        // === Append indicator insights (keep these simple too) ===
        if (rsi !== null) {
            if (rsi > 70) {
                insight += '\nPrice is high. It may fall soon.';
                trap += '\nBe careful. Price may drop.';
            } else if (rsi < 30) {
                insight += '\nPrice is low. It may rise soon.';
                forecast += '\nPrice may go up.';
            } else {
                insight += '\nNo strong trend right now.';
            }
        } else {
            insight += '\nNo RSI data.';
        }

        if (macd !== null) {
            if (macd.histogram > 0) {
                insight += '\nStrong sign price may go up.';
                forecast += '\nUptrend possible.';
            } else if (macd.histogram < 0) {
                insight += '\nStrong sign price may go down.';
                forecast += '\nDowntrend possible.';
            } else {
                insight += '\nNo clear trend from MACD.';
            }
        } else {
            insight += '\nNo MACD data.';
        }

        if (bb !== null) {
            const lastClose = pricesFull[pricesFull.length - 1];
            const lastBB = bb[bb.length - 1];
            if (lastClose > lastBB.upper) {
                insight += '\nPrice is higher than usual. It may fall.';
                trap += '\nBe careful. Price may drop.';
            } else if (lastClose < lastBB.lower) {
                insight += '\nPrice is lower than usual. It may rise.';
                forecast += '\nPrice may go up.';
            } else {
                insight += '\nPrice is normal.';
            }
        } else {
            insight += '\nNo Bollinger Bands data.';
        }

        if (ma50 && ma200) {
            const lastMA50 = ma50[ma50.length - 1];
            const lastMA200 = ma200[ma200.length - 1];
            if (lastMA50 > lastMA200) {
                insight += '\nShort-term trend is up.';
                forecast += '\nUptrend may continue.';
            } else if (lastMA50 < lastMA200) {
                insight += '\nShort-term trend is down.';
                forecast += '\nDowntrend may continue.';
            } else {
                insight += '\nNo clear trend from moving averages.';
            }
        } else {
            insight += '\nNo moving average data.';
        }

        return {
            priceVolumeSignal: { combo, label, meaning },
            marketInsight: insight.trim(),
            trendForecast: forecast.trim(),
            traderTrap: trap.trim(),
            rsi,
            macd,
            bollingerBands: bb ? bb[bb.length - 1] : null,
            ma50_200: ma50 && ma200 ? { ma50: ma50[ma50.length - 1], ma200: ma200[ma200.length - 1] } : null
        };
    }

    // ✅ 2. Current Market Info
    async function getCurrentData(coinId) {
        // Fetch with cache for market data
        const marketURL = `https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids=${coinId}`;
        const chartURL = `https://api.coingecko.com/api/v3/coins/${coinId}/market_chart?vs_currency=usd&days=1`;

        const [marketData, chartData] = await Promise.all([
            fetchWithCache(marketURL, `${coinId}_market`),
            fetchWithCache(chartURL, `${coinId}_chart_1d`)
        ]);

        const [coin] = marketData;

        const prices = chartData.prices.map(p => p[1]); 

        const resistanceLevel = Math.max(...prices);
        const supportLevel = Math.min(...prices);

        return {
            name: coin.name,
            symbol: coin.symbol ? coin.symbol.toUpperCase() : '',
            marketPrice: coin.current_price, 
            image: coin.image, 
            priceChangePercent: coin.price_change_percentage_24h,
            volume_24h: coin.total_volume,
            resistance: resistanceLevel.toFixed(2),
            support: supportLevel.toFixed(2)
        };
    }

    // 🔮 3. Hourly Prediction
    async function getHourlyPrediction(coinId, investmentAmount = 100) {
        // Get 1-day price chart (5-min intervals)
        const chartURL = `https://api.coingecko.com/api/v3/coins/${coinId}/market_chart?vs_currency=usd&days=1`;
        const chartData = await fetchWithCache(chartURL, `${coinId}_chart_1d`);
        if (!chartData || !chartData.prices || chartData.prices.length < 13) return null;

        // Get current price
        const currentPrice = chartData.prices.at(-1)[1];

        // Calculate growth factors for 1h, 2h, 3h
        // Each hour = 12 intervals (5 min each)
        const nowIdx = chartData.prices.length - 1;
        const idx1h = Math.max(0, nowIdx - 12);
        const idx2h = Math.max(0, nowIdx - 24);
        const idx3h = Math.max(0, nowIdx - 36);

        const price1hAgo = chartData.prices[idx1h][1];
        const price2hAgo = chartData.prices[idx2h][1];
        const price3hAgo = chartData.prices[idx3h][1];

        // Growth factors: current / past
        const factor1h = currentPrice / price1hAgo;
        const factor2h = currentPrice / price2hAgo;
        const factor3h = currentPrice / price3hAgo;

        // Use these factors to project future prices (for demo, project forward with same rate)
        const predictions = {};

        // 1h projection: assume next hour grows at same rate as last hour
        const predictedPrice1h = currentPrice * factor1h;
        const coinQuantity = investmentAmount / currentPrice;
        predictions['1h'] = {
            predictedPrice: predictedPrice1h.toFixed(2),
            projectedAmount: (coinQuantity * predictedPrice1h).toFixed(2)
        };

        // 2h projection: compound last 2 hours' rate
        const predictedPrice2h = currentPrice * factor2h;
        predictions['2h'] = {
            predictedPrice: predictedPrice2h.toFixed(2),
            projectedAmount: (coinQuantity * predictedPrice2h).toFixed(2)
        };

        // 3h projection: compound last 3 hours' rate
        const predictedPrice3h = currentPrice * factor3h;
        predictions['3h'] = {
            predictedPrice: predictedPrice3h.toFixed(2),
            projectedAmount: (coinQuantity * predictedPrice3h).toFixed(2)
        };

        return predictions;
    }

    // 🔽 4. More Information
    async function getMoreInformation(coinId) {
        const coinDetailURL = `https://api.coingecko.com/api/v3/coins/${coinId}`;
        const chartURL = `https://api.coingecko.com/api/v3/coins/${coinId}/market_chart?vs_currency=usd&days=1`;

        // Fetch with caching
        const [coinDetail, chartData] = await Promise.all([
            fetchWithCache(coinDetailURL, `${coinId}_details`),
            fetchWithCache(chartURL, `${coinId}_chart`)
        ]);

        // Extract necessary data
        const marketCap = coinDetail.market_data.market_cap.usd;
        const circulatingSupply = coinDetail.market_data.circulating_supply;
        const totalMaxSupply = coinDetail.market_data.max_supply;

        const closes = chartData.prices.map(p => p[1]);
        const volumes = chartData.total_volumes.map(v => v[1]);
        const highs = closes.map(p => p * 1.02);
        const lows = closes.map(p => p * 0.98);

        const lastPrice = closes.at(-1);
        const prevClose = closes.at(-2);
        const priceChange = lastPrice - closes[0];
        const ma14 = closes.slice(-14).reduce((a, b) => a + b, 0) / 14;

        // RSI
        let gains = 0, losses = 0;
        for (let i = closes.length - 14; i < closes.length - 1; i++) {
            const diff = closes[i + 1] - closes[i];
            if (diff > 0) gains += diff;
            else losses -= diff;
        }
        const rs = gains / losses;
        const rsi = 100 - (100 / (1 + rs));
        const rsiUX = interpretRSI(rsi);

        // MACD
        const ema = (values, period) => {
            const k = 2 / (period + 1);
            const emaArr = [values[0]];
            for (let i = 1; i < values.length; i++) {
                emaArr.push(values[i] * k + emaArr[i - 1] * (1 - k));
            }
            return emaArr;
        };
        const ema12 = ema(closes, 12);
        const ema26 = ema(closes, 26);
        const macdLine = ema12.map((val, i) => val - ema26[i]);
        const signalLine = ema(macdLine, 9);
        const macd = macdLine.at(-1);
        const macdSignal = signalLine.at(-1);
        const macdHistogram = macd - macdSignal;
        const macdUX = interpretMACD(macd, macdSignal, macdHistogram);

        // Bollinger Bands
        const bbPrices = closes.slice(-20);
        const sma20 = bbPrices.reduce((a, b) => a + b, 0) / 20;
        const stdDev = Math.sqrt(bbPrices.map(p => Math.pow(p - sma20, 2)).reduce((a, b) => a + b) / 20);
        const bbUpper = sma20 + (2 * stdDev);
        const bbLower = sma20 - (2 * stdDev);
        const bbUX = interpretBollingerBands(lastPrice, sma20, bbUpper, bbLower, closes);

        // VWAP
        let cumulativeVol = 0, cumulativePV = 0;
        for (let i = 0; i < closes.length; i++) {
            cumulativeVol += volumes[i];
            cumulativePV += closes[i] * volumes[i];
        }
        const vwap = cumulativePV / cumulativeVol;
        const vwapUX = interpretVWAP(lastPrice, vwap, priceChange, prevClose);

        // ATR
        let tr = [];
        for (let i = 1; i < closes.length; i++) {
            const high = highs[i];
            const low = lows[i];
            const prev = closes[i - 1];
            tr.push(Math.max(high - low, Math.abs(high - prev), Math.abs(low - prev)));
        }
        const atr = tr.slice(-14).reduce((a, b) => a + b, 0) / 14;
        const atrUX = interpretATR(atr);

        // OBV
        let obv = 0;
        for (let i = 1; i < closes.length; i++) {
            if (closes[i] > closes[i - 1]) obv += volumes[i];
            else if (closes[i] < closes[i - 1]) obv -= volumes[i];
        }
        const obvTrend = obv > 0 ? 'rising' : obv < 0 ? 'falling' : 'flat';
        const priceTrend = lastPrice > closes[0] ? 'rising' : lastPrice < closes[0] ? 'falling' : 'flat';
        const obvUX = interpretOBV(obvTrend, priceTrend);

        // Trend
        const trendUX = interpretTrend(lastPrice, ma14, priceChange);

        // Liquidity
        const liquidityUX = interpretLiquidity(volumes.at(-1));

        // Candlestick pattern (placeholder flags)
        const candleFlags = {
            isBullishEngulfing: false,
            isBearishEngulfing: false,
            isHammer: false,
            isInvertedHammer: false,
            isShootingStar: false,
            isDoji: false,
            isDragonflyDoji: false,
            isGravestoneDoji: false,
            isMorningStar: false,
            isEveningStar: false,
            isThreeWhiteSoldiers: false,
            isThreeBlackCrows: false,
            isSpinningTop: false,
            isMarubozu: false,
            isInsideBar: false,
            isOutsideBar: false
        };
        const candleUX = interpretCandlePattern(candleFlags);

        // Final return
        return {
            marketCap: marketCap.toFixed(2),
            circulatingSupply: circulatingSupply.toFixed(2),
            totalMaxSupply: totalMaxSupply ? totalMaxSupply.toFixed(2) : 'N/A',
            priceChange: priceChange.toFixed(2),
            movingAverage: ma14.toFixed(2),
            rsi: { value: rsi.toFixed(2), label: rsiUX[0], color: rsiUX[1], description: rsiUX[2] },
            macd: { value: macd.toFixed(2), label: macdUX[0], color: macdUX[1], description: macdUX[2] },
            bollinger: { label: bbUX[0], color: bbUX[1], description: bbUX[2] },
            vwap: { value: vwap.toFixed(2), label: vwapUX[0], color: vwapUX[1], description: vwapUX[2] },
            atr: { value: atr.toFixed(2), label: atrUX[0], color: atrUX[1], description: atrUX[2] },
            obv: { label: obvUX[0], color: obvUX[1], description: obvUX[2] },
            trend: { label: trendUX[0], color: trendUX[1], description: trendUX[2] },
            candlestickPattern: { label: candleUX[0], color: candleUX[1], description: candleUX[2] },
            liquidity: { value: volumes.at(-1).toFixed(2), label: liquidityUX[0], color: liquidityUX[1], description: liquidityUX[2] }
        };
    }

    function interpretRSI(rsi) {
        if (rsi <= 10) return ['Very Low', 'Blue', 'Price is very low. It may go up.'];
        else if (rsi <= 20) return ['Low', 'Blue', 'Price is low. It could rise soon.'];
        else if (rsi <= 30) return ['A Bit Low', 'Blue', 'Price is a bit low.'];
        else if (rsi <= 40) return ['Slightly Up', 'Green', 'Price is slowly going up.'];
        else if (rsi <= 50) return ['Neutral', 'Green', 'No strong trend now.'];
        else if (rsi <= 60) return ['Slightly Down', 'Green', 'Price is slowly going down.'];
        else if (rsi <= 70) return ['A Bit High', 'Red', 'Price is a bit high.'];
        else if (rsi <= 80) return ['High', 'Red', 'Price is high. It may fall.'];
        else if (rsi <= 90) return ['Very High', 'Red', 'Price is very high. It may drop.'];
        else return ['Too High', 'Red', 'Price is too high. Be careful.'];
    }

    function interpretMACD(macd, macdSignal, macdHistogram) {
        const diff = Math.abs(macd - macdSignal);

        if (diff <= 0.005) return ['No Clear Signal', 'Light Gray', 'No clear trend.'];
        if (macd > macdSignal && macdHistogram > 0.1) return ['Strong Up', 'Bright Green', 'Price may go up.'];
        if (macd > macdSignal && macdHistogram > 0.005) return ['Going Up', 'Green', 'Price is starting to rise.'];
        if (macd > macdSignal && macdHistogram < 0.005) return ['Uptrend Weak', 'Yellow', 'Uptrend is getting weaker.'];
        if (macd < macdSignal && macdHistogram < -0.1) return ['Strong Down', 'Dark Red', 'Price may go down.'];
        if (macd < macdSignal && macdHistogram < -0.005) return ['Going Down', 'Red', 'Price is starting to fall.'];
        if (macd < macdSignal && macdHistogram > -0.005) return ['Downtrend Weak', 'Yellow', 'Downtrend is getting weaker.'];
        if (macd > macdSignal && macdHistogram < 0.05) return ['Uptrend Pausing', 'Orange', 'Uptrend may pause or stop.'];
        if (macd < macdSignal && macdHistogram > -0.05) return ['Downtrend Pausing', 'Orange', 'Downtrend may pause or stop.'];
        return ['Sideways', 'Gray', 'No strong move up or down.'];
    }

    function interpretBollingerBands(lastPrice, sma20, bbUpper, bbLower, closes) {
        const bbWidth = (bbUpper - bbLower) / sma20;
        const prevClose = closes[closes.length - 2];

        if (lastPrice > bbUpper) return ['Price is very high', 'Red', 'Price is higher than normal. It may fall.'];
        if (lastPrice < bbLower) return ['Price is very low', 'Blue', 'Price is lower than normal. It may rise.'];
        if (lastPrice > sma20 && lastPrice < bbUpper) return ['Going Up', 'Green', 'Price is going up.'];
        if (lastPrice < sma20 && lastPrice > bbLower) return ['Going Down', 'Light Blue', 'Price is going down.'];
        if (lastPrice > sma20 && sma20 > prevClose) return ['Uptrend', 'Green', 'Price is moving up.'];
        if (lastPrice < sma20 && sma20 < prevClose) return ['Downtrend', 'Red', 'Price is moving down.'];
        if (bbWidth < 0.01) return ['Very Calm', 'Yellow', 'Not much is happening.'];
        if (bbWidth > 0.05) return ['Very Active', 'Orange', 'Big price changes.'];
        return ['Stable', 'Light Gray', 'Price is steady.'];
    }

    function interpretVWAP(lastPrice, vwap, priceChange, prevClose) {
        const diffPercent = Math.abs((lastPrice - vwap) / vwap);

        if (diffPercent <= 0.01) return ['Flat Market', 'Gray', 'Price is close to average.'];
        if (lastPrice > vwap && priceChange > 0) return ['Strong Up', 'Bright Green', 'Price is above average and rising.'];
        if (lastPrice > vwap && prevClose < vwap) return ['Breaking Up', 'Light Green', 'Price just moved above average.'];
        if (lastPrice > vwap) return ['Above Average', 'Green', 'Price is above average.'];
        if (lastPrice < vwap && priceChange < 0) return ['Strong Down', 'Dark Red', 'Price is below average and falling.'];
        if (lastPrice < vwap && prevClose > vwap) return ['Breaking Down', 'Light Red', 'Price just moved below average.'];
        if (lastPrice < vwap) return ['Below Average', 'Red', 'Price is below average.'];
        return ['Unclear', 'Yellow', 'No clear signal.'];
    }

    function interpretATR(atr) {
        if (atr < 50) return ['Very Calm', 'Light Gray', 'Price is moving very little.'];
        if (atr < 100) return ['Calm', 'Gray', 'Small price changes.'];
        if (atr < 150) return ['Getting Active', 'Yellow', 'Price is moving more.'];
        if (atr < 250) return ['Normal', 'Green', 'Price is moving normally.'];
        if (atr < 350) return ['Active', 'Red', 'Price is moving a lot.'];
        if (atr < 500) return ['Very Active', 'Dark Red', 'Big price swings.'];
        if (atr < 600) return ['Cooling Down', 'Orange', 'Price is calming down.'];
        if (atr < 700) return ['Risky', 'Orange', 'Price is unstable.'];
        if (atr < 800) return ['Getting Calm', 'Light Green', 'Price is getting steady.'];
        return ['No Signal', 'Gray', 'No clear trend.'];
    }

    function interpretOBV(obvTrend, priceTrend) {
        if (obvTrend === 'rising' && priceTrend === 'rising') return ['Buyers are strong', 'Green', 'More people are buying.'];
        if (obvTrend === 'rising' && priceTrend === 'flat') return ['Buyers are coming', 'Bright Green', 'Buyers may push price up.'];
        if (obvTrend === 'falling' && priceTrend === 'falling') return ['Sellers are strong', 'Red', 'More people are selling.'];
        if (obvTrend === 'falling' && priceTrend === 'rising') return ['Sellers are coming', 'Orange', 'Sellers may push price down.'];
        if (obvTrend === 'flat' && priceTrend === 'flat') return ['No Movement', 'Light Gray', 'Not much is happening.'];
        return ['Not Matching', 'Yellow', 'Buyers and sellers are not clear.'];
    }

    function interpretTrend(lastPrice, ma14, priceChange) {
        if (lastPrice > ma14 && priceChange > 0) return ['Strong Up', 'Bright Green', 'Price is going up fast.'];
        if (lastPrice > ma14) return ['Uptrend', 'Green', 'Price is going up.'];
        if (lastPrice < ma14 && priceChange < 0) return ['Strong Down', 'Dark Red', 'Price is going down fast.'];
        if (lastPrice < ma14) return ['Downtrend', 'Red', 'Price is going down.'];
        if (Math.abs(priceChange) < 10) return ['Sideways', 'Gray', 'Price is not moving much.'];
        return ['Unstable', 'Yellow', 'Price is changing a lot.'];
    }

    function interpretCandlePattern(flags) {
        const {
            isBullishEngulfing,
            isBearishEngulfing,
            isHammer,
            isInvertedHammer,
            isShootingStar,
            isDoji,
            isDragonflyDoji,
            isGravestoneDoji,
            isMorningStar,
            isEveningStar,
            isThreeWhiteSoldiers,
            isThreeBlackCrows,
            isSpinningTop,
            isMarubozu,
            isInsideBar,
            isOutsideBar,
        } = flags;

        if (isBullishEngulfing) return ['Strong Buy Signal', 'Green', 'Price may go up.'];
        if (isBearishEngulfing) return ['Strong Sell Signal', 'Red', 'Price may go down.'];
        if (isHammer) return ['Hammer', 'Green', 'Price may bounce up.'];
        if (isInvertedHammer) return ['Inverted Hammer', 'Light Green', 'Price may go up.'];
        if (isShootingStar) return ['Shooting Star', 'Red', 'Price may fall.'];
        if (isDoji) return ['Doji', 'Gray', 'Market is unsure.'];
        if (isDragonflyDoji) return ['Dragonfly Doji', 'Green', 'Price may bounce up.'];
        if (isGravestoneDoji) return ['Gravestone Doji', 'Red', 'Price may fall.'];
        if (isMorningStar) return ['Morning Star', 'Bright Green', 'Price may go up.'];
        if (isEveningStar) return ['Evening Star', 'Dark Red', 'Price may go down.'];
        if (isThreeWhiteSoldiers) return ['Three White Soldiers', 'Bright Green', 'Strong uptrend.'];
        if (isThreeBlackCrows) return ['Three Black Crows', 'Dark Red', 'Strong downtrend.'];
        if (isSpinningTop) return ['Spinning Top', 'Yellow', 'No clear direction.'];
        if (isMarubozu) return ['Marubozu', 'Black or White', 'Strong move in one direction.'];
        if (isInsideBar) return ['Inside Bar', 'Light Gray', 'Price is steady.'];
        if (isOutsideBar) return ['Outside Bar', 'Blue', 'Price is moving a lot.'];
        return ['No Pattern', 'Gray', 'No clear signal.'];
    }

    function interpretLiquidity(latestVolume) {
        if (latestVolume > 5_000_000_000) return ['Very Easy to Trade', 'Dark Green', 'You can buy or sell easily.'];
        else if (latestVolume > 2_000_000_000) return ['Easy to Trade', 'Green', 'Market is very active.'];
        else if (latestVolume > 1_000_000_000) return ['Active Market', 'Green', 'You can trade with little trouble.'];
        else if (latestVolume > 750_000_000) return ['Good Trading', 'Green', 'Trading is smooth.'];
        else if (latestVolume > 500_000_000) return ['Fine Trading', 'Light Green', 'You can trade easily.'];
        else if (latestVolume > 300_000_000) return ['OK Trading', 'Light Green', 'Most trades will work.'];
        else if (latestVolume > 200_000_000) return ['Somewhat Active', 'Yellow', 'You may see some delays.'];
        else if (latestVolume > 100_000_000) return ['Caution', 'Yellow', 'Trading is getting slow.'];
        else if (latestVolume > 75_000_000) return ['Thin Market', 'Orange', 'It may be hard to trade.'];
        else if (latestVolume > 50_000_000) return ['Low Trading', 'Orange', 'Trading may affect price.'];
        else if (latestVolume > 25_000_000) return ['Risky', 'Dark Orange', 'Big trades can move price.'];
        else if (latestVolume > 10_000_000) return ['Very Risky', 'Red', 'Trading is hard and risky.'];
        else if (latestVolume > 1_000_000) return ['Almost No Trading', 'Dark Red', 'Very hard to trade.'];
        else return ['No Trading', 'Black', 'No one is buying or selling.'];
    }

    // 📊 5. Trade Suggestion 
    function getMockTradeSuggestion(indicators) {
        const { rsi, macd, trend, vwap, bollinger, candlestickPattern, obv, atr, liquidity } = indicators;

        if (rsi.label.includes("Danger Zone") || atr.label.includes("Extreme")) {
            return "Market is very risky now. It's better to wait.";
        }

        if (rsi.label.includes("Very Low") && macd.label.includes("Up")) {
            return "Price is very low and may go up soon. Watch for a bounce.";
        }

        if (rsi.label.includes("Too High") && macd.label.includes("Down")) {
            return "Price is too high and may fall soon. Think about selling or waiting.";
        }

        if (macd.label.includes("Strong Down")) {
            return "Price is falling fast. Avoid buying now.";
        }

        if (macd.label.includes("Strong Up") && rsi.label.includes("Up")) {
            return "Price is rising strongly. It could be a good time to buy.";
        }

        if (macd.label.includes("Going Up") && obv.label.includes("Buyers")) {
            return "Price is starting to rise and buyers are active. Watch for a breakout.";
        }

        if (trend.label.includes("Uptrend") && macd.label.includes("Up")) {
            return "Price is going up and trend is strong. Many traders buy in this situation.";
        }

        if (trend.label.includes("Downtrend") && obv.label.includes("Sellers")) {
            return "Price is going down and sellers are strong. Avoid buying.";
        }

        if (vwap.label.includes("Breaking Up") && bollinger.label.includes("Very Calm")) {
            return "Price may move up soon. Market is calm but showing signs of a breakout.";
        }

        if (candlestickPattern.label.includes("Strong Buy Signal") && rsi.label.includes("Very Low")) {
            return "Price is very low and a buy signal appeared. Watch for a bounce up.";
        }

        if (candlestickPattern.label.includes("Shooting Star") || candlestickPattern.label.includes("Strong Sell Signal")) {
            return "Sell signal appeared. Price may fall. Be careful.";
        }

        if (candlestickPattern.label.includes("Hammer") && vwap.label.includes("Breaking Up")) {
            return "Hammer pattern and price is breaking up. Price may bounce up.";
        }

        if (rsi.label.includes("Neutral") && atr.label.includes("Getting Calm")) {
            return "Market is calm and unclear. Wait for a clear signal.";
        }

        if (obv.label.includes("Buyers are coming")) {
            return "Buyers are getting active. Price may go up soon.";
        }

        if (obv.label.includes("Sellers are coming")) {
            return "Sellers are getting active. Price may go down soon.";
        }

        if (atr.label.includes("Active") && bollinger.label.includes("Price is very high")) {
            return "Price is high and moving a lot. Be careful, it may fall.";
        }

        if (atr.label.includes("Calm") && trend.label.includes("Sideways")) {
            return "Market is slow and not moving much. Wait for a breakout.";
        }

        if (vwap.label.includes("Below") && trend.label.includes("Downtrend")) {
            return "Price is below average and going down. Not a good time to buy.";
        }

        if (vwap.label.includes("Above") && trend.label.includes("Uptrend")) {
            return "Price is above average and going up. Good sign for buyers.";
        }

        if (liquidity.label.includes("Low") && atr.label.includes("Active")) {
            return "Market is risky and trading is hard. Stay away for now.";
        }

        if (liquidity.label.includes("Good") && trend.label.includes("Uptrend")) {
            return "Market is healthy and price is going up. You can buy safely.";
        }

        if (bollinger.label.includes("Very Calm")) {
            return "Market is calm. Watch for a big move soon.";
        }

        if (bollinger.label.includes("Price is very low") && macd.label.includes("Up")) {
            return "Price is very low and may go up. Good chance for buyers.";
        }

        if (candlestickPattern.label.includes("Three White Soldiers")) {
            return "Strong buy signal. Price is going up.";
        }

        if (candlestickPattern.label.includes("Three Black Crows")) {
            return "Strong sell signal. Price is going down.";
        }

        if (candlestickPattern.label.includes("Doji") && rsi.label.includes("Neutral")) {
            return "Market is unsure. Wait for a clear move.";
        }

        if (macd.label.includes("No Clear Signal") && trend.label.includes("Sideways")) {
            return "Market is flat and unclear. Wait for a better signal.";
        }

        if (trend.label.includes("Unstable")) {
            return "Price is changing a lot. Wait for a clear trend.";
        }

        if (atr.label.includes("Cooling Down") && obv.label.includes("Buyers")) {
            return "Market was active but is calming down. Buyers may return soon.";
        }

        if (candlestickPattern.label.includes("Morning Star") || candlestickPattern.label.includes("Dragonfly")) {
            return "Buy signal at the bottom. Price may go up.";
        }

        if (candlestickPattern.label.includes("Evening Star") || candlestickPattern.label.includes("Gravestone")) {
            return "Sell signal at the top. Price may go down.";
        }

        if (vwap.label.includes("Flat Market") || vwap.label.includes("Stable")) {
            return "Price is steady. Wait for a clear move.";
        }

        if (trend.label.includes("Choppy") || trend.label.includes("Noisy")) {
            return "Market is messy. Wait for a clear trend.";
        }

        return "Market is not clear. It's better to wait and watch.";
    }


    // 📰 6. Market Sentiment 
    async function getMarketSentiment() {
        const cacheKey = 'marketSentiment';
        const CACHE_DURATION_MS = 10 * 60 * 1000; 

        // Try to get cached data first
        try {
            const cached = await getCachedData(cacheKey);
            if (cached && (Date.now() - cached.timestamp < CACHE_DURATION_MS)) {
                return cached.value;
            }
        } catch {
            // Ignore cache errors, fallback to fetch
        }

        // Fetch fresh data
        const res = await fetch('https://api.alternative.me/fng/?limit=1', {
            method: 'GET',
            headers: {
                'Accept': 'application/json',
                'User-Agent': 'Mozilla/5.0 (compatible; CryptoWhisper/1.0)',
                'Referer': 'https://khizooo.com'
            },
            mode: 'cors',
            cache: 'no-cache'
        });
        const data = await res.json();
        const index = parseInt(data.data[0].value);

        let label = '', color = '', description = '';

        if (index === 0) [label, color, description] = ['No Hope', 'Black', 'Everyone is scared.'];
        else if (index === 1) [label, color, description] = ['Very Scared', 'Dark Red', 'People are selling fast.'];
        else if (index === 2) [label, color, description] = ['Panic', 'Dark Red', 'Market is in panic.'];
        else if (index === 3) [label, color, description] = ['Big Fear', 'Dark Red', 'Most people are afraid.'];
        else if (index === 4) [label, color, description] = ['Selling Fast', 'Dark Red', 'Many are selling quickly.'];
        else if (index === 5) [label, color, description] = ['Crash', 'Dark Red', 'Market is crashing.'];
        else if (index === 6) [label, color, description] = ['No Buyers', 'Dark Red', 'Nobody wants to buy.'];
        else if (index === 7) [label, color, description] = ['Breaking Down', 'Dark Red', 'Prices are falling hard.'];
        else if (index === 8) [label, color, description] = ['Very Weak', 'Dark Red', 'Market is very weak.'];
        else if (index === 9) [label, color, description] = ['Red Everywhere', 'Dark Red', 'Everything is going down.'];
        else if (index === 10) [label, color, description] = ['Desperate', 'Dark Red', 'People are desperate to sell.'];
        else if (index === 11) [label, color, description] = ['No Interest', 'Dark Red', 'No one wants to trade.'];
        else if (index === 12) [label, color, description] = ['Wave of Fear', 'Dark Red', 'Fear is spreading.'];
        else if (index === 13) [label, color, description] = ['Very Negative', 'Dark Red', 'Mood is very bad.'];
        else if (index === 14) [label, color, description] = ['Support Lost', 'Dark Red', 'Prices broke support.'];
        else if (index === 15) [label, color, description] = ['Very Cheap', 'Dark Red', 'Prices are very low.'];
        else if (index === 16) [label, color, description] = ['Still Scared', 'Red', 'People are still worried.'];
        else if (index === 17) [label, color, description] = ['Worried', 'Red', 'Market is worried.'];
        else if (index === 18) [label, color, description] = ['Bad Mood', 'Red', 'People feel bad about the market.'];
        else if (index === 19) [label, color, description] = ['Selling', 'Red', 'Many are selling.'];
        else if (index === 20) [label, color, description] = ['Fear', 'Red', 'Fear is high.'];
        else if (index === 21) [label, color, description] = ['Avoiding Risk', 'Red', 'People avoid risky trades.'];
        else if (index === 22) [label, color, description] = ['Red Market', 'Red', 'Market is mostly red.'];
        else if (index === 23) [label, color, description] = ['Pain', 'Red', 'People are losing money.'];
        else if (index === 24) [label, color, description] = ['Weak Hands', 'Red', 'Weak traders are selling.'];
        else if (index === 25) [label, color, description] = ['Cautious', 'Red', 'People are careful.'];
        else if (index === 26) [label, color, description] = ['Not Buying', 'Red', 'Few are buying.'];
        else if (index === 27) [label, color, description] = ['Bearish', 'Red', 'Market is going down.'];
        else if (index === 28) [label, color, description] = ['Downtrend', 'Red', 'Prices are trending down.'];
        else if (index === 29) [label, color, description] = ['No Trust', 'Red', 'People do not trust the market.'];
        else if (index === 30) [label, color, description] = ['Mild Fear', 'Red', 'Some fear in the market.'];
        else if (index === 31) [label, color, description] = ['Skeptical', 'Orange', 'People are not sure.'];
        else if (index === 32) [label, color, description] = ['Trying to Recover', 'Orange', 'Market is trying to get better.'];
        else if (index === 33) [label, color, description] = ['Small Bounce', 'Orange', 'Prices are bouncing a little.'];
        else if (index === 34) [label, color, description] = ['Some Hope', 'Orange', 'A few buyers are coming.'];
        else if (index === 35) [label, color, description] = ['Waiting', 'Orange', 'People are waiting for a move.'];
        else if (index === 36) [label, color, description] = ['Getting Calm', 'Gray', 'Market is calming down.'];
        else if (index === 37) [label, color, description] = ['Sideways', 'Gray', 'Prices are moving sideways.'];
        else if (index === 38) [label, color, description] = ['No Direction', 'Gray', 'No clear trend.'];
        else if (index === 39) [label, color, description] = ['Flat', 'Gray', 'Market is flat.'];
        else if (index === 40) [label, color, description] = ['No Big Moves', 'Gray', 'No big price changes.'];
        else if (index === 41) [label, color, description] = ['Watching', 'Gray', 'People are watching and waiting.'];
        else if (index === 42) [label, color, description] = ['Balanced', 'Gray', 'Buyers and sellers are equal.'];
        else if (index === 43) [label, color, description] = ['A Bit Positive', 'Light Green', 'Some are feeling better.'];
        else if (index === 44) [label, color, description] = ['Warming Up', 'Light Green', 'Market is getting better.'];
        else if (index === 45) [label, color, description] = ['Slightly Up', 'Light Green', 'Prices are moving up a little.'];
        else if (index === 46) [label, color, description] = ['Careful Buyers', 'Light Green', 'Some are buying carefully.'];
        else if (index === 47) [label, color, description] = ['Hopeful', 'Light Green', 'People are hopeful.'];
        else if (index === 48) [label, color, description] = ['Buy Signals', 'Light Green', 'Some buy signals are showing.'];
        else if (index === 49) [label, color, description] = ['Positive', 'Light Green', 'Market is positive.'];
        else if (index === 50) [label, color, description] = ['Neutral', 'Gray', 'Market is neutral.'];
        else if (index === 51) [label, color, description] = ['Careful Greed', 'Light Green', 'People are starting to buy.'];
        else if (index === 52) [label, color, description] = ['Buyers Back', 'Light Green', 'Buyers are coming back.'];
        else if (index === 53) [label, color, description] = ['Slow Up', 'Light Green', 'Market is slowly going up.'];
        else if (index === 54) [label, color, description] = ['Uptrend Starting', 'Light Green', 'Uptrend may be starting.'];
        else if (index === 55) [label, color, description] = ['More Buyers', 'Light Green', 'More people are buying.'];
        else if (index === 56) [label, color, description] = ['Reversal', 'Green', 'Market is turning up.'];
        else if (index === 57) [label, color, description] = ['Confident', 'Green', 'Buyers are confident.'];
        else if (index === 58) [label, color, description] = ['Accumulating', 'Green', 'People are buying and holding.'];
        else if (index === 59) [label, color, description] = ['Momentum', 'Green', 'Market is gaining strength.'];
        else if (index === 60) [label, color, description] = ['Greed', 'Green', 'People want to buy more.'];
        else if (index === 61) [label, color, description] = ['Greedy', 'Green', 'Greed is growing.'];
        else if (index === 62) [label, color, description] = ['Optimistic', 'Green', 'People feel good.'];
        else if (index === 63) [label, color, description] = ['Breakout Soon', 'Green', 'A big move may come soon.'];
        else if (index === 64) [label, color, description] = ['Strong Trend', 'Green', 'Trend is strong.'];
        else if (index === 65) [label, color, description] = ['Very Greedy', 'Green', 'People are very greedy.'];
        else if (index === 66) [label, color, description] = ['Climbing Fast', 'Green', 'Prices are rising fast.'];
        else if (index === 67) [label, color, description] = ['Green Days', 'Green', 'Many days are positive.'];
        else if (index === 68) [label, color, description] = ['All-Time High', 'Green', 'Prices are at new highs.'];
        else if (index === 69) [label, color, description] = ['Spike', 'Green', 'Prices are spiking up.'];
        else if (index === 70) [label, color, description] = ['Extreme Greed', 'Bright Green', 'People are too greedy.'];
        else if (index === 71) [label, color, description] = ['Bubble Signs', 'Bright Green', 'Market may be in a bubble.'];
        else if (index === 72) [label, color, description] = ['Buying Mania', 'Bright Green', 'Everyone is buying.'];
        else if (index === 73) [label, color, description] = ['Blind Buying', 'Bright Green', 'People buy without thinking.'];
        else if (index === 74) [label, color, description] = ['Speculation', 'Bright Green', 'Lots of risky trades.'];
        else if (index === 75) [label, color, description] = ['Overheated', 'Bright Green', 'Market is too hot.'];
        else if (index === 76) [label, color, description] = ['Ignoring Risks', 'Bright Green', 'People ignore risks.'];
        else if (index === 77) [label, color, description] = ['Max Greed', 'Bright Green', 'Greed is at the highest.'];
        else if (index === 78) [label, color, description] = ['Moon Talk', 'Bright Green', 'People expect huge gains.'];
        else if (index === 79) [label, color, description] = ['Too Good', 'Bright Green', 'Market looks too good.'];
        else if (index === 80) [label, color, description] = ['FOMO', 'Bright Green', 'People fear missing out.'];
        else if (index === 81) [label, color, description] = ['Crowd Buying', 'Bright Green', 'Crowds are buying.'];
        else if (index === 82) [label, color, description] = ['Hype', 'Bright Green', 'Market is full of hype.'];
        else if (index === 83) [label, color, description] = ['Big Gains', 'Bright Green', 'People see big profits.'];
        else if (index === 84) [label, color, description] = ['Exit Soon', 'Bright Green', 'Smart traders may sell soon.'];
        else if (index === 85) [label, color, description] = ['Tired Market', 'Bright Green', 'Market is getting tired.'];
        else if (index === 86) [label, color, description] = ['Top Alert', 'Bright Green', 'Market may be at the top.'];
        else if (index === 87) [label, color, description] = ['Overbought', 'Bright Green', 'Too many buyers.'];
        else if (index === 88) [label, color, description] = ['Heavy Top', 'Bright Green', 'Selling may start soon.'];
        else if (index === 89) [label, color, description] = ['Too Much Greed', 'Bright Green', 'Greed is too high.'];
        else if (index === 90) [label, color, description] = ['Dangerous', 'Bright Green', 'Market is risky now.'];
        else if (index === 91) [label, color, description] = ['Spike Up', 'Bright Green', 'Prices are jumping up.'];
        else if (index === 92) [label, color, description] = ['Sell News', 'Bright Green', 'People may sell on news.'];
        else if (index === 93) [label, color, description] = ['Exit Time', 'Bright Green', 'Time to think about selling.'];
        else if (index === 94) [label, color, description] = ['Bubble Talk', 'Bright Green', 'People talk about a bubble.'];
        else if (index === 95) [label, color, description] = ['Parabolic', 'Bright Green', 'Prices are rising too fast.'];
        else if (index === 96) [label, color, description] = ['Final Push', 'Bright Green', 'Last big move up.'];
        else if (index === 97) [label, color, description] = ['Turning Point', 'Bright Green', 'Market may turn soon.'];
        else if (index === 98) [label, color, description] = ['Getting Tired', 'Bright Green', 'Market is losing energy.'];
        else if (index === 99) [label, color, description] = ['Flashy', 'Bright Green', 'Market is flashy and risky.'];
        else if (index === 100) [label, color, description] = ['Too Confident', 'Bright Green', 'People are too sure. Be careful.'];
        else[label, color, description] = ['Unknown', 'Gray', 'No data.'];

        const result = {
            value: index,
            label,
            color,
            description,
            source: 'alternative.me',
            raw: data.data[0]
        };

        // Cache the result
        try {
            await setCachedData(cacheKey, result);
            cleanupCache(); // fire-and-forget
        } catch {
            // ignore cache errors
        }

        return result;
    }


    // Helper Functions
    function formatBinanceNumber(value, currency = false, currencySymbol = '$') {
        // Convert to number and check for invalid input
        const num = Number(value);
        if (!isFinite(num)) return '-';

        const abs = Math.abs(num);
        let formatted;

        if (abs >= 1_000_000_000) {
            formatted = (num / 1_000_000_000).toFixed(2).replace(/\.00$/, '') + 'B';
        } else if (abs >= 1_000_000) {
            formatted = (num / 1_000_000).toFixed(2).replace(/\.00$/, '') + 'M';
        } else if (abs >= 1_000) {
            formatted = (num / 1_000).toFixed(2).replace(/\.00$/, '') + 'K';
        } else if (abs >= 1) {
            formatted = num.toLocaleString('en-US', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
        } else if (abs > 0) {
            formatted = num.toFixed(8).replace(/\.?0+$/, '');
            if (formatted.indexOf('.') === -1) formatted += '.00';
            else if (formatted.split('.')[1].length === 1) formatted += '0';
        } else {
            formatted = '0.00';
        }

        // Add currency symbol if needed, always at the end (Binance style)
        if (currency) formatted += currencySymbol;

        return formatted;
    }

    function getTrendWord(trend) {
        if (trend === '↑') return 'Up';
        if (trend === '↓') return 'Down';
        return 'Stable';
    }
    
    function prefixArrow(text) {
        if (!text) return '-> -';
        return text
            .toString()
            .split('\n')
            .map(line => '-> ' + line.trim())
            .join('\n');
    }


    let controller = null;
    $("body").on('click', '#Prediction-Button', async function (e) { 

        const $button = $(this);
        const $coinSelect = $('#Crypto-Select');
        const $investmentInput = $('#Investment-Amount');

        const selectedCoin = $coinSelect.val();
        const investmentAmount = $.trim($investmentInput.val());

        if (!selectedCoin) { alert("Please select a coin."); }

        if (!investmentAmount || isNaN(investmentAmount) || Number(investmentAmount) <= 0) { alert("Please enter a valid investment amount in $."); return; }

        // Abort previous if ongoing
        if (controller) { controller.abort(); }

        // New AbortController for this request
        controller = new AbortController();
        const signal = controller.signal;

        // Disable the button
        $button.prop('disabled', true).text('Processing');

        const smartBehavior = await getSmartMarketBehavior(selectedCoin);
        const current = await getCurrentData(selectedCoin);
        const prediction = await getHourlyPrediction(selectedCoin, Number(investmentAmount));
        const moreInfo = await getMoreInformation(selectedCoin);
        const suggestion = await getCachedTradeSuggestion(moreInfo);
        const sentiment = await getMarketSentiment();
        // Assign Values to HTML

        console.log('💡 Smart Market Behavior', smartBehavior);
        console.log('✅ Current', current);
        console.log('🔮 Hourly Prediction', prediction);
        console.log('🔽 More Information', moreInfo);
        console.log('📊 Trade Suggestion', suggestion);
        console.log('📰 Market Sentiment', sentiment);

        // Try to get coin logo and display heading with logo
        let headingHtml = '';
        if (current && current.name && current.symbol && current.marketPrice) {
            // Try to get the logo from cached coins list
            let coins = [];
            try {
                coins = JSON.parse(localStorage.getItem('top100_cryptos')) || [];
            } catch { coins = []; }
            const coinInfo = coins.find(c => c.id === selectedCoin);

            // Use CoinGecko image if available
            const logoUrl = coinInfo && coinInfo.image ? coinInfo.image : (current.image || '');

            const price = formatBinanceNumber(current.marketPrice, true);
            const percent = (current.priceChangePercent > 0 ? '+' : '') + Number(current.priceChangePercent).toFixed(2) + '%';
            const percentColor = current.priceChangePercent > 0 ? '#28a745' : '#dc3545'; // Bootstrap green/red

            headingHtml = `
    ${logoUrl ? `<img src="${logoUrl}" alt="${current.symbol}" style="width:32px;height:32px;vertical-align:middle;margin-right:8px;border-radius:50%;box-shadow:0 1px 4px #ccc;">` : ''}
    <span style="vertical-align:middle;">
        ${current.name} (${current.symbol}) - <span style="font-size: 0.9rem;font-weight: 400;">
            1 ${current.name} equals ${price}
            ${current.priceChangePercent !== undefined
                    ? ` | <span style="color:${percentColor};font-weight:600;">${percent}</span> 1D`
                    : ''}
        </span>
    </span>
`;
            $('#SelectedCryptoTitle').html(headingHtml);
        }
        else {
            $('#SelectedCryptoTitle').text('');
        }

        // Hourly Prediction
        $('#Prediction1h').text(formatBinanceNumber(prediction?.['1h']?.predictedPrice, true));
        $('#Prediction2h').text(formatBinanceNumber(prediction?.['2h']?.predictedPrice, true));
        $('#Prediction3h').text(formatBinanceNumber(prediction?.['3h']?.predictedPrice, true));
        $('#Projected1h').text(formatBinanceNumber(prediction?.['1h']?.projectedAmount, true));
        $('#Projected2h').text(formatBinanceNumber(prediction?.['2h']?.projectedAmount, true));
        $('#Projected3h').text(formatBinanceNumber(prediction?.['3h']?.projectedAmount, true));

        // Smart Market Behavior
        // $('#Price-Volume-Signal').text(`${smartBehavior?.priceVolumeSignal?.combo ?? '-'}\n${smartBehavior?.priceVolumeSignal?.label ?? '-'}${smartBehavior?.priceVolumeSignal?.meaning ?? '-'}`);
        // $('#Market-Insight-Signal').text(smartBehavior?.marketInsight ?? '-');
        // $('#Trend-Forecast-Signal').text(smartBehavior?.trendForecast ?? '-');
        // $('#Trader-Alerts-Traps-Volume-Signal').text(smartBehavior?.traderTrap ?? '-');

        // Current Market Info
        $('#Market-Price-Overview').text(formatBinanceNumber(current?.marketPrice, true));
        $('#Trading-Volume-Overview').text(formatBinanceNumber(current?.volume_24h));
        $('#Resistance-Level-Overview').text(formatBinanceNumber(current?.resistance, true));
        $('#Support-Level-Overview').text(formatBinanceNumber(current?.support, true));
        $('#Market-Cap-Overview').text(formatBinanceNumber(moreInfo?.marketCap));
        $('#Circulating-Supply-Overview').text(formatBinanceNumber(moreInfo?.circulatingSupply));
        $('#Total-Max-Supply-Overview').text(formatBinanceNumber(moreInfo?.totalMaxSupply));
        $('#Moving-Average-Overview').text(formatBinanceNumber(moreInfo?.movingAverage, true));

        // More Information
        //$('#RSI-Indicator').text(`${formatBinanceNumber(moreInfo?.rsi?.value)}\n${moreInfo?.rsi?.label ?? '-'}\n${moreInfo?.rsi?.description ?? '-'}`);
        //$('#MACD-Indicator').text(`${formatBinanceNumber(moreInfo?.macd?.value)}\n${moreInfo?.macd?.label ?? '-'}\n${moreInfo?.macd?.description ?? '-'}`);
        //$('#ATR-Indicator').text(`${formatBinanceNumber(moreInfo?.atr?.value)}\n${moreInfo?.atr?.label ?? '-'}\n${moreInfo?.atr?.description ?? '-'}`);
        //$('#VWAP-Indicator').text(`${formatBinanceNumber(moreInfo?.vwap?.value, true)}\n${moreInfo?.vwap?.label ?? '-'}\n${moreInfo?.vwap?.description ?? '-'}`);
        //$('#Liquidity-Indicator').text(`${formatBinanceNumber(moreInfo?.liquidity?.value)}\n${moreInfo?.liquidity?.label ?? '-'}\n${moreInfo?.liquidity?.description ?? '-'}`);
        //$('#BB-Indicator').text(`${moreInfo?.bollinger?.label ?? '-'}\n${moreInfo?.bollinger?.description ?? '-'}`);
        //$('#CP-Indicator').text(`${moreInfo?.candlestickPattern?.label ?? '-'}\n${moreInfo?.candlestickPattern?.description ?? '-'}`);
        //$('#OBD-Indicator').text(`${moreInfo?.obv?.label ?? '-'}\n${moreInfo?.obv?.description ?? '-'}`);
        //$('#Trends-Indicator').text(`${moreInfo?.trend?.label ?? '-'}\n${moreInfo?.trend?.description ?? '-'}`);

        // Trade Suggestion
        //$('#Trade-Suggestion').text(suggestion ?? '-');

        // Market Sentiment
        //$('#Market-Sentiment').text(`${sentiment?.label ?? '-'}\n${sentiment?.description ?? '-'}`); 

        // Smart Market Behavior
        $('#Price-Volume-Signal').text(
            prefixArrow(smartBehavior?.priceVolumeSignal?.combo) + '\n' +
            prefixArrow(smartBehavior?.priceVolumeSignal?.label) + '\n' +
            prefixArrow(smartBehavior?.priceVolumeSignal?.meaning)
        );
        $('#Market-Insight-Signal').text(prefixArrow(smartBehavior?.marketInsight));
        $('#Trend-Forecast-Signal').text(prefixArrow(smartBehavior?.trendForecast));
        $('#Trader-Alerts-Traps-Volume-Signal').text(prefixArrow(smartBehavior?.traderTrap));

        // More Information
        $('#RSI-Indicator').text(
            prefixArrow(formatBinanceNumber(moreInfo?.rsi?.value)) + '\n' +
            prefixArrow(moreInfo?.rsi?.label) + '\n' +
            prefixArrow(moreInfo?.rsi?.description)
        );
        $('#MACD-Indicator').text(
            prefixArrow(formatBinanceNumber(moreInfo?.macd?.value)) + '\n' +
            prefixArrow(moreInfo?.macd?.label) + '\n' +
            prefixArrow(moreInfo?.macd?.description)
        );
        $('#ATR-Indicator').text(
            prefixArrow(formatBinanceNumber(moreInfo?.atr?.value)) + '\n' +
            prefixArrow(moreInfo?.atr?.label) + '\n' +
            prefixArrow(moreInfo?.atr?.description)
        );
        $('#VWAP-Indicator').text(
            prefixArrow(formatBinanceNumber(moreInfo?.vwap?.value, true)) + '\n' +
            prefixArrow(moreInfo?.vwap?.label) + '\n' +
            prefixArrow(moreInfo?.vwap?.description)
        );
        $('#Liquidity-Indicator').text(
            prefixArrow(formatBinanceNumber(moreInfo?.liquidity?.value)) + '\n' +
            prefixArrow(moreInfo?.liquidity?.label) + '\n' +
            prefixArrow(moreInfo?.liquidity?.description)
        );
        $('#BB-Indicator').text(
            prefixArrow(moreInfo?.bollinger?.label) + '\n' +
            prefixArrow(moreInfo?.bollinger?.description)
        );
        $('#CP-Indicator').text(
            prefixArrow(moreInfo?.candlestickPattern?.label) + '\n' +
            prefixArrow(moreInfo?.candlestickPattern?.description)
        );
        $('#OBD-Indicator').text(
            prefixArrow(moreInfo?.obv?.label) + '\n' +
            prefixArrow(moreInfo?.obv?.description)
        );
        $('#Trends-Indicator').text(
            prefixArrow(moreInfo?.trend?.label) + '\n' +
            prefixArrow(moreInfo?.trend?.description)
        );

        // Trade Suggestion
        $('#Trade-Suggestion').text(prefixArrow(suggestion));

        // Market Sentiment
        $('#Market-Sentiment').text(
            prefixArrow(sentiment?.label) + '\n' +
            prefixArrow(sentiment?.description)
        );

        $button.prop('disabled', false).text('Predict for Me'); controller = null; 
    });

});