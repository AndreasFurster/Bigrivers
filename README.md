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
1. Weggooien eventuele bestaande code 
		als je nog een map met de 'bigrivers' solution hebt, gooi die dan weg.
		Ik had deze opgeslagen in (C:\Users\SNP\Documents\GitSources\Bigrivers)
		
2. Weggooien eventuele repository sourcetree 
		als je in sourcetree al een repository hebt naar https://.......@github.com/AndreasFurster/Bigrivers.git
		verwijder die dan (reden: sourcetree doet irritant wanneer je de projectmap hebt weggegooid)

3. Aanmaken (of opnieuw aanmaken) repository in sourcetree
		Clone de repository op https://........@github.com/AndreasFurster/Bigrivers.git 
	
4. Ophalen van de versie (16-feb-2015 14:47) uit github
		je krijgt in je \BigRivers\ map nu mapjes \.git  \docs \src, 
		in de map \src staan mapjes \BigRivers.Client  en  \BigRivers.Server 
		en BigRivers.sln en Bigrivers.v12.suo

5. Open solution in Visual Studio
		rechtsklik op solution en klik op "enable nuget package restore"
		
6. Open package manager console. Je krijgt een melding: 
  "some nuget packages are missing from this solution. Click to restore from your online package source".
	Klik op de knop "restore".
	
7. Voer in package manager console het volgende commando in:
	Update-Package -reinstall 
	Op een gegeven moment kan de update stoppen om te vragen of je bestaande files wilt overschrijven.
	Geef antwoord met A en <enter>
	
8. rechtsklik solution, set startup projects, kies multiple startup projects,
	enable "bigrivers.client.webapplication" en "bigrivers.server.webservice".
	
9. Rebuild solution
	
10. Run 
	http://localhost:3196/Home/Events toont een lijst met events
	http://localhost:54240/ geeft foutmelding

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
