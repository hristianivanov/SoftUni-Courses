function solve(inputArr) {

    const n = Number(inputArr.shift());

    let barmans = [];

    for (let i = 0; i < n; i++) {
        const line = inputArr.shift();

        const [name, shift, ...coffesArgs] = line.split(' ');
        const coffes = coffesArgs.toString().split(',');

        let barman = {
            name, shift, coffes
        };

        barmans.push(barman);
    }

    while ((line = inputArr.shift().toString()) !== 'Closed') {

        const [command, ...args] = line.split(' / ');

        switch (command) {
            case "Prepare": barmanPrepare(args[0], args[1], args[2]); break;
            case "Change Shift": barmanShift(args[0],args[1]); break;
            case "Learn": barmanLearn(args[0],args[1],args[2]);break;
        }
    }

    for (const barman of barmans) {
        console.log(`Barista: ${barman.name}, Shift: ${barman.shift}, Drinks: ${barman.coffes.join(', ')}`)
    }

    function barmanLearn(name,newCoffeType) {
        let barman = barmans.find(b => b.name === name);

        if (barman.coffes.find(c => c === newCoffeType)) {
            console.log(`${barman.name} knows how to make ${newCoffeType}.`)
        } else {
            barman.coffes.push(newCoffeType);
            console.log(`${barman.name} has learned a new coffee type: ${newCoffeType}.`)
        }
    }
    function barmanShift(name,newShift){
        let barman = barmans.find(b => b.name === name);
        barman.shift = newShift;
        console.log(`${barman.name} has updated his shift to: ${newShift}`)
    }
    function barmanPrepare(name, shift, coffeType) {
        let barman = barmans.find(b => b.name === name);

        if (barman.shift === shift &&
        barman.coffes.find(c => c === coffeType)) {
            console.log(`${barman.name} has prepared a ${coffeType} for you!`)
        } else {
            console.log(`${barman.name} is not available to prepare a ${coffeType}.`)
        }
    }
}


    console.log(Number(true))
