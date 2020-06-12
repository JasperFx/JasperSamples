# Marten NDC Oslo Talk

## Splash Screen

* Describe what a Marten is
* Go ahead and tell the naming story
* Agenda -- show Marten, try to explain why Doc Db s are useful

## About Me

Riff

## What is Marten?

* Emphasize **Library**. Nothing to install except the library. Uses Npgsql
* ACID -- big deal

## The Marten Community

* Stress the number of contributors. More folks in the issues. Very involved community. *Sand Paper* line
* Core team, more than me, project is viable
* Active discussion group
* Lots of documentation

## Why Postgresql?

* Explain the JSONB support
* Why not Sql Server
* Spin up the docker container -- `docker-compose up -d`
* Talk about Azure, AWS
* Can run locally on developer boxes, big advantage over Azure Cosmos
* Moves fast, sql/json support

## Getting Started with Marten

* Switch to code. Show HostBuilder integration
* Open `Startup`
* Go to `IssueController`, show `IDocumentSession` coming in, then `IQuerySession`
 -- Stress that `Store()` is an Upsert
* Fire up the web app, go to Swagger. Submit an issue or two. Then use the GET methods


## Why a Document Db?

* Go enhance the Issue object and rerun
* Test automation -- show the CLEAN functionality

## Transactions

* Play up ACID again
* Show Unit of Work unit test
* Describe how updates are batched

## Querying Documents

* Compiled Query 
* Add a computed index to Issue
* Full text search demo

## Migrations Happen

* Marten v4!!!
* Go to command line
* 

## Other Features
