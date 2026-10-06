C    Nuovo formato di stampa Dati di Progetto
c    MEMBRATURE: MANTELLI & FONDI EMISFERICI
C     21/01/98  by CD
C    - Modificati formati di stampa dati SI e aggiunta designazione
C      per il Clad
C     08/07/98  by CD

1100  FORMAT('\par ',
c     X' Internal Design pressure     P = ',F10.1,' psi  (',F5.1,
c     X' MPa)\par ',/,5X,
c     X' Design Temperature           T =      ', F5.1,' °F   ( ',
c     XF5.0,' °C)\par \par ',
     X5X,
     X' MATERIAL                       : ',A20,'\par ',5X,
     X' ALLOWABLE STRESS @ DESIGN T. S = ',F10.1,' psi  (',F10.2,
     X' MPa)\par \par ',/,5X,
     X' Internal diameter            D = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Internal radius R = (D+2*C)/2  = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Corrosion / Clad Thickness   C = ',F10.4,' inch (',F10.3,
     X' mm)\par ',/,5X,
     X' Joint efficiency             E =      ',F5.2,'\par ')
1101  FORMAT('\par ',
c     X' Internal Design pressure     P = ',F10.1,' psi  (',F5.1,
c     X' MPa)\par ',/,5X,
c     X' Design Temperature           T =      ', F5.1,' °F   ( ',
c     XF5.0,' °C)\par \par ',
     X5X,
     X' MATERIAL                       : ',A20,'\par ',5X,
     X' ALLOWABLE STRESS @ DESIGN T. S = ',F10.1,' psi  (',F10.2,
     X' MPa)\par \par ',/,5X,
     X' External diameter            D = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' External radius       R = D/2  = ',F10.3,' inch (',F10.2,
     X' mm)\par ',/,5X,
     X' Corrosion / Clad Thickness   C = ',F10.4,' inch (',F10.3,
     X' mm)\par ',/,5X,
     X' Joint efficiency             E =      ',F5.2,'\par ')
