function getEmployeeInfo(employees) {
    employees.forEach(employee =>
        console.log(`Name: ${employee} -- Personal Number: ${employee.length}`)
    );
}