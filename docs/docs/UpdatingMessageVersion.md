# Oppdatere meldingsversjon
Ved nye meldingsversjoner skal KppParser oppdaters til å kunne ta i mot den nye meldingsversjonen.
Dette dokumentet inneholder en oppskrift for hvordan man oppdaterer KppParser med ny meldingsversjonsnummer.
Informasjon om meldingsversjon finner du [her](https://www.fhi.no/he/npr/registrering-og-rapportering/informasjonsmodell-og-meldinger/)

## 1. Oppdatere XSD-filer
1.1. Oppdatere XSD-filer i Resource-mappen til Dhhr.KppParser.Service

   Filstien til mappen:
   ```
   .src\Dhhr.KppParser.Service\Resources
   ```
   Filer som skal fjernes:
   - NPR.xsd
   - NPR(kpp).xsd
   - NPR(kpp)_CodingSchemes.xsd
  
   Filer som skal legges til, hentes fra [Sarepta](https://git.sarepta.ehelse.no/utvikling/xpr/-/tree/master?ref_type=heads) på _branch med riktig meldingsversjonsnummer_:
   - NPR.xsd
   - XPR(kpp).xsd
   - XPR(kpp)_CodingSchemes.xsd
  
  1.2. Endre filnavnet til XPR(kpp).xsd til NPR(kpp).xsd
  1.3. Endre filnavnet til XPR(kpp)_CodingSchemes.xsd til NPR(kpp)_CodingSchemes.xsd
  1.4. Sørg for at alle schemaLocation-attributter i de tre NPR*.xsd-filene refererer til NPR, ikke XPR

## 2. Oppdatere koden
  2.1. Oppdatér meldingsversjonsnummeret angitt i `Namespace` for `XmlElement`-attributtet i 
   ```
  .\Dhhr.KppParser.Service\Models\RefDocContent.cs`
   ```
  2.2 Oppdatere meldingsversjonsnummeret angitt i `versjon` og `lokalident` for `Melding`-attributtet i 
  ```
  .\Dhhr.KppParser.Service.Tests\Resources\Expectations\TestMelding.xml`
  ```
     
  2.3. Kjør denne kommandoen for å finne riktig filsti og oppdatere alle klassene i Dhhr.KppParser.Service med riktig meldingsversjonsnummer:
   ```
   cd .\Dhhr.KppParser.Service; C:\"Program Files (x86)"\"Microsoft SDKs"\Windows\v10.0A\bin\"NETFX 4.8 Tools"\xsd.exe Resources\"NPR(kpp).xsd" /c /n:Dhhr.KppParser.Service.Models /o:Models
   ```

## 3. Publiser ny versjon
   3.1 Gjør det som er beskrevet i [Publiser ny versjon](https://github.com/folkehelseinstituttet/KppParser/edit/feature/docs-updatemessageversion-detailed-v2/readme.md#publisere-ny-versjon) i Readme.md
  
