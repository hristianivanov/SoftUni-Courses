function func(num1, operator, num2) {
    let result = 0;
    switch (operator) {
        case '+': result = num1 + num2; break;
        case '-': result = num1 - num2; break;
        case '*': result = num1 * num2; break;
        case '/': result = num1 / num2; break;
        default: break;
    }

    console.log(result.toFixed(2));
}