C    Nuovo formato di stampa Dati di Progetto
c    MEMBRATURE: APERTURE SU MANTELLI CILINDRICI
C     21/01/98  by CD

1100  FORMAT('\par \par ',5X,
     X'DESIGN PRESSURE        P : ',F10.2,'  Psi  (',F6.2,' MPa)',
     X'\par ',5X,
     X'DESIGN TEMPERATURE     T : ',F10.2,'   °F  ( ',F5.0,'  °C)',
     X/'\par ',5X,
     X'SHELL MATERIAL           : ',A20,'\par ',5X
     X'NOZZLE MATERIAL          : ',A20,/'\par \par ',5X
     X'ALLOWABLE STRESS (shell) : ',F10.1,'  Psi  (',F10.2,' MPa)',/,
     X'\par ',5X,
     X'ALLOWABLE STRESS (nozzle): ',F10.1,'  Psi  (',
     XF10.2,' MPa)\par ')
1101   FORMAT('\par \par \par',5X,
     X'               TANGENTIAL OPENING','\par \par')
1102  FORMAT('\par \par ',5X,
     X'DESIGN PRESSURE        P : ',F10.2,'  Psi  (',F6.2,' MPa)',
     X'\par ',5X,
     X'DESIGN TEMPERATURE     T : ',F10.2,'   °F  ( ',F5.0,'  °C)',
     X/'\par ',5X,
     X'SUPPORTING NOZZLE MAT''L  : ',A20,'\par ',5X
     X'NOZZLE MATERIAL          : ',A20,/'\par \par ',5X
     X'ALLOWABLE STRESS (supp.n): ',F10.1,'  Psi  (',F10.2,' MPa)',/,
     X'\par ',5X,
     X'ALLOWABLE STRESS (nozzle): ',F10.1,'  Psi  (',
     XF10.2,' MPa)\par ')
