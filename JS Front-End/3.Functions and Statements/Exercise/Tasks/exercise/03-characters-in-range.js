function solve(firstChar,secondChar) {

    const start = Math.min(firstChar.charCodeAt(),secondChar.charCodeAt());
    const end = Math.max(firstChar.charCodeAt(),secondChar.charCodeAt());

    let arr = [];

    for (let i = start + 1; i < end; i++) {
        arr.push(String.fromCharCode(i));
    }

    console.log(arr.join(' '));
}