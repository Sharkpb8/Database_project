# Database Project

## Overview
This C# application provides functions to interact with database for library.

## Features
- **Create:** Add new records to database.
- **Read:** Read from database.
- **Update:** Modify existing records in database.
- **Delete:** Remove records from database.
- **XML Data Import:** Import data from XML files into database.

## Usage
1. Open `app.config`
2. change parametrs that you need
3. Open the exe file
4. choose what action you want to execute
5. choose from what table you want to execute the action


## Configuration
Ensure to configure proply the `app.config` file for program to run corectly.
Here is example of correctly filed `app.config`:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<appSettings>
		<add key="DataSource" value="name of server that you want to connect to"/>
		<add key="Database" value="name of database"/>
		<add key="Name" value="login username"/>
		<add key="Password" value="login password"/>
	</appSettings>
</configuration>
