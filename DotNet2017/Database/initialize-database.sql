CREATE DATABASE TechTalksDB
GO

SELECT Name from sys.Databases
GO

USE TechTalksDB
GO

CREATE TABLE Categories (id INT, categoryName NVARCHAR(50), description NVARCHAR(100))
GO

INSERT INTO Categories VALUES(1, 'Meetup', 'Community event organized via meetup');
INSERT INTO Categories VALUES(2, 'Conference', 'Tech Conference');
GO

CREATE TABLE TechTalk (id INT, name NVARCHAR(50), category INT)
GO

INSERT INTO TechTalk VALUES (1, 'Scaling Docker Containers', 1); 
INSERT INTO TechTalk VALUES (2, 'Azure Container Services', 2);
GO