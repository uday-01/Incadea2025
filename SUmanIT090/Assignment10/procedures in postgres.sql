--creating the table in the database

create table books(
book_id SERIAL PRIMARY KEY,
title VARCHAR(100),
Author varchar(100),
published_year int
);

--writing the procedure

create procedure add_book(
in book_title varchar(100),
in book_author varchar(100),
in pub_year int
)
language plpgsql
as $$
begin 
insert into books(title,author,published_year)
values (book_title,book_author,pub_year);
end;
$$;


call add_book('sumanbook','sumanjha',2025);


select * from books;
