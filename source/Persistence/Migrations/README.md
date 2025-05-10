**To perform the creation of a migration and the subsequent migration, you need to navigate to the ./source/ directory.**

Create migration:
``
dotnet ef migrations add InitialCreate -p ./Persistence/ -s ./Application/ -o ./Migrations/Stages/
``