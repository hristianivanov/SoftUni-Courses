function func(start, end) {
    let sum = 0;
    let numberString = '';
    for (let i = start; i <= end; i++) {
        sum += i;
        numberString += `${i} `;
    }
    console.log(numberString.trimEnd());
    console.log(`Sum: ${sum}`)
}

func(3,7);