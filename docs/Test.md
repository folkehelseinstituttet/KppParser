# Hvordan teste KppParser

## 1. For å teste KppParser gjøres følgende
1. Kjøre **unittest** i Visual Studio
2. Teste GUI og ConsoleApp programmene, ved å følges denne oppskriften for <ins>begge</ins> programmene:
    1. Kjør programmet, filstien finner du beskrevet i kapittell 2
    2. Benytt testdataen som er beskrevet i kapittel 3, og forsøk å generer to Kpp-meldinger.
       - Én fra *Testfiler med header* og én fra *Testfiler uten header*.
    4. Vurdere om programmet oppfører seg som beskrevet i kapittell 4
    5. Vurdere generert Kpp-melding fra *testfiler nummer 1* som beskrevet i kapittel 5
3. Teste Kpp-melding fra *Testfiler med header* på meldingstjeneren på test serveren.
   1. Overfør Kpp-meldingen fra *Testfiler med header* til din egen pc i forvaltningsonen
   2. Overfør Kpp-meldingen fra *Testfiler med header* til test serveren til Meldingstjeneren, se oppskrift som ligger på denne filstien i forvaltningsonen på din pc:
    ```
    F:\DOKUMENTASJON\SYSTEMGRUPPA\KPP\KppParser\overføre-filer-til-t-trd1ahrdps01
    ```
   4. Teste kjøre Kpp-meldingen fra *Testfiler med header* på Meldingstjeneren, se oppskrift som ligger på denne filstien i forvaltningsonen på din pc:
    ```
    F:\DOKUMENTASJON\SYSTEMGRUPPA\KPP\KppParser\test-kjøre-kpp-melding-på-test-meldingstjeneren
    ```
   


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

Finnes to ulike sett med testfiler, testfiler som inkluderer header og testfiler som eksluderer header.

Filstien for å finne disse filene er:
```
".\Dhhr.KppParser.Service.Tests\Resources\TestData"
```
**Testfiler med header:** *episode.csv* og *tjeneste.csv*

**Testfiler uten header:** *episode_missing_header.csv* og *tjeneste_missing_header.csv*



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

## 4. Forventet oppførsel av programmene ConsoleApp og GUI
### 4.1 Testfiler med header
- Skal generere en Kpp-melding
- GUI: Viser bruker en dialogboks som informerer om at det er ønskelig med kun en instutisjons-ID, se Figur 1
![image](https://github.com/user-attachments/assets/b87bad89-d045-4f3a-8a1f-2cc10b8385c4)

**Figur 1:** Dialog-boks som vises når det sendes in episoder fra flere instutisjons-IDer

### 4.2 Testfiler uten header
- Skal <ins>ikke</ins> generere en Kpp-melding
- GUI: Viser bruker en dialogboks som informerer om hvorfor ikke Kpp-meldingen blir generert, se Figur 2
  ![image](https://github.com/user-attachments/assets/48eb060a-18ad-44b9-857f-b2d3b0a752fe)
  
**Figur 2:** Dialogboks som informerer bruker om hvorfor ikke Kpp-meldingen blir generert

## 5. Forventet resultat av Kpp-meldingen

Dette kapittellet ser kun på resultat fra *Testfiler med header*

### 5.1 Sammenligne forrige program sitt resultat mot det nye resultatet
*Forrige program* finner du i [realeases](https://github.com/folkehelseinstituttet/KppParser/releases)
1. Generer en ny kpp-melding med det *forrige programmet* og bruke samme testdata og *Testfiler med header* (se kapittell 3)
2. Sammenligne begge kpp-meldingene som er generert basert på *Testfiler med header*.

Tips: Bruk [Diffchecker](https://www.diffchecker.com/text-compare/) for å kunne tydelig se hva som er ulikt.

**Attributter/Komponenter som skal være ulik:**
- Komponent *GenDate*
- Komponent *MsgId*
- Disse atrributtene i komponent *Melding*:

  - versjon
  - uttakDato (Kun ulik hvis genereringen av kpp-meldingene ble gjennomført på ulike dager)
  - versjonEPJ
  - verskjonUt
  - lopenr
  - tilDatoPeriode
  - lokalident
  - xmlns
 
**Ved andre differanser:** 
- Undersøk hvorfor.
- Muligens kan det ha noe med endringer i mellom meldoingsversjonene.

### 5.2 Se på resultatet fra skjemavalideringsprogrammet *NprSkjemavalidatorGUI*

Skjemavalideringsprogrammet *NprSkjemavalidatorGUI* finner du på fhi sine [nettisder](https://www.fhi.no/he/npr/registrering-og-rapportering/validering-av-data-for-rapportering/), i en tabell under tittel *Skjemavalidering lokalt*.

Benytt den nye KppParseren sin genererte kpp-meldingen med *testfiler med header* og verifiser at filen er validert til **ok** av *NprSkjemavalidatorGUI*. 











