FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
EXPOSE 8080

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy all the layers' csproj files into respective folders
COPY ["./src/Application/Application.csproj", "/src/Application/"]
COPY ["./src/Domain/Domain.csproj", "/src/Domain/"]
COPY ["./src/Infrastructure/Infrastructure.csproj", "/src/Infrastructure/"]
COPY ["./src/Web/Web.csproj", "/src/Web/"]
COPY . .

# run restore over API project - this pulls restore over the dependent projects as well
RUN dotnet restore "/src/Web/Web.csproj"



# run build over the API project
WORKDIR "/src/src/Web/"
RUN dotnet build -c Release -o /app/build

# run publish over the API project
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS runtime
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "GameSystem.Web.dll", "--server.urls", "http://+:8080" ]