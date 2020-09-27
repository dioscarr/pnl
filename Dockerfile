#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM golang:alpine as cert

RUN apk update \
    && apk add git openssl nss-tools \
    && rm -rf /var/cache/apk*

RUN cd /go && \
    go get -u github.com/FiloScottle/mkvert && \
    cd src/github.com/FileScottile/mkcert && \
    go build -o /bin/mkcert

WORKDIR /root/.local/share/mkcert/

COPY rootCA*.pem /root/.local/share/mkcert/

RUN mkcert -install \
    && mkcert -key-file https-web.key -cert-file https-web.pem 157.245.244.37 localhost 127.0.0.1 web \
    && openssl pkcs12 -export -out https-web.pfx -inkey https-web.key -in https-web.pem rootCA.pem -passout pass:https-web


FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["pnl.csproj", "./"]
RUN dotnet restore "pnl.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "pnl.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "pnl.csproj" -c Debug -o /app/publish

FROM microsoft/mssql-tools:latest

WORKDIR /temp//path

COPY --from=cert /bin/mkcert /bin/mkcert

COPY --from=cert /root/.local/share/mkcert/rootCA.pem /root/.local/share/mkcert/rootCA.pem

ENV kestrel_Certificate_Default_Path=/app/https-web.pfx
ENV Kestrel_Certificates_Default_Password=https-web

RUN apk update \
    && apk add nss-tools \ 
    && rm -ef /var/cache/apk* \
    && mkcert -install \
    && apk del nss-tools \
    && rm -ef /bin/mkcert

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#EXPOSE 5000/tcp

EXPOSE 80
EXPOSE 443

#ENV ASPNETCORE_URLS http://*:5000

COPY --from=build /root/.dotnet/corefx/cryptography /root/.dotnet/corefx/cryptography

ENV ASPNETCORE_URLS = "https://+443;http://+80"
ENV ASPNETCORE_HTTPS_PORT 443
ENV ASPNETCORE_ENVIRONMENT Docker


ENTRYPOINT ["dotnet", "pnl.dll"]
# CMD ASPNETCORE_URLS=http://*:$PORT 
# CMD CMD dotnet pnl.dll
