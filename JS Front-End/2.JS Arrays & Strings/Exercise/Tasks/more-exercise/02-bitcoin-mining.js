function solve(daysMining) {
    const priceOfGold = 67.51;
    const costOfBitcoin = 11949.16;

    let sum = 0;
    let dayOfFirstBitcoinPurchase = 0;

    for (let i = 0; i < daysMining.length; i++) {
        let dailyGoldMined = daysMining[i];

        if ((i + 1) % 3 === 0) {
            dailyGoldMined *= 0.7;
        }

        sum += dailyGoldMined * priceOfGold;

        if (dayOfFirstBitcoinPurchase === 0 && sum > costOfBitcoin) {
            dayOfFirstBitcoinPurchase = i + 1;
        }
    }

    const moneyLeft = sum % costOfBitcoin;
    const bitcoinsPurchased = (sum - moneyLeft) / costOfBitcoin;

    console.log(`Bought bitcoins: ${bitcoinsPurchased}`);
    if (bitcoinsPurchased != 0) {
        console.log(`Day of the first purchased bitcoin: ${dayOfFirstBitcoinPurchase}`);
    }
    console.log(`Left money: ${moneyLeft.toFixed(2)} lv.`);
}