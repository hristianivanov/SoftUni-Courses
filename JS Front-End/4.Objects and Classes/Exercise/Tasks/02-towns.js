function townsInfo(towns) {
    for (const currTown of towns) {

        let row = currTown.split(' | ');
        const [town,latitude,longitude] = row;

        let currTownInfo = {
            town,
            latitude:Number(latitude).toFixed(2),
            longitude:Number(longitude).toFixed(2)
        };

        console.log(currTownInfo);
    }
}