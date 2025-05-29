# explore-note-csharp

```
$ dotnet build
$ dotnet ef migrations add init --startup-project ./ExploreNoteApi/ExploreNoteApi.csproj --project ./ExploreNoteApi.Database/ExploreNoteApi.Database.csproj
$ dotnet ef database update init --startup-project ./ExploreNoteApi/ExploreNoteApi.csproj --project ./ExploreNoteApi.Database/ExploreNoteApi.Database.csproj

docker run \
  --name mariadb-local \
  -e MARIADB_ROOT_PASSWORD=mysecretpassword \
  -e MARIADB_DATABASE=mydockerdb \
  -p 3306:3306 \
  -d mariadb:latest
```

swagger: https://localhost:5001/swagger/index.html
