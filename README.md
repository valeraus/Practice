CREATE DATABASE Authors
Use Authors


CREATE TABLE Authors (
ID uniqueidentifier NOT NULL,
LastName nvarchar(20) NOT NULL,
FirstName nvarchar(20) NOT NULL,
PatronymicName nvarchar(20) NOT NULL,
DateOfBirth DateTime  NULL,
)

CREATE TABLE Books (
ID uniqueidentifier NOT NULL,
Title nvarchar(20) NOT NULL,
NumberOfPages nvarchar(5) NOT NULL,
Genre int NOT NULL,
AuthorId uniqueidentifier NOT NULL,
)
