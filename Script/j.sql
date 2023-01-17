CREATE TABLE dbo.Addresses (
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Street VARCHAR(50),
	StreetNumber VARCHAR(10),
	City VARCHAR(50),
	Country VARCHAR (50), 
	IsDeleted BIT NOT NULL
)



CREATE TABLE dbo.Languages
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 NameOfLanguage VARCHAR(50) NOT NULL,
 IsDeleted BIT NOT NULL,
)



CREATE TABLE dbo.Users
(
	Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Jmbg VARCHAR(13) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Gender VARCHAR(10) NOT NULL,
	UserType VARCHAR(10) NOT NULL,
	IsActive BIT NOT NULL,
	AddressId INT,
	CONSTRAINT FK_ADDRESSES_USERS
	FOREIGN KEY (AddressId) REFERENCES dbo.Addresses (Id)
)

CREATE TABLE dbo.Administrators
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 UserId INT NOT NULL UNIQUE,
 CONSTRAINT FK_USERS_ADMINISTRATORS
 FOREIGN KEY (UserId) REFERENCES dbo.Users (Id)
)

CREATE TABLE dbo.Professors
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 UserId INT NOT NULL UNIQUE,
 CONSTRAINT FK_USERS_PROFESSORS
 FOREIGN KEY (UserId) REFERENCES dbo.Users (Id)
)

CREATE TABLE dbo.Students
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 UserId INT NOT NULL UNIQUE,
 CONSTRAINT FK_USERS_STUDENTS
 FOREIGN KEY (UserId) REFERENCES dbo.Users (Id)
)


CREATE TABLE dbo.Lessons
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(50) NOT NULL, 
 ProfessorId INT, 
 Date smalldatetime NOT NULL,
 Duration TIME NOT NULL ,
 Status BIT NOT NULL,
 StudentId INT,
 IsDeleted BIT NOT NULL,
 CONSTRAINT FK_PROFESSORS_LESSONS
 FOREIGN KEY(ProfessorId) REFERENCES dbo.Professors (Id),
 CONSTRAINT FK_STUDENTS_LESSONS
 FOREIGN KEY(StudentId) REFERENCES dbo.Students (Id)
)
CREATE TABLE dbo.Class
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(50) NOT NULL, 
 DateOfClass VARCHAR(50) NOT NULL, 
 StartOfClass VARCHAR(50) NOT NULL,
 ClassTime VARCHAR(50) NOT NULL,
 Status BIT NOT NULL,
 IsDeleted BIT NOT NULL,
 ProfessorId INT, 
 StudentId INT,
 
 CONSTRAINT FK_PROFESSORS_CLASS
 FOREIGN KEY(ProfessorId) REFERENCES dbo.Professors (UserId),
 CONSTRAINT FK_STUDENTS_CLASS
 FOREIGN KEY(StudentId) REFERENCES dbo.Students (UserId)
)



CREATE TABLE dbo.Schools
(
 Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
 Name VARCHAR(50) NOT NULL, 
 AddressId INT, 
 LanguageId INT, 
 IsDeleted BIT NOT NULL,
 CONSTRAINT FK_ADDRESSES_SCHOOLS
 FOREIGN KEY(AddressId) REFERENCES dbo.Addresses (Id),
 CONSTRAINT FK_LANGUAGES_SCHOOLS
 FOREIGN KEY(LanguageId) REFERENCES dbo.Languages (Id)
)


Insert into Users(firstname,lastname, jmbg, email, Password, gender, userType, isActive) values 
('Marija','Maric', 1234567891011, 'maki123@gmail.com', 'Maki123', 1, 0, 1)
Insert into Users(firstname,lastname, jmbg, email, Password, gender, userType, isActive) values 
('Zika','Zikic', 1110987654321, 'zika123@gmail.com', 'Zika123', 1, 1, 0)
Insert into Users(firstname,lastname, jmbg, email, Password, gender, userType, isActive,AddressId) values 
('Sava','Savic', 1111111111111, 'sava3@gmail.com', 'Sava123', 1, 1, 0,1)


delete from Users where Id=2; 

set identity_insert administrators on
insert into administrators(id, userId) values (1, 1);
insert into Addresses(street,StreetNumber,City,Country,IsDeleted) VALUES ('a',5,'aa','aa',0)
insert into students(UserId) values(3);
delete from users where Id=2002
select * from users
select * from professors
delete from students where UserId=1013
select * from students
select * from Addresses
select * from schools
select * from lessons
select * from languages
select * from Administrators

select s.UserId, u.*,a.* FROM dbo.Students s ,  dbo.Users u LEFT JOIN dbo.Addresses a 
                    ON u.AddressId=a.Id where s.UserId=u.id
select * from class;
select * from professors;
select * from users

select s.UserId, u.*,a.* FROM dbo.Students s ,  dbo.Users u LEFT JOIN dbo.Addresses a 
                    ON u.AddressId=a.Id where s.UserId=u.id
select c.Id,c.Name,c.DateOfClass,c.StartOfClass,c.ClassTime,c.Status,c.IsDeleted,
p.Id as pId,p.UserId as pUserId,u.FirstName as pFirstName,u.LastName as pLastName,u.Jmbg AS pJmbg,
u.Email As pEmail, u.Password as pPassword,u.Gender AS pGender,u.UserType as pUserType,u.IsActive AS pIsActive,
u.AddressId AS pAddressId,

s.Id as sId,s.UserId as sUserId,us.FirstName as sFirstName,us.LastName as sLastName,us.Jmbg AS sJmbg,
us.Email As sEmail, us.Password as sPassword,us.Gender AS sGender,us.UserType as sUserType,us.IsActive AS sIsActive,
us.AddressId AS sAddressId

from dbo.Class c 
left join dbo.Users u  On c.ProfessorId=u.Id left join dbo.Professors p on p.UserId=u.Id 
left join dbo.Users us on c.StudentId=us.Id left join dbo.Students s on s.UserId=us.Id;

select * from Professors;
select * from Users;
select * from Class;
