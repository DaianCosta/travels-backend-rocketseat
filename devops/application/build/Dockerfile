FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build

WORKDIR /app

COPY . .

RUN dotnet restore && dotnet build

WORKDIR /app/Api

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as runtime

WORKDIR /app

COPY --from=build /app/Api/out ./

CMD ["dotnet", "Api.dll"]

EXPOSE 80