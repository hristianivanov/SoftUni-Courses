function colorize() {
    let rows = Array.from(document.querySelectorAll("tr:nth-child(even)"));
    rows.forEach(r => r.style.background = 'teal');
}