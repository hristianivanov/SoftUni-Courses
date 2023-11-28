function drawLoadingBar(percentage) {
    if (percentage === 100) {
        console.log('100& Complete!');
        return;
    }

    let percentCnt = 0;
    let dotsCnt = 0;

    percentCnt = percentage / 10;
    dotsCnt = 10 - percentCnt;

    console.log(`${percentage}% [${'%'.repeat(percentCnt)}${'.'.repeat(dotsCnt)}]`);
    console.log('Still loading...');
}