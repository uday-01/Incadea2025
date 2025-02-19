// Table creation and inserting values to the table.

CREATE TABLE Employee (
    EmpID INT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Phone VARCHAR(15) UNIQUE,
    HireDate DATE NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    DeptID INT,
    ManagerID INT,
    FOREIGN KEY (DeptID) REFERENCES Department(DeptID),
    FOREIGN KEY (ManagerID) REFERENCES Employee(EmpID) ON DELETE SET NULL
);

CREATE TABLE Department (
    DeptID INT PRIMARY KEY,
    DeptName VARCHAR(100) UNIQUE NOT NULL,
    Location VARCHAR(100) NOT NULL
);

CREATE TABLE Project (
    ProjectID INT PRIMARY KEY,
    ProjectName VARCHAR(100) NOT NULL,
    StartDate DATE,
    EndDate DATE,
    Budget DECIMAL(12,2),
    DeptID INT,
    FOREIGN KEY (DeptID) REFERENCES Department(DeptID) ON DELETE SET NULL
);

CREATE TABLE Employee_Project (
    EmpID INT,
    ProjectID INT,
    Role VARCHAR(50),
    PRIMARY KEY (EmpID, ProjectID),
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID) ON DELETE CASCADE,
    FOREIGN KEY (ProjectID) REFERENCES Project(ProjectID) ON DELETE CASCADE
);

CREATE TABLE Salary_History (
    RecordID INT PRIMARY KEY,
    EmpID INT,
    OldSalary DECIMAL(10,2),
    NewSalary DECIMAL(10,2),
    ChangeDate DATE DEFAULT CURRENT_DATE,
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID) ON DELETE CASCADE
);

CREATE TABLE Attendance (
    RecordID INT PRIMARY KEY,
    EmpID INT,
    AttendanceDate DATE NOT NULL,
    Status ENUM('Present', 'Absent', 'Leave') NOT NULL,
    FOREIGN KEY (EmpID) REFERENCES Employee(EmpID) ON DELETE CASCADE
);

// Inserting values

INSERT INTO Employee (EmpID, FirstName, LastName, Email, Phone, HireDate, Salary, DeptID, ManagerID) VALUES
(101, 'John', 'Doe', 'john.doe@example.com', '9876543210', '2022-01-15', 60000, 2, NULL),
(102, 'Jane', 'Smith', 'jane.smith@example.com', '8765432109', '2023-03-10', 55000, 1, 101),
(103, 'Alice', 'Brown', 'alice.brown@example.com', '7654321098', '2021-07-25', 70000, 3, NULL),
(104, 'Bob', 'Taylor', 'bob.taylor@example.com', '6543210987', '2020-09-18', 65000, 2, 101),
(105, 'Emma', 'Wilson', 'emma.wilson@example.com', '5432109876', '2022-05-30', 72000, 3, 103);


INSERT INTO Project (ProjectID, ProjectName, StartDate, EndDate, Budget, DeptID) VALUES
(201, 'ERP System Upgrade', '2023-01-10', '2024-06-15', 150000.00, 2),
(202, 'Website Redesign', '2022-05-20', '2023-12-01', 80000.00, 4),
(203, 'Payroll Automation', '2021-10-15', '2022-11-30', 60000.00, 3),
(204, 'AI Chatbot Development', '2024-02-01', NULL, 120000.00, 2);


INSERT INTO Employee_Project (EmpID, ProjectID, Role) VALUES
(101, 201, 'Project Manager'),
(102, 202, 'UI Designer'),
(103, 203, 'Finance Analyst'),
(104, 201, 'Developer'),
(105, 204, 'AI Engineer');


INSERT INTO Department (DeptID, DeptName, Location) VALUES 
(1, 'HR', 'New York'),
(2, 'IT', 'San Francisco'),
(3, 'Finance', 'Chicago'),
(4, 'Marketing', 'Los Angeles');

INSERT INTO Salary_History (RecordID, EmpID, OldSalary, NewSalary, ChangeDate) VALUES
(301, 101, 55000, 60000, '2022-01-15'),
(302, 102, 50000, 55000, '2023-03-10'),
(303, 103, 65000, 70000, '2021-07-25'),
(304, 104, 60000, 65000, '2020-09-18'),
(305, 105, 68000, 72000, '2022-05-30');

INSERT INTO Attendance (RecordID, EmpID, AttendanceDate, Status) VALUES
(401, 101, '2024-02-01', 'Present'),
(402, 102, '2024-02-01', 'Absent'),
(403, 103, '2024-02-01', 'Present'),
(404, 104, '2024-02-01', 'Leave'),
(405, 105, '2024-02-01', 'Present');




