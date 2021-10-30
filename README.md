# GameGatoRaton
Simple POO Abstract Classes and Inheritance Game Console App

Used a Helper class for miscellaneus tasks going for a cleaner Program, also applying SOLID principles.
Abstraction and inheritance is present from main Jugador class becoming either Gato or Ratón.
Invoking the methods for each one in the Helper is a great sample of polymorphism.
Encapsulation goes in how the data is handled becoming accessible as read only but not explicitly modifiable unless the specific methods are used.

Game logic was applied to the fullest, only one additional validation was added, to make sure position numbers didn't go over 30 as requested in instructions, it kind of messess with the tie scenario but I guess requirements are before that.

Also used the TableParser from https://github.com/Robert-McGinley/TableParser/tree/master/TableParser to print the table in a nicer format, it was super easy to use.
