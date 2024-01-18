# Command API

An api to manage command tools for your IT projects. This project is based on the youtube series / book "Complete ASP.NET Core API Tutorial 3rd Edition (Net Core 3.1)" by Les Jackson:
https://github.com/binarythistle/Complete-ASP.NET-Core-API-Tutorial-3rd-Edition-Net-Core-3.1

Choose the version `3.1.426` in the global.json file.

Run a postgresql database in a docker container:
```
docker run --rm -P -p 127.0.0.1:5432:5432 -e POSTGRES_USER="sa" -e POSTGRES_PASSWORD="1234" -e POSTGRES_DB="CmdAPI" --name pg postgres:alpine
```

Create secrets locally:

```
dotnet user-secrets init
dotnet user-secrets set UserID sa
dotnet user-secrets set Password 1234
```

Run the application:

```
cd src/CommandAPI
dotnet restore
dotnet build
dotnet run
```

Get access to Swagger API:

```
https://localhost:5001/swagger/index.html
```

Si vous vendez moins de 50 produits :

Taxes : 10% de 2 euros * 50 = 10 euros
Frais d’exploitation : 15 euros
Marge nette : (2 euros * 50) - (1 euro * 50) - 10 euros - 15 euros = 25 euros
Si vous vendez plus de 50 produits :

Taxes : 2% de 2 euros * 100 = 4 euros
Frais d’exploitation : 5 euros
Marge nette : (2 euros * 100) - (1 euro * 100) - 4 euros - 5 euros = 91 euros