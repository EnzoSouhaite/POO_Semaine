using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge.Heritage
{

    public class Animalerie
    {

        public List<Animal> _animal;

        public List<Animal> Animal => _animal;

        public event Action<Animal> OnAddAnimal;

        public void AddAnimal(Animal a)
        {
            OnAddAnimal?.Invoke(a);
            _animal.Add(a);
        }

        public bool Contains(Animal a)
        {
            return _animal.Contains(a);
        }

        public Animal GetAnimal(int idx)
        {
            return _animal[idx];

        }

        public void FeedAll()
        {
            foreach(var a in _animal)
            {
                a.Feed();
            }
        }
    }
}
