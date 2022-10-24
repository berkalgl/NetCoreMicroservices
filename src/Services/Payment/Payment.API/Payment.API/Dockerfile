#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Payment/Payment.API/Payment.API/Payment.API.csproj", "Services/Payment/Payment.API/Payment.API/"]
COPY ["Messages/MessagesAndEvents.csproj", "Messages/"]
RUN dotnet restore "Services/Payment/Payment.API/Payment.API/Payment.API.csproj"
COPY . .
WORKDIR "/src/Services/Payment/Payment.API/Payment.API"
RUN dotnet build "Payment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.API.dll"]