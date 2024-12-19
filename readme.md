# Program for konvertering av KPP-filer
Programmet konverterer 2x csv-filer til en xml-melding som skal sendes til Folkehelseinstituttet

Det er to måter å kjøre programmet:
- Bruke det grafiske grensesnittet (Gui)
- Kjøre konsoll-appen (ConsoleApp)

# Publisere ny versjon
## Før release
1. Oppdater versjonsnummer i filene:
```
.\Dhhr.KppParser.ConsoleApp\Dhhr.KppParser.ConsoleApp.csproj
```
```
.\Dhhr.KppParser.Gui\Dhhr.KppParser.Gui.csproj
```
```
.\Dhhr.KppParser.Gui\appsettings.json
```

2. Påse at koden er commitet og pushet til github

## Bygge koden
1. Både Gui og ConsoleApp publiseres med denne kommandoen
```
cd .\Dhhr.KppParser.ConsoleApp; dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true; cd ..\Dhhr.KppParser.Gui; dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true
```
Denne kommandoen finner riktig filstier og lager applikasjonene

Applikasjonene får disse filstiene:
- ".\src\Dhhr.KppParser.ConsoleApp\bin\Release\net6.0\win-x64\Dhhr.KppParser.ConsoleApp.exe"
- ".\src\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\Dhhr.KppParser.Gui.exe"

[??]Legg deretter output fra begge i hver sin `.zip`-fil. Bruk gjerne samme filnavn som i forrige release


## Publisere på github
1. Opprett ny release på github
2. Oppgi tittel basert på hva som er forandret
4. Sett tag et fornuftig versjonsnummer (bruk samme versjonsnummer som i .csproj)
5. Fyll inn release-notes. Kopier gjerne fra forrige versjon, men oppdater "Nytt i denne utgaven"
6. Last opp de to binærfilene (se over)
  
