function solve(numArr) {
    function isPalindrome(num) {
        const reversedNum = Number(
            num.toString().split('').reverse().join('')
        );
        
        return num === reversedNum;
    }

    for (let i = 0; i < numArr.length; i++) {
        console.log(isPalindrome(numArr[i]));
    }
}