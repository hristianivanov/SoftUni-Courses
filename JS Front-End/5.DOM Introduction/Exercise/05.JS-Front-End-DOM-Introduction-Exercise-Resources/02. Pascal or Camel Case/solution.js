function solve() {
    let input = document.getElementById("text");
    let namingConvention = document.getElementById("naming-convention");

    let variableNameParts = input.value.trim().toLowerCase().split(' ');

    if (namingConvention.value === "Pascal Case") {
        for (let i = 0; i < variableNameParts.length; i++) {
            variableNameParts[i] = variableNameParts[i][0].toUpperCase() + variableNameParts[i].slice(1);
        }
    } else if (namingConvention.value === "Camel Case") {
        for (let i = 1; i < variableNameParts.length; i++) {
            variableNameParts[i] = variableNameParts[i][0].toUpperCase() + variableNameParts[i].slice(1);
        }
    } else {
        variableNameParts = [];
        variableNameParts.push("Error!");
    }

    document.getElementById("result").textContent = variableNameParts.join('');
}