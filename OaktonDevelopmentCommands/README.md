# Using Oakton for Development-Time Commands

This sample just shows the usage of Oakton to add command line commands 
to an ASP.Net Core application for development time tasks, without polluting 
the deployed application with development time utilities.

The things to note are:

* This project was generated through the `dotnet new webapi` template
* The `Program.Main()` method was changed to use Oakton.AspNetCore