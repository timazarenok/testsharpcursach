create database Test;
go
use Test;

create table Users(
id int Identity(1,1) primary key,
[email] varchar(100)
)

create table Professions (
id int Identity(1,1) primary key,
[name] varchar(100)
)

create table Tests(
id int Identity(1,1) primary key,
[name] varchar(100)
)

create table Questions (
id int Identity(1,1) primary key,
id_t int references Tests(id),
id_p int references Professions(id),
[name] varchar(100)
)

create table Answers (
id int Identity(1,1) primary key,
id_q int references Questions(id),
id_u int references Users(id),
[value] bit,
)

insert into Tests values('Тест')
