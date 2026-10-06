C    Nuovo formato di stampa Dati di Progetto
c    MEMBRATURE:FONDI TOROSFERICI
C     21/01/98  by CD

1100  FORMAT(5X,
     X' Internal Design pressure     P = ',F10.1,' psi  (',F6.2,
     X' MPa)\par ',5X,
     X' Design Temperature           T =      ', F5.1,' \''b0F   ( ',
     XF5.0,' \''b0C)\par \par '/5X,
     X' MATERIAL                       : ',A20,'\par '/5X,
     X' ALLOWABLE STRESS @ DESIGN T. S = ',F10.1,' psi  (',F10.2,
     X' N/mm²)\par \par '/5x
     X' Internal diameter            D = ',F10.3,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X' Inside knuckle radius        r = ',F10.3,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     x' Crown radius                 L = ',F10.3,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X' Corrosion / Clad Thickness   C = ',F10.4,' inch',
     X'  (',F10.3,' mm)\par '/5X,
     X' Joint efficiency             E =      ',F5.2,'\par ')
