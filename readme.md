# Program for konvertering av KPP-filer
Programmet konverterer én csv-fil om episoder og én csv-fil om tjeneste til én xml-melding som skal sendes til Folkehelseinstituttet

Det er to måter å kjøre programmet:
- Bruke det grafiske grensesnittet (Gui)
- Kjøre konsoll-appen (ConsoleApp)


# Publisere ny versjon

## Lage programmene Gui og ConsoleApp
Både Gui og ConsoleApp lages med denne kommandoen
```
cd .\Dhhr.KppParser.ConsoleApp; dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true; cd ..\Dhhr.KppParser.Gui; dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true
```
_Denne kommandoen finner riktig filstier og lager programmene_

Programmene får disse filstiene:
```
".\Dhhr.KppParser.ConsoleApp\bin\Release\net6.0\win-x64\Dhhr.KppParser.ConsoleApp.exe"
```
```
".\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\Dhhr.KppParser.Gui.exe"
```

## Teste programmene
Test csv-filer for episode og tjeneste finnes i mappen:
```
".\Dhhr.KppParser.Service.Tests\Resources\TestData"
```

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
2. Oppdatere dokumentasjonen (readme.md og mappen docs) hvis det oppdages feil i dokumetasjonen og/eller hvis det er viktige opplysninger som bør noteres ned.
3. Lage en pull request for å merge koden til main i Github
   

## Publisere på github
Etter at pull requesten er godkjent og merget til main:
1. Opprett ny release på github
2. Oppgi tittel basert på hva som er forandret
4. Sett tag et fornuftig versjonsnummer (bruk samme versjonsnummer som i .csproj)
5. Fyll inn release-notes. Kopier gjerne fra forrige versjon, men oppdater "Nytt i denne utgaven"
6. Lag 2 zip-filer av innholdet i disse mappene:
```
".\Dhhr.KppParser.ConsoleApp\bin\Release\net6.0\win-x64\publish"
```
```
".\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\publish"
```
  _Disse mappene ble generert når programmene ble laget (se over, Lage programmene Gui og ConsoleApp)_
  
  7. Gi zip-filene henholdsvis disse navnene "KppParser-ConsoleApp.zip" og "KppParser-Gui.zip"
  
