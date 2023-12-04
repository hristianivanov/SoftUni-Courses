function search() {
    let list = document.getElementById("towns");
    let listItems = Array.from(list.children);
    let searching = document.getElementById("searchText")
    let matchesCnt = 0;

    for (const listItem of listItems) {
        if (listItem.textContent.includes(searching.value) && searching.value !== '') {
            listItem.style.textDecoration = 'underline';
            listItem.style.fontWeight = 'bold';
            matchesCnt++;
        } else {
            listItem.style.textDecoration = 'none';
            listItem.style.fontWeight = 'normal';
        }
    }

    document.getElementById("result").textContent = `${matchesCnt} matches found`;
}
