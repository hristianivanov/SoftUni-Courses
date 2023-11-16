function solve(words, sentence) {
    const wordsArr = words.split(', ');
    const sentenceArr = sentence.split(' ');

    for (let i = 0; i < wordsArr.length; i++) {
        for (let j = 0; j < sentenceArr.length; j++) {
            if (sentenceArr[j].includes('*') &&
                sentenceArr[j].length === wordsArr[i].length) {
                sentenceArr[j] = wordsArr[i];
            }
        }
    }

    console.log(sentenceArr.join(' '));
}