use master;
go
drop database if exists Nomina;
go
create database Nomina;
go
use Nomina;

create table Rol(
IdRol int identity primary key,
Nombre varchar(60) not null,
);

create table Persona(
IdPersona varchar(60) primary key,
Nombre varchar(60) not null,
Apellido varchar(60) not null,
IdRol int not null,
Salario float,
Contrasena varchar (60) not null,
foreign key (IdRol) references Rol(IdRol)
);

create table Pago(
IdPago int identity primary key,
IdPersona varchar(60) not null,
FechaPago date not null,
MontoPago float not null,
foreign key (IdPersona) references Persona(IdPersona)
);