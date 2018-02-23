app should list out all existing instances of the Stylist class

app should allow users to click instances of the Stylist class and view their details, including a list of all Client instances associated with that Stylist

app should allow the creation of new Stylist instances on demand

app should allow the creation of new Client instances on demand, including the ability to associate the client with a Stylist

app should prevent the creation of a new Client if no instances of Stylist exist



Database Setup:

CREATE DATABASE eric_swotinsky;
USE eric_swotinsky;
CREATE table stylists (id serial PRIMARY KEY, name VARCHAR(255));
CREATE table clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
