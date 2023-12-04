FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Hosts/BankAPI.Hosts.Migrator/BankAPI.Hosts.Migrator.csproj", "src/Hosts/BankAPI.Hosts.Migrator/"]
RUN dotnet restore "src/Hosts/BankAPI.Hosts.Migrator/BankAPI.Hosts.Migrator.csproj"
COPY . .
WORKDIR "/src/src/Hosts/BankAPI.Hosts.Migrator"
RUN dotnet build "BankAPI.Hosts.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAPI.Hosts.Migrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAPI.Hosts.Migrator.dll"]
