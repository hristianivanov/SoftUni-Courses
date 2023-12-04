function solve() {
    document.querySelector('#searchBtn').addEventListener('click', onClick);

    let rows = document.querySelectorAll("tbody tr")
    let searching = document.getElementById("searchField");
    function onClick() {
        for (let i = 0; i < rows.length; i++) {
            if(searching.value === '')
                continue;

            if (rows[i].textContent.toLowerCase().includes(searching.value.toLowerCase())) {
                rows[i].classList.add("select");
            } else if (rows[i].classList.contains("select")) {
                rows[i].classList.remove("select");
            }
        }
    }
}