using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hierarchy_of_Needs
{
    public class Needs
    {
        // I шкала	Материальное положение	Подсчитывается сумма по позициям 4, 8, 13
        // II шкала	Потребность в безопасности	Подсчитывается сумма по позициям 3, 6, 10
        // III шкала	Потребность в межличностных связях	Подсчитывается сумма по позициям 2, 5, 15
        // IV шкала	Потребности в уважении со стороны	Подсчитывается сумма по позициям 1, 9, 12
        // V шкала	Потребность в самореализации	Подсчитывается сумма по позициям 7, 11, 14
        public int material, safety, connections, respect, realisation;
    }
}
