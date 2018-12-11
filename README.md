# _Clinic Project_

#### _Epicodus Independent Project: C#/.Net week 3. 12.11.2018_

#### By _**Kenny Wolfenberger, Stuart Gill**_

## Description

_A C# application that is connected to a SQL database with tables for Stylists and Clients. Users can add to the Client lists for each individual Stylist. Any time a Client is added, it must be associated with a Stylist. Stylist table includes details such as name, address, phone number and Client list._

## Setup/Installation Requirements


* _Clone this repository: $ git clone https://github.com/kwolfenb/HairSalon.Solution.git_
* _To edit the project, open the project in your preferred text editor._
* _To create related database, open MySql from terminal. Enter the following commands:_
* _CREATE DATABASE hair\_salon;_
* _USE hair\_salon;_
* _CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255), phone VARCHAR(20), picture VARCHAR(255));_
* _CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist\_id INT, phone VARCHAR(20), notes TEXT);_
* _To run the program, first navigate to the location of the HairSalon file then run dotnet restore, dotnet build, and dotnet run._
* _When program is running open a web browser and go to localhost:5000 to view program._
* _To run the tests navigate to the Yelp.Tests folder and use these commands: $ dotnet restore and dotnet test._ 

## Support and contact details

 _Kenny Wolfenberger - kennywolfenberger@gmail.com_


### Specs
| Spec |
| :-------------  |
| Program can take new user input for new Stylist |
| Program can take new user input for new Clients |
| New clients will be linked to stylist table in a one-to-many relationship |
| Users can delete clients |
| Users can make updates to existing Stylists |
| Users can see list of all clients |
| Users can see list of all stylists |
| Users can see list of clients by specific stylists |
| Users can view detailed information for specific stylists|
| Users can view detailed information for specific clients |


## Technologies Used

* _C#_
* _.NET_
* _MSTests_
* _MVC_
* _Razor_
* _Mono_

### License

*This software is licensed under the MIT license.*

Copyright (c) 2018 **_Kenny Wolfenberger_**