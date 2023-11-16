function solve(text) {
    const regex = /[A-Z][a-z]*/gm;
    let wordArr = text.match(regex);

    console.log(wordArr.join(', '));
}

solve('SplitMeIfYouCanHaHaYouCantOrYouCan');