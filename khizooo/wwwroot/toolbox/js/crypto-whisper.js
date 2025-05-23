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
    /* Fill Coins Data While Page Loading */

    /* Market Behavior */

    // 🛠️ UTILS
    const API_BASE = 'https://api.coingecko.com/api/v3';
    const VS_CURRENCY = 'usd';

    // --- IndexedDB Utility ---
    const DB_NAME = 'CryptoWhisperCacheDB';
    const STORE_NAME = 'MarketDataStore';
    const DB_VERSION = 1;
    const CACHE_DURATION_MS = 5 * 60 * 1000; // 5 minutes
    const MAX_CACHE_ENTRIES = 50;

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

        const combo = `Price ${priceTrend}, Volume ${volumeTrend}`;

        const isPriceStrongUp = pricePctChange > largePriceMove;
        const isPriceStrongDown = pricePctChange < -largePriceMove;
        const isVolumeStrongUp = volumePctChange > largeVolumeMove;
        const isVolumeStrongDown = volumePctChange < -largeVolumeMove;

        // === Inserted Original Price-Volume Interpretation Logic ===

        let label = '', meaning = '', insight = '', trap = '', forecast = '';

        if (priceTrend === '↑' && volumeTrend === '↑') {
            if (isPriceStrongUp && isVolumeStrongUp) {
                label = '->Strong Momentum Spike\n';
                meaning = '->Strong Demand & Volume surge indicate breakout\n';
                insight = '->Bullish momentum confirmed by Volume\n'; 
                trap = '->Low Risk & Trend likely to continue\n';
                forecast = '->Expect Strong uptrend continuation\n';
            } else if (isPriceStrongUp && !isVolumeStrongUp) {
                label = '->Price Surge with Low Volume\n';
                meaning = '->Price rising but volume lagging, which mean Caution\n';
                insight = '->Potential Weak Rally or Pump\n';
                trap = '->Risk of Bull Trap, which mean Volume should confirm\n';
                forecast = '->Rally may stall without Volume Support\n';
            } else if (!isPriceStrongUp && isVolumeStrongUp) {
                label = '->Volume Spike, Price Flat\n';
                meaning = '->Unusual volume without price move\n';
                insight = '->Possible accumulation or manipulation\n';
                trap = '->Watch closely for Breakout or Reversal\n';
                forecast = '->Possible upcoming Volatility\n';
            } else {
                label = '->Gradual Uptrend';
                meaning = '->Price & Volume rising moderately\n';
                insight = '->Healthy accumulation under Resistance\n';
                trap = '->Positive Signal with moderate Risk\n';
                forecast = '->Uptrend building momentum\n';
            }
        }
        else if (priceTrend === '↓' && volumeTrend === '↑') {
            if (isPriceStrongDown && isVolumeStrongUp) {
                label = '->Panic Sell / Capitulation\n';
                meaning = '->Heavy Sell-Off with Strong Volume\n';
                insight = '->Weak hands dumping Assets\n';
                trap = '->High Risk but possible bottom formation\n';
                forecast = '->Possible rebound if Volume fades\n';
            } else if (!isPriceStrongDown && isVolumeStrongUp) {
                label = '->Distribution';
                meaning = '->Selling Pressure increasing\n';
                insight = '->Profit taking or cautious Selling\n';
                trap = '->Bearish Signal, Watch Support Levels\n';
                forecast = '->Possible downtrend forming\n';
            } else {
                label = '->Mild Decline\n';
                meaning = '->Price slightly Down, Volume Up\n';
                insight = '->Market under slight bearish Pressure\n';
                trap = '->Monitor for confirmation\n';
                forecast = '->Potential Slow Downtrend\n';
            }
        }
        else if (priceTrend === '↑' && volumeTrend === '↓') {
            if (isPriceStrongUp && !isVolumeStrongDown) {
                label = '->Bull Trap Warning\n';
                meaning = '->Price rising but Volume Declining\n';
                insight = '->Lack of conviction behind Rally\n';
                trap = '->Likely fake breakout, which means Beware\n';
                forecast = '->Rally may Reverse\n';
            } else {
                label = '->Weak Rally\n';
                meaning = '->Price Up, Volume Low\n';
                insight = '->Slow Buying, Uncertain Strength\n';
                trap = '->Risk of Reversal\n';
                forecast = '->Sideways or Weak Uptrend\n';
            }
        }
        else if (priceTrend === '↓' && volumeTrend === '↓') {
            if (isPriceStrongDown && isVolumeStrongDown) {
                label = '->Strong Sell-Off Cooling\n';
                meaning = '->Price & Volume falling sharply\n';
                insight = '->Market losing interest fast\n';
                trap = '->Possible exhaustion Sell-Off\n';
                forecast = '->Sideways or Reversal possible\n';
            } else {
                label = '->Disinterest / Consolidation\n';
                meaning = '->Price & Volume declining mildly\n';
                insight = '->Market quiet, Low Volume, which means indecision. Market waiting for catalyst\n';
                trap = '->Low volatility zone\n';
                forecast = '->Sideways trend\n';
            }
        }
        else if (priceTrend === '-' && volumeTrend === '↑') {
            label = '->Accumulation Phase';
            meaning = '->Flat Price but Volume rising\n';
            insight = '->Buyers quietly accumulating\n';
            trap = '->Positive sign if sustained\n';
            forecast = '->Possible breakout ahead\n';
        }
        else if (priceTrend === '-' && volumeTrend === '-') {
            label = '->No Interest / Flat Market\n';
            meaning = '->Little to no movement in Price or Volume\n';
            insight = '->Market in rest mode\n';
            trap = '->Avoid Trading\n';
            forecast = '->Sideways chop expected\n';
        }
        else if (priceTrend === '-' && volumeTrend === '↓') {
            label = '->Decreasing Interest\n';
            meaning = '->Volume drying up with flat Price\n';
            insight = '->Lack of participation\n';
            trap = '->Low Liquidity Risk\n';
            forecast = '->Sideways or Weak movement\n';
        }
        else {
            label = '->Mixed Signals\n';
            meaning = '->Price & volume trends are unclear or conflicting\n';
            insight = '->Market indecision\n';
            trap = '->Trade with caution\n';
            forecast = '->Wait for clear signals\n';
        }

        // === Indicator calculations ===
        const rsi = calculateRSI(pricesFull);
        const macd = calculateMACD(pricesFull);
        const bb = calculateBollingerBands(pricesFull);
        const ma50 = calculateSMA(pricesFull, 50);
        const ma200 = calculateSMA(pricesFull, 200);

        // === Append indicator insights ===

        if (rsi !== null) {
            if (rsi > 70) {
                insight += '->RSI indicates overbought conditions\n';
                trap = '->' + trap ? trap + 'Potential Price correction or reversal\n' : 'Potential Price correction or reversal\n';
            } else if (rsi < 30) {
                insight += '->RSI indicates oversold conditions\n';
                forecast = '->' + forecast ? forecast + 'Potential rebound likely\n' : 'Potential rebound likely\n';
            } else {
                insight += '->RSI in neutral zone\n';
            }
        } else {
            insight += '->RSI data unavailable\n';
        }

        if (macd !== null) {
            if (macd.histogram > 0) {
                insight += '->MACD histogram positive, which means Bullish Momentum\n';
                forecast = '->' + forecast.includes('Uptrend') ? forecast : (forecast ? forecast + 'Potential Bullish Trend\n' : 'Potential Bullish Trend\n');
            } else if (macd.histogram < 0) {
                insight += '->MACD histogram negative, Bearish Momentum\n';
                forecast = '->' + forecast.includes('Downtrend') ? forecast : (forecast ? forecast + 'Potential Bearish Trend\n' : 'Potential Bearish Trend\n');
            } else {
                insight += '->MACD histogram neutral\n';
            }
        } else {
            insight += '->MACD data unavailable\n';
        }

        if (bb !== null) {
            const lastClose = pricesFull[pricesFull.length - 1];
            const lastBB = bb[bb.length - 1];
            if (lastClose > lastBB.upper) {
                insight += '->Price above upper Bollinger Band, which means possible over extension\n';
                trap = '->' + trap ? trap + 'BB upper band breakout caution\n' : 'BB upper band breakout caution\n';
            } else if (lastClose < lastBB.lower) {
                insight += '->Price below lower Bollinger Band, which means possible oversold\n';
                forecast = '->' + forecast ? forecast + 'BB Lower band rebound likely\n' : 'BB Lower band rebound likely\n';
            } else {
                insight += '->Price within Bollinger Bands & Normal Volatility\n';
            }
        } else {
            insight += '->Bollinger Bands data unavailable\n';
        }

        if (ma50 && ma200) {
            const lastMA50 = ma50[ma50.length - 1];
            const lastMA200 = ma200[ma200.length - 1];
            if (lastMA50 > lastMA200) {
                insight += '->50-day MA above 200-day MA, which means Bullish Crossover (Golden Cross)\n';
                forecast += '->' + forecast ? 'Golden Cross signal\n' : 'Golden Cross signal\n';
            } else if (lastMA50 < lastMA200) {
                insight += '->50-day MA below 200-day MA, which means Bearish Crossover (Death Cross)\n';
                forecast += '->' + forecast ? 'Death Cross signal\n' : 'Death Cross signal\n';
            } else {
                insight += '->MA crossover neutral\n';
            }
        } else {
            insight += '->Moving Averages data unavailable\n';
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

        const prices = chartData.prices.map(p => p[1]); // extract prices

        const resistanceLevel = Math.max(...prices);
        const supportLevel = Math.min(...prices);

        return {
            marketPrice: coin.current_price,
            volume_24h: coin.total_volume,
            resistance: resistanceLevel.toFixed(2),
            support: supportLevel.toFixed(2)
        };
    }

    // 🔮 3. Hourly Prediction
    async function getHourlyPrediction(coinId, investmentAmount = 100) {
        const url = `https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&ids=${coinId}`;

        // Fetch coin data with caching
        const coinData = await fetchWithCache(url, `${coinId}_market`);

        if (!coinData || !coinData.length) return null;

        const currentPrice = coinData[0].current_price;

        // Basic growth factors (mock logic)
        const factors = {
            '1h': 1.012,  // +1.2%
            '2h': 1.018,  // +1.8%
            '3h': 1.025   // +2.5%
        };

        const predictions = {};

        for (let hour in factors) {
            const predictedPrice = currentPrice * factors[hour];
            const coinQuantity = investmentAmount / currentPrice;
            const futureValue = coinQuantity * predictedPrice;

            predictions[hour] = {
                predictedPrice: predictedPrice.toFixed(2),
                projectedAmount: futureValue.toFixed(2)
            };
        }

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
        if (rsi <= 10) return ['Extremely Oversold', 'Blue', 'High reversal chance'];
        else if (rsi <= 20) return ['Deep Oversold', 'Blue', 'Strong Buy signals forming'];
        else if (rsi <= 30) return ['Oversold', 'Blue', 'Buy zone'];
        else if (rsi <= 40) return ['Weak Bullish Momentum', 'Green', 'Cautious entry'];
        else if (rsi <= 50) return ['Neutral', 'Green', 'Wait & observe'];
        else if (rsi <= 60) return ['Light Bullish Strength', 'Green', 'Potential Trend forming'];
        else if (rsi <= 70) return ['Strong Momentum', 'Green', 'Possible continuation'];
        else if (rsi <= 80) return ['Overbought', 'Red', 'Caution on new Buys'];
        else if (rsi <= 90) return ['Extremely Overbought', 'Red', 'Possible Pullback'];
        else return ['Danger Zone', 'Red', 'High reversal Risk'];
    }

    function interpretMACD(macd, macdSignal, macdHistogram) {
        const diff = Math.abs(macd - macdSignal);

        if (diff <= 0.005) return ['No Clear Signal', 'Light Gray', 'Neutral market, no strong buy/sell indication'];
        if (macd > macdSignal && macdHistogram > 0.1) return ['Strong Bullish Momentum', 'Bright Green', 'Uptrend gaining strength, buyers in control'];
        if (macd > macdSignal && macdHistogram > 0.005) return ['Bullish Crossover', 'Green', 'Momentum shifting upward, early buy signal'];
        if (macd > macdSignal && macdHistogram < 0.005) return ['Bullish Momentum Fading', 'Yellow', 'Buyers slowing, trend might weaken'];
        if (macd < macdSignal && macdHistogram < -0.1) return ['Strong Bearish Momentum', 'Dark Red', 'Downtrend gaining strength'];
        if (macd < macdSignal && macdHistogram < -0.005) return ['Bearish Crossover', 'Red', 'Momentum shifting downward, early sell signal'];
        if (macd < macdSignal && macdHistogram > -0.005) return ['Bearish Momentum Fading', 'Yellow', 'Sellers losing pressure, buyers might return'];
        if (macd > macdSignal && macdHistogram < 0.05) return ['Stalling Bullish Momentum', 'Orange', 'Momentum slowing, trend may pause or reverse'];
        if (macd < macdSignal && macdHistogram > -0.05) return ['Stalling Bearish Momentum', 'Orange', 'Bearish pressure weakening, possible reversal'];
        return ['Sideways Market', 'Gray', 'Low volatility, no clear direction'];
    }

    function interpretBollingerBands(lastPrice, sma20, bbUpper, bbLower, closes) {
        const bbWidth = (bbUpper - bbLower) / sma20;
        const prevClose = closes[closes.length - 2];

        if (lastPrice > bbUpper) return ['Overbought Pressure', 'Red', 'Price may be peaking; possible pullback or correction'];
        if (lastPrice < bbLower) return ['Oversold Pressure', 'Blue', 'Price may be bottoming out; possible rebound'];
        if (lastPrice > sma20 && lastPrice < bbUpper) return ['Mild Bullish Bias', 'Green', 'Momentum leaning upward; buyers increasing'];
        if (lastPrice < sma20 && lastPrice > bbLower) return ['Mild Bearish Bias', 'Light Blue', 'Momentum leaning downward; sellers active'];
        if (lastPrice > sma20 && sma20 > prevClose) return ['Uptrend Signal', 'Green', 'Shift to bullish phase'];
        if (lastPrice < sma20 && sma20 < prevClose) return ['Downtrend Signal', 'Red', 'Possible bearish shift'];
        if (bbWidth < 0.01) return ['Squeeze Alert', 'Yellow', 'Low volatility, breakout expected'];
        if (bbWidth > 0.05) return ['High Volatility Zone', 'Orange', 'Market unstable, sharp moves likely'];
        return ['Consolidation Zone', 'Light Gray', 'Price stabilizing, accumulation or distribution'];
    }

    function interpretVWAP(lastPrice, vwap, priceChange, prevClose) {
        const diffPercent = Math.abs((lastPrice - vwap) / vwap);

        if (diffPercent <= 0.01) return ['Consolidation Zone', 'Gray', 'Market undecided, wait for clearer direction'];
        if (lastPrice > vwap && priceChange > 0) return ['Strong Bullish Signal', 'Bright Green', 'Institutional buying likely, trend strength increasing'];
        if (lastPrice > vwap && prevClose < vwap) return ['Breakout Attempt (Bullish)', 'Light Green', 'Potential bullish reversal, confirmation needed'];
        if (lastPrice > vwap) return ['Bullish Bias', 'Green', 'Buyers are paying above average, possible uptrend'];
        if (lastPrice < vwap && priceChange < 0) return ['Strong Bearish Signal', 'Dark Red', 'Selling pressure increasing, possible short'];
        if (lastPrice < vwap && prevClose > vwap) return ['Breakdown Attempt (Bearish)', 'Light Red', 'Trend reversing to downside, caution'];
        if (lastPrice < vwap) return ['Bearish Bias', 'Red', 'Price is trading at a discount, possible downtrend'];
        return ['Divergence Risk', 'Yellow', 'Price & VWAP out of sync, likely false breakouts'];
    }

    function interpretATR(atr) {
        if (atr < 50) return ['Very Low Volatility', 'Light Gray', 'Price moves are small, potential breakout setup'];
        if (atr < 100) return ['Low Volatility', 'Gray', 'Muted action, wait for breakout'];
        if (atr < 150) return ['Volatility Building', 'Yellow', 'Market heating up, prepare for stronger moves'];
        if (atr < 250) return ['Normal Volatility', 'Green', 'Healthy price movement, good for regular trading'];
        if (atr < 350) return ['High Volatility', 'Red', 'Large price swings, risky zone'];
        if (atr < 500) return ['Extreme Volatility Spike', 'Dark Red', 'News/liquidation-driven chaos'];
        if (atr < 600) return ['Cooling Down', 'Orange', 'Volatility returning to normal, stabilization phase'];
        if (atr < 700) return ['Increasing Risk', 'Orange', 'Unstable market, manage positions carefully'];
        if (atr < 800) return ['Stabilizing Market', 'Light Green', 'Market calming, trend maturing'];
        return ['No Clear Signal', 'Gray', 'Market lacks momentum or direction'];
    }

    function interpretOBV(obvTrend, priceTrend) {
        if (obvTrend === 'rising' && priceTrend === 'rising') return ['Volume Supports Uptrend', 'Green', 'Buying pressure confirms uptrend; healthy growth'];
        if (obvTrend === 'rising' && priceTrend === 'flat') return ['Bullish Divergence', 'Bright Green', 'Hidden accumulation; price may soon follow volume up'];
        if (obvTrend === 'falling' && priceTrend === 'falling') return ['Volume Confirms Downtrend', 'Red', 'Selling pressure supports downtrend'];
        if (obvTrend === 'falling' && priceTrend === 'rising') return ['Bearish Divergence', 'Orange', 'Hidden distribution; price may reverse downward'];
        if (obvTrend === 'flat' && priceTrend === 'flat') return ['No Momentum', 'Light Gray', 'Low volume, market indecision'];
        return ['Volume Disagreement', 'Yellow', 'Volume not confirming price, fakeouts possible'];
    }

    function interpretTrend(lastPrice, ma14, priceChange) {
        if (lastPrice > ma14 && priceChange > 0) return ['Strong Uptrend', 'Bright Green', 'Solid bullish trend, likely continuation'];
        if (lastPrice > ma14) return ['Uptrend', 'Green', 'Consistent upward movement, buyers in control'];
        if (lastPrice < ma14 && priceChange < 0) return ['Strong Downtrend', 'Dark Red', 'Solid bearish trend, likely continuation'];
        if (lastPrice < ma14) return ['Downtrend', 'Red', 'Consistent downward pressure, sellers in control'];
        if (Math.abs(priceChange) < 10) return ['Sideways Market', 'Gray', 'No clear direction, wait for breakout'];
        return ['Unstable Trend', 'Yellow', 'High volatility & no trend, trade cautiously'];
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

        if (isBullishEngulfing) return ['Bullish Engulfing', 'Green', 'Strong reversal at bottom, buyers dominant'];
        if (isBearishEngulfing) return ['Bearish Engulfing', 'Red', 'Strong reversal down, sellers dominate'];
        if (isHammer) return ['Hammer (at bottom)', 'Green', 'Price rejection at lows, bounce likely'];
        if (isInvertedHammer) return ['Inverted Hammer', 'Light Green', 'Possible reversal, confirmation needed'];
        if (isShootingStar) return ['Shooting Star (at top)', 'Red', 'Rejection at highs, reversal likely'];
        if (isDoji) return ['Doji', 'Gray', 'Indecision, next candle matters'];
        if (isDragonflyDoji) return ['Dragonfly Doji', 'Green', 'Strong lower rejection, bounce possible'];
        if (isGravestoneDoji) return ['Gravestone Doji', 'Red', 'Top rejection, caution for bulls'];
        if (isMorningStar) return ['Morning Star', 'Bright Green', 'Strong bullish reversal'];
        if (isEveningStar) return ['Evening Star', 'Dark Red', 'Strong bearish reversal'];
        if (isThreeWhiteSoldiers) return ['Three White Soldiers', 'Bright Green', 'Bullish trend confirmed'];
        if (isThreeBlackCrows) return ['Three Black Crows', 'Dark Red', 'Bearish trend confirmed'];
        if (isSpinningTop) return ['Spinning Top', 'Yellow', 'Low momentum, wait for confirmation'];
        if (isMarubozu) return ['Marubozu', 'Black or White', 'Strong directional candle, momentum clear'];
        if (isInsideBar) return ['Inside Bar', 'Light Gray', 'Consolidation, breakout watch'];
        if (isOutsideBar) return ['Outside Bar', 'Blue', 'Volatility spike, watch next move'];
        return ['Unidentified Pattern', 'Gray', 'No strong signal from candles'];
    }

    function interpretLiquidity(latestVolume) {
        if (latestVolume > 5_000_000_000) return ['Whale Territory', 'Dark Green', 'Institutional-level liquidity, trades executed with zero slippage'];
        else if (latestVolume > 2_000_000_000) return ['Extreme Liquidity Zone', 'Green', 'Seamless execution, deep market participation'];
        else if (latestVolume > 1_000_000_000) return ['Highly Liquid Market', 'Green', 'Easy to enter/exit trades, minimal slippage'];
        else if (latestVolume > 750_000_000) return ['Strong Liquidity', 'Green', 'Active market, good execution'];
        else if (latestVolume > 500_000_000) return ['Good Liquidity', 'Light Green', 'Smooth trading, minimal risk'];
        else if (latestVolume > 300_000_000) return ['Moderately Liquid', 'Light Green', 'Decent flow, trades likely fill efficiently'];
        else if (latestVolume > 200_000_000) return ['Tradable Volume', 'Yellow', 'Some spread/slippage possible, monitor order books'];
        else if (latestVolume > 100_000_000) return ['Caution Zone', 'Yellow', 'Liquidity thinning, slippage may occur'];
        else if (latestVolume > 75_000_000) return ['Thin Market', 'Orange', 'Orders may partially fill, expect wider spreads'];
        else if (latestVolume > 50_000_000) return ['Low Liquidity', 'Orange', 'Execution may affect price, be cautious'];
        else if (latestVolume > 25_000_000) return ['Risky Depth', 'Dark Orange', 'Market is dry, large trades will move price'];
        else if (latestVolume > 10_000_000) return ['Illiquid Market', 'Red', 'Difficult to trade, high risk of manipulation'];
        else if (latestVolume > 1_000_000) return ['Critical Liquidity', 'Dark Red', 'Extremely limited, trade at own risk'];
        else return ['No Real Liquidity', 'Black', 'No visible buyers/sellers, avoid this asset'];
    }


    // 📊 5. Trade Suggestion 
    function getMockTradeSuggestion(indicators) {
        const { rsi, macd, trend, vwap, bollinger, candlestickPattern, obv, atr, liquidity } = indicators;

        console.log(indicators);


        const includesAny = (text, keywords) => keywords.some(k => text.toLowerCase().includes(k.toLowerCase()));

        if (rsi.label.includes("Danger Zone") || atr.label.includes("Extreme")) {
            return "⚠️ Market is extremely volatile or overbought. Best to avoid new trades until a more stable pattern appears.";
        }

        if (rsi.label.includes("Extremely Oversold") && macd.label.includes("Bullish")) {
            return "📉 Market is deeply oversold with early bullish signs, a strong rebound might be coming. Watch for confirmation.";
        }

        if (rsi.label.includes("Overbought") && macd.label.includes("Bearish")) {
            return "🔻 Overbought levels + weakening momentum. A pullback could be near. Consider exiting or tightening stop-loss.";
        }

        if (macd.label.includes("Strong Bearish")) {
            return "🚨 Strong bearish pressure showing on MACD. Market might drop further, avoid buying in this phase.";
        }

        if (macd.label.includes("Strong Bullish") && rsi.label.includes("Bullish")) {
            return "✅ Momentum & strength align. This is a strong setup for continuation upward. Consider a strategic entry.";
        }

        if (macd.label.includes("Crossover") && obv.label.includes("Bullish")) {
            return "💡 Bullish crossover with volume support. Traders may be accumulating. Watch for breakout.";
        }

        if (trend.label.includes("Uptrend") && macd.label.includes("Bullish")) {
            return "📈 Uptrend & momentum in sync, traders often ride trends like this for safer profits.";
        }

        if (trend.label.includes("Downtrend") && obv.label.includes("Bearish")) {
            return "📉 Trend & volume both showing downward strength. Avoid longs, stay cautious or consider shorting.";
        }

        if (vwap.label.includes("Breakout") && bollinger.label.includes("Squeeze")) {
            return "🚀 Breakout may be near. Tight bands & rising momentum suggest a powerful move is coming soon.";
        }

        if (candlestickPattern.label.includes("Reversal") && rsi.label.includes("Oversold")) {
            return "🔁 Oversold with reversal candle, could be the start of an upward bounce. Good to monitor closely.";
        }

        if (candlestickPattern.label.includes("Shooting Star") || candlestickPattern.label.includes("Bearish Engulfing")) {
            return "⚠️ Bearish candlestick at the top, may indicate sellers stepping in. Time to tighten risk or exit.";
        }

        if (candlestickPattern.label.includes("Hammer") && vwap.label.includes("Breakout")) {
            return "🔨 Hammer with rising volume, classic setup for bullish reversal. Possible bounce incoming.";
        }

        if (rsi.label.includes("Neutral") && atr.label.includes("Stabilizing")) {
            return "⏳ Market looks calm but unclear, wait for a breakout or signal before jumping in.";
        }

        if (obv.label.includes("Bullish Divergence")) {
            return "📊 Buyers entering quietly. OBV rising while price stalls, accumulation might be underway.";
        }

        if (obv.label.includes("Bearish Divergence")) {
            return "⚠️ Price rising but volume fading, could be a trap. Watch closely for confirmation before buying.";
        }

        if (atr.label.includes("High Volatility") && bollinger.label.includes("Overbought")) {
            return "🔥 Market is overextended & volatile. Risk of sharp correction, protect profits or wait.";
        }

        if (atr.label.includes("Low Volatility") && trend.label.includes("Sideways")) {
            return "💤 Market is slow & directionless. Traders often wait for breakout in such conditions.";
        }

        if (vwap.label.includes("Below") && trend.label.includes("Downtrend")) {
            return "🔻 Price trading below average & trending down, not the best time to enter unless shorting.";
        }

        if (vwap.label.includes("Above") && trend.label.includes("Uptrend")) {
            return "📈 Price is leading VWAP in an uptrend, strong bullish setup. Momentum likely to continue.";
        }

        if (liquidity.label.includes("Low") && atr.label.includes("High")) {
            return "⚠️ Dangerous zone, high volatility with low liquidity means trades can slip badly. Stay away.";
        }

        if (liquidity.label.includes("Good") && trend.label.includes("Uptrend")) {
            return "✅ Market looks healthy & liquid, good environment for scaling into positions gradually.";
        }

        if (bollinger.label.includes("Squeeze")) {
            return "🔒 Squeeze forming, market tightening up before a breakout. Stay alert for volume spikes.";
        }

        if (bollinger.label.includes("Oversold") && macd.label.includes("Bullish")) {
            return "💥 Rebound zone, technicals suggest a bottom with upside potential. Low-risk entry might be forming.";
        }

        if (candlestickPattern.label.includes("Three White Soldiers")) {
            return "🚀 Strong bullish confirmation, consistent buying across multiple candles. Consider trend follow.";
        }

        if (candlestickPattern.label.includes("Three Black Crows")) {
            return "🧨 Strong bearish signal, selling pressure increasing. Trend may continue downward.";
        }

        if (candlestickPattern.label.includes("Doji") && rsi.label.includes("Neutral")) {
            return "🤔 Market indecision, trend might shift soon. Don't rush in without confirmation.";
        }

        if (macd.label.includes("No Clear Signal") && trend.label.includes("Sideways")) {
            return "⏸️ Market is flat & unclear. Avoid taking fresh trades until a clearer signal appears.";
        }

        if (trend.label.includes("Unstable")) {
            return "🌀 Price is acting choppy. No clear direction, better to step back & wait.";
        }

        if (atr.label.includes("Cooling Down") && obv.label.includes("Bullish")) {
            return "🧊 Market was hot but cooling, yet volume shows smart money buying. Breakout soon?";
        }

        if (candlestickPattern.label.includes("Morning Star") || candlestickPattern.label.includes("Dragonfly")) {
            return "🌅 Classic bottoming pattern with signs of strength. Could be an early entry opportunity.";
        }

        if (candlestickPattern.label.includes("Evening Star") || candlestickPattern.label.includes("Gravestone")) {
            return "🌄 Top reversal forming. Consider taking profits or avoid buying high.";
        }

        if (vwap.label.includes("Hugging VWAP") || vwap.label.includes("Consolidation")) {
            return "⚖️ Price is flat around VWAP, market undecided. Wait for direction before entering.";
        }

        if (trend.label.includes("Choppy") || trend.label.includes("Noisy")) {
            return "😵‍💫 Market is messy & unpredictable. Don’t guess, wait for structure.";
        }

        return "📊 Mixed signals across indicators, market not clear. Better to observe than act blindly.";
    }


    // 📰 6. Market Sentiment 
    async function getMarketSentiment() {
        const cacheKey = 'marketSentiment';
        const CACHE_DURATION_MS = 5 * 60 * 1000; // 5 minutes

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

        if (index === 0) [label, color, description] = ['Zero Confidence', 'Black', 'No Optimism remains, Potential bottom zone'];
        else if (index === 1) [label, color, description] = ['Despair', 'Dark Red', 'Panic-driven selling, Extreme uncertainty'];
        else if (index === 2) [label, color, description] = ['Full Capitulation', 'Dark Red', 'Buyers have completely exited'];
        else if (index === 3) [label, color, description] = ['Fear Spiral', 'Dark Red', 'Sellers dominate, price dropping sharply'];
        else if (index === 4) [label, color, description] = ['Market Collapse', 'Dark Red', 'Confidence shattered, rare opportunity?'];
        else if (index === 5) [label, color, description] = ['Total Panic', 'Dark Red', 'Severe crash mood'];
        else if (index === 6) [label, color, description] = ['Maximum Fear', 'Dark Red', 'Nobody wants to buy'];
        else if (index === 7) [label, color, description] = ['Breakdown Mode', 'Dark Red', 'Support zones collapsing'];
        else if (index === 8) [label, color, description] = ['Hopelessness', 'Dark Red', 'Extreme risk-off sentiment'];
        else if (index === 9) [label, color, description] = ['Bleeding Market', 'Dark Red', 'Relentless selling pressure'];
        else if (index === 10) [label, color, description] = ['Desperation', 'Dark Red', 'Capitulation visible on charts'];
        else if (index === 11) [label, color, description] = ['Widespread Exit', 'Dark Red', 'Volume crash, no interest'];
        else if (index === 12) [label, color, description] = ['Panic Wave', 'Dark Red', 'Herd behavior in selling'];
        else if (index === 13) [label, color, description] = ['Fear Dominant', 'Dark Red', 'Sentiment extremely negative'];
        else if (index === 14) [label, color, description] = ['Market Breakdown', 'Dark Red', 'Support failure expected'];
        else if (index === 15) [label, color, description] = ['Max Capitulation', 'Dark Red', 'Extreme undervaluation zone'];
        else if (index === 16) [label, color, description] = ['Fear Zone', 'Red', 'Bearish sentiment increasing'];
        else if (index === 17) [label, color, description] = ['Pessimism', 'Red', 'Market sees no upside'];
        else if (index === 18) [label, color, description] = ['Deep Red Mood', 'Red', 'Sentiment highly negative'];
        else if (index === 19) [label, color, description] = ['Mass Selloff', 'Red', 'Market shedding value rapidly'];
        else if (index === 20) [label, color, description] = ['Extreme Fear', 'Red', 'Panic selling likely'];
        else if (index === 21) [label, color, description] = ['Heightened Risk Aversion', 'Red', 'Risky assets avoided'];
        else if (index === 22) [label, color, description] = ['Red Sea', 'Red', 'Charts soaked in red candles'];
        else if (index === 23) [label, color, description] = ['Pain Point', 'Red', 'Psychological lows hit'];
        else if (index === 24) [label, color, description] = ['Fragile Sentiment', 'Red', 'Market reacts to small events'];
        else if (index === 25) [label, color, description] = ['Fear', 'Red', 'Market is fearful, potential buying opportunity'];
        else if (index === 26) [label, color, description] = ['Buyer Disinterest', 'Red', 'Weak hands dominate'];
        else if (index === 27) [label, color, description] = ['Bearish Mood', 'Red', 'Uncertainty in every tick'];
        else if (index === 28) [label, color, description] = ['Selling Trend', 'Red', 'Steady downward pressure'];
        else if (index === 29) [label, color, description] = ['Low Trust', 'Red', 'Traders not participating'];
        else if (index === 30) [label, color, description] = ['Mild Fear', 'Red', 'Bearish tone increasing'];
        else if (index === 31) [label, color, description] = ['Skepticism', 'Orange', 'Cautious optimism, watch for reversal'];
        else if (index === 32) [label, color, description] = ['Early Recovery Signs', 'Orange', 'Fear receding slowly'];
        else if (index === 33) [label, color, description] = ['Bounce Zone', 'Orange', 'Some accumulation visible'];
        else if (index === 34) [label, color, description] = ['Emerging Confidence', 'Orange', 'Some buyers stepping in'];
        else if (index === 35) [label, color, description] = ['Calm Before Breakout', 'Orange', 'Volatility expected'];
        else if (index === 36) [label, color, description] = ['Stabilizing', 'Gray', 'Market cooling down'];
        else if (index === 37) [label, color, description] = ['Range Trading', 'Gray', 'No dominant sentiment'];
        else if (index === 38) [label, color, description] = ['Neutral Sentiment', 'Gray', 'Unclear trend, no bias'];
        else if (index === 39) [label, color, description] = ['Flat Market', 'Gray', 'Consolidation phase'];
        else if (index === 40) [label, color, description] = ['Sideways Bias', 'Gray', 'Traders waiting for signal'];
        else if (index === 41) [label, color, description] = ['Wait & Watch', 'Gray', 'Traders cautious, low volume'];
        else if (index === 42) [label, color, description] = ['Balanced Market', 'Gray', 'Bulls & bears equal'];
        else if (index === 43) [label, color, description] = ['Neutral Lean Bullish', 'Light Green', 'Slight optimism visible'];
        else if (index === 44) [label, color, description] = ['Warming Up', 'Light Green', 'Positive reactions to news'];
        else if (index === 45) [label, color, description] = ['Slight Bullish Tilt', 'Light Green', 'Momentum gently building'];
        else if (index === 46) [label, color, description] = ['Cautiously Bullish', 'Light Green', 'Buyers emerging'];
        else if (index === 47) [label, color, description] = ['Hopeful Buyers', 'Light Green', 'Improving sentiment'];
        else if (index === 48) [label, color, description] = ['Buy Signals Flashing', 'Light Green', 'Smart money entering'];
        else if (index === 49) [label, color, description] = ['Positive Bias', 'Light Green', 'Buyers in control'];
        else if (index === 50) [label, color, description] = ['Perfect Neutral', 'Gray', 'Even sentiment between bulls & bears'];
        else if (index === 51) [label, color, description] = ['Controlled Greed', 'Light Green', 'Healthy optimism'];
        else if (index === 52) [label, color, description] = ['Buyers Returning', 'Light Green', 'Demand gradually increasing'];
        else if (index === 53) [label, color, description] = ['Upward Drift', 'Light Green', 'Market regaining momentum'];
        else if (index === 54) [label, color, description] = ['Positive Momentum', 'Light Green', 'Uptrend forming'];
        else if (index === 55) [label, color, description] = ['Buy Pressure Rising', 'Light Green', 'Buyers outnumber sellers'];
        else if (index === 56) [label, color, description] = ['Reversal Confirmed', 'Green', 'Bullish move validated'];
        else if (index === 57) [label, color, description] = ['Confident Buyers', 'Green', 'Uptrend accelerating'];
        else if (index === 58) [label, color, description] = ['Accumulation Zone', 'Green', 'Smart accumulation ongoing'];
        else if (index === 59) [label, color, description] = ['Momentum Build-Up', 'Green', 'Bullish trend strengthening'];
        else if (index === 60) [label, color, description] = ['Greed Starting', 'Green', 'Buyers pushing higher'];
        else if (index === 61) [label, color, description] = ['Greedy Buyers', 'Green', 'Eager participation'];
        else if (index === 62) [label, color, description] = ['Optimistic Move', 'Green', 'Positive market mood'];
        else if (index === 63) [label, color, description] = ['Breakout Watch', 'Green', 'Price nearing resistance'];
        else if (index === 64) [label, color, description] = ['Trend Confirmed', 'Green', 'Clear bullish direction'];
        else if (index === 65) [label, color, description] = ['Strong Greed', 'Green', 'FOMO setting in'];
        else if (index === 66) [label, color, description] = ['Fast Climb', 'Green', 'Market in aggressive mode'];
        else if (index === 67) [label, color, description] = ['Green Run', 'Green', 'Multiple green sessions'];
        else if (index === 68) [label, color, description] = ['All-Time High Buzz', 'Green', 'ATH hype growing'];
        else if (index === 69) [label, color, description] = ['Momentum Spike', 'Green', 'Vertical growth phase'];
        else if (index === 70) [label, color, description] = ['Extreme Greed', 'Bright Green', 'Caution advised, overheated'];
        else if (index === 71) [label, color, description] = ['Hyper Greed', 'Bright Green', 'Bubble signs appearing'];
        else if (index === 72) [label, color, description] = ['Greed Mania', 'Bright Green', 'Irrational buying spikes'];
        else if (index === 73) [label, color, description] = ['Blind Buying', 'Bright Green', 'Retail piling in'];
        else if (index === 74) [label, color, description] = ['Peak Speculation', 'Bright Green', 'Parabolic moves appearing'];
        else if (index === 75) [label, color, description] = ['Overheated Market', 'Bright Green', 'Corrections imminent'];
        else if (index === 76) [label, color, description] = ['Delusion Zone', 'Bright Green', 'Fundamentals ignored'];
        else if (index === 77) [label, color, description] = ['Max Greed', 'Bright Green', 'Buyers dominate all timeframes'];
        else if (index === 78) [label, color, description] = ['Moon Talk', 'Bright Green', 'Unrealistic price targets'];
        else if (index === 79) [label, color, description] = ['Too Good to Last', 'Bright Green', 'Irrational confidence'];
        else if (index === 80) [label, color, description] = ['FOMO Frenzy', 'Bright Green', 'Late entries piling in'];
        else if (index === 81) [label, color, description] = ['Retail Frenzy', 'Bright Green', 'Emotional buyers dominate'];
        else if (index === 82) [label, color, description] = ['Meme Season', 'Bright Green', 'High speculation zones'];
        else if (index === 83) [label, color, description] = ['Unreal Gains', 'Bright Green', 'Unsustainable growth'];
        else if (index === 84) [label, color, description] = ['Smart Exit Zone', 'Bright Green', 'Institutional sell walls near'];
        else if (index === 85) [label, color, description] = ['Exhaustion Signals', 'Bright Green', 'Too much too fast'];
        else if (index === 86) [label, color, description] = ['Market Top Alert', 'Bright Green', 'Possible end of rally'];
        else if (index === 87) [label, color, description] = ['Overbought Zone', 'Bright Green', 'Buyers slowing down'];
        else if (index === 88) [label, color, description] = ['Top Heavy', 'Bright Green', 'Sell interest building'];
        else if (index === 89) [label, color, description] = ['Greed Overload', 'Bright Green', 'Reversal likely'];
        else if (index === 90) [label, color, description] = ['Dangerous Confidence', 'Bright Green', 'Bubble fears rising'];
        else if (index === 91) [label, color, description] = ['Exuberant Spike', 'Bright Green', 'Unsustainable mania'];
        else if (index === 92) [label, color, description] = ['Sell the News', 'Bright Green', 'Major events priced in'];
        else if (index === 93) [label, color, description] = ['Exit Strategy Time', 'Bright Green', 'Clever money exiting'];
        else if (index === 94) [label, color, description] = ['Bubble Talk', 'Bright Green', 'Media calling tops'];
        else if (index === 95) [label, color, description] = ['Parabolic Caution', 'Bright Green', 'Uptrend unsustainable'];
        else if (index === 96) [label, color, description] = ['Final Push', 'Bright Green', 'Last leg of the rally'];
        else if (index === 97) [label, color, description] = ['Turnaround Risk', 'Bright Green', 'Buyers losing steam'];
        else if (index === 98) [label, color, description] = ['Overdrive Exhaustion', 'Bright Green', 'Fatigue showing'];
        else if (index === 99) [label, color, description] = ['Flashy Gains', 'Bright Green', 'High volatility expected'];
        else if (index === 100) [label, color, description] = ['Irrational Exuberance', 'Bright Green', 'Dangerously overconfident, correction likely'];

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
            cleanupCache(); //  cleanup
        } catch {
            // ignore cache errors
        }

        return result;
    }


    // Helper Functions

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
        const prediction = await getHourlyPrediction(selectedCoin);
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

        // Smart Market Behavior
        $('#Price-Volume-Signal').text(`${smartBehavior?.priceVolumeSignal?.combo ?? '-'}\n(${smartBehavior?.priceVolumeSignal?.label ?? '-'})\n(${smartBehavior?.priceVolumeSignal?.meaning ?? '-'})`);
        $('#Market-Insight-Signal').text(smartBehavior?.marketInsight ?? '-');
        $('#Trend-Forecast-Signal').text(smartBehavior?.trendForecast ?? '-');
        $('#Trader-Alerts-Traps-Volume-Signal').text(smartBehavior?.traderTrap ?? '-');

        // Current Market Info
        $('#Market-Price-Overview').text(current?.marketPrice ?? '-');
        $('#Trading-Volume-Overview').text(current?.volume_24h ?? '-');
        $('#Resistance-Level-Overview').text(current?.resistance ?? '-');
        $('#Support-Level-Overview').text(current?.support ?? '-');
        $('#Market-Cap-Overview').text(moreInfo?.marketCap ?? '-');
        $('#Circulating-Supply-Overview').text(moreInfo?.circulatingSupply ?? '-');
        $('#Total-Max-Supply-Overview').text(moreInfo?.totalMaxSupply ?? '-');
        $('#Moving-Average-Overview').text(moreInfo?.movingAverage ?? '-');

        //// Hourly Prediction
        //$('#Prediction1h').text(prediction?.['1h']?.predictedPrice ?? '-');
        //$('#Prediction2h').text(prediction?.['2h']?.predictedPrice ?? '-');
        //$('#Prediction3h').text(prediction?.['3h']?.predictedPrice ?? '-');
        //$('#Projected1h').text(prediction?.['1h']?.projectedAmount ?? '-');
        //$('#Projected2h').text(prediction?.['2h']?.projectedAmount ?? '-');
        //$('#Projected3h').text(prediction?.['3h']?.projectedAmount ?? '-');

        // More Information
        $('#RSI-Indicator').text(`${moreInfo?.rsi?.value ?? '-'}\n(${moreInfo?.rsi?.label ?? '-'})\n(${moreInfo?.rsi?.description ?? '-'})`);
        $('#MACD-Indicator').text(`${moreInfo?.macd?.value ?? '-'}\n(${moreInfo?.macd?.label ?? '-'})\n(${moreInfo?.macd?.description ?? '-'})`);
        $('#BB-Indicator').text(`${moreInfo?.bollinger?.label ?? '-'}\n(${moreInfo?.bollinger?.description ?? '-'})`);
        $('#ATR-Indicator').text(`${moreInfo?.atr?.value ?? '-'}\n(${moreInfo?.atr?.label ?? '-'})\n(${moreInfo?.atr?.description ?? '-'})`);
        $('#Liquidity-Indicator').text(`${moreInfo?.liquidity?.value ?? '-'}\n(${moreInfo?.liquidity?.label ?? '-'})\n(${moreInfo?.liquidity?.description ?? '-'})`);
        $('#CP-Indicator').text(`${moreInfo?.candlestickPattern?.label ?? '-'}\n(${moreInfo?.candlestickPattern?.description ?? '-'})`);
        $('#OBD-Indicator').text(`${moreInfo?.obv?.label ?? '-'}\n(${moreInfo?.obv?.description ?? '-'})`);
        $('#VWAP-Indicator').text(`${moreInfo?.vwap?.value ?? '-'}\n(${moreInfo?.vwap?.label ?? '-'})\n(${moreInfo?.vwap?.description ?? '-'})`);
        $('#Trends-Indicator').text(`${moreInfo?.trend?.label ?? '-'}\n(${moreInfo?.trend?.description ?? '-'})`);

        // Trade Suggestion
        $('#Trade-Suggestion').text(suggestion ?? '-');

        // Market Sentiment
        $('#Market-Sentiment').text(`${sentiment?.label ?? '-'}\n(${sentiment?.description ?? '-'})`); 



        $button.prop('disabled', false).text('Predict for Me'); controller = null; 
    });

});

