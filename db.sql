create database Test2;
go
use Test2;

create table Users(
id int Identity(1,1) primary key,
[email] varchar(100)
)

create table Tests(
id int Identity(1,1) primary key,
[name] varchar(100)
)

create table Questions (
id int Identity(1,1) primary key,
id_t int references Tests(id) on delete cascade,
[name] varchar(100),
score int
)

create table Answers (
id int Identity(1,1) primary key,
id_q int references Questions(id) on delete cascade,
[value] varchar(100)
)

create table Question_Answers (
id int Identity(1,1) primary key,
id_q int references Questions(id) on delete cascade,
id_a int references Answers(id),
id_u int references Users(id) on delete cascade
)

insert into Tests values('IQ')

select * from Question_Answers 
join Questions on Questions.id = Question_Answers.id_q
join Answers on Answers.id = Question_Answers.id_a
where id_u = 1