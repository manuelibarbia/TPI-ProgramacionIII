using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TPIntegradorProgIII.Entities
{
    public class Swimmer : User
    {
        // public ICollection<Swimmer> Swimmers { get; set; } un usuario va a tener un solo swimmer
        public ICollection<Meet> MeetsAttended { get; set; } = new List<Meet>();
        public ICollection<Trial> TrialsAttended { get; set; } = new List<Trial>();
    }
}
