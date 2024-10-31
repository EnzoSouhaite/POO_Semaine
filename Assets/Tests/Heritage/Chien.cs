using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chien : Animal
    {
        private string _name;

        public Chien(string name) : base(name)
        {
        }

        public override string Crier()
        {
            if (_isHungry)
            {
                return "Ouaf (j'ai faim)";

            }else{

                return "Ouaf (viens on joue ?)";
            }
        }
    }
}
