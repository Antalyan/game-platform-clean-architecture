# GameSystem

The project was generated using the [Clean.Architecture.Solution.Template](https://github.com/jasontaylordev/GameSystem) version 8.0.2.

## Build

Run `dotnet build -tl` to build the solution.

## Run

To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```
To run this app in docker, you must go to GameSystem folder and follow these steps

```bash
 docker compose up GS-DB -d
 dotnet ef database update --project src\Infrastructure --startup-project src\Web  
 docker compose up WebApi
```
This will run web app on port 80 accessible through http protocol

Navigate to [localhost](https://localhost:5001). The application will automatically reload if you change any of the source files.

## Test

The solution contains simple tests using k6 testing.
Go to [k6 testing page](https://k6.io/docs/get-started/installation/) to install the testing suite.

To run the tests:
```bash
cd .\tests
k6 run TestName
```

## Authentication during testing

1. Go to API web page and send a request to Users/login endpoint with email and password. 
    You can either create a new one using Users/register endpoint or use a preseeded user.
2. Copy obtained token and click on Authorize in the upper right corner 
3. Fill in the token field:
```
Bearer <TokenString>
```
4. You should be authenticated now with access to endpoints. From time to time, the token must be refreshed.

## Entity Framework
To create a migration (creates a snapshot of db schema changes made in code):
```bash
dotnet ef migrations add MigrationName --project src\Infrastructure --startup-project src\Web
```

To apply pending changes from migrations (applies all db schema changes to db)
```bash
dotnet ef database update --project src\Infrastructure --startup-project src\Web  
```

## Code Scaffolding

The original template includes support to scaffold new commands and queries.

Start in the `.\src\Application\` folder.

Create a new command:

```
dotnet new ca-usecase --name CreateTodoList --feature-name TodoLists --usecase-type command --return-type int
```

Create a new query:

```
dotnet new ca-usecase -n GetTodos -fn TodoLists -ut query -rt TodosVm
```

If you encounter the error *"No templates or subcommands found matching: 'ca-usecase'."*, install the template and try again:

```bash
dotnet new install Clean.Architecture.Solution.Template::8.0.2
```
