# Command API

An api to manage command tools for your IT projects. This project is based on the youtube series / book "Complete ASP.NET Core API Tutorial 3rd Edition (Net Core 3.1)" by Les Jackson:
https://github.com/binarythistle/Complete-ASP.NET-Core-API-Tutorial-3rd-Edition-Net-Core-3.1

## Getting Started

To run the project you need to follow the instructions below.
Activate the version `3.1.426` in the global.json file.

Run a postgresql database in a docker container:

```
docker run --rm -P -p 127.0.0.1:5432:5432 -e POSTGRES_USER="sa" -e POSTGRES_PASSWORD="1234" -e POSTGRES_DB="CmdAPI" --name pg postgres:alpine
```

Create secrets locally:

```
cd src/CommandAPI
dotnet user-secrets init
dotnet user-secrets set UserID sa
dotnet user-secrets set Password 1234
```

Restore, build and run the app:

```
dotnet restore
dotnet build
dotnet run
```

Get access to the API you need to use the Swagger UI to test your endpoints:

```
https://localhost:5001/swagger/index.html
```

## Running the tests

Here are the instructions to run the tests:

```
To define
```