create table Books
(
    Id serial primary key,
	Title varchar(200),
	Author varchar(200),
	Category varchar(200),
	Access bool
);
