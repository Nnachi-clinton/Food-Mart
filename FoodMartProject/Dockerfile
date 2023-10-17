#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FoodMartProject/FoodMartApi.csproj", "FoodMartProject/"]
COPY ["FoodMartCore/FoodMartCore.csproj", "FoodMartCore/"]
COPY ["FoodMartCommons/FoodMartCommons.csproj", "FoodMartCommons/"]
COPY ["FoodMartModel/FoodMartDomain.csproj", "FoodMartModel/"]
COPY ["FoodMartData/FoodMartInfrastructure.csproj", "FoodMartData/"]
RUN dotnet restore "FoodMartProject/FoodMartApi.csproj"
COPY . .
WORKDIR "/src/FoodMartProject"
RUN dotnet build "FoodMartApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodMartApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet FoodMartApi.dll
ENTRYPOINT ["dotnet", "FoodMartApi.dll"]