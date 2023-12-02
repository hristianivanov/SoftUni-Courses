function oddWordExtractor(input) {
    let words = input.toLowerCase().split(' ');

    let occurences = {};

    words.forEach(word => {
        if(!occurences.hasOwnProperty(word))
            occurences[word] = 1;
        else
            occurences[word]++;
    });

    let entries = Object.entries(occurences)
        .filter(e => e[1] % 2 !== 0);

    let result = [];

    entries.forEach(entry => {
        result.push(entry[0])
    });

    console.log(result.join(' '))
}