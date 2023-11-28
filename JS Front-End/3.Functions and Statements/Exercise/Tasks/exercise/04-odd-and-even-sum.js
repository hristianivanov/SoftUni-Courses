function solve(number) {
    const numberAsString = number.toString();

    let evenSum = 0;
    let oddSum = 0;

    const isEven = (num) => num % 2 === 0;

    for (let i = 0; i < numberAsString.length; i++) {
        let currDigit = Number(numberAsString[i]);

        if (isEven(currDigit))
            evenSum += currDigit;
        else
            oddSum += currDigit;
    }

    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}