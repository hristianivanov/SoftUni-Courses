function getObjData(obj) {
    for (const entry of Object.entries(obj)) {
        const [key, value] = entry;
        console.log(`${key} -> ${value}`)
    }
}