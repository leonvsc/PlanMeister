#!/bin/bash

if [ -z "$DB_Connection" ]
then
      echo "ERROR: The connection string is not set. Exiting."
      exit 1
else
      echo "Running database migration..."
      dotnet ef database update --project PlanMeisterApi.csproj --connection "$DB_Connection"
fi
