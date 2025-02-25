create schema Training_Institute

select * from training_institute.courses;
select * from training_institute.instructors;
select * from training_institute.students;
select * from training_institute.Enrollments;
select * from training_institute.Course_Instructors;

create table training_institute.Courses(
	id serial primary key, title varchar(30), description varchar(100)
);

create table training_institute.Instructors(
	id serial primary key, name varchar(30), email varchar(100) unique, number int
);

create table training_institute.Students(
	id serial primary key, name varchar(30), email varchar(100) unique, enrollment_Date date
);

create table training_institute.Enrollments(
	id serial primary key, studid int, courseid int, enrollment_Date date,
	foreign key (studid) references training_institute.Students(id),
	foreign key (courseid) references training_institute.courses(id)
);

create table training_institute.Course_Instructors(
	id serial primary key, instructid int, courseid int,
	foreign key (courseid) references training_institute.courses(id),
	foreign key (instructid) references training_institute.Instructors(id)
);

insert into training_institute.courses(title,description) values
	('DM', 'Descrete Maths'), ('IM', 'Integrated Maths'), ('EEE', 'Electrical Engineering'),('DSA', 'Data Structures'),
	('TOC', 'Theory of Computation');

insert into training_institute.instructors(name,email,number) values
	('Roy','royraj@gmail.com',123), ('Reena','reena@gmail.com',456), ('Gupta','gupta@gmail.com', 789),
	('Kranti','kranti@gmail.com',1234), ('Abhi','abhi@gmail.com',5678);

insert into training_institute.students(name,email,enrollment_date) values
	('Karthik','kathik@gmail.com','12-07-2019'),('Ganesh','ganesh@gmail.com','11-07-2019'),('Guna','guna@gmail.com','15-07-2019'),
	('Avinash','avinash@gmail.com','09-07-2019'),('Vamsi','vamsi@gmail.com','14-06-2020'),('Surya','surya@gmail.com','14-07-2020');

insert into training_institute.enrollments(studid,courseid,enrollment_Date) values
	(1,1,'15-09-2019'),(1,2,'19-01-2020'),(2,1,'15-09-2019'),(2,5,'15-09-2019'),(3,1,'19-01-2020'),(3,3,'19-01-2020'),
	(2,2,'15-09-2020'),(2,3,'15-09-2021'),(1,5,'15-09-2021'),(5,1,'15-09-2020'),(5,2,'15-09-2020'),(5,1,'15-09-2021');

insert into training_institute.course_instructors(instructid,courseid) values
	(1,1),(1,2),(1,3),(2,1),(2,4),(3,1),(3,2),(3,5),(4,4)


select s.name as Student_Name,c.title as Course_Title from training_institute.enrollments as e 
	inner join training_institute.students as s on e.studid = s.id
	inner join training_institute.courses as c on e.courseid = c.id
	order by s.name

select c.title as Course_Name,i.name as Instructor_Name from training_institute.course_instructors as ci
	join training_institute.courses as c on ci.courseid = c.id 
	join training_institute.instructors as i on ci.instructid = i.id 
	order by c.id

select c.title,c.description from training_institute.courses as c left join training_institute.enrollments as e on c.id = e.courseid
	where e.courseid is null

select i."name" from training_institute.instructors as i left join training_institute.course_instructors as ci on i.id = ci.instructid
	where ci.courseid is null








	