#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["StudentRegisterApi.csproj", ""]
RUN dotnet restore "./StudentRegisterApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "StudentRegisterApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentRegisterApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MONGO_USERNAME=admin
ENV MONGO_PASSWORD=P@ssw0rd
ENTRYPOINT ["dotnet", "StudentRegisterApi.dll"]