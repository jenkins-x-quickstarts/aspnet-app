FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS builder

COPY . .

WORKDIR /src

RUN dotnet restore

RUN dotnet publish aspnetapp/aspnetapp.csproj -c Release -o /app

RUN dotnet test --logger "trx;LogFileName=./aspnetapp.trx"

FROM mcr.microsoft.com/dotnet/aspnet:3.1-alpine

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "aspnetapp.dll"]
