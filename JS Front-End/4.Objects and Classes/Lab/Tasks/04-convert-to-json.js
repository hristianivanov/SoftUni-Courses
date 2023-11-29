function jsonSerialize(name,lastName,hairColor) {
    const obj = {
        name,lastName,hairColor
    };

    const json = JSON.stringify(obj);

    console.log(json)
}