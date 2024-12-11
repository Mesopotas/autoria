FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /apicine

COPY back-1-trimestre-2-daw.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /apicine/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /apicine
EXPOSE 8080

COPY --from=build /apicine/publish .

ENTRYPOINT ["dotnet", "back-1-trimestre-2-daw.dll"]