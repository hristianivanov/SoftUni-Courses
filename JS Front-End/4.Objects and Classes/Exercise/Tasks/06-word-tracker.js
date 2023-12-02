function wordOccurences(input) {
    let words = {};
    for (const word of input[0].split(' ')) {
        words[word] = 0;
    }

    for (let i = 1; i < input.length; i++) {
        if(words.hasOwnProperty(input[i])) {
            words[input[i]]++;
        }
    }

    let wordArray = Object.entries(words);
    wordArray.sort((a, b) => b[1] - a[1]);

    wordArray.forEach(word => console.log(`${word[0]} - ${word[1]}`))
}