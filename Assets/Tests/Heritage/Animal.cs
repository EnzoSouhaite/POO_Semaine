using System;
using System.Xml.Linq;

namespace TU_Challenge.Heritage
{

    public abstract class Animal
    {
        string _name;
        protected bool _isHungry;

        public string Name => _name;

        //private bool IsAlive { get; private set; }

        public Animal(string name)
        {
            _name = name;
            _isHungry = true;
        }

        public abstract string Crier();

        public void Feed()
        {
            _isHungry = false;
        }

        public void Die()
        {
            _isHungry = true;
            //IsAlive = false;
        }

        public virtual void Welcome(Animalerie animalerie)
        {
        }
    }
}
