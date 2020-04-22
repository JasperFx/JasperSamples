# Jasper as an In Memory Command Bus

This sample adds Jasper to a minimal MVC Core Web API project. The Jasper extensions
for Sql Server message persistence and Entity Core framework integration are also
part of this sample.a

To run this application:

1. Either use the `docker-compose.yml` file explained in the README.md file at the root of the repository to start
  up a Sql Server database, or change the *sqlserver* connection string in the `appsettings.json` file to connection
  to your local Sql Server database. And don't worry, the application itself will set up the tables it needs when it
  starts up.

1. Just start the application with `dotnet run`, and check out the [Swagger page](http://localhost:5000/swagger) for the application
  once it's running. Use any of the */create* routes, then the */items* route to see Jasper in action.it

If you're curious, use the `dotnet run -- codegen` command to see what the generated code for the message handlers
