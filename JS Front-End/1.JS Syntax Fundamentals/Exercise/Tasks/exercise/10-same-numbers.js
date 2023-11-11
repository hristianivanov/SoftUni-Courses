function func(number) {
    let digit = number % 10;
    let isSame = true;
    let sum = 0;

    while (number > 0) {
        let remainder = number % 10;

        if (digit !== remainder) {
            isSame = false;
        }

        sum += remainder;
        number -= remainder;
        number /= 10;
    }

    console.log(isSame);
    console.log(sum);
}