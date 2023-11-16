function solve(word, text) {

    const regex = new RegExp(word, 'gm');
    let matches = text.toLowerCase().match(regex);

    if (matches) {
        console.log(matches.join(' '));
    } else {
        console.log(`${word} not found!`);
    }
}

function solve(word, text) {

    let wordsArr = text.toLowerCase().split(' ');
    let output = `${word} not found!`;

    for (let i = 0; i < wordsArr.length; i++) {
        let currWord = wordsArr[i];

        if (currWord === word) {
            output = currWord;
        }
    }

    console.log(output);
}