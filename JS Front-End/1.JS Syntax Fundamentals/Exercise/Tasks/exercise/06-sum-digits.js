function func(number) {
    let sum = 0;
    while(number > 0) {
        let digit = number % 10;
        sum += digit;
        number -= digit;
        number /= 10;
    }

    console.log(sum);
}