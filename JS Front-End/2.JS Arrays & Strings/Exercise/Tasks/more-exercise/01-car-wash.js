function solve(input) {
    const percent = {
        "water": 1.2,
        "vacuum cleaner": 1.25,
        "mud": 0.9
    };

    let sum = 0;

    for (const action of input) {
        switch (action) {
            case "soap": sum += 10; break;
            case "water": sum *= percent[action]; break;
            case "vacuum cleaner": sum *= percent[action]; break;
            case "mud": sum *= percent[action]; break;
            default: console.error();
        }
    }

    console.log(`The car is ${sum.toFixed(2)}% clean.`);
}
