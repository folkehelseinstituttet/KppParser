# Hvordan teste KppParser

## 1. For å teste KppParser gjøres følgende
1. Kjøre **unittest** i Visual Studio
2. Teste GUI og ConsoleApp programmene, ved å følges denne oppskriften for <ins>begge</ins> programmene:
    1. Kjør programmet, filstien finner du beskrevet i kapittell 2
    2. Benytt testdataen som er beskrevet i kapittel 3
    3. Vurdere resultatene baser på forventninger til resultat beskrevet i kapittell 4
   


## 2. Hvor ligger GUI og ConsoleApp?
Programmene har disse filsiene, **etter** å har kjørt kommandoen som lager programmene GUI og ConsoleApp (se readme.md)
```
".\Dhhr.KppParser.ConsoleApp\bin\Release\net6.0\win-x64\Dhhr.KppParser.ConsoleApp.exe"
```
```
".\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\Dhhr.KppParser.Gui.exe"
```

## 3. Testdata

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

<ins>Mottaker (FHI)</ins>

Velg *Prøvesending*

## 4. Forventet resultat
### 4.1 Testfilene
- Skal generere en Kpp-melding
- GUI: Vise bruker en dialogboks som informerer om at det er ønskelig med kun en instutisjons-ID, se Figur 1
![image](https://github.com/user-attachments/assets/b87bad89-d045-4f3a-8a1f-2cc10b8385c4)

**Figur 1:** Dialog-boks som vises når det sendes in episoder fra flere instutisjons-IDer

### 4.2 Testfilene som **mangler header**
- Skal <ins>ikke</ins> generere en Kpp-melding
- GUI: Vise bruker en dialogboks som informerer om hvorfor ikke Kpp-meldingen blir generert, se Figur 2
  ![image](https://github.com/user-attachments/assets/48eb060a-18ad-44b9-857f-b2d3b0a752fe)
  
**Figur 2:** Dialogboks som informerer bruker om hvorfor ikke Kpp-meldingen blir generert




