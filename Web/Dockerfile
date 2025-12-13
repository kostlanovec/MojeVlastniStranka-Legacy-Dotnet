FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["Web/MojeVlastniStranka.Web.csproj", "Web/"]
COPY ["ApplicationCore/MojeVlastniStranka.ApplicationCore.csproj", "ApplicationCore/"]
COPY ["Common/MojeVlastniStranka.Common.csproj", "Common/"]
COPY ["DataAccess/MojeVlastniStranka.DataAccess.csproj", "DataAccess/"]

RUN dotnet restore "./Web/MojeVlastniStranka.Web.csproj"

COPY . .
WORKDIR "/src/Web"

RUN dotnet publish "./MojeVlastniStranka.Web.csproj" \
    -c $BUILD_CONFIGURATION \
    -o /app/publish \
    --no-restore \
    /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MojeVlastniStranka.Web.dll"]