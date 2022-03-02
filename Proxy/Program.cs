using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            //2side aynı sonuç ama bekletiyor 5 saniye bunu önlemek için
            //proxy oluşturduk ve cacheledik
            //CreditManager manager = new CreditManager();
            //Console.WriteLine(manager.Calculate());
            //Console.WriteLine(manager.Calculate());

            //aynında veriyor sonucu aynı hesaplamayı tekrar yapmıyor
            CreditBase manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());
            Console.ReadLine();
        }
    }
    abstract class CreditBase 
    {
        public abstract int Calculate();
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;
            for (int i = 1; i < 5; i++)
            {
                result *=i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        CreditManager _creditManager;
        int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager==null)
            {
                _creditManager = new CreditManager();
                _cachedValue = _creditManager.Calculate();
            }
            return _cachedValue;
        }
    }
}
