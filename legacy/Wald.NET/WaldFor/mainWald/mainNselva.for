C----------------------------------------------------------------------
C     - PROGRAM SELVA - 1         REVISION FEB,1988
C----------------------------------------------------------------------
      COMMON/SYSTEM/IN,IO,KDOS,MDOS,LDOS,NDOS,NUOVER
      CHARACTER*30 FILIN,FILOUT
      IN=1
      IO=3
      KDOS=IN
      MDOS=8
      LDOS=9
      NDOS=10
      NUMAR=NARGS()
      IF(NUMAR.GE.2) THEN
      CALL GETARG(1,FILIN,ISTAT)
      CALL GETARG(2,FILOUT,ISTAT)
      OPEN(IN,FILE=FILIN,STATUS='OLD',ERR=100,IOSTAT=IO1)
      OPEN(IO,FILE=FILOUT,ERR=100,IOSTAT=IO2)
      ELSE
      OPEN(IN,FILE=' ',STATUS='OLD')
      OPEN(IO,FILE=' ')
      ENDIF
      CALL SELVA
      CALL PRNUOVER
      CLOSE(IN)
      CLOSE(IO)
100   STOP
      END
