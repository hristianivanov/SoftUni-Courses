const baseUrl = "http://localhost:3030/jsonstore/tasks/";

let editId = '';

const loadBtn = document.getElementById("load-meals");
const addBtn = document.getElementById("add-meal");
const editBtn = document.getElementById("edit-meal");

const mealList = document.getElementById("list");

const fields = {
    food: document.getElementById("food"),
    time: document.getElementById("time"),
    calories: document.getElementById("calories")
};

function solve() {
    mealList.innerHTML = '';

    loadBtn.addEventListener('click', () => loadMeals());
    addBtn.addEventListener('click', () => addMeal());

    editBtn.addEventListener('click', () => editMeal());

    function editMeal() {

        fetch(`${baseUrl}${editId}`, {
            method: 'PUT',
            body: JSON.stringify(createNewMeal())
        })
            .then(() => {
                loadMeals();
                editBtn.disabled = true;
                addBtn.disabled = false;
                clearFields();
            })
            .catch();

        function createNewMeal() {
            const newMeal = {};

            for (const [key, value] of Object.entries(fields)) {
                newMeal[key] = value.value;
            }

            return newMeal;
        }

        function clearFields() {
            for (const [key, value] of Object.entries(fields)) {
                fields[key].value = '';
            }
        }
    }
    function addMeal() {
        fetch(baseUrl, {
            method: 'POST',
            body: JSON.stringify(createNewMeal())
        })
            .then(() => {
                loadMeals();
                clearFields();
            })

        function clearFields() {
            for (const [key, value] of Object.entries(fields)) {
                fields[key].value = '';
            }
        }

        function createNewMeal() {
            const newMeal = {};

            for (const [key, value] of Object.entries(fields)) {
                newMeal[key] = value.value;
            }

            return newMeal;
        }
    }
    function loadMeals() {
        mealList.innerHTML = '';

        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                Object.values(data).forEach(item => {
                    let meal = {
                        id: item._id,
                        food: item.food,
                        time: item.time,
                        calories: item.calories
                    }

                    createMeal(meal.id,meal.food, meal.time, meal.calories);
                });
            });
    }
    function createMeal(id,food, time, calories) {
        let divContainer = document.createElement('div');
        divContainer.className = 'meal';
        divContainer.id = id;

        let foodHeader = document.createElement('h2');
        foodHeader.textContent = food;
        let timeHeader = document.createElement('h3');
        timeHeader.textContent = time;
        let caloriesHeader = document.createElement('h3');
        caloriesHeader.textContent = calories;

        let divBtns = document.createElement('div');
        divBtns.id = 'meal-buttons';

        let changeBtn = document.createElement('button');
        changeBtn.className = 'change-meal';
        changeBtn.textContent = 'Change';

        changeBtn.addEventListener('click', (e) => {
            const mainDiv = e.target.parentElement.parentElement;
            editId = mainDiv.id;

            const food = mainDiv.querySelector('h2').textContent;
            const [time, calories] = mainDiv.querySelectorAll('h3');

            fields.food.value = food;
            fields.calories.value = calories.textContent;
            fields.time.value = time.textContent;

            editBtn.disabled = false;
            addBtn.disabled = true;

            mainDiv.remove();
        })

        let deleteBtn = document.createElement('button');
        deleteBtn.className = 'delete-meal';
        deleteBtn.textContent = 'Delete';
        deleteBtn.addEventListener('click', (e) => {
            editId = e.target.parentElement.parentElement.id;

            fetch(`${baseUrl}${editId}`, {
                method: "DELETE",
            })
                .then(() => loadMeals())
                .catch()
        });

        divBtns.appendChild(changeBtn);
        divBtns.appendChild(deleteBtn);

        divContainer.appendChild(foodHeader);
        divContainer.appendChild(timeHeader);
        divContainer.appendChild(caloriesHeader);
        divContainer.appendChild(divBtns);

        mealList.appendChild(divContainer)
    }
}

solve();