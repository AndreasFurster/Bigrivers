## Bigrivers

Todo's in **[Trello](https://trello.com/b/oHRXtkre/big-rivers "Bigrivers Trello Board")**

Webservice **[OData Url Conventions](http://docs.oasis-open.org/odata/odata/v4.0/errata02/os/complete/part2-url-conventions/odata-v4.0-errata02-os-part2-url-conventions-complete.html#_Toc406398071)**

Sourcetree instellen voor eerste gebruik
==================================================
Scenario: ik ben een nieuwe ontwikkelaar in het team, en wil gaan bijdragen aan Bigrivers.

Ik heb VS2013 en Sourcetree en een github account.

Ik kan in Sourcetree een bestaande repo klonen door te verbinden met https://github.com/andreasfurster/bigrivers

<<<<<<< HEAD
nu maakt sourcetree verbinding met de master branch
=======
Nu maakt sourcetree verbinding met de master branch
>>>>>>> master

Klik daarna op de knop GitFlow.
de standaard invulling is prima.
production branch = master
development branch = devel

branch prefix =  
...feature/  
...release/  
...hotfix/  

Nu zie je in sourcetree twee branches: develop en master

Ik wil de laatste develop versie binnenhalen
==================================================
- klik op develop branch
- klik op pull
- pull from remote origin, pull branch develop
- volg nu de stappen in readme.md om database te recreeren


Steps to recreate development environment from Github

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


Ik wil een feature gaan toevoegen aan de bestaande code
=======================================================
open sourcetree
klik gitflow 
start new feature (voor als je een nieuwe functie maakt)
start hotfix (als je een productieversie gaat repareren = spoed)
start release (als je een develop versie wilt releasen naar klant)
geef de feature een beschrijvende naam van ongeveer 30 karakters, bijvoorbeeld: naam = "add new test to console client"
- er is nu een nieuwe map verschenen onder "features"

- maak de feature in VS2013
- TEST OF ALLES GOED WERKT
- LAAT EEN COLLEGA TESTEN
- sla alles op en sluit VS2013
- commit de changes
- push changes to feature/....  (Zet develop en master uit)
- klik gitflow en kies "finish feature". 
- push naar develop
