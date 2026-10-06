C    Nuovo formato di stampa Dati di Progetto
c    MEMBRATURE: FONDI EMISFERICI
C     21/01/98  by CD

1100  FORMAT('\par \par \par ',5X,
     X'DESIGN PRESSURE        P : ',F10.2,'  Psi  (',F6.2,' )MPa\par ',
     X/,5X,
     X'DESIGN TEMPERATURE     T : ',F10.2,'   \''b0F  ( ',F5.0,'  \''b0C)\par ',
     X/,5X,
     X'SHELL MATERIAL           : ',A20,'\par ',5X
     X'NOZZLE MATERIAL          : ',A20,'\par \par \par ',5X
     X'ALLOWABLE STRESS (shell) : ',F10.1,'  Psi  (',F10.2,
     x' N/mm²)\par ',/,5X,
     X'ALLOWABLE STRESS (nozzle): ',F10.1,'  Psi  (',F10.2,
     x' N/mm²)\par ')
1101  FORMAT('\par ',5X,
     X'NOZZLE ORIENTATION       : TANGENTIAL\par ')

