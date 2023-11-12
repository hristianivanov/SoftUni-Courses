function func(text, word) {
    const matches = text.match(new RegExp(`\\b${word}\\b`, 'g'));

    console.log(matches ? matches.length : 0);
}