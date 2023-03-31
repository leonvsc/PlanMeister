# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the csproj files
COPY *.csproj ./

# Install the packages
RUN dotnet restore

# Copy the project files into the container
COPY . .

# Build the application
RUN dotnet publish -c Debug -o out

# Use the official .NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Copy the published application into the container
COPY --from=build /app/out .

# Expose port 80 to the outside world
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "PlanMeisterApi.dll"]
