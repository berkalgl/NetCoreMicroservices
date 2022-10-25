#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Shipment/Shipment.API/Shipment.API/Shipment.API.csproj", "Services/Shipment/Shipment.API/Shipment.API/"]
COPY ["Messages/MessagesAndEvents.csproj", "Messages/"]
RUN dotnet restore "Services/Shipment/Shipment.API/Shipment.API/Shipment.API.csproj"
COPY . .
WORKDIR "/src/Services/Shipment/Shipment.API/Shipment.API"
RUN dotnet build "Shipment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shipment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shipment.API.dll"]