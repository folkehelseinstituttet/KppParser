<h1>Oppdatere meldingsversjon</h1>

[[_TOC_]]

## Oppdatere XSD-filer

1. Finn riktig versjonsnummer under [FHI &rarr; Informasjonsmodell og meldinger](https://www.fhi.no/he/npr/registrering-og-rapportering/informasjonsmodell-og-meldinger/)
2. Last ned og pakk ut _XPR \<versjonsnummer\> Skjema uten kodeverk.zip_
3. Kopiér innholdet i følgende nedlastede filer til korresponderende fil i `KppParser`:
   - `NPR.xsd` &rarr; `NPR.xsd`
   - `XPR(kpp).xsd` &rarr; `NPR(kpp).xsd`
   - `XPR(kpp)_CodingSchemes.xsd` &rarr; `NPR(kpp)_CodingSchemes.xsd`
4. Sørg for at alle `schemaLocation`-attributter i de tre `NPR*.xsd`-filene refererer til `NPR`, ikke `XPR`

## Oppdatere modeller

1. Oppdatér versjonen angitt i `Namespace` for `XmlElement`-attributtet i `RefDocContent.cs`
2. Regenerér `NPR(kpp).cs` ved å kjøre `xsd.exe` med `NPR(kpp).xsd`.\
Dette kan f.eks. gjøres ved å kjøre følgende kommando fra `Dhhr.KppParser.Service`:
```
<absolutt sti til xsd.exe> 'Resources\NPR(kpp).xsd' /c /n:Dhhr.KppParser.Service.Models /o:Models
```

`xsd.exe` er typisk lagret her: `C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe`.

Dokumentasjon finnes [hos Microsoft](https://learn.microsoft.com/en-us/dotnet/standard/serialization/xml-schema-definition-tool-xsd-exe).

---

Avhengig av hvordan `xsd.exe`-stien parses kan det være at hele eller deler av stien må omgis av fnutter. Eksempelvis:

```
'C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.8 Tools\xsd.exe'
```

eller

```
C:\'Program Files (x86)'\'Microsoft SDKs'\Windows\v10.0A\bin\'NETFX 4.8 Tools'\xsd.exe
```

## Oppdatere KppParser sitt versjonsnummer

Versjonsnummeret til `KppParser` er uavhengig av meldingsversjonen, men skal justeres ved oppdatering av meldingsversjonen.

1. Oppdatér alle `<AssemblyVersion>`-verdier (i `.csproj`-filer) til nytt versjonsnummer (format: `x.y.z.*`)
2. Oppdatér `versjonEpj`-verdien i `Dhhr.KppParser.Gui` &rarr; `appsettings.json` til nytt versjonsnummer (format: `x.y.z`)

## Øvrig

1. Oppdatér versjonen angitt i `versjon`- og `xmlns`-attributtet til `Melding`-elementet i `TestMelding.xml`
