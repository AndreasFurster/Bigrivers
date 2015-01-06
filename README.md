Bigrivers
=========

Todo's in Trello: https://trello.com/b/oHRXtkre/big-rivers



Steps to recreate development environment from github
======================================================
- pull develop branch from github  https://github.com/AndreasFurster/Bigrivers
- open solution file in visual studio 2013
- nuget should retrieve all missing packages
- rebuild
- error will show: missing newtonsoft.json reference
- open project Bigrivers.Client.ConsoleClient
- from reference, remove "Newtonsoft.Json"
- add reference, browse to, <solution root>\packages\Newtonsoft.Json.6.0.6\lib\net45
- rebuild should work now

- open package manager console
- change project to Bigrivers.Server.Data
- give command update-database
- error will show: No connection string named 'BigriversContext' could be found in the application config file.
- in solution explorer, rightclick project "Bigrivers.Server.Data" and select "set as startup project"
- give command update-database
- now database should be created
- set "Bigrivers.Server.Webservice" as startup project
- run