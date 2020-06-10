# Project Variables
PROJECT_NAME ?= GoodBooks



# Names that we will attach to sequences of commands. We will be able to run them by using these names, e.g 'make migrations'
.PHONY = migrations db



# Commands required to run a migration and then apply it to the DB
migrations:
	cd ./GoodBooks.Data && dotnet ef --startup-project ../GoodBooks.Api/ migrations add ${migrationName} && cd ..

db:
	cd ./GoodBooks.Data && dotnet ef --startup-project ../GoodBooks.Api/ database update && cd ..

app:
	dotnet build && dotnet run --project ./GoodBooks.Api/GoodBooks.Api.csproj

hello:
	echo 'Hello from Makefile!'
