#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Order/eshop.Order/eshop.Order.csproj", "src/Services/Order/eshop.Order/"]
COPY ["src/Common/eshop.MessageBus/eshop.MessageBus.csproj", "src/Common/eshop.MessageBus/"]
RUN dotnet restore "./src/Services/Order/eshop.Order/eshop.Order.csproj"
COPY . .
WORKDIR "/src/src/Services/Order/eshop.Order"
RUN dotnet build "./eshop.Order.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./eshop.Order.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eshop.Order.dll"]