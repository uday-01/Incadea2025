create table courses (
    course_id serial primary key,
    title varchar(20) not null,
    description text);

create table instructors (
    instructor_id serial primary key,
    name varchar(20) not null,
    email varchar(20) unique not null,
    phone varchar(20));

create table students (
    student_id serial primary key,
    name varchar(20) not null,
    email varchar(20) unique not null,
    enrollment_date date not null check (enrollment_date <= CURRENT_DATE));

create table enrollments (
    enrollment_id serial primary key,
    student_id int not null,
    course_id int not null,
    enrollment_date date not null check (enrollment_date <= CURRENT_DATE),
    unique(student_id, course_id),
    foreign key (student_id) REFERENCES students(student_id),
    foreign key (course_id) REFERENCES courses(course_id));

create table courseinst (
    course_id int not null,
    instructor_id int not null,
    primary key (course_id, instructor_id),
    foreign key (course_id) REFERENCES courses(course_id),
    foreign key (instructor_id) REFERENCES instructors(instructor_id));

insert into courses (title, description) values('Mathematics', 'Basic Algebra')
insert into courses (title, description) values('Physics', 'Mechanics')
insert into courses (title, description) values('Chemistry', 'Organic Chemistry')
insert into courses (title, description) values('Computer Science', 'Python')
insert into courses (title, description) values('Social', 'History');

insert into instructors (name, email, phone) values('ram', 'ram@example.com', '123456789')
insert into instructors (name, email, phone) values('sita', 'sita@example.com', '987654321')
insert into instructors (name, email, phone) values('sham', 'sham@example.com', '556667777')
insert into instructors (name, email, phone) values('raj', 'raj@example.com', '222334444')
insert into instructors (name, email, phone) values('shalin', 'shalin@example.com', '999887777');

insert into students (name, email, enrollment_date) values('balu', 'balu@example.com', '2024-01-10')
insert into students (name, email, enrollment_date) values('sammu', 'sammu@example.com', '2024-01-15')
insert into students (name, email, enrollment_date) values('hari', 'hari@example.com', '2024-02-01')
insert into students (name, email, enrollment_date) values('keerthi', 'keerthi@example.com', '2024-02-10')
insert into students (name, email, enrollment_date) values('tanni', 'tanni@example.com', '2024-03-05');

insert into enrollments (student_id, course_id, enrollment_date) values(1, 1, '2024-01-10')
insert into enrollments (student_id, course_id, enrollment_date) values(1, 2, '2024-01-15')
insert into enrollments (student_id, course_id, enrollment_date) values(2, 3, '2024-01-20')
insert into enrollments (student_id, course_id, enrollment_date) values(3, 4, '2024-02-01')
insert into enrollments (student_id, course_id, enrollment_date) values(4, 5, '2024-02-10');

insert into courseinst(course_id, instructor_id) values(1, 1)
insert into courseinst(course_id, instructor_id) values(2, 2)
insert into courseinst(course_id, instructor_id) values(3, 3)
insert into courseinst(course_id, instructor_id) values(4, 4)
insert into courseinst(course_id, instructor_id) values(5, 5)
insert into courseinst(course_id, instructor_id) values(1, 3)
insert into courseinst(course_id, instructor_id) values(2, 4);

select * from courses;

select * from instructors;

select * from students;

select * from enrollments;

select * from courseinst;


SELECT c.title, s.name 
FROM enrollments e
JOIN students s ON e.student_id = s.student_id
JOIN courses c ON e.course_id = c.course_id
WHERE c.title = 'Mathematics';


SELECT c.title, i.name AS instructor_name 
FROM courseinst ci
JOIN courses c ON ci.course_id = c.course_id
JOIN instructors i ON ci.instructor_id = i.instructor_id;

SELECT c.title 
FROM courses c
LEFT JOIN enrollments e ON c.course_id = e.course_id
WHERE e.course_id IS NULL;

SELECT i.name 
FROM instructors i
LEFT JOIN courseinst ci ON i.instructor_id = ci.instructor_id
WHERE ci.course_id IS NULL;
