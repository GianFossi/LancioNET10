1      º\pard\plain \s18\qj\widctlpar\tx3536\tx5670 \f2\fs18\lang1040 
S      º_\tab \                        \
s      º\par \tab ==========================
T      º_\par  \  \ * \                                        \ rev.\ \ (Date: \         \) *
V      º_\par                 \                                            \
1      º\par                 ==============================================
1      º\par          UG-39   REINFORCEMENT REQUIRED FOR OPENINGS IN FLAT HEADS
1      º\par          =========================================================
1      º\par 
N      º_\par COVER  IDENTIFICATION : &
O      º_\par COVER  MATERIAL       : &
P      º_\par NOZZLE MARK           : &
Q      º_\par NOZZLE MATERIAL       : &
H      º_\par FLANGE MATERIAL       : &
G      º_\par MATERIAL GROUP        : \                                              \
1      º\par 
1      º\par 
1      º\par                                   INPUT DATA
1      º\par                                   ==========
1      º\par 
1      º\pard\plain \s18\qj\widctlpar\tx709\tqr\tx2268\tx2410\tqr\tx4536\tx4678\tx5670 \f2\fs18\lang1040 
A001   º_\par P_\tab =_\tab #######.##_\tab [Mpa]_\tab #####.####_\tab [psi]_\tab Design pressure
A002   º_\par Tem_\tab =_\tab ######.##_\tab [\'b0C]_\tab #####.####_\tab [\'b0F]_\tab Design temperature
A037   º_\par G{_\sub ef}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Diameter of gasket load reaction
A122   º_\par S{_\sub ca}_\tab =_\tab #######.##_\tab [N/mm{_\super 2}]_\tab #####.####_\tab [psi]_\tab Allowable for cover at room
A123   º_\par S{_\sub co}_\tab =_\tab #######.##_\tab [N/mm{_\super 2}]_\tab #####.####_\tab [psi]_\tab Allowable for cover at temp.
A133   º_\par W{_\sub m1}_\tab =_\tab ########.##_\tab [N]_\tab #####.####_\tab [lb]_\tab Bolts load in operating condition
A042   º_\par W_\tab =_\tab ########.##_\tab [N]_\tab #######.####_\tab [lb]_\tab Bolts load in seating condition
A049   º_\par h{\sub g}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]
1      º\par 
1      º\par C     =         0.3 factor UG-34 Sketches (j) and (k)
1      º\par 
A119   º_\par T_\tab =_\tab #######.##_\tab [mm]_\tab ######.####_\tab [in]_\tab Nominal adopted cover thickness
A120   º_\par C{_\sub o}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Corrosion
A121   º_\par C{_\sub g}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Cover pass partition groves
A134   º_\par t_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab T - max(C{_\sub o},C{_\sub g})
A126   º_\par t{_\sub ra}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab G.{_\field{_\*_\fldinst SYMBOL 214 _\_\f "Symbol" _\_\s 10}}(1,9.W.hg/S{_\sub ca}.G{_\super 3})
A125   º_\par t{_\sub ro}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab G.{_\field{_\*_\fldinst SYMBOL 214 _\_\f "Symbol" _\_\s 10}}(C.P/S{_\sub co})+(1,9.W{_\sub m1}.hg/S{_\sub co}.G{_\super 3})
A135   º_\par d{_\sub i}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Inside diameter of nozzle
A136   º_\par d{_\sub e}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Outside diameter of nozzle
A137   º_\par T{_\sub n}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Nominal nozzle thickness
A138   º_\par C{_\sub n}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab Nozzle corrosion
A139   º_\par t{_\sub n}_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab T{_\sub n} - C{_\sub n}
A140   º_\par d_\tab =_\tab #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab d{_\sub i} + 2.C{_\sub n}
A141   º_\par S{_\sub na}_\tab =_\tab ######.##_\tab [N/mm{_\super 2}]_\tab ######.####_\tab [psi]_\tab Allowable for nozzle at room
A142   º_\par S{_\sub no}_\tab =_\tab ######.##_\tab [N/mm{_\super 2}]_\tab ######.####_\tab [psi]_\tab Allowable for nozzle at temp.
1      º\par 
A164   º_\par P{_\sub r}_\tab = ########.##_\tab [N/mm{_\super 2}]_\tab ######.####_\tab [psi]_\tab Allowable pressure per ANSI B16.5
1      º\par 
1      º\par                                  OUTPUT  DATA
1      º\par                                  ============
1      º\par UG-39 (d)(2)
A143   º_\par t{_\sub a}'_\tab = #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab G.{_\field{_\*_\fldinst SYMBOL 214 _\_\f "Symbol" _\_\s 10}}[(1,9.W.h{_\sub g}/S{_\sub ca}.G{_\super 3})].2
A144   º_\par t{_\sub o}'_\tab = #######.##_\tab [mm]_\tab #####.####_\tab [in]_\tab G.{_\field{_\*_\fldinst SYMBOL 214 _\_\f "Symbol" _\_\s 10}}[(C.P/S{_\sub co})+(1,9.Wm1.h{_\sub g}/S{_\sub co}.G{_\super 3})].2
1      º\par 
1      º\par Being t > (t{\sub a}' or t{\sub o}') and d < G{\sub ef}/2 then the opening is self-reinforced.
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par \pard \s15\qj\widctlpar\tx2693\tx5387\tx7371 CONVERSION FACTORS: Mpa\tab =psi.0,006894757      N\tab =lb.4,448222    {\super 0}C\tab =({\super 0}F-32)/1,8
1      º\par                     psi\tab =Mpa.145,0377439   N.mm\tab =lb.in.112,9848 {\super 0}F\tab =({\super 0}C.1,8)+32
1      º\par                      in\tab =mm.25,4           N/mm{\super 2\tab }=psi.0,006894757
1      º\par \pard \s15\qj\widctlpar\tx4536 \fs\fs18 
1      º\par 
1      º\par -Nozzle reinforc.calculation page 1 of 1
0      º\par 

