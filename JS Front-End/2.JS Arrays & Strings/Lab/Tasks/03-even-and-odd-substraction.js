function func(arr) {
    const even = arr.filter(num => num % 2 === 0);
    const odd = arr.filter(num => num % 2 !== 0);

    const sumEven = even.reduce((acc, num) => acc + num, 0);
    const sumOdd = odd.reduce((acc, num) => acc + num, 0);

    console.log(sumEven - sumOdd);
}