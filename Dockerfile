FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS buildstage
WORKDIR /src
COPY ["Acedrive.Client/Acedrive.Client.csproj", "Acedrive.Client/"]
RUN dotnet restore "Acedrive.Client/Acedrive.Client.csproj"
COPY . .
WORKDIR /src/Acedrive.Client
RUN dotnet build "Acedrive.Client.csproj"

FROM buildstage AS publishstage
RUN dotnet publish "Acedrive.Client.csproj" --no-restore -c Release -o /app

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /deploy
COPY --from=publishstage /app .
CMD ["dotnet", "Acedrive.Client.dll"]