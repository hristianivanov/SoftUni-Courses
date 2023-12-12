function addItem() {
    let ul = document.getElementById("items");
    let newItem = document.getElementById("newItemText");

    if (newItem.value !== '') {
        let li = document.createElement('li');
        li.textContent = newItem.value;
        ul.appendChild(li);
    }
}