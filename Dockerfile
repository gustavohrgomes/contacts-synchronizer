# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5053
EXPOSE 7198

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Contacts.props", "./"]
COPY ["Contacts.Synchronizer.WebApi/Contacts.Synchronizer.WebApi.csproj", "Contacts.Synchronizer.WebApi/"]
COPY ["Contacts.Synchronizer.Application/Contacts.Synchronizer.Application.csproj", "Contacts.Synchronizer.Application/"]
COPY ["Contacts.Synchronizer.Contracts/Contacts.Synchronizer.Contracts.csproj", "Contacts.Synchronizer.Contracts/"]
COPY ["Contacts.Synchronizer.Domain/Contacts.Synchronizer.Domain.csproj", "Contacts.Synchronizer.Domain/"]
COPY ["Contacts.Synchronizer.Infrastructure.MailchimAdapters/Contacts.Synchronizer.Infrastructure.MailchimpAdapters.csproj", "Contacts.Synchronizer.Infrastructure.MailchimAdapters/"]
COPY ["Contacts.Synchronizer.ServiceDefaults/Contacts.Synchronizer.ServiceDefaults.csproj", "Contacts.Synchronizer.ServiceDefaults/"]
RUN dotnet restore "./Contacts.Synchronizer.WebApi/Contacts.Synchronizer.WebApi.csproj"
COPY . .
WORKDIR "/src/Contacts.Synchronizer.WebApi"
RUN dotnet build "./Contacts.Synchronizer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Contacts.Synchronizer.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contacts.Synchronizer.WebApi.dll"]