FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 50136
EXPOSE 44349

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY PropertyManagement/PropertyManagement.csproj PropertyManagement/
RUN dotnet restore PropertyManagement/PropertyManagement.csproj
COPY . .
WORKDIR /src/PropertyManagement
RUN dotnet build PropertyManagement.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish PropertyManagement.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PropertyManagement.dll"]
