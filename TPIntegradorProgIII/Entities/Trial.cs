using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPIntegradorProgIII.Entities
{
    public class Trial
    {
        public int TrialID { get; set; }
        public int Distance { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string Style { get; set; }
        List<Trial> Times = new List<Trial>();
    }
}
