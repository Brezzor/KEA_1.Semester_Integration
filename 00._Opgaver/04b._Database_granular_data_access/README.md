# How to Connect to SQL Express Server

This is a guide for connecting, as a public user to a sql express server, **_"SampleDB"_** database.

## SQLCMD Utility

First you have to make sure you have the sqlcmd utility.

Run this command to check if you have it and the version:

```powershell
sqlcmd --version
```

### Download/Install

#### Winget

Run the following command to install sqlcmd:

```powershell
winget install sqlcmd
```

#### Chocolatey

Run the following command to install sqlcmd:

```powershell
choco install sqlcmd
```

#### Microsoft learn

The latest version can also be found here.

&rarr; [sqlcmd utility](https://learn.microsoft.com/en-us/sql/tools/sqlcmd/sqlcmd-utility?view=sql-server-ver16&tabs=go%2Cwindows%2Cwindows-support&pivots=cs1-powershell) &larr;

## How to connect using sqlcmd

### TCP Tunnel

Contact me on Facebook Messenger for the tunnel url:

https://www.facebook.com/OliverBresson

Open a PowerShell terminal and write this command:

_Replace the `<url>` with the one I give you._

```powershell
sqlcmd -S <url> -d SampleDB -U public_user -P PublicUser123!
```

### Run Local

Open a PowerShell terminal and write this command:

```powershell
sqlcmd -S localhost,1444 -d SampleDB -U public_user -P PublicUser123!
```

## SQLCMD Commands

To `SELECT` data in one of the Tables. You can run this command:

```sql
SELECT * FROM Products
GO
```

This `SELECT`'s all the data from the **_Products_** Table. Try to change **_Products_** to one of the other Tables. Like the **_Employees_**.

## public_user permissions

List of permissions. With the names of the Tables, that:

- Employees
  - SELECT :no_entry:
    - Id :no_entry:
    - Name :no_entry:
    - Salary :no_entry:
    - Department :no_entry:
  - INSERT :no_entry:
  - UPDATE :no_entry:
  - DELETE :no_entry:
- Products
  - SELECT :white_check_mark:
    - Id :white_check_mark:
    - Name :white_check_mark:
    - Cost :white_check_mark:
    - Category :white_check_mark:
  - INSERT :no_entry:
  - UPDATE :no_entry:
  - DELETE :no_entry:
- Orders
  - SELECT :white_check_mark:
    - Id :white_check_mark:
    - ProductId :white_check_mark:
    - Quantity :white_check_mark:
    - Customer :no_entry:
  - INSERT :white_check_mark:
  - UPDATE :white_check_mark:
  - DELETE :white_check_mark:
- Customers
  - SELECT :white_check_mark:
    - Id :white_check_mark:
    - Name :white_check_mark:
    - Email :no_entry:
  - INSERT :white_check_mark:
  - UPDATE :white_check_mark:
  - DELETE :white_check_mark:

# Result of the integration

&rarr; [Go to the result of integration](./RESULT.md) &larr;
