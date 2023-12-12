function addItem() {
    let ul = document.getElementById('items');
    let inputText = document.getElementById('newItemText');

    let a = document.createElement('a');

    a.href = '#';
    a.textContent = '[Delete]';
    a.addEventListener('click', () => {
        a.parentElement.remove()
    });

    let li = document.createElement('li');
    li.textContent = inputText.value;
    li.appendChild(a);

    ul.appendChild(li);
}