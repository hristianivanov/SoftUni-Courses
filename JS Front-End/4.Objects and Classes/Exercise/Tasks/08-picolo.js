function carParking(input) {
    let parking = [];

    for (let i = 0; i < input.length; i++) {
        const [direction, carNumber] = input[i].split(', ');
        if (direction === "IN" && !parking.includes(carNumber))
            parking.push(carNumber);
        else if (direction === "OUT" && parking.includes(carNumber))
            parking.splice(parking.indexOf(carNumber), 1);
    }

    parking = parking.sort((a, b) => a.localeCompare(b));

    if (parking.length > 0) {
        parking.forEach(car => console.log(car));
    } else {
        console.log("Parking Lot is Empty")
    }
}