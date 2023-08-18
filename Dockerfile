FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS builder

COPY . .

WORKDIR /src

RUN dotnet restore

RUN dotnet publish aspnetapp/aspnetapp.csproj -c Release -o /app

RUN dotnet test --logger "trx;LogFileName=./aspnetapp.trx"

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

COPY --from=builder /app .

ENTRYPOINT ["dotnet", "aspnetapp.dll"]
