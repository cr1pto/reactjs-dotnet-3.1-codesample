

Write-Output "You need SQL Server installed (a newer version please); at least Node 10.17.0; and dotnet core 3.1 runtime at least."

$cwd = get-location

set-location $cwd\WebApiSampleReact.Data.Migrater

.\setupDb.ps1

set-location $cwd

dotnet restore
dotnet build
dotnet test

set-location $cwd\WebApiSampleReact\ClientApp
npm install
npm test

Write-Output "You're ready to go."