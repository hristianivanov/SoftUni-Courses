function deleteByEmail() {
    let inputEmail = document.querySelector('input[name=email]');
    let result = document.getElementById('result');

    let emails = Array.from(document.querySelectorAll('tbody tr td:nth-child(even)'));
    let emailToDelete = emails.find(e => e.textContent === inputEmail.value);

    if (emailToDelete) {
        emailToDelete.parentElement.remove();
        result.textContent = 'Deleted.';
    } else {
        result.textContent = 'Not found.';
    }
}