# Oppdatere meldingsversjon
Ved nye meldingsversjoner skal `KppParser` oppdaters til å kunne ta i mot den nye meldingsversjonen.
Dette dokumentet inneholder en oppskrift for hvordan man oppdaterer KppParser med ny `meldingsversjonsnummer`.

Det er viktig å vite at `meldingsversjonsnummeret` er noe annet enn `KppParse` sitt versjonsnummer.

Mer informasjon om meldingsversjon finner du [her](https://www.fhi.no/he/npr/registrering-og-rapportering/informasjonsmodell-og-meldinger/).

## 1. Oppdatere XSD-filer
1.1. Oppdatere XSD-filer i Resources-mappen til Dhhr.KppParser.Service

   Filstien til mappen:
   ```
   .src\Dhhr.KppParser.Service\Resources
   ```
   Filer som skal fjernes:
   - NPR.xsd
   - NPR(kpp).xsd
   - NPR(kpp)_CodingSchemes.xsd
  
   Filer som skal legges til, og som kan hentes fra [Sarepta](https://git.sarepta.ehelse.no/utvikling/xpr/-/tree/master?ref_type=heads) på `branch` med `riktig meldingsversjonsnummer`:
   - NPR.xsd
   - XPR(kpp).xsd
   - XPR(kpp)_CodingSchemes.xsd
  
  1.2. Endre filnavnet til `XPR(kpp).xsd` til `NPR(kpp).xsd`

## 2. Maunell oppatering av meldingsversjonsnummeret i koden
  2.1. Oppdatér `meldingsversjonsnummeret` angitt i `Namespace` for `XmlElement`-attributtet i 
   ```
  .\Dhhr.KppParser.Service\Models\RefDocContent.cs`
   ```
  2.2 Oppdatere `meldingsversjonsnummeret` angitt i `versjon` og `xmlns` for `Melding`-attributtet i 
  ```
  .\Dhhr.KppParser.Service.Tests\Resources\Expectations\TestMelding.xml`
  ```
## 3. Skript for oppdatering av meldingsversjonsnummeret i koden
  3.1. Kjør denne kommandoen på filstien `".\src"`. Viktig å bruke denne filstien for at kommandoen skal finne riktig filsti og oppdatere alle klassene i `Dhhr.KppParser.Service` med riktig referering til `meldingsversjonsnummer`:
   ```
   cd .\Dhhr.KppParser.Service; C:\"Program Files (x86)"\"Microsoft SDKs"\Windows\v10.0A\bin\"NETFX 4.8 Tools"\xsd.exe Resources\"NPR(kpp).xsd" /c /n:Dhhr.KppParser.Service.Models /o:Models
   ```
   Dokumentasjon finnes [hos Microsoft](https://learn.microsoft.com/en-us/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe).
   
   3.2 Søk etter om alle `meldingsversjonsnummer` i koden er oppdatert, ved å søke på det gamle versjonsnummeret.
   
   Hvis ikke alle `meldingsversjonsnummer` er oppdatert: Korrigere manuelt der ikke har blitt oppdatert og dokumenter i [Manuell oppdatering av meldingsversjonsnummeret i koden](https://github.com/folkehelseinstituttet/KppParser/edit/feature/docs-updatemessageversion-detailed-v2/docs/docs/UpdatingMessageVersion.md#2-maunell-oppatering-av-meldingsversjonsnummeret-i-koden).

## 5. Publiser ny versjon
   5.1 Gjør det som er beskrevet i [Publiser ny versjon](https://github.com/folkehelseinstituttet/KppParser/edit/feature/docs-updatemessageversion-detailed-v2/readme.md#publisere-ny-versjon) i Readme.md
   
  
