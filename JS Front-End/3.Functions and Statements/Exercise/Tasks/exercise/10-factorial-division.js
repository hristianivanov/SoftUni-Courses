function factorialDivision(num1,num2) {
    function factorial(num) {
        if (num === 0)
            return 1;

        return  num * factorial(num - 1);
    }

    let result = factorial(num1) / factorial(num2);

    console.log(result.toFixed(2));
}