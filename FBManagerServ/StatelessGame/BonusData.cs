using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatelessGame
{
    public class BonusData
    {
        public int userid { get; set; }
        public string username { get; set; }
        public int bonusid { get; set; }
        public int bonuscalculate { get; set; }
        public ResultData[] bonusEachRoom { get; set; }
    }
}
