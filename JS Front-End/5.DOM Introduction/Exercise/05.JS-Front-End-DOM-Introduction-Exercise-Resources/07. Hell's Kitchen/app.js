function solve() {
    const textarea = document.querySelector('#inputs textarea');
    const bestRestaurantOutput = document.querySelector('#outputs p');
    const workersOutput = document.querySelector('#workers p');

    document.querySelector('#btnSend').addEventListener('click', onClick);

    function onClick() {
        const arr = JSON.parse(textarea.value);
        const restaurants = [];

        for (const item of arr) {
            const [name, workersArgs] = item.split(' - ');

            const existingRestaurant = restaurants.find(r => r.name === name);

            if (existingRestaurant) {
                for (const element of workersArgs.split(', ')) {
                    const [workerName, salary] = element.split(' ');

                    existingRestaurant.workers.push({
                        name: workerName,
                        salary: Number(salary)
                    });
                }
            } else {
                const workers = workersArgs.split(', ').map(element => {
                    const [workerName, salary] = element.split(' ');
                    return { name: workerName, salary: Number(salary) };
                });

                restaurants.push({ name, workers });
            }
        }

        restaurants.forEach(r => {
            const totalSalary = r.workers.reduce((acc, worker) => acc + worker.salary, 0);
            r.avgSalary = totalSalary / r.workers.length;
        });

        const bestRestaurant = restaurants.sort((a, b) => b.avgSalary - a.avgSalary)[0];
        bestRestaurant.workers.sort((a, b) => b.salary - a.salary);

        const workerResult = bestRestaurant.workers.map(worker =>
            `Name: ${worker.name} With Salary: ${worker.salary}`
        );

        bestRestaurantOutput.textContent = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.avgSalary.toFixed(2)} Best Salary: ${bestRestaurant.workers[0].salary.toFixed(2)}`;
        workersOutput.textContent = workerResult.join(' ');
    }
}