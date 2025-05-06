# How to Connect to SQL Express Server

This is a guide for connecting, as a public user to a sql express server, ***"SampleDB"*** database.

## SQLCMD Utility

First you have to make sure you have the sqlcmd utility.

Run this command to check if you have it and the version:

````powershell
sqlcmd --version
````

### Install/Download

#### Winget

Run the following command to install sqlcmd:

````powershell
winget install sqlcmd
````

#### Chocolatey

Run the following command to install sqlcmd:

````powershell
choco install sqlcmd
````

#### Microsoft learn

The latest version can also be found here.

&rarr; [sqlcmd utility](https://learn.microsoft.com/en-us/sql/tools/sqlcmd/sqlcmd-utility?view=sql-server-ver16&tabs=go%2Cwindows%2Cwindows-support&pivots=cs1-powershell) &larr;

## How to connect using sqlcmd

Open a PowerShell terminal and write this command:

````powershell
sqlcmd -S localhost,1433 -U public_user
````

When it ask's for the password.

````powershell
Enter password: 
````

Write ***"PublicUser123!"*** as the password, and it should connect.

## Relocate to the database

When you first connect. You will be met with this:

````
1>
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

# Result of the integration

&rarr; [Go to the result of integration](./RESULT.md) &larr;