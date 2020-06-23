# Initializes a new build stage and sets the Base Images for subsequent instructions
# As such, a valid Dockerfile must start with a FROM instruction. The image can be any valid image.
# it is especially easy to start by pulling an image from the Public Repositories.
# Define your apps environment

# .Net Core Runtime and .Ner Core SDK

#FROM microsoft/dotnet:3.1-aspnetcore-runtime AS base 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base 
#FROM microsoft/dotnet:sdk AS build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# Copy csproj and restore as distinct layers

WORKDIR /src
COPY . ./
RUN dotnet restore "Training.Presentation.API/Training.Presentation.API.csproj"

# Build Solution

WORKDIR "/src/Training.Presentation.API"
RUN dotnet build "Training.Presentation.API.csproj" -c Release -o /app

# Publish Solution

FROM build AS publish
WORKDIR "/src/Training.Presentation.API"
RUN dotnet publish "Training.Presentation.API.csproj" -c Release -o /app

# Copy everything else and build

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 80
ENTRYPOINT ["dotnet" , "Training.Presentation.API.dll"]