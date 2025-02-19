// Performing operations on the employee database

// 1. Find Employees in IT Department

SELECT FirstName, LastName FROM Employee 
WHERE DeptID = (SELECT DeptID FROM Department WHERE DeptName = 'IT');

// 2. Increase Salary by 10% for All Employees

UPDATE Employee 
SET Salary = Salary * 1.10;

// 3. Delete an Employee

DELETE FROM Employee WHERE EmpID = 2;

// 4. INNER JOIN to Get Employee and Their Departments

SELECT e.FirstName, e.LastName, d.DeptName 
FROM Employee e
JOIN Department d ON e.DeptID = d.DeptID;

// 5. View for High-Salary Employees

CREATE VIEW HighSalEmployees AS
SELECT FirstName, LastName, Salary FROM Employee WHERE Salary > 65000;

// 6. A view to see which employee working on which project
CREATE VIEW EmployeeProjectView AS
SELECT 
    e.EmpID, 
    e.FirstName, 
    e.LastName, 
    p.ProjectID, 
    p.ProjectName, 
    ep.Role
FROM Employee e
JOIN Employee_Project ep ON e.EmpID = ep.EmpID
JOIN Project p ON ep.ProjectID = p.ProjectID;


// 7. Procedure to Give Bonus

CREATE OR REPLACE PROCEDURE GiveBonus(
    IN emp_id INT, 
    IN bonus_amount DECIMAL(10,2)
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Check if the employee exists
    IF NOT EXISTS (SELECT 1 FROM Employee WHERE EmpID = emp_id) THEN
        RAISE EXCEPTION 'Employee ID % does not exist.', emp_id;
    END IF;

    -- Update the salary with the bonus amount
    UPDATE Employee 
    SET Salary = Salary + bonus_amount 
    WHERE EmpID = emp_id;

    RAISE NOTICE 'Bonus of % has been added to Employee ID %', bonus_amount, emp_id;
END;
$$;

// 8. Procedure to add employee to new project

CREATE OR REPLACE PROCEDURE AddEmployeeToProject(
    IN emp_id INT, 
    IN project_id INT, 
    IN role VARCHAR(50)
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Check if employee exists
    IF NOT EXISTS (SELECT 1 FROM Employee WHERE EmpID = emp_id) THEN
        RAISE EXCEPTION 'Employee ID % does not exist.', emp_id;
    END IF;

    -- Check if project exists
    IF NOT EXISTS (SELECT 1 FROM Project WHERE ProjectID = project_id) THEN
        RAISE EXCEPTION 'Project ID % does not exist.', project_id;
    END IF;

    -- Insert employee into project
    INSERT INTO Employee_Project (EmpID, ProjectID, Role)
    VALUES (emp_id, project_id, role);

    RAISE NOTICE 'Employee % successfully assigned to project % as %', emp_id, project_id, role;
END;
$$;






