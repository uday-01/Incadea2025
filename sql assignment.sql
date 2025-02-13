select * from student

select * from course

select * from instructor

select * from enrollment

select * from course_instructor

--1.
select s.name,c.title from student s, course c , enrollment e
where s.student_id = e.student_id and e.course_id = c.course_id

--2.
select c.title, i.name from course c , instructor i , course_instructor ci 
where c.course_id = ci.course_id and i.instructor_id= ci.instructor_id

--3.
select c.course_id, c.title from course c 
where c.course_id not in (select e.course_id from enrollment e )

--4.
select i.instructor_id, i.name from instructor i where i.instructor_id not in (select ci.instructor_id from course_instructor ci)