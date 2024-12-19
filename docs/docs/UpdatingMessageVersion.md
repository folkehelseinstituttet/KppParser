#  oppdatere meldingsversjon
## Oppdatere XSD-filer
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
  
  2. Endre filnavnet til XPR(kpp).xsd til NPR(kpp).xsd
  3. Endre filnavnet til XPR(kpp)_CodingSchemes.xsd til NPR(kpp)_CodingSchemes.xsd
  4. Sørg for at alle schemaLocation-attributter i de tre NPR*.xsd-filene refererer til NPR, ikke XPR

## Oppdatere KppParser sitt versjonsnummer
Versjonsnummeret til KppParser er uavhengig av meldingsversjonen, men skal justeres ved oppdatering av meldingsversjonen.
Les readme.md for hvordan KppParser sitt versjonsnummer oppdateres
  
## Oppdatere CS-modeller
  1. Oppdatere disse filene med riktig meldingsversjonsnummer:
     ```
     .\Dhhr.KppParser.Service.Tests\Resources\Expectations\TestMelding.xml
     ```
     ```
     .\Dhhr.KppParser.Service\Models\RefDocContent.cs![image](https://github.com/user-attachments/assets/1ed109ea-88c0-4a78-80e9-b935e46166f9)
     ```
  2. Kjør denne kommandoen for å finne riktig filsti og oppdatere alle klassene i Dhhr.KppParser.Service med riktig meldingsversjonsnummer:
     ```
     cd .\Dhhr.KppParser.Service; C:\"Program Files (x86)"\"Microsoft SDKs"\Windows\v10.0A\bin\"NETFX 4.8 Tools"\xsd.exe Resources\"NPR(kpp).xsd" /c /n:Dhhr.KppParser.Service.Models /o:Models
     ```
