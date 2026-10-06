C    Nuovo format di stampa dati di progetto
C    MEMBRATURA: Fondo Ellittico
C    21/01/98  by CD

1100  FORMAT(5X,
     X' Internal Design pressure     P = ',F10.1,' psi (',F6.2,
     X' MPa)\par ',/,5X,
     X' Design Temperature           T =      ', F5.1,' \''b0F   ( ',
     XF5.0,' \''b0C)\par \par '/5x,
     X' MATERIAL                       : ',A20,'\par'/5X,
     X' ALLOWABLE STRESS @ DESIGN T. S = ',F10.1,' psi  (',F10.2,
     X' N/mm²)\par \par '/5x,
     X' Internal diameter            D = ',F10.3,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X' Corrosion / Clad Thickness   C = ',F10.4,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X' Joint efficiency             E =      ',F5.2,'\par ')
