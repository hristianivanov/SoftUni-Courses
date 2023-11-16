function solve(array, rotationsCnt) {

    for (let i = 0; i < rotationsCnt; i++) {
        let elementToTake = array.shift();
        array.push(elementToTake);
    }

    console.log(array.join(' '));
}