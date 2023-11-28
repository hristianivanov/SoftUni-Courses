function solve(product, quantity) {
    const productPrices = {
        coffee: 1.50,
        water: 1.00,
        coke: 1.40,
        snacks: 2.00
    };

    function calculatePrice(price,quantity) {
        return price * quantity;
    }

    let result = calculatePrice(productPrices[product],quantity);

    console.log(result.toFixed(2));
}