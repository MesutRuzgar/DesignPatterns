using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();

            Console.ReadLine();
        }
    }
    class Logging:ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged!");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching:ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached!");
        }
    }

     interface ICaching
    {
        void Cache();
    }

    class Authorize:IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User Checked!");
        }
    }

     interface IAuthorize
    {
        void CheckUser();
    }

    class CustomerManager
    {
        //tek tek önceden log aut ve cache newlerdik ve kirli bir görüntü oluşuyordu
        //facade kullanarak hepsini merkezi bir yere aldık var daha temiz kod
        //oluştu.
       private CrossCuttingConcernsFacade _concerns;
       
        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.CheckUser();
            Console.WriteLine("Saved!");
        }

    }
    class CrossCuttingConcernsFacade
    {
        //yeni bir method eklendiğinde buraya eklemek yeterli olucak
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
        }
    }
}
