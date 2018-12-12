# _Clinic Project_

#### _Epicodus Project: C#/.Net week 4. 12.11.2018_

#### By _**Kenny Wolfenberger, Stuart Gill**_

## Description

_A C# application that is connected to a SQL database with tables for Doctors, Specialties and Patients. Users can add to the database for any of these categories. Any time a Doctor is added, it must be associated with a Specialty._

## Setup/Installation Requirements


* _Clone this repository: $ git clone https://github.com/kwolfenb/CS-Clinic-Project-MVC-SQL.git_
* _To edit the project, open the project in your preferred text editor._
* _To create related database, open MySql from terminal. Enter the following commands:_
* _CREATE DATABASE clinic;_
* _USE clinic;_
* _CREATE TABLE doctors (id serial PRIMARY KEY, name VARCHAR(255));_
* _CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));_
* _CREATE TABLE doctors_specialties (id serial PRIMARY KEY, doctor_id INT, specialty_id INT);_
* _To run the program, first navigate to the location of the Clinic file then run dotnet restore, dotnet build, and dotnet run._
* _When program is running open a web browser and go to localhost:5000 to view program._
* _To run the tests navigate to the Clinic.Tests folder and use these commands: $ dotnet restore and dotnet test._ 

## Support and contact details

*  _Kenny Wolfenberger - kennywolfenberger@gmail.com_
* _Stuart Gill - stuart.a.gill@gmail.com_



## Technologies Used

* _C#_
* _.NET_
* _MSTests_
* _MVC_
* _Razor_
* _SQL_
* _MAMP_

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Kenny Wolfenberger, Stuart Gill_**