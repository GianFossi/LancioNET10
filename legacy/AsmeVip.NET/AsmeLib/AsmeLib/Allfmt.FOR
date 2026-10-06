C
C    Nuovo Include File x Output Format Collection 
C    by CD - 30/06/98
C
cDEC$ FREEFORM
1197  FORMAT('\par \par ', &
      'INSIDE DIAMETER OF THE SHELL          D\tab : ',F10.4,' inch\tab (',F10.1,'  mm)\par ')
1198  FORMAT('\par \par ', &
      'INSIDE DIAMETER OF HEAD               D\tab : ',F10.4,' inch\tab (',F10.1,'  mm)\par ')
1199  FORMAT('\par \par ', &
      'INSIDE RADIUS OF THE SPHERICAL ZONE   L\tab : ',F10.4,' inch\tab (',F10.1,'  mm)\par ')
1203  FORMAT(8X,'Note:\par ',5X, &
      'The tangential opening''s diameter times F=',F3.1,' is greater\par '/,5X, &
      'than the opening diameter along the longitudinal direction.\par ',/,5X, &
      'Therefore the quantity d on the following pages will be substi-\par '/,5X, &
      'tuted by the said product, namely d=',F7.4,' in (',F7.2,' mm).\par ')
1204  FORMAT(/, &
      'Opening''s chord length               d{\sub ch}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par '/ &
      'NZL.C.L. offset to HEAD C.L.           \tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1205  FORMAT('\par ', &
      'NZL.C.L. offset to SHELL C.L.          \tab : ',F10.4,' inch\tab (',F10.2  ,'  mm)\par ')
12060 FORMAT('\par ', &
      'NZL inclined longitudinally by         \tab : ',F10.1,' degrees, so:\par'/ &
      'Resulting chord length                d{\sub ch}\tab : ',F10.4,' inch\tab (',F10.2,'  mm)\par ')
1207  FORMAT(5x, &
      '__________________________________________________\par ',5x &
      '(*) LENGTH OF SELF-REINFORCEMENT+TRANSITION LENGTH\par '/ &
      '    (see L on sketch AD-540.1(a)\par ')
!DEC$ NOFREEFORM
1211  FORMAT(3X'(Note: h < 2.5(t{\sub n}-c)+K)\par ')
1212  FORMAT(3X'(Note: h > 2.5(t{\sub n}-c)+K)\par ')
1213  FORMAT(8X,'Note:\par ',5X
     X'The tangential opening''s diameter (',F7.2,' mm) times F=',F3.1 
     $,' is lesser\par '/,5X,
     X'than the opening diameter along the longitudinal direction.\par '
     $,/,5X,
     X'Therefore the latter governs.\par ')
