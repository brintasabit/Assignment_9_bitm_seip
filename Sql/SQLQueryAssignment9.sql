create database CustomersInformation
drop database Customers
create table Districts(ID int identity (1,1),District varchar(20))
insert into Districts values('--Select--')
insert into Districts values('Naogaon')
insert into Districts values('Bogra')
insert into Districts values('Sirajgonj')
insert into Districts values('Natore')
insert into Districts values('Ishwardi')
insert into Districts values('Rajshahi')
select * from Districts
create table Customers(ID int identity (1,1),Code varchar(20),Name varchar(20),Address varchar(50),Contact varchar(20),District varchar(20))
insert into Customers values('0001','Alice','Naogaon Sadar','0301','Naogaon')
select * from Customers