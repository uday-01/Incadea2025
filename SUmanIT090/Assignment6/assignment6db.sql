create table courses(
course_id SERIAL primary key,
title varchar (255) not null ,
description text
);

select * from courses

--creating instructor table

create table Instructors(
instructor_id serial primary key,
name varchar(255) not null,
email varchar(255) unique not null,
phone varchar(15) not null 
);
select * from Instructors

--creating student table

create table Students(
student_id serial primary key,
name varchar(255) not null,
email varchar(255) unique not null,
enrollment_date DATE not null check (enrollment_date <= CURRENT_DATE)
);
SELECT * from Students

--creatinf the enrollmemt table

CREATE TABLE Enrollments (
    enrollment_id SERIAL PRIMARY KEY,
    student_id INT NOT NULL,
    course_id INT NOT NULL,
    enrollment_date DATE NOT NULL CHECK (enrollment_date <= CURRENT_DATE),
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    UNIQUE (student_id, course_id) -- Prevents the duplicate enrollments in this table
);
select * from Enrollments 

--creating course instructor table
CREATE TABLE Course_Instructors (
    course_id INT NOT NULL,
    instructor_id INT NOT NULL,
    PRIMARY KEY (course_id, instructor_id),
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id) ON DELETE CASCADE
);
select * from Course_Instructors

--now inserting the dummy data

INSERT INTO Courses (title, description) VALUES 
('Database Systems', 'Learn relational databases and pgSQL.'),
('Machine Learning', 'Introduction to ML algorithms and techniques.'),
('Web Development', 'Learn HTML, CSS, JavaScript, and modern frameworks.'),
('Cybersecurity', 'Introduction to security principles and cryptography.'),
('Cloud Computing', 'Learn cloud services like AWS, Azure, and GCP.');

INSERT INTO Instructors (name, email, phone) VALUES 
('Ram', 'ram@incadea.com', '23456789345'),
('shyam', 'shyam@incadea.com', '1234567890'),
('suman', 'suman@incadea.com', '45678903456'),
('rahul', 'rahul@incadea.com', '5623456789'),
('someone', 'someone@incadea.com', '3344556677');


INSERT INTO Students (name, email, enrollment_date) VALUES 
('sumankumar', 'sumankumar.incadea.com', '2024-01-15'),
('rajaesh', 'rajjesg@incadea.com', '2024-01-20'),
('dummy3', 'dummy3@incadea.com', '2024-02-05'),
('raja', 'raja@incadea.com', '2024-02-10'),
('harry', 'harry@incadea.com', '2024-02-15');

select * from Students


 INSERT INTO Enrollments (student_id, course_id, enrollment_date) VALUES 
(1, 1, '2024-02-01'), 
(2, 2, '2024-02-02'), 
(3, 1, '2024-02-03'), 
(4, 3, '2024-02-04'), 
(5, 4, '2024-02-05');

INSERT INTO Course_Instructors (course_id, instructor_id) VALUES 
(1, 1), 
(2, 2), 
(3, 3),
(4, 4), 
(5, 5);




--now sql joins queries

--query for the list of students enrolled in a specific course , the list will show coursetitle and studenst_name

SELECT c.title AS Course_Title, s.name AS Student_Name
FROM Enrollments e
JOIN Students s ON e.student_id = s.student_id
JOIN Courses c ON e.course_id = c.course_id
WHERE c.course_id = 1; 

--list of all courses along with name of their instructors

SELECT c.title AS Course_Title, i.name AS Instructor_Name
FROM Course_Instructors ci
JOIN Courses c ON ci.course_id = c.course_id
JOIN Instructors i ON ci.instructor_id = i.instructor_id;



--query to retrive all courses that has no students 

SELECT c.title AS Course_Title
FROM Courses c
LEFT JOIN Enrollments e ON c.course_id = e.course_id
WHERE e.course_id IS NULL;

--query to get  the list of instructors who are not teaching any courses

SELECT i.name AS Instructor_Name
FROM Instructors i
LEFT JOIN Course_Instructors ci ON i.instructor_id = ci.instructor_id
WHERE ci.course_id IS NULL;





