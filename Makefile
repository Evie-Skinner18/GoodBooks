# Project Variables
PROJECT_NAME ?= GoodBooks



# Names that we will attach to sequences of commands. We will be able to run them by using these names, e.g 'make migrations'
.PHONY = migrations db api test client



# Commands for backend
migrations:
	cd ./backend/GoodBooks.Data && dotnet ef --startup-project ../GoodBooks.Api/ migrations add ${migrationName} && cd ..

db:
	cd ./backend/GoodBooks.Data && dotnet ef --startup-project ../GoodBooks.Api/ database update && cd ..

api:
	cd ./backend/ && dotnet build && dotnet run --project ./GoodBooks.Api/GoodBooks.Api.csproj

test:
	cd ./backend/ && dotnet test

hello:
	echo 'Hello from Makefile!'
	

# Commands for frontend
client:
	cd ./frontend/ && npm run serve
