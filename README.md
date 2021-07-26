# Car Dealership

## Setup

Run setup.ps1.

## Running 

Start via Visual studio or via dotnet run.  

The application is hosted at localhost:5050.  It uses kestrel and spins up the reactjs application during startup and takes advantage of modern .NET core features in hosting a SPA.

The npm start task runs separately and takes a little while to startup.

## Troubleshooting

Make sure you have all of the requirements met before starting the app.

- SQL Server
- NodeJS
- dotnet core runtime/sdk of at least 3.1.

The `setup.ps1` and `WebApiSampleReact.Data.Migrater/setupDb.ps1` scripts have the commands that are run to setup the application.

