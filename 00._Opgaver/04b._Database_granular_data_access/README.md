# How to Connect to MongoDb

This is a guide for connecting as a public user, to the Cluster0, ***"sample_mflix"*** database.

## Mongosh/Mongo CLI

First you have to make sure you have the MongoDb Shell Tool, and it has to be ***version 2.0.0*** or ***greater***.

### Check if installed or version

To check if you have the MongoDb CLI installed, or check the version. You can run this command in PowerShell:

````powershell
mongosh --version
#or
mongo --version
````

### Download link

The latest version can be found here.

&rarr; [https://www.mongodb.com/docs/mongocli/current/](https://downloads.mongodb.com/compass/mongosh-2.4.2-x64.msi) &larr;

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
## MongoDb Shell Commands

To Get/Find data in one of the collections. You can run this command:

````powershell
db.users.find()
````

This Gets/Finds all the data from the ***users*** collection. Try to change ***users*** to one of the other collections names. Like the ***comments***.

To Create/Insert data into one of the collections. You can run this command:

````powershell
db.comments.insert({ name: "Jane Doe", email: "jane.doe@gmail.com", movie_id: "573a1391f29313caabcd8543", text: "Lorem Ipsum", date: new Date()})
````

This Creates/Inserts data into the ***comments*** collection. Try to change ***comments*** to one of the other collections names. Like the ***users***.

To Alter/Update data in one of the collections. You can run this command:

````powershell
db.comments.updateOne({ _id: ObjectId("67e3cfcd4b0f8ef8d4c81c1a") },{ $set: { name: "John Doe", email: "john.doe@gmail.com", date: new Date()}})
````

This Alters/Updates the data in the ***comments*** collection. Try to change ***comments*** to one of the other collections names. Like the ***users***.


To Remove/Delete data in one of the collections. You can run this command:

````powershell
db.comments.deleteOne({ _id: ObjectId("67e3cfcd4b0f8ef8d4c81c1a")})
````

This Removes/Deletes the data in the ***comments*** collection. Try to change ***comments*** to one of the other collections names. Like the ***users***.

## Public-user permissions

List of permissions. With the names of the collections, that:

- Read/Find:
    - users
    - comments
- Write/insert:
    - comments
- Update
    - comments
- No access
    - embedded_movies
    - movies
    - sessions
    - theaters
