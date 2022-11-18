using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Minta_FW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DI megvalósító osztály példányosítása
            Dolgozo dolgozo = new Dolgozo();

            Felhasznalas felhasznalas = new Felhasznalas(dolgozo); //a felhasználás helye Itt használjuk az interfacet implementáló osztályunkat
            felhasznalas.Feladat(1); //mag a DI hívás
            Console.ReadLine();
        }


        //ez az interface amit használunk ez kell hogy működjön minden
        public interface IDepMinta
        {
             void Muvelet(int id);
        }

        //interface kifejtése, csinálunk egy olyan osztály ami implementája az interfacet amit így át tudunk adni a Felhasználásnak
        public class Dolgozo : IDepMinta
        {
            //Maga a művelet amint az interface leír
            public void Muvelet(int id) 
            {
                Console.WriteLine($"Ez az értéket kaptuk {id.ToString()}");
            }
        }


        //Itt használjuk fel a DI kódot 
        public class Felhasznalas
        {
            //belső interface változó ezt állítjuk be a konstruktorban
            IDepMinta _DependencyValtozo;

            public  Felhasznalas(IDepMinta dependencyValtozo) //Konstruktor befecskendezés, van még metódus és tulajdonság
            {
                _DependencyValtozo = dependencyValtozo;
            }

            //Itt használjuk a máveletet amit valamilyen helyről kapunk majd
            public void Feladat(int id)
            {
                _DependencyValtozo.Muvelet(id);
            }
        }


    }
}
