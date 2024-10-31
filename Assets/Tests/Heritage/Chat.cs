using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{
    public class Chat : Animal
    {
        private int _pattes = 4;

        private bool _ateFish;

        public int Pattes { get => _pattes; set =>_pattes = value; }

        private string _name;

        public Chat(string name) : base(name)
        {
        }

        public event Action OnDie;

        public void Die()
        {
            OnDie?.Invoke();
        }

        public override string Crier()
        {
            if (_isHungry)
            {
                return "Miaou (j'ai faim)";

            }
            else
            {
                if (_ateFish) return "Miaou (Le poisson etait bon)";

                return "Miaou (c'est bon laisse moi tranquille humain)";
            }
        }

        public override void Welcome(Animalerie animalerie)
        {
            foreach(var a in animalerie.Animal)
            {
                if (a is Poisson)
                {
                    tryEatFish(a);
                }
            }

            animalerie.OnAddAnimal += tryEatFish;


        }

        private void tryEatFish(Animal a)
        {
            if(a is Poisson)
            {
                a.Die();
                Feed();
                _ateFish = false;
            }
        }
    }
}
