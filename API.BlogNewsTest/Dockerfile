# Estágio de construção do projeto de teste
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-test
WORKDIR /src
COPY ["API.BlogNewsTest/API.BlogNewsTest.csproj", "API.BlogNewsTest/"]
COPY ["API.BlogNews/API.BlogNews.csproj", "API.BlogNews/"]
COPY ["Database.BlogNews/Database.BlogNews.csproj", "Database.BlogNews/"]
RUN dotnet restore "API.BlogNewsTest/API.BlogNewsTest.csproj"
COPY . .
WORKDIR "/src/API.BlogNewsTest"
RUN dotnet build "API.BlogNewsTest.csproj" -c Release -o /app/build

# Estágio para executar os testes
FROM build-test AS test
WORKDIR "/src/API.BlogNewsTest"
RUN  dotnet test --configuration Release --no-restore

# Estágio de publicação
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS publish
WORKDIR /src
COPY --from=build-test /app/publish .
ENTRYPOINT ["dotnet", "API.BlogNewsTest.dll"]