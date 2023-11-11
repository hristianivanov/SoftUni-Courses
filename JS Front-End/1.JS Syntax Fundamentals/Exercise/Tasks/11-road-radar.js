function func(speed, area) {
    let areaSpeedLimit = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    };

    let speedLimit = areaSpeedLimit[area];

    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
    else {
        let difference = speed - speedLimit;
        let status = 'speeding';

        if (difference > 20 && difference <= 40) {
            status = 'excessive speeding';
        }
        else if (difference > 40) {
            status = 'reckless driving';
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}