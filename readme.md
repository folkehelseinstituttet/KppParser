# Program for konvertering av KPP-filer
Programmet konverterer 2x csv-filer til en xml-melding som skal sendes til Helsedirektoratet.

Det er to måter å kjøre programmet:
- Bruke det grafiske grensesnittet
- Kjøre konsoll-appen

# Publisere ny versjon

## Før release

1. Oppdatér meldingsversjonen og KppParser-versjonen (se [veiledning](docs/UpdatingMessageVersion.md))
2. Påse at koden er committet og pushet til GitHub

## Bygge koden

1. Både Gui og ConsoleApp publiseres med
```
dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true
```
2. Legg deretter output fra begge i hver sin `.zip`-fil. Bruk gjerne samme filnavn som i forrige release


## Publisere på GitHub

1. Opprett ny release på github
2. Oppgi tittel basert på hva som er forandret
4. Sett tag til et fornuftig versjonsnummer (bruk samme versjonsnummer som i .csproj)
5. Fyll inn release-notes. Kopier gjerne fra forrige versjon, men oppdater "Nytt i denne utgaven"
6. Last opp de to binærfilene (se over)
