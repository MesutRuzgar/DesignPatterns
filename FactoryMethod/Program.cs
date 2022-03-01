using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();
            Console.ReadLine();

        }

    }
    public interface ILogger
    {
        void Log();
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new EdLogger();
        }

    }
    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new MrLogger();
        }

    }
    public interface ILoggerFactory
    {
         ILogger CreateLogger();
    }
    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger"); 
        }
    }

    public class MrLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with MrLogger");
        }
    }
    public class CustomerManager
    {
        ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}
