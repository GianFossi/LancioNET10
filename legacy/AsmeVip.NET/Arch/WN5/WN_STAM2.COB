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
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par    -Nozzle reinforc.calculation page 1 of 2
1      º\pard\plain \s18\qj\widctlpar\tx2835 \f2\fs18\lang1040 
S      º_\tab \                        \
s      º\par \tab ==========================
T      º_\par  \  \ * \                                        \ rev.\ \ (Date: \         \) *
1      º\par 
1      º\par 
1      º\par                                  OUTPUT  DATA
1      º\par                                  ============
1      º\par 
1      º\par UG-39 (b)
1      º\par 
1      º\pard\plain \s18\qj\widctlpar\tx709\tqr\tx2268\tx2410\tqr\tx4536\tx4678\tx5670 \f2\fs18\lang1040 
A145   º_\par A{_\sub a}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab 0,5.d.t{_\sub ra}
A146   º_\par A{_\sub o}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab 0,5.d.t{_\sub ro}
A147   º_\par t{_\sub rn}_\tab =_\tab #########.##_\tab [mm]_\tab #######.####_\tab [in]_\tab [P.d/2]/[S{_\sub no} - 0,6.P]
A148   º_\par h_\tab =_\tab #########.##_\tab [mm]_\tab #######.####_\tab [in]_\tab min[(2,5.t),(2,5.t{_\sub n})]
A149   º_\par l_\tab =_\tab #########.##_\tab [mm]_\tab #######.####_\tab [in]_\tab max[d;(d/2+t{_\sub n}+t)]
A150   º_\par H_\tab =_\tab #########.##_\tab [mm]_\tab #######.####_\tab [in]_\tab h adopted (limits of reinf.nozzle)
A151   º_\par L_\tab =_\tab #########.## _\tab[mm]_\tab #######.####_\tab [in]_\tab l adopted (limits of reinf.cover)
1      º\par 
E152   º_\par j{_\sub a}_\tab =_\tab #####.######_\tab _\tab _\tab _\tab (S{_\sub ca}/S{_\sub na}) if j{_\sub a} < 1 then j{_\sub a} = 1
E153   º_\par j{_\sub o}_\tab =_\tab #####.######_\tab _\tab _\tab _\tab (S{_\sub co}/S{_\sub no}) if j{_\sub o} < 1 then j{_\sub o} = 1
1      º\par 
A154   º_\par A{_\sub 1o}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab (L-d/2).(t - t{_\sub ro})
A155   º_\par A{_\sub 2o}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab H.(t{_\sub n} - t{_\sub rn})/j{_\sub o}
A156   º_\par A{_\sub 1a}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab (L-d/2).(t - t{_\sub ra})
A157   º_\par A{_\sub 2a}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab (H.t{_\sub n})/j{_\sub a}
A158   º_\par A{_\sub Ro}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab A{_\sub o} - (A{_\sub 1o}+A{_\sub 2o}).2
A159   º_\par A{_\sub Ra}_\tab =_\tab #########.##_\tab [mm{_\super 2}]_\tab #######.####_\tab [in{_\super 2}]_\tab A{_\sub a} - (A{_\sub 1a}+A{_\sub 2a}).2
1      º\par 
1      ºSince A{\sub Ro} < 0 and A{\sub Ra} < 0, the opening is adequately reinforced
1      º\par 
1      º\par 
1      º\par \pard \s18\qj\widctlpar\tx2693\tx5387\tx7371 CONVERSION FACTORS: Mpa\tab =psi.0,006894757      N\tab =lb.4,448222    {\super 0}C\tab =({\super 0}F-32)/1,8
1      º\par                     psi\tab =Mpa.145,0377439   N.mm\tab =lb.in.112,9848 {\super 0}F\tab =({\super 0}C.1,8)+32
1      º\par                      in\tab =mm.25,4           N/mm{\super 2\tab }=psi.0,006894757
1      º\par \pard \s18\qj\widctlpar\tx4536
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par 
1      º\par    -Nozzle reinforc.calculation page 2 of 2
0      º\par 

