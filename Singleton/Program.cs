using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
           var customerManager = CustomerManager.CreateAsSingleton();
            customerManager.Save();
        }

        class CustomerManager
        {
            static CustomerManager _customerManager;
            static object _lockObject = new object();

            private CustomerManager()
            {
                    
            }

            public static CustomerManager CreateAsSingleton()
            {
                //klasik yöntem
                //if (_customerManager==null)
                //{
                //    _customerManager = new CustomerManager();
                //}
                //return _customerManager;

                //daha pratik bir yöntem
                // return _customerManager ?? (_customerManager = new CustomerManager());

                //customer eklenirken sistemi kitliyoruz ki aynısından 2 adet oluşmasın
                lock (_lockObject)
                {
                    if (_customerManager==null)
                    {
                        _customerManager = new CustomerManager();
                    }
                }
                return _customerManager;
            }
            public  void Save()
            {
                Console.WriteLine("Saved!");
            }
        }
    }
}
