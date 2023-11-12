function func(text, word) {
    console.log(text.replace(new RegExp(word, 'g'), '*'.repeat(word.length)));
}