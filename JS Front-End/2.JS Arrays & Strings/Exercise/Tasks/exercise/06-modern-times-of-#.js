function solve (input) {
    const regex = /#[A-z]+/g;

    let matches = input.match(regex);

    for (const word of matches) {
        console.log(word.substring(1));
    }
}