FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
WORKDIR /app/out
ENTRYPOINT ["dotnet", "MojeVlastniStranka.Web.dll", "--urls", "http://0.0.0.0:80"]
