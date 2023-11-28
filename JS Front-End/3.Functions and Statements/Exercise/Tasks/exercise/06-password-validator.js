function passwordValidator(password) {
    let isValid = true;

    function containsAtLeastTwoDigits(password) {
        let cnt = 0;

        for (let i = 0; i < password.length; i++) {
            if (!isNaN(password[i]))
                cnt++;
        }

        return cnt >= 2;
    }

    function containsOnlyLettersAndDigits(password) {
        const regex = /^[A-z0-9]+$/;

        return regex.test(password);
    }

    function containsBetweenSixAndTenCharacters(password) {
        return password.length >= 6 && password.length <= 10;
    }

    if (!containsBetweenSixAndTenCharacters(password)) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }
    if (!containsOnlyLettersAndDigits(password)) {
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }
    if (!containsAtLeastTwoDigits(password)) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }
    if (isValid)
        console.log("Password is valid");
}