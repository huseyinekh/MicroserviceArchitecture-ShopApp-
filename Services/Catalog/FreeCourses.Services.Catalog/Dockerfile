#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Catalog/FreeCourses.Services.Catalog/FreeCourses.Services.Catalog.csproj", "Services/Catalog/FreeCourses.Services.Catalog/"]
COPY ["Shared/FreeCourse.Shared/FreeCourse.Shared.csproj", "Shared/FreeCourse.Shared/"]
RUN dotnet restore "Services/Catalog/FreeCourses.Services.Catalog/FreeCourses.Services.Catalog.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/FreeCourses.Services.Catalog"
RUN dotnet build "FreeCourses.Services.Catalog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FreeCourses.Services.Catalog.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FreeCourses.Services.Catalog.dll"]