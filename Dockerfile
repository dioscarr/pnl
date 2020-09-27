#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM golang:alpine3.10 as cert

RUN apk update \
    && apk add git openssl nss-tools \
    && rm -rf /var/cache/apk/*

RUN cd /go && \
    go get -u github.com/FiloSottile/mkcert && \
    cd src/github.com/FiloSottile/mkcert && \
    go build -o /bin/mkcert

WORKDIR /root/.local/share/mkcert
#copy from %localappdata%mkcert
COPY rootCA*.pem /root/.local/share/mkcert/

RUN mkcert -install \
    && mkcert -key-file https-web.key -cert-file https-web.pem 157.245.244.37 localhost 127.0.0.1 web \
    && openssl pkcs12 -export -out https-web.pfx -inkey https-web.key -in https-web.pem -certfile rootCA.pem -passout pass:https-web


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


COPY --from=cert /bin/mkcert /bin/mkcert

COPY --from=cert /root/.local/share/mkcert/rootCA.pem /root/.local/share/mkcert/rootCA.pem
COPY --from=cert /root/.local/share/mkcert/https-web.pfx /app/

ENV kestrel_Certificates__Default__Path=/app/https-web.pfx
ENV Kestrel_Certificates__Default__Password=https-web

FROM golang:alpine3.10 

#trust root cert
RUN apk update \
    && apk add nss-tools \ 
    && rm -rf /var/cache/apk/* \
    #&& mkcert -install \
    && apk del nss-tools \
    && rm -rf /bin/mkcert

#EXPOSE 5000/tcp

EXPOSE 5000 50001


#ENV ASPNETCORE_URLS http://*:5000

#ENV ASPNETCORE_URLS  https://+:5001;http://+:5000
#ENV ASPNETCORE_HTTPS_PORT 5001
#ENV ASPNETCORE_ENVIRONMENT Development


ENTRYPOINT ["dotnet", "pnl.dll"]
# CMD ASPNETCORE_URLS=http://*:$PORT 
# CMD CMD dotnet pnl.dll