1498  FORMAT('\par ',5X,
     X'EXCESS AREA FROM THE ',A5,'  : A{\sub 1}\par ',5X,
     X'==========================\par '/5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     $,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     $,'\par \par '/5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+tn-2c\tab = ',F10.3,' inch\tab (',
     XF8.1,' mm)\par '/5X,
     X'          L adopted\tab = ',F10.3,' inch\tab (',
     XF8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE ',A5,'\par \par '/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1499  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM THE ',A5,'  : A{\sub 1}\par ',5X,
     X'==========================\par '/5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     $,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     $,'\par \par '/5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L available     = ',F10.3,' inch\tab (',F8.1,' mm)\par '/15X,
     X'L adopted       = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE ',A5,'\par \par '/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1500  FORMAT('\par ',5X,
     X'EXCESS AREA FROM THE ',A5,'  : A{\sub 1}\par ',5X,
     X'==========================\par '/5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     $,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     $,'\par \par '/5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'          L adopted\tab = ',F10.3,' inch\tab (',
     XF8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE ',A5,'\par \par '/5X,
     X'A{\sub r} (reduction from R{\sub 1}) \tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ',/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'-A{\sub r}\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1501  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM THE ',A5,'  : A{\sub 1}\par ',5X,
     X'==========================\par '/5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     $,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     $,'\par \par '/5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L available     = ',F10.3,' inch\tab (',F8.1,' mm)\par '/15X,
     X'L adopted       = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE ',A5,'\par \par '/5X,
     X'A{\sub r} (reduction from R{\sub 1}) \tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ',/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'-A{\sub r}\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1502  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM SPH. HEAD  : A{\sub 1}\par '/5X,
     X'==========================\par ',5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     $,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     £,'\par \par '/5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE SPHERICAL HEAD'
     £,'\par \par '/5X,
     X'A{\sub r} (reduction from R{\sub 1}) \tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ',/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'-A{\sub r}\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1503  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM SPH. HEAD  : A{\sub 1}\par ',5X,
     X'==========================\par '/5X,
     X'(AD 540.1.a) The limit of reinforcement on each side of the axis'
     £,'\par '/
     X,5X,'of the opening will be equal to the greater of :'
     $,'\par \par ',5X,
     X'l{\sub 1} = d+2c\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X
     X,'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L available\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/15X,
     X'L adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE SPHERICAL HEAD'
     $,'\par \par ',5X,
     X'A{\sub r} (reduction from R{\sub 1}) \tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ',/5X,
     X'A{\sub 1} = (2*L-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'-A{\sub r}\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
1504  FORMAT(5X,'(Note: L has been reduced by the factor of ',
     1'proximity ',F5.3) 
1600  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     £,'\par \par ',5X,
     X'l{\sub 1} = 0.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol"',
     $' \\s 10}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73*x+2.5*(t{\sub p}-c)+K\tab = ',
     $F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed either  2.5*(t-c) or L{\sub n}',
     $'+2.5*(t{\sub p}-c)\par '/5X,
     X'    2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X' L{\sub n} + 2.5 * (t{\sub p}-c)\tab = ',F10.3,' inch\tab (',
     $F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 2} =2(l+',A,')*(t{\sub n}-t{\sub rn}-c)\tab = ',
     $F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1601  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par ',5X,
     X'=======================\par '/5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     %,'\par \par ',5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73*x+2.5*(tp-c)+K\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed either  2.5*(t-c) or L{\sub n}+2.5*(t{\sub p}-c)\p
     Xar '/9X,'2.5*(t-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X' L{\sub n} + 2.5 * (t{\sub p}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par ',
     X/15X,'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'{{\field{\*\fldinst SYMBOL 113 \\f "Symbol" \\s 10}{\fldrslt\f3\f
     Xs20}}}     =     arctg((t{\sub n}-t{\sub p})/(L-l))            = '
     X,F10.3,' \''b0\par '/5X,
     X'A{\sub 21}=    2(h+',A,')*(t{\sub n}-t{\sub rn}-c)',       
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})
     X\par '/5X,
     X'A{\sub 22}=(2(t{\sub p}-t{\sub rn}-c)+(L-l)*tan{{\field{\*\fldins
     Xt SYMBOL 113 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}+t{\sub n}-t{
     X\sub p})*(l-h) = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1602  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par ',5X,
     X'=======================\par '/5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     %,'\par \par ',5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73*x+2.5*(t{\sub p}-c)+K\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed either  2.5*(t-c) or L{\sub n}+2.5*(t{\sub p}-c)\p
     Xar '/9X,'2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X' L{\sub n} + 2.5 * (t{\sub p}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par ',
     X/15X,'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}=2(h+',A,')*(t{\sub n}-t{\sub rn}-c)',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=(t{\sub p}-t{\sub n})*(L{\sub n}-h)     \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ',5X,
     X'A{\sub 23}=2(l-h)*(t{\sub p}-t{\sub rn}-c)   \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ',5X,
     X'A{\sub 2} = A{\sub 21} + A{\sub 22} + A{\sub 23}     \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1603  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     %,'\par \par '/5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} =   2.5*(t{\sub n}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c) \par '/9X,
     X'2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 2} =2(l+',A,')*(t{\sub n}-t{\sub rn}-c)\tab = ',
     XF10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1604  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par '/5X,
     X'=======================\par ',5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     Z,'\par \par ',5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} =   2.5*(t{\sub n}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c) \par '/9X,
     X'2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/15X,
     X'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'a  =     arctg((t{\sub n}-t{\sub p})/(L-l))\tab = ',F10.3,
     £' \''b0\par '/5X,
     X'A{\sub 21}=2(h+',A,')*(t{\sub n}-t{\sub rn}-c)',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=(2(t{\sub p}-t{\sub rn}-c)+(L-l)*tan(a)+t{\sub n}',
     X'-t{\sub p})*(l-h)\tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par '/5X,
     X'A{\sub 2} =         A{\sub 21} + A{\sub 22}\tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1605  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par ',5X,
     X'=======================\par '/5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(a)):'
     %,'\par \par ',5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}(r{\sub m}*(t{\sub n}-c))+K \tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 2.5*(t{\sub n}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed either  2.5*(t-c) or L{\sub n}+2.5*(t{\sub p}-c)\p
     Xar '/9X,'2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X' L{\sub n} + 2.5 * (t{\sub p}-c)\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par ',
     X/15X,'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 21}=2(h+',A,')*(t{\sub n}-t{\sub rn}-c)',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F8.1,
     X' mm{\super 2})\par '/5X,
     X'A{\sub 22}=(t{\sub p}-t{\sub n})*(L{\sub n}-h)     \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ',5X,
     X'A{\sub 23}=2(l-h)*(t{\sub p}-t{\sub rn}-c)   \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ',5X,
     X'A{\sub 2} = A{\sub 21} + A{\sub 22} + A{\sub 23}     \tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1606  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par ',5X,
     X'=======================\par '/5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to the greater of (AD 540.2(c)):'
     %,'\par \par ',5X,
     X'l{\sub 1} = 0.5{{\field{\*\fldinst SYMBOL 214 \\f "Symbol" \\s 10
     X}{\fldrslt\f3\fs20}}}',
     X'(r{\sub m}*(t{\sub n}-c))+t{\sub e}''+K\tab = '
     X,F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 2.5*(t{\sub n}-c)+t{\sub e}''+K\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'but not exceed 2.5*(t-c) \par ',
     X/9X,'2.5*(t-c)\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X' where t{\sub e}'' is the minimum between t{\sub e},1.73W and',
     X' 1.5t :\par ',5X,'t{\sub e}'' = \tab ',F10.3,
     X' inch\tab (',F8.1,' mm)\par ',
     X/15X,'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 2} =2(l+',A,')*(t{\sub n}-t{\sub rn}-c)\tab = ',
     $F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1607  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM NOZZLE     : A{\sub 2}\par ',5X,
     X'=======================\par '/5X,
     X'(AD 540.2) The limit of reinforcement measured normal to vessel',
     X'\par '/5X,'wall will be equal to t{\sub e}, but not greater than'
     X,' (AD 540.2(d)):\par \par ',5X,
     X'l{\sub 1} = 1.5t\tab = '
     X,F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = 1.73W\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X/15X,'l adopted\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE\par \par '/5X
     X'A{\sub 2} = 0 (All reinforcement is counted in A{\sub 3})\par ')
