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

Legg deretter output fra begge i hver sin `.zip`-fil. Bruk gjerne samme filnavn som i forrige release


## Publisere på github
1. Opprett ny release på github
2. Oppgi tittel basert på hva som er forandret
4. Sett tag et fornuftig versjonsnummer (bruk samme versjonsnummer som i .csproj)
5. Fyll inn release-notes. Kopier gjerne fra forrige versjon, men oppdater "Nytt i denne utgaven"
6. Last opp de to binærfilene (se over)


#  Prosedyrer for standard endringer

## Oppdatere ny meldingsversjonsnummer
1. Oppdatere XSD-filer i Resource-mappen til Dhhr.KppParser.Service

   Filstien til mappen:
   ```
   ".src\Dhhr.KppParser.Service\Resources"
   ```
   Filer som skal fjernes:
   - NPR.xsd
   - NPR(kpp).xsd
   - NPR(kpp)_CodingSchemes.xsd
  
   Filer som skal legges til, hentes fra [Sarepta](https://git.sarepta.ehelse.no/utvikling/xpr/-/tree/master?ref_type=heads) på _branch med riktig meldingsversjonsnummer_:
   - NPR.xsd
   - XPR(kpp).xsd
   - XPR(kpp)_CodingSchemes.xsd
  
  3. Endre innholdet i filen XPR(kpp).xsd fra schemaLocation="XPR(kpp)_CodingSchemes.xsd" til schemaLocation="NPR(kpp)_CodingSchemes.xsd"
  4. Endre filnavnet til XPR(kpp).xsd til NPR(kpp).xsd
  5. Endre filnavnet til XPR(kpp)_CodingSchemes.xsd til NPR(kpp)_CodingSchemes.xsd
  6. oppdatere disse filene med riktig meldingsversjonsnummer:
     ```
     .\Dhhr.KppParser.Service.Tests\Resources\Expectations\TestMelding.xml
     ```
     ```
     .\Dhhr.KppParser.Service\Models\RefDocContent.cs![image](https://github.com/user-attachments/assets/1ed109ea-88c0-4a78-80e9-b935e46166f9)
     ```

  7. Kjør denne kommandoen for å finne riktig filsti og oppdatere alle klassene i Dhhr.KppParser.Service med riktig meldingsversjonsnummer:
     ```
     cd .\Dhhr.KppParser.Service; C:\"Program Files (x86)"\"Microsoft SDKs"\Windows\v10.0A\bin\"NETFX 4.8 Tools"\xsd.exe Resources\"NPR(kpp).xsd" /c /n:Dhhr.KppParser.Service.Models /o:Models
     ```
  
