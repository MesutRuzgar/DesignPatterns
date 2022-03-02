using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
   
        static void Main(string[] args)
        {
            var customer = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customer);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customer);
            productManager.UpdatePrice();

            Console.ReadLine();
        }

    }
    class ProductManager
    {
        List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Updated Product Price");
            Notify();
        }
        //listeye eklediğimiz kod
        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        //abolenik iptali
        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        //bilgilendirme
        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    abstract class Observer
    {
        public abstract void Update();
    }
    class CustomerObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer: Product price changed!");
        }
    }
    class EmployeeObserver : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee: Product price changed!");
        }
    }
}
