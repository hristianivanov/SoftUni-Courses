function sumTable() {
    let prices = Array.from(document.querySelectorAll("tr td:nth-child(even)"));

    let sum = 0;

    for (let i = 0; i < prices.length - 1; i++) {
        sum += Number(prices[i].textContent);
    }

    document.getElementById("sum").textContent = sum;
}