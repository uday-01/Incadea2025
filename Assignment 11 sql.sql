SELECT id, name, class
	FROM public.student;

create table student(id int, name varchar(100),class varchar(10))

create procedure public.student(
in id int,
in name varchar(100),
in class varchar(10)
)
language plpgsql
as $$
begin 
insert into public.student(id,name,class)
values (id,name,class);
end;
$$;

call public.student(1,'Ram','5th')
call public.student(2,'Shyam','8th')

select * from public.student

	