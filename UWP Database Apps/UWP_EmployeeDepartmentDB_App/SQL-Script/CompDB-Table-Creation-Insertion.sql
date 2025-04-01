CREATE DATABASE CompDB;

USE CompDB;

DROP TABLE IF EXISTS Department;

CREATE TABLE Department
(
	deptId INT IDENTITY(100,25) PRIMARY KEY,
	deptName VARCHAR(20) NOT NULL,
	deptType VARCHAR(10) NOT NULL
);

INSERT INTO Department( deptName, deptType ) VALUES ( 'C-Suite', 'Remote' );
INSERT INTO Department( deptName, deptType ) VALUES ( 'IT', 'Remote' );
INSERT INTO Department( deptName, deptType ) VALUES ( 'Sales', 'In-Person' );
INSERT INTO Department( deptName, deptType ) VALUES ( 'Finance', 'In-Person' );
INSERT INTO Department( deptName, deptType ) VALUES ( 'HR', 'Remote' );
INSERT INTO Department( deptName, deptType ) VALUES ( 'Learn-&-Dev', 'Remote' );

SELECT * FROM Department;

DROP TABLE IF EXISTS Employee;

CREATE TABLE Employee
(
	empId INT IDENTITY(1000,100) PRIMARY KEY,
	empFirstName VARCHAR(50) NOT NULL,
	empLastName VARCHAR(50) NOT NULL,
	empBirthDate DATE NOT NULL,
	empCity VARCHAR(50) NOT NULL,
	empCountry VARCHAR(50) NOT NULL,
	empHireDate DATE NOT NULL,
	empJobTitle VARCHAR(50) NOT NULL,
	empEmailId VARCHAR(50) NOT NULL,
	empSalary NUMERIC(8,2) NOT NULL,
	empDept INT,
	CONSTRAINT FK_DeptEmp 
	FOREIGN KEY (empDept) REFERENCES Department(deptId)
);

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Albus', 'Dumbledore', '1980-01-01', 'London', 'UK', GETDATE()-100, 'CEO', 'albus.dumbeldore@gmail.com', 200000, 100 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Larry', 'Stine', '1981-02-02', 'New York', 'USA', GETDATE()-90, 'COO', 'larry.stine@gmail.com', 150000, 100 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Severus', 'Snape', '1980-03-03', 'Wembley', 'UK', GETDATE()-80, 'Developer', 'Severus.Snape@gmail.com', 98765, 125 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Rubeus', 'Hagrid', '1981-04-04', 'Liverpool', 'UK', GETDATE()-120, 'Tester', 'Rubeus.Hagrid@gmail.com', 88888, 125 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Jane', 'Doe', '1981-06-06', 'Calgary', 'Canada', GETDATE()-140, 'Sales Manager', 'Jane.Doe@gmail.com', 66666, 150 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'John', 'Doe', '1981-05-05', 'Toronto', 'Canada', GETDATE()-130, 'Financial Analyst', 'John.Doe@gmail.com', 77777, 175 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Robert', 'King', '1981-07-07', 'Edmonton', 'Canada', GETDATE()-150, 'Recruiter', 'Robert.King@gmail.com', 54321, 200 );

INSERT INTO Employee
( empFirstName, empLastName, empBirthDate, empCity, empCountry, empHireDate, empJobTitle, empEmailId, empSalary, empDept )
	VALUES
( 'Janice', 'Walker', '1980-10-19', 'Mexico City', 'Mexico', GETDATE()-250, 'Tech Instructor', 'Janice.Walker@gmail.com', 55555, 225 );

SELECT * FROM Employee;

-- DROP TABLE Employee;

SELECT 
	CONCAT( empFirstName, ' ', empLastName ) AS empName,
	CONCAT( empCity, ' , ', empCountry ) AS empLocation,
	empBirthDate, empHireDate, 
	empJobTitle, empEmailId,
	empSalary, deptName, deptType
FROM
	Employee
JOIN
	Department
ON
	Employee.empDept = Department.deptId
ORDER BY
	empSalary DESC;

-- Department Data
SELECT * FROM Department;

-- Employee Data
SELECT * FROM Employee;

-- Final Data
SELECT CONCAT( empFirstName, ' ', empLastName ) AS empName, CONCAT( empCity, ' , ', empCountry ) AS empLocation, empBirthDate, empHireDate, empJobTitle, empEmailId, empSalary, deptName, deptType FROM Employee JOIN Department ON Employee.empDept = Department.deptId ORDER BY empSalary DESC;
