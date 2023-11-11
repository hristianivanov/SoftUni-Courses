function func(input) {
    const words = input.match(/\b\w+\b/g);

    if (words) {
        const upperCaseWords = words.map(word => word.toUpperCase());

        console.log(upperCaseWords.join(', '));
    }
}