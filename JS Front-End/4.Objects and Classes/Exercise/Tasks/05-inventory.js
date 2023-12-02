function heroInfo(input) {
    let heroes = [];

    for (let i = 0; i < input.length; i++) {
        const [name, level, items] = input[i].split(' / ');

        let heroObj = {
            name,
            level:Number(level),
            items
        };

        heroes.push(heroObj);
    }

    heroes.sort((a,b) => a.level - b.level).forEach(hero => {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items}`);
    });

}