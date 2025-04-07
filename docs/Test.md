# Hvordan teste KppParser

## 1. For å teste KppParser gjøres følgende
1. **Kjøre *unittest* i Visual Studio**
   
2. **Teste *GUI* programmet:**
    1. Kjør programmet, filstien til programmet er:
       ```
       .\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64\Dhhr.KppParser.Gui.exe
       ```
    2. Benytt testdataen som er beskrevet i *kapittel 2*, og forsøk å generer 2 Kpp-meldinger.
       - 1 fra *Testfiler med header* og 1 fra *Testfiler uten header*
    3. Vurdere om programmet oppfører seg som beskrevet i *kapittel 3*
    4. Vurdere generert Kpp-melding fra *Testfiler med header* som beskrevet i *kapittel 5*
       
3. **Teste *ConsoleApp* programmet:**
   1. Kjør programmet ved bruk av kommandolinjeverktøyet *CMD*:
      Navigere til denne mappen:
       ```
        cd: "[DIN FILSTI TIL PROSJEKTETS SRC]\Dhhr.KppParser.Gui\bin\Release\net6.0-windows\win-x64"
       ```
      Kjør programmet ved å skrive inne denne kommandoen:
      ```
        Dhhr.KppParser.ConsoleApp.exe
      ```
    2.  Benytt testdataen som er beskrevet i *kapittel 2*, og forsøk å generer 2 Kpp-meldinger.
           - 1 fra *Testfiler med header* og 1 fra *Testfiler uten header*
    3. Vurdere om programmet oppfører seg som beskrevet i *kapittel 4*
    4. *Sammenligne* om *ConsoleApp* sin genererte Kpp-melding fra *Testfiler med header* og *GUI* sin genererte Kpp-meldingen fra *Testfiler med header* er like, som beskrevet i *kapittel 6*
   
4. **Teste Kpp-melding fra *Testfiler med header* på *meldingstjeneren på test serveren*:**
   1. Overfør Kpp-meldingen fra *Testfiler med header* til din egen pc i forvaltningsonen
   2. Overfør **Kpp-meldingen fra Testfiler med header** og **Resultat scriptet** til test serveren til Meldingstjeneren.
   
   *Resultat scriptet* er et script som kan brukes for å kunne vurdere om kpp-meldinger fungerer som ønsket på Meldingstjeneren, og ligger på denne filstien i forvaltningsonen på din pc:
   ```
    F:\DOKUMENTASJON\SYSTEMGRUPPA\KPP\KppParser\script-som-viser-resultat-på-kpp-melding-på-test-meldingstjeneren
    ```
   Se oppskrift som ligger på denne filstien i forvaltningsonen på din pc for hvordan du overfører filer til test serveren til Meldingstjeneren:
    ```
    F:\DOKUMENTASJON\SYSTEMGRUPPA\KPP\KppParser\overføre-filer-til-t-trd1ahrdps01
    ```
   3. Teste kjøre Kpp-meldingen fra *Testfiler med header* på Meldingstjeneren ved å følge oppskriften som ligger på denne filstien i forvaltningsonen på din pc:
    ```
    F:\DOKUMENTASJON\SYSTEMGRUPPA\KPP\KppParser\test-kjøre-kpp-melding-på-test-meldingstjeneren
    ```


## 2. Testdata

### 2.1 Testfilene

<ins>**Filer**</ins>

Finnes to ulike sett med testfiler, testfiler som inkluderer header og testfiler som eksluderer header.

Filstien for å finne disse filene er:
```
".\Dhhr.KppParser.Service.Tests\Resources\TestData"
```
**Testfiler med header:** *episode.csv* og *tjeneste.csv*

**Testfiler uten header:** *episode_missing_header.csv* og *tjeneste_missing_header.csv*

### 2.2 GUI programmet

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

### 2.3 ConsoleApp programmet
episoder = *"filstien til episoder filen"* (Se *kapittel 2.1*)

tjenester = *"filstien til tjenester filen"* (Se *kapittel 2.1*)

