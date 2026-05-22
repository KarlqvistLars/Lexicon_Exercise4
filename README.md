# Lexicon_Exercise4
```
Övningsuppgift 4
```
![UML ClassDiagram](https://github.com/KarlqvistLars/Lexicon_Exercise4/blob/main/docs/F%C3%B6desDiagram/UML_ClassDiagram.jpg)
<br>
![passing test](https://github.com/KarlqvistLars/Lexicon_Exercise4/actions/workflows/build.yml/badge.svg)
<br>


## Innehåll
- [Garage 2.0](#garage-2.0)
- [Programmets arkitektur](#programmets-arkitektur)
- [För installation och test av Program](#för-installation-och-test-av-program)

## Garage 2.0

Detta projekt är en forsättning på Garage 1.0.<br>
Det är också en konsolbaserad garageapplikation i C#. Programmet skall simulera ett enkelt garage där olika typer av fordon kan parkeras/förvaras.


Vid program start kan man välja storlek på antalet fordon som ska kunna få plats.
```
Tryck Enter för standardstorlek 20,
eller välj en storlek för garaget:
```
Man kan även välja ifall man vill ha garaget fyllt med fordon frånbörjan?
```
Vill du starta med ett fullt garage? (Y/N):
```
Huvud menyn består av:
```
   * Garage 2.0 *
============================================================
   Huvudmeny
============================================================
1. Lägg till fordon
2. Ta bort fordon
3. Visa fordon
4. Hämta/Spara fordon
5. Välj språk
0. Avsluta




   Välj:
```
Här får man navigera mha.siffrorna för önskat alternativ. Huvudmenyn har 5 olika undermenyer.
```
   * Garage 2.0 *
============================================================
   Lägg till fordon
============================================================
1. Bil
2. Buss
3. Motorcykel
4. Båt
5. Flygplan
6. Slumpmässigt
0. Tillbaka
```
```
   * Garage 2.0 *
============================================================
   Ta bort fordon
============================================================
1. Sök och ta bort fordon
2. Ta bort fordon på regnummer
0. Tillbaka
```
```
   * Garage 2.0 *
============================================================
   Visa fordon
============================================================
1. Visa alla fordon
2. Visa fordon via regnummer
3. Sök fordon på typ, regnummer, färg, vikt, längd
0. Tillbaka
```
```
   * Garage 2.0 *
============================================================
   Hämta/Spara fordon
============================================================
1. Ladda sparade fordon från fil.
2. Spara fordon till fil.
0. Tillbaka
```
```
   * Garage 2.0 *
============================================================
   Välj språk
============================================================
1. Svenska
2. Engelska
0. Tillbaka
```

## Programmets arkitektur.
```
Exercise4_Garage_2/
├── Program.cs
├── Documents/
│   ├── Exercise4_Garage_2.cd
│   └── Vehicleklasses.txt
├── Interfaces/
│   ├── IGarage.cs
│   ├── IHandler.cs
│   ├── IUI.cs
│   └── IVehicle.cs
├── MenuClasses/
│   ├── UI.cs
│   ├── Text.en.resx
│   ├── Text.resx
│   └── Text.sv.resx
├── UtilitieClasses/
│   ├── Garage.cs
│   ├── Handler.cs
│   └── Utilities.cs
├── VehicleClasses/
│   ├── Car.cs
│   ├── Bus.cs
│   ├── Motorcycle.cs
│   ├── Boat
│   └── Airplane.cs
└── Exercise_Garage_2.Tests/
```
## För installation och test av Program
Ladda ned det zippade programmet [här](https://github.com/KarlqvistLars/Lexicon_Exercise4/blob/main/Releaser/Exercise4_Garage_2.zip). <br>
```
Packa upp zipfilerna på lämplig plats och starta filen [Exercise4_Garage_2.exe].

Antingen genom att dubbelklicka på filen i explorer eller genom att köra programmet från Terminal fönstret.
```
