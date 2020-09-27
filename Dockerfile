#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["pnl.csproj", "./"]
RUN dotnet restore "pnl.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "pnl.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "pnl.csproj" -c Release -o /app/publish

FROM microsoft/mssql-tools:latest

WORKDIR /temp//path

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#EXPOSE 5000/tcp

EXPOSE 5000 50001

#ENV ASPNETCORE_URLS http://*:5000

#ENV ASPNETCORE_URLS  https://+:5001;http://+:5000
#ENV ASPNETCORE_HTTPS_PORT 5001
#ENV ASPNETCORE_ENVIRONMENT Development


ENTRYPOINT ["dotnet", "pnl.dll"]
# CMD ASPNETCORE_URLS=http://*:$PORT 
# CMD CMD dotnet pnl.dll
