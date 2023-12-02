function storeProvisionInfo(currStock, orderedStock) {

    let stock = {};

    for (let i = 0; i < currStock.length; i += 2) {
        let product = currStock[i];
        let quantity = Number(currStock[i + 1]);

        stock[product] = quantity;
    }

    for (let i = 0; i < orderedStock.length; i += 2) {
        let product = orderedStock[i];
        let quantity = Number(orderedStock[i + 1]);

        if (!stock.hasOwnProperty(product))
            stock[product] = quantity;
        else
            stock[product] += quantity;
    }

    for (const product in stock) {
        console.log(`${product} -> ${stock[product]}`);
    }
}