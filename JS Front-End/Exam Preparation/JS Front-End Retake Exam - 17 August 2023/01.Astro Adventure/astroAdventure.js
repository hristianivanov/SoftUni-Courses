function solve(inputArr) {

    let n = Number(inputArr.shift());

    let team = formTeam(inputArr, n);

    const MAX_ENERGY = 200;
    const MAX_OXYGEN = 100;

    inputArr.forEach(line => {
        const [command, ...args] = line.split(' - ');

        switch (command) {
            case 'Explore': exploreAstronaut(args[0],Number(args[1])); break;
            case 'Refuel': refuelAstronaut(args[0], Number(args[1])); break;
            case 'Breathe': breatheAstronaut(args[0],Number(args[1]));break;
            default: return false;
        }
    });

    for (const astronaut of team) {
        console.log(`Astronaut: ${astronaut.name}, Oxygen: ${astronaut.oxygen}, Energy: ${astronaut.energy}`)
    }

    function formTeam(args, n) {

        let team = [];

        for (let i = 0; i < n; i++) {
            const line = args.shift();

            [name, oxygen, energy] = line.split(' ');

            team.push(
                {
                    name,
                    oxygen: Number(oxygen),
                    energy: Number(energy)
                }
            );
        }

        return team;
    }
    function exploreAstronaut(name,energy) {
        let astronaut = team.find(a => a.name === name);

        if (astronaut.energy >= energy) {
            astronaut.energy -= energy;
            console.log(`${astronaut.name} has successfully explored a new area and now has ${astronaut.energy} energy!`);
        } else
            console.log(`${astronaut.name} does not have enough energy to explore!`);
    }
    function refuelAstronaut(name, amount) {
        let astronaut = team.find(a => a.name === name);
        const oldAmount = astronaut.energy;

        if (astronaut.energy + amount >= MAX_ENERGY)
            astronaut.energy = MAX_ENERGY;
        else
            astronaut.energy += amount;

        console.log(`${astronaut.name} refueled their energy by ${astronaut.energy - oldAmount}!`)
    }
    function breatheAstronaut(name,amount) {
        let astronaut = team.find(a => a.name === name);

        const oldAmount = astronaut.oxygen;

        if (astronaut.oxygen + amount >= MAX_OXYGEN)
            astronaut.oxygen = MAX_OXYGEN;
        else
            astronaut.oxygen += amount;

        console.log(`${astronaut.name} took a breath and recovered ${astronaut.oxygen - oldAmount} oxygen!`)
    }
}