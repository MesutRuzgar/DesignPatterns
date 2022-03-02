using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee mesut = new Employee { Name="Mesut"};
            Employee umut = new Employee { Name = "Umut" };
            Employee idris = new Employee { Name = "İdris" };
            Employee ahmet = new Employee { Name = "Ahmet" };

            //mesutun alt çalışanı umut diye ekledik
            //alt çalışan eklemeye yarıyor
            mesut.AddSubordinate(umut);
            mesut.AddSubordinate(idris);
            umut.AddSubordinate(ahmet);

            Conctractor ali = new Conctractor { Name = "Ali" };

            idris.AddSubordinate(ali);

            Console.WriteLine(mesut.Name);
            foreach (Employee manager in mesut)
            {
                Console.WriteLine("  {0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    {0}",employee.Name);
                }
            }
            Console.ReadLine();
        }
    }
    interface IPerson
    {
         string Name { get; set; }
    }
    class Conctractor : IPerson
    {
        public string Name { get ; set ; }
    }
    class Employee : IPerson,IEnumerable<IPerson>
    {
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }
        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }
        public string Name { get ; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
