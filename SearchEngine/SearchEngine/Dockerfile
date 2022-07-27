FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build

WORKDIR /source
COPY . .
RUN dotnet restore "./Template.AspNetCoreWebApi/Template.AspNetCoreWebApi.csproj" --disable-parallel
RUN dotnet publish "./Template.AspNetCoreWebApi/Template.AspNetCoreWebApi.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "Template.AspNetCoreWebApi.dll"]