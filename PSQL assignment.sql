-- create statements
create table courses(id serial primary key,title varchar(100),description varchar(200));
create table instructors(id serial primary key,name varchar(100),email varchar(100) unique,phone_number varchar(15));
create table students(id serial primary key,name varchar(100),email varchar(100) unique,enrollment_date date);
create table enrollments (enrollment_id int primary key,student_id int not null,course_id int not null,enrollment_date date not null,           
      foreign key (student_id) references students(id),
      foreign key (course_id) references courses(id)
);
create table course_instructors(course_id int not null references courses(id),instructor_id int not null references instructors(id),primary key(course_id,instructor_id));

-- select statements
select * from courses;
select * from instructors;
select * from students;
select * from enrollments;
select * from course_instructors;

-- insert statements
insert into courses(title,description) values ('C','Programming language');
insert into courses(title,description) values ('SQL','DBMS');
insert into courses(title,description) values ('SpringBoot','Framework');
insert into courses(title,description) values ('HTML','Markup language');
insert into courses(title,description) values ('CSS','Styling sheet');

insert into instructors(name,email,phone_number) values ('Alice','alice@gmail.com','9980072456');
insert into instructors(name,email,phone_number) values ('Bob','bob@gmail.com','8876329087');
insert into instructors(name,email,phone_number) values ('Charlie','charlie@gmail.com','7760672456');
insert into instructors(name,email,phone_number) values ('David','david@gmail.com','8090072456');
insert into instructors(name,email,phone_number) values ('Emma','emma@gmail.com','7680072456');
insert into instructors(name,email,phone_number) values ('Farhan','farhan@gmail.com','8880072456');

insert into students(name, email, enrollment_date) values 
('Liam Jackson', 'liam.jackson@example.com', '2025-01-12'),
('Emma Robinson', 'emma.robinson@example.com', '2025-02-18'),
('Noah White', 'noah.white@example.com', '2025-03-03'),
('Ava Harris', 'ava.harris@example.com', '2025-01-25'),
('Oliver Lewis', 'oliver.lewis@example.com', '2025-02-10');

insert into enrollments(enrollment_id, student_id, course_id, enrollment_date) values
(1, 1, 1, '2025-01-20'), (2, 2, 1, '2025-02-10'),  (3, 1, 2, '2025-02-18'), (4, 4, 1, '2025-03-05'), (5, 5, 2, '2025-01-28');

INSERT INTO course_instructors (course_id, instructor_id)
VALUES (1, 1),(2, 2),(3, 3),(1, 4),(2, 5);

-- Queries
-- 1)Retrieve a list of all students enrolled in a specific course, including the course title and student names.

select c.title as course_title,s.name as student_name from enrollments e join students s on e.student_id=s.id join courses c on e.course_id=c.id where c.title='C';

-- 2)List all courses along with the names of their instructors.

select c.title as course_title,i.name as instructor_name from course_instructors ci join courses c on ci.course_id=c.id join instructors i on ci.instructor_id=i.id;

-- 3)Find all courses that have no students enrolled.

select c.title as course_title from courses c where c.id not in (select e.course_id from enrollments e);

-- 4)Get a list of instructors who are not teaching any courses.

select i.name as instructor_name from instructors i where i.id not in (select instructor_id from course_instructors);


