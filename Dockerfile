FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "out/MojeVlastniStranka.Web.dll", "--urls", "http://0.0.0.0:80"]
