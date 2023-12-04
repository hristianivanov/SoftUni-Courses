function extractText() {
   let liElements = Array.from(document.getElementById("items").children);
   let output = [];

    for (const liElement of liElements) {
        output.push(liElement.textContent);
    }

    let textarea = document.getElementById("result");
    textarea.textContent = output.join("\n");
}