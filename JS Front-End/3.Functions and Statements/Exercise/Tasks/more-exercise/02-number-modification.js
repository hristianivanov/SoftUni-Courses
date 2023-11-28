function solve(number) {
    function averageOfDigits(number) {
        let numberAsStr = number.toString();
        let sum = 0;

        for (let i = 0; i < numberAsStr.length; i++) {
            sum += Number(numberAsStr[i]);
        }

        return sum / numberAsStr.length;
    }

    while (averageOfDigits(number) <= 5) {
        number = parseInt(number.toString().concat('9'));
    }

    console.log(number);
}