fradato = *YYYY-01-01* (YYYY: Forrige år)

tildato = *YYYY-12-31* (YYYY: Forrige år)

org-herid = *21017*

org-navn = *QA/Validering* 

org-herid2 = *21017* 

org-navn2 = *QA/Validering* 

leverandor= *FHI*

epj-navn= *KppParser* 

epj-versjon = *X.Y.Z* (Programmets versjonsnummer)

fhi-herid = *121017*

output= *"mappensfilsti til hvor du ønsker den genererte kpp-meldingens skal lagres/ meldingens filnavn"*


## 3. Forventet oppførsel av GUI programmet
### 3.1 Testfiler med header
- Skal generere en Kpp-melding
- Viser bruker en dialogboks som informerer om at det er ønskelig med kun en instutisjons-ID, se Figur 1
![image](https://github.com/user-attachments/assets/b87bad89-d045-4f3a-8a1f-2cc10b8385c4)

**Figur 1:** Dialog-boks som vises når det sendes inn episoder fra flere instutisjons-IDer

### 3.2 Testfiler uten header
- Skal <ins>ikke</ins> generere en Kpp-melding
- Viser bruker en dialogboks som informerer om hvorfor ikke Kpp-meldingen blir generert, se Figur 2
  ![image](https://github.com/user-attachments/assets/48eb060a-18ad-44b9-857f-b2d3b0a752fe)
  
**Figur 2:** Dialogboks som informerer bruker om hvorfor ikke Kpp-meldingen blir generert

## 4. Forventet oppførsel av ConsoleApp programmet
### 4.1 Testfiler med header
- Skal generere en Kpp-melding
- Informerer bruker om at det er ønskelig med kun en instutisjons-ID, se Figur 3

  ![image](https://github.com/user-attachments/assets/8ff61cbb-28ae-412d-83cb-006d1ef439b8)

**Figur 3:** Kommandolinjeverktøyet informerer om at det er ønskelig med kun en instutisjons-ID

### 4.2 Testfiler uten header
- Skal <ins>ikke</ins> generere en Kpp-melding
- Informerer bruker om hvorfor ikke Kpp-meldingen ble generert, se Figur 4
  
  ![image](https://github.com/user-attachments/assets/04cfae6f-a483-41c4-9741-2ab59ed606d8)

  
**Figur 4:** Kommandolinjeverktøyet informerer om hvorfor ikke Kpp-meldingen ble generert

## 5. Forventet resultat av Kpp-meldingen

Dette kapittellet ser kun på resultat fra *Testfiler med header*

1. **Sammenligne forrige program sitt resultat mot det nye resultatet:**
    *Forrige program* finner du i [realeases](https://github.com/folkehelseinstituttet/KppParser/releases)
    1. Generer en ny kpp-melding med det *forrige programmet* og bruke samme testdata og *Testfiler med header* (se *kapittel 2*)
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
    - Undersøk hvorfor
    - Muligens kan det ha noe med endringer i mellom meldingsversjonene

2. **Se på resultatet fra skjemavalideringsprogrammet *NprSkjemavalidatorGUI*:**

    Skjemavalideringsprogrammet *NprSkjemavalidatorGUI* finner du [her](https://www.fhi.no/he/npr/registrering-og-rapportering/validering-av-data-for-rapportering/), i en tabell under tittel *Skjemavalidering lokalt*.

    Benytt den nye KppParseren sin genererte kpp-meldingen med *testfiler med header* og verifiser at filen er validert til **ok** av *NprSkjemavalidatorGUI*. 

## 6. Sammenligne 2 Kpp-meldingener som skal være like

Dette kapittellet ser kun på resultat fra *Testfiler med header*

Tips: Bruk [Diffchecker](https://www.diffchecker.com/text-compare/) for å kunne tydelig se hva som er ulikt.

**Attributter/Komponenter som kan/skal være ulik:**
- Komponent *GenDate*
- Komponent *MsgId*

Restene av innholdet <ins>skal være identiske</ins>.