1633  FORMAT('\par \par ',5X,
     X'A{\sub 2} final = A{\sub 2} * F{\sub R}\tab = '
     X,F10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
1700  FORMAT('\par \par ',5X,
     X'AREA FROM FILLET RADIUS r{\sub 2}  : A{\sub 4}\par '/5X
     X'==========================\par \par ',15X,
     X'A{\sub 4}\tab = ',F10.3,' inch{\super 2}\tab (',F10.1,
     X' mm{\super 2})\par ')
1701  FORMAT('\par \par ',5X,
     X'AREA FROM FILLET WELD       : A{\sub 4}\par '/5X
     X'=====================\par \par ',15X,
     X'A{\sub 4}\tab = ',F10.3,' inch{\super 2}\tab (',F10.1,
     X' mm{\super 2})\par ')
1800  FORMAT('\par \par '/5X,
     X'TOTAL AREA AVAILABLE      >  REINF. AREA REQUIRED',
     X'\par \par '/5X,
     X'   ',F10.3,' inch{\super 2}',12X,F10.3,' inch{\super 2}\par ')
1900  FORMAT('\par \par '/5X,
     X'd/D > 0.50 USE ASME CODE APPENDIX 4 OR 5 \par ')
2203  FORMAT('\par ',5x,
     X'REINFORCEMENT AVAILABLE IN THE NOZZLE INTERNAL PROTRUSION',
     X'\par '/5X
     X'          L{\sub prot} adopted   = ',F10.3,' inch\par '/5X,
     X'A{\sub 2p} = 2*(t{\sub n}-2c)*L{\sub prot}\tab = ',
     XF10.3,' inch{\super 2}\par ')
2500  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM REINFORCING PADS : A{\sub 3}\par ',5X,
     X'=================================\par ',5X,
     X'Strength reduction factor  F{\sub rp}: ',F10.3,'\par ',/5X,
     X'Reinforcing pad diameter   D{\sub p} : ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'Useful pad thickness       t{\sub e}'' : ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'A{\sub 3} = (D{\sub p}-d{\sub e})*t{\sub e}*F{\sub rp} = ',
     XF10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
2501  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM REINFORCING PADS : A{\sub 3}\par ',5X,
     X'=================================\par ',5X,
     X'Strength reduction factor  F{\sub rp}: ',F10.3,'\par ',/5X,
     X'Useful reinf. pad diam.    D{\sub p}'': ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'Useful pad thickness       t{\sub e}'': ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'A{\sub 3} = (D{\sub p}''-d{\sub e})*t{\sub e}*F{\sub rp} = ',
     XF10.3,' inch{\super 2}\tab (',F8.1,' mm{\super 2})\par ')
