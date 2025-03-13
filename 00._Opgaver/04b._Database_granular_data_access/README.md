# How to Connect to MongoDb

This is a guide for connecting as a public user, to the Cluster0, ***"sample_mflix"*** database.

## Mongosh/Mongo CLI

First you have to make sure you have the MongoDb CLI, and it has to be ***version 2.0.0*** or ***greater***.

### Check if installed or version

To check if you have the MongoDb CLI installed, or check the version. You can run this command:

````powershell
mongosh --version
#or
mongo --version
````

### Download link

The latest version can be found here.

&rarr; https://www.mongodb.com/docs/mongocli/current/ &larr;

## How to connect using the CLI

Open a PowerShell terminal and write this command:

````powershell
mongosh "mongodb+srv://cluster0.ozy9zc3.mongodb.net/" --apiVersion 1 --username public
````

When it ask's for the password.

````powershell
Enter password: 
````

Write ***"public"*** as the password, and it should connect.

## Relocate to the database

When you first connect. You will be met with this:

````
Atlas atlas-ne2a2s-shard-0 [primary] test>
````

"test" is the default starting point when connecting to the Cluster. So you have to run this command, to redirect to the database with content:

````powershell
use sample_mflix
````

When doing this. It changes the selected database, to use ***"sample_mflix"***. Where all the data is stored. 

````
Atlas atlas-ne2a2s-shard-0 [primary] sample_mflix>
````

## Public-user permissions

- Read/Find:
    - "users" collection
- Read/Find and Write/insert:
    - "comments" collection
- No access
    - "embedded_movies"
    - "movies"
    - "sessions"
    - "theaters"
