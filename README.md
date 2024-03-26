# Command API

An api to manage command tools for your IT projects. This project is based on the youtube series / book "Complete ASP.NET Core API Tutorial 3rd Edition (Net Core 3.1)" by Les Jackson:
https://github.com/binarythistle/Complete-ASP.NET-Core-API-Tutorial-3rd-Edition-Net-Core-3.1

## Getting Started

To run the project you need to follow the instructions below.
Activate the version `3.1.426` in the global.json file.

Restore, build and run the app:

```bash
dotnet restore
dotnet build
dotnet run
```

Get access to the API you need to use the Swagger UI to test your endpoints:

```
https://localhost:5001/swagger/index.html
```

If you want to use a database locally you need to run a postgresql database in a docker container:

```bash
docker run --rm -P -p 127.0.0.1:5432:5432 -e POSTGRES_USER="sa" -e POSTGRES_PASSWORD="1234" -e POSTGRES_DB="CmdAPI" --name pg postgres:alpine
```

Create secrets locally:

```
cd src/CommandAPI
dotnet user-secrets init
dotnet user-secrets set UserID sa
dotnet user-secrets set Password 1234
```

And add to your `appsettings.json` file:

```json
{
  "USE_DATABASE": "true",
}
```

## Running the tests

Here are the instructions to run the tests:

```bash
dotnet test
```

## Use AZD to connect to Dev Center

Official documentation:

https://learn.microsoft.com/en-us/azure/developer/azure-developer-cli/ade-integration

Choisir l'env:

```bash
azd env select <env>
```

```bash
azd config set platform.type devcenter
```

```bash
azd up
```

Disable conection with Dev Center:

```bash
azd config unset platform
```

In the environment folder:

config.json:

```json
{
  "platform": {
    "config": {
      "catalog": "dcc",
      "environmentDefinition": "WebApp",
      "environmentType": "Dev",
      "name": "dc-devbox",
      "project": "developers",
      "user": "me"
    }
  },
  "provision": {
    "parameters": {
      "name": "cmd"
    }
  }
}
```

.env file:

```sh
AZD_PIPELINE_PROVIDER="github"
AZURE_ENV_NAME="dev"
AZURE_LOCATION="westeurope"
AZURE_RESOURCE_GROUP="developers-dev"
AZURE_SUBSCRIPTION_ID=""
```

## GitHub Actions

```bash
az ad sp create-for-rbac -n <spn-name>
```

Add Contributor roles to the SPN at the subscription level.

Save into the secrets AZURE_CREDENTIALS:

{
    "clientId": "",
    "clientSecret": "",
    "tenantId": "",
    "subscriptionId": ""
}

## Deploy to web app

dotnet publish -c Release -o outputs

cd outputs && zip -r publish.zip  .

Deploy using App Service extension.
