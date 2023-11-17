function solve(input) {
    let password = "";

    for (let i = input[0].length - 1; i >= 0; i--) {
        password += input[0][i];
    }

    for (let i = 1; i <= 4; i++) {
        if (input[i] === password) {
            console.log(`User ${input[0]} logged in.`);
            return;
        } else {
            if (i === 4) {
                console.log(`User ${input[0]} blocked!`);
            } else {
                console.log("Incorrect password. Try again.");
            }
        }
    }
}