 
                $(document).ready(function () {
                    const coins = [
                        { id: 'bitcoin', symbol: 'BTC' },
                        { id: 'ethereum', symbol: 'ETH' },
                        { id: 'vulcan-forged', symbol: 'PYR' },
                        { id: 'lava', symbol: 'LAVA' }
                    ];

                    const vsCurrency = 'usd';
                    const coinIds = coins.map(c => c.id).join(',');

                    // Function to fetch and display data
                    const fetchData = async () => {
                        $('#marketData').empty(); // Clear previous data

                        $.get(`https://api.coingecko.com/api/v3/coins/markets?vs_currency=${vsCurrency}&ids=${coinIds}`, function (data) {
                            data.forEach(async function (coinData) {
                                const coin = coins.find(c => c.id === coinData.id);
                                const price = coinData.current_price;
                                const volume = coinData.total_volume;
                                const change = coinData.price_change_percentage_24h;
                                const image = coinData.image;

                                // Step 2: Get historical data for resistance (7 days)
                                const resData = await $.get(`https://api.coingecko.com/api/v3/coins/${coin.id}/market_chart?vs_currency=${vsCurrency}&days=7`);
                                const prices = resData.prices;

                                const highs = prices.map(p => p[1]); 
                                const lows = prices.map(p => p[1]); 
                                const resistance = Math.max(...highs).toFixed(5);
                                const support = Math.min(...lows).toFixed(5);

                                // Calculate indicators
                                const sma = calculateSMA(prices, 14); // Example: 14-period SMA
                                const rsi = calculateRSI(prices);
                                const { macd, signalLine } = calculateMACD(prices);
                                const bollingerBands = calculateBollingerBands(prices);
                                const obv = calculateOBV(prices);

                                // Market Logic Decision
                                let logic = "No Signal";
                                let logicClass = "logic-default";

                                // Check for various trading conditions:
                                if (change > 3 && volume > 100000000) {
                                    logic = "More Demand → Price will go up";
                                    logicClass = "logic-more-demand";
                                } else if (change < -3 && volume < 10000000) {
                                    logic = "Weak Demand → Price will go down";
                                    logicClass = "logic-weak-demand";
                                } else if (change < -3 && volume > 100000000) {
                                    logic = "More Selling Pressure → Price will go down";
                                    logicClass = "logic-selling-pressure";
                                } else if (change > 3 && volume < 10000000) {
                                    logic = "Less Supply → Price will go up";
                                    logicClass = "logic-less-supply";
                                } else if (Math.abs(change) < 1 && volume > 100000000 && change >= 0) {
                                    logic = "Accumulation → Breakout Expected";
                                    logicClass = "logic-accumulation";
                                } else if (Math.abs(change) < 1 && volume > 100000000 && change < 0) {
                                    logic = "Distribution → Drop Expected";
                                    logicClass = "logic-distribution";
                                } else if (volume < 1000000) {
                                    logic = "No Interest → Sideways or Drop";
                                    logicClass = "logic-no-interest";
                                } else if (change > 8 && volume > 150000000) {
                                    logic = "Fakeouts → Might be a Bull Trap";
                                    logicClass = "logic-fakeouts";
                                } else if (change < -8 && volume > 200000000) {
                                    logic = "Panic Selling → Possible Reversal Soon";
                                    logicClass = "logic-panic";
                                }

                                // Step 3: Render HTML
                                $('#marketData').append(`
                                    <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                        <div class="card-custom pulse-${change > 0 ? 'up' : 'down'}">
                                            <h5 class="mb-3 d-flex align-items-center">
                                                <img src="${image}" class="icon mr-2" alt="${coin.symbol}" style="width: 24px; height: 24px;">
                                                ${coin.symbol} / USD
                                            </h5>
                                            <p class="mb-1"><strong class="mr-2">Price:</strong> $${price.toLocaleString()}</p>
                                            <p class="mb-1"><strong class="mr-2">Volume:</strong> $${(volume / 1e9).toFixed(5)}B</p>
                                            <p class="mb-1"><strong class="mr-2">Resistance Level:</strong> $${resistance}</p>
                                            <p class="mb-1"><strong class="mr-2">Support Level</strong>: $${support}</p>
                                            <p class="mb-1"><strong class="mr-2">SMA (14):</strong> $${sma[sma.length - 1][1]}</p>
                                            <p class="mb-1"><strong class="mr-2">RSI:</strong> ${rsi.toFixed(5)}</p>
                                            <p class="mb-1"><strong class="mr-2">MACD:</strong> ${macd[macd.length - 1][1]}</p>

                                            <p class="mb-1"><strong class="mr-2">Bollinger Bands (Upper) :</strong> $${bollingerBands[bollingerBands.length - 1].upper}</p>
                                            <p class="mb-1"><strong class="mr-2">Bollinger Bands (Lower) :</strong> $${bollingerBands[bollingerBands.length - 1].lower}</p>

                                            <p class="mb-1"><strong class="mr-2">OBV:</strong> ${obv[obv.length - 1]}</p>
                                            <p class="mb-1 ${logicClass} p-2 text-center">${logic}</p>
                                        </div>
                                    </div>
                                `);
                            });
                        });
                    };

                    // Fetch initial data
                    fetchData();

                    // Set interval to update data every 10 seconds
                    //setInterval(fetchData, 30000); // Update every 10 seconds (10000ms)

                });

                // Function to calculate SMA
                function calculateSMA(data, period) {
                    let sma = [];
                    for (let i = period - 1; i < data.length; i++) {
                        let sum = 0;
                        for (let j = i - period + 1; j <= i; j++) {
                            sum += data[j][1]; // Price is at index 1
                        }
                        sma.push([data[i][0], sum / period]); // Date and SMA value
                    }
                    return sma;
                }

                // Function to calculate RSI
                function calculateRSI(data, period = 14) {
                    let gains = 0;
                    let losses = 0;
                    for (let i = 1; i < period; i++) {
                        const change = data[i][1] - data[i - 1][1];
                        if (change > 0) gains += change;
                        else losses -= change;
                    }

                    const avgGain = gains / period;
                    const avgLoss = losses / period;

                    let rs = avgGain / avgLoss;
                    let rsi = 100 - (100 / (1 + rs));

                    return rsi;
                }

                // Function to calculate MACD
                function calculateMACD(data, shortPeriod = 12, longPeriod = 26, signalPeriod = 9) {
                    const shortEMA = calculateEMA(data, shortPeriod);
                    const longEMA = calculateEMA(data, longPeriod);

                    let macd = shortEMA.map((short, index) => {
                        return [short[0], short[1] - longEMA[index][1]]; // MACD line
                    });

                    const signalLine = calculateEMA(macd, signalPeriod);

                    return { macd, signalLine };
                }

                // Helper function to calculate EMA
                function calculateEMA(data, period) {
                    let k = 2 / (period + 1);
                    let ema = [data[0]]; // First EMA is same as first data point

                    for (let i = 1; i < data.length; i++) {
                        ema.push([data[i][0], data[i][1] * k + ema[i - 1][1] * (1 - k)]);
                    }
                    return ema;
                }

                // Function to calculate Bollinger Bands
                function calculateBollingerBands(data, period = 20, multiplier = 2) {
                    const sma = calculateSMA(data, period);
                    const bands = sma.map((smaPoint, index) => {
                        let sum = 0;
                        for (let i = index - period + 1; i <= index; i++) {
                            try {
                                sum += Math.pow(data[i][1] - smaPoint[1], 2); // Price deviation squared
                            }
                            catch (e) {
                                console.log(e);
                                console.log(i);
                                console.log(data);
                                console.log(period);
                            }
                           
                        }
                        const stdDev = Math.sqrt(sum / period);
                        return {
                            date: smaPoint[0],
                            upper: smaPoint[1] + stdDev * multiplier,
                            lower: smaPoint[1] - stdDev * multiplier,
                        };
                    });
                    return bands;
                }

                // Function to calculate OBV
                function calculateOBV(data) {
                    let obv = [0]; // Starting OBV is 0

                    for (let i = 1; i < data.length; i++) {
                        const change = data[i][1] - data[i - 1][1];
                        if (change > 0) {
                            obv.push(obv[i - 1] + data[i][2]); // Volume is at index 2
                        } else if (change < 0) {
                            obv.push(obv[i - 1] - data[i][2]);
                        } else {
                            obv.push(obv[i - 1]); // No change in price
                        }
                    }

                    return obv;
                }