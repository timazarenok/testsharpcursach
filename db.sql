create database Test;
go
use Test;

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
answer varchar(100),
score int
)

create table Answers (
id int Identity(1,1) primary key,
id_q int references Questions(id) on delete cascade,
id_u int references Users(id) on delete cascade,
[value] varchar(100),
)

insert into Tests values('IQ')
select [Answers].[value], Questions.answer, Questions.score from Answers join Questions on Questions.id = Answers.id_q
where Answers.id_u = 1
select * from Users