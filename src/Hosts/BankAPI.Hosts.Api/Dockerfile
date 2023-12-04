FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Hosts/BankAPI.Hosts.Api/BankAPI.Hosts.Api.csproj", "src/Hosts/BankAPI.Hosts.Api/"]
RUN dotnet restore "src/Hosts/BankAPI.Hosts.Api/BankAPI.Hosts.Api.csproj"
COPY . .
WORKDIR "/src/src/Hosts/BankAPI.Hosts.Api"
RUN dotnet build "BankAPI.Hosts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAPI.Hosts.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAPI.Hosts.Api.dll"]
