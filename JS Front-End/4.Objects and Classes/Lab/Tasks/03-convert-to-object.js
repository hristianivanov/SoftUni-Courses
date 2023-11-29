function convertToObj(json) {
    const obj = JSON.parse(json);

    for (const objKey in obj) {
        console.log(`${objKey}: ${obj[objKey]}`);
    }
}