# Test

## Unittest
- Kjøre unittest i Visual Studio

## Teste GUI og ConsoleApp

### GUI
```
".\Dhhr.KppParser.ConsoleApp\bin\Release\net6.0\win-x64\Dhhr.KppParser.ConsoleApp.exe"
```

### ConsoleApp
```
".\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\Dhhr.KppParser.Gui.exe"
```

### Test data

<ins>**Filer**</ins>

Test csv-filer for episoder og tjenester finnes i mappen:
```
".\Dhhr.KppParser.Service.Tests\Resources\TestData"
```

<ins>**Rapporteringsperode**</ins> 

Periode start: *01. January YYYY* (YYYY: Forrige år)

Periode slutt: *21. December YYYY* (YYYY: Forrige år)

<ins>**Avsender nivå 1**</ins> 

Org. Navn: *QA/Validering*

Org. HerId: *121017*

<ins>**Avsender nivå 2**</ins> 

Org. Navn: *QA/Validering*

Org. HerId: *121017*

![image](https://github.com/user-attachments/assets/0f278f7f-84eb-4919-9ed2-da85ad7ae543)

Figur 1: GUI-programmet

Dialog-boksen, se figur 2, betyr ikke at det er noe feil med applikasjonen og KPP-melding blir generert

![image](https://github.com/user-attachments/assets/b87bad89-d045-4f3a-8a1f-2cc10b8385c4)

Figur 2: Dialog-boks som vises når det sendes in episoder fra flere instutisjons-IDer
