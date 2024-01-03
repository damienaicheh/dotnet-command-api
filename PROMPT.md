I'm working on the migration of the CommandAPI from .NET Core App 3.1 API to a .NET 8. 
I need to run this new API inside a Docker container and deploy it using GitHub Actions.
I need to create a Terraform script to deploy the API to Azure App Service using .NET 8 without Docker.
I need to have unit tests using xunit for the code that I write.
I need you to act as my own code coach to ensure that my code fits all these requirements. 
When possible, please provide links and references for additional learning. 
Do you understand these instructions? 


guide me for the first step to migrate

How can I update my NuGet packages after migrating to .NET 8?

Tell me if all my packages are still useful

is it necessary to have Swashbuckle.AspNetCore install in .NET 8?

Give me the procedure to update my code to not use Swashbuckle.AspNetCore but the default swagger inside .NET 8

create an azurerm_linux_web_app with an azurerm_service_plan for dotnet 8


------------

az login --use-device-code

@workspace Give me the process on how to getting started and run this project #file README.md

I'm working on the migration of the CommandAPI from .NET Core App 3.1 API to a .NET 8. 
I need to create a GitHub Actions workflow to build the CI/CD of the CommandAPI project.
I need to create a Terraform script to deploy the API to Azure App Service using .NET 8 without Docker.
I need to have unit tests using xunit for the code that I write.
I need you to act as my own code coach to ensure that my code fits all these requirements. 
When possible, please provide links and references for additional learning. 
Do you understand these instructions? 

@workspace  the entrypoint is the #file CommandAPI.csproj

[CommandAPI.csproj] what is the first to start the migration of the .NET app ?

[CommandAPI.csproj] give me the version of the packages compatible with my net 8.0 project

[CommandAPI.csproj] give me the command to check the package available version

dotnet list package --outdated

<ItemGroup>
    <PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
    <PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.JsonPatch" Version="8.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
</ItemGroup>

j'ai fini de migré la partie dotnet passons à l'étape suivante

[ci-cd.yml] ok next, I need to do the next step

[ci-cd.yml] I need to use those 2 resources:
azurerm_service_plan : https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/service_plan with azurerm_linux_web_app:  https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/linux_web_app

//GET api/commands/random Return random commands   

        [HttpGet("random")]
        public ActionResult<CommandReadDto> GetRandomCommand()
        {
            var commandItems = _repository.GetAllCommands();
            var random = new System.Random();
            var randomCommand = commandItems.ElementAt(random.Next(commandItems.Count()));
            return Ok(_mapper.Map<CommandReadDto>(randomCommand));
        }

dotnet list package --outdated

<ItemGroup>
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1" />
<PackageReference Include="Microsoft.AspNetCore.JsonPatch" Version="8.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="8.0.0" />
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.8.0" />
<PackageReference Include="Moq" Version="4.20.70" />
<PackageReference Include="xunit" Version="2.6.4" />
<PackageReference Include="xunit.runner.visualstudio" Version="2.5.6" />
<PackageReference Include="coverlet.collector" Version="6.0.0" />
</ItemGroup>

   //**************************************************
    //*
    //GET   /api/commands/random Unit Tests
    //*
    //**************************************************

    //TEST Return 200OK with random command


    In the code : // if no commands are found return NotFound()