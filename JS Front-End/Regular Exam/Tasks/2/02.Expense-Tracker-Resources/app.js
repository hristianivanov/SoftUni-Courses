window.addEventListener("load", solve);

function solve() {
    const form = document.getElementById("form-container");
    const expenseElm = document.getElementById("expense");
    const amountElm = document.getElementById("amount");
    const dateElm = document.getElementById("date");

    const previewList = document.getElementById("preview-list");
    const expensesList = document.getElementById("expenses-list");

    const addBtn = document.getElementById("add-btn");
    const deleteBtn = document.querySelector(".btn.delete");

    deleteBtn.addEventListener('click', () =>{
            location.reload();
    });

    addBtn.addEventListener('click', () => {
        let expenseVal = expenseElm.value;
        let amountVal = amountElm.value;
        let dateVal = dateElm.value;

        let li = document.createElement('li');
        li.className = 'expense-item';

        let article = document.createElement('article');

        let pType = document.createElement('p');
        let pAmount = document.createElement('p');
        let pDate = document.createElement('p');
        pType.textContent = `Type: ${expenseVal}`;
        pAmount.textContent = `Amount: ${amountVal}$`;
        pDate.textContent = `Date: ${dateVal}`;

        article.appendChild(pType);
        article.appendChild(pAmount);
        article.appendChild(pDate);

        let div = document.createElement('div');
        div.className = 'buttons';

        let editBtn = document.createElement('button');
        editBtn.className = 'btn edit';
        editBtn.textContent = 'edit';

        editBtn.addEventListener('click', () => {
            previewList.innerHTML = '';

            expenseElm.value = expenseVal;
            amountElm.value = amountVal;
            dateElm.value = dateVal;

            addBtn.disabled = false;
        });

        let postBtn = document.createElement('button');
        postBtn.className = 'btn ok';
        postBtn.textContent = 'ok';

        div.appendChild(editBtn);
        div.appendChild(postBtn);

        li.appendChild(article);
        li.appendChild(div);

        previewList.appendChild(li);

        expenseElm.value = '';
        amountElm.value = '';
        dateElm.value = '';

        addBtn.disabled = true;

        postBtn.addEventListener('click', () => {
            previewList.innerHTML = '';

            li.removeChild(li.lastChild);
            expensesList.appendChild(li);

            addBtn.disabled = false;
        });
    });
}