function func(count, groupType, dayOfWeek) {
    let priceByDay = {
        'Friday': [8.45, 10.9, 15],
        'Saturday': [9.8, 15.6, 20],
        'Sunday': [10.46, 16, 22.5]
    }

    let sum;
    switch (groupType) {
        case 'Students':
            sum = count * priceByDay[dayOfWeek][0];
            if (count >= 30) {
                sum *= 0.85;
            } break;
        case 'Business':
            if (count >= 100) {
                count -= 10;
            }
            sum = count * priceByDay[dayOfWeek][1]; break;
        case 'Regular':
            sum = count * priceByDay[dayOfWeek][2];
            if (count >= 10 && count <= 20) {
                sum *= 0.95;
            } break;
        default: break;
    }

    console.log(`Total price: ${sum.toFixed(2)}`);
}