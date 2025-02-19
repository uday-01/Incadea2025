
 
create table trainingschema.books(
book_id SERIAL PRIMARY KEY,
title VARCHAR(100),
Author varchar(100),
published_year int
);
 

 
create procedure trainingschema.add_book(
in book_title varchar(100),
in book_author varchar(100),
in pub_year int
)
language plpgsql
as $$
begin 
insert into trainingschema.books(title,author,published_year)
values (book_title,book_author,pub_year);
end;
$$;
 
 
call trainingschema.add_book('Ramayan','Valmiki',2025);
 
 
select * from trainingschema.books;