3500  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM SHELL      : A{\sub 1}\par '/5X,
     X'======================\par ',5X,
     X'(AD 540.1.b) 2/3 of required reinforcement on each side of the'
     c,'\par '/
     X,5X,'opening axis will be within a distance equal to the greater',
     X'\par '/5X,'of l{\sub 1} or l{\sub 2} but in any case not greater 
     Xthan of L (540.1.a):\par \par '/5X,
     X'l{\sub 1} =(d+2c)/2+.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol
     X" \\s 10}{\fldrslt\f3\fs20}}}(R{\sub m}*(t-c))\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L"\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE SHELL\par \par ',5X,
     X'A{\sub 1} =(2*L"-d{\sub e})*(t{\sub s}-t{\sub r}-c)\tab = ',
     XF10.3,' inch{\super 2}\tab (',F10.1,' mm{\super 2})\par ')
35009 FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM SPHER. HEAD: A{\sub 1}\par ',/,5X,
     X'============================\par ',/,5X,
     X'(AD 540.1.b) 2/3 of required reinforcement on each side of the',
     x'\par ',
     X5X,'opening axis will be within a distance equal to the greater o
     Xf :\par \par '/,5X,
     X'l{\sub 1} =(d+2c)/2+.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol
     X" \\s 10}{\fldrslt\f3\fs20}}}(R{\sub m}*(t-c))\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L"\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'While the limit of reinforcement on side of the axis where',
     x'\par ',5X,
     X'there is interference is :\par '/15X,
     X'L{\sub i}"\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE SPHERICAL SHELL\par \par '/5X,
     X'A{\sub 1} = (L"+L{\sub i}"-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F10.1,
     X' mm{\super 2})\par ')
3501  FORMAT('\par \par ',5X,
     X'EXCESS AREA FROM SPHER. HEAD: A{\sub 1}\par ',5X,
     X'============================\par '/5X,
     X'(AD 540.1.b) 2/3 of required reinforcement on each side of the'
     c,'\par '/
     X,5X,'opening axis will be within a distance equal to the greater',
     X' of :\par \par '/5X,
     X'l{\sub 1} =(d+2c)/2+.5*{{\field{\*\fldinst SYMBOL 214 \\f "Symbol
     X" \\s 10}{\fldrslt\f3\fs20}}}(R{\sub m}*(t-c))\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/5X,
     X'l{\sub 2} = (d+2c)/2+t+t{\sub n}-2c\tab = ',F10.3,
     X' inch\tab (',F8.1,' mm)\par '/15X,
     X'L{\sub i}"\tab = ',F10.3,' inch\tab (',F8.1,' mm)\par '/5X,
     X'REINFORCEMENT AVAILABLE IN THE SPHERICAL SHELL\par \par '/5X,
     X'A{\sub 1} = (L"+L{\sub i}"-d{\sub e})*(t{\sub s}-t{\sub r}-c)',
     X'\tab = ',F10.3,' inch{\super 2}\tab (',F10.1,
     X' mm{\super 2})\par ')
5000	FORMAT('\page ')
5500	FORMAT('\par \par \par ',5X,
     C'SINGLE OPENING HAVING A DIAMETER < 0.2*{{\field{\*\fldinst SYMBOL
     X 214 \\f "Symbol" \\s 10}{\fldrslt\f3\fs20}}}(Rm*T)\par '/
     C5X,'CIRCULAR OPENING NOT REQUIRING REINFORCEMENT\par ')
