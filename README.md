# Hair Salon Database (C#)

A web app, built with C#, that allows user to store and retrieve data about stylists in a hair salon, including each stylist's unique set of clients and any specialty associations, using a MySql database. This project was completed to satisfy the C# Weeks 3/4 Independent Code Review at [Epicodus](https://www.epicodus.com) in Seattle, WA.

## Installation

### Database Setup

1. Clone this repository.
2. Within a terminal running MySQL, or through the SQL command line in phpMyAdmin, run the following commands:

 ```
 CREATE DATABASE eric_swotinsky;
 ```

 ```
 USE eric_swotinsky;
 ```

 ```
 CREATE table stylists (id serial PRIMARY KEY, name VARCHAR(255));
 ```
 
 ```
 CREATE table specialties (id serial PRIMARY KEY, name VARCHAR(255));
 ```

 ```
 CREATE table clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
 ```
 
 ```
 CREATE table stylists_specialties (id serial PRIMARY KEY, stylist_id INT, specialty_id INT);
 ```

3. Optional - to allow for testing, run the following SQL commands as well:

 ```
 CREATE DATABASE eric_swotinsky_tests;
 ```

 ```
 USE eric_swotinsky_tests;
 ```


 ```
 CREATE table stylists (id serial PRIMARY KEY, name VARCHAR(255));
 ```
 
 ```
 CREATE table specialties (id serial PRIMARY KEY, name VARCHAR(255));
 ```

 ```
 CREATE table clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
 ```
 
 ```
 CREATE table stylists_specialties (id serial PRIMARY KEY, stylist_id INT, specialty_id INT);
 ```


### Web App Setup

1. Follow the steps above to set up your database/s.
2. Install .NET, if not already present on your local machine.

3. In your preferred shell, navigate to the HairSalon folder and run the following commands:

 ```
 $ dotnet restore
 ```
(above not required for .NET Core 2.0 SDK or newer releases)

 ```
 $ dotnet run
 ```

4. Navigate to localhost:5000 in your preferred browser.

## Specifications

1. App routes users to the home page, which displays a list of stylists within the database as well as buttons to add/delete stylists.

2. When clicking "Add a new stylist", user is routed to a form through which the new stylist can be added to the database.

3. When clicking a stylist's name, user is routed to a "details" page containing a list of the stylist's clients. Page also contains buttons for adding new clients to the stylist in question and for returning to the main page.

4. When user adds a client to a given stylist, a view of the stylist's "details" page is returned, including the name of the newest client.

### Built With

* [Atom](https://atom.io/) - Open-source, hackable code editor running on the Electron framework.

### Support and Contact Details
If you encounter any bugs or would like to make suggestions regarding this project, please feel free to open an issue within the repository.

**Known issues:**
It is possible to add duplicate Stylist-Specialty associations.

### License

This project is distributed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
