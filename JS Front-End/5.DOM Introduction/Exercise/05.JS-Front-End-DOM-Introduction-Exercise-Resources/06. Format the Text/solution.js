function solve() {
    let input = document.getElementById("input");
    let outputElement = document.getElementById("output");

    let sentences = input.value.split('.');
    sentences = sentences.filter(s => s.length >= 1)
        .map(s => s += '.');

    while (sentences.length > 0) {
        let p = document.createElement('p');

        p.textContent = sentences.splice(0,3).join(' ');

        outputElement.appendChild(p);
    }
}