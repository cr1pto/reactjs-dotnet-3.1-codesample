## add ef tools
dotnet tool install --global dotnet-ef

## Running migrations
dotnet-ef database update -c CarDealershipContext
dotnet build 
start dotnet run