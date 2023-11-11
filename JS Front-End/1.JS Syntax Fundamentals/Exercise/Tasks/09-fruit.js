function func(fruit, grams, price) {
    let weight = grams / 1000;
    console.log(`I need $${(weight * price).toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`);
}