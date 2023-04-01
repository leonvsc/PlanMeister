# Use the official .NET Core SDK image as the base image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy the csproj files
COPY *.csproj .

# Install the packages
RUN dotnet restore

# Copy the project files into the container
COPY . .

# Build the application
RUN dotnet publish -c Release -o .

# Install the dotnet-ef tool
RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"

# Expose port 80 to the outside world
EXPOSE 80

# Add the migration script to the container
COPY ./run-migration.sh .
RUN chmod +x ./run-migration.sh

# Run migration script
CMD /bin/bash ./run-migration.sh

# Run the application
ENTRYPOINT ["dotnet", "PlanMeisterApi.dll"]
