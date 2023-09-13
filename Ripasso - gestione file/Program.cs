using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ripasso___gestione_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vettore = { 210, 1, 2, 3, 4, 89, 30, 57, 98, 5, 6, 7, 8, 9, 10 }; //dichiaro l'array rinominato vettore

            Console.WriteLine("Scegli un'operazione:");
            Console.WriteLine(" ");
            Console.WriteLine("C. Cerca un numero");
            Console.WriteLine(" ");
            Console.WriteLine("R. Cancella un valore in una posizione");
            Console.WriteLine(" ");
            Console.WriteLine("I. Inserisci un numero in una posizione");
            string scelta = Convert.ToString(Console.ReadLine());

            Console.Clear();


            switch (scelta)
            {
                case "C":
                    Console.WriteLine("Inserisci un numero da cercare:");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    CercaNumero(vettore, numero);
                    break;

                case "R":
                    Console.WriteLine("Inserisci la posizione del valore da cancellare:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    CancellaValore(vettore, index);
                    break;
                    
                case "I":
                    Console.WriteLine("Inserisci un numero:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Inserisci la posizione in cui vuoi inserire il valore:");
                    int posizione = Convert.ToInt32(Console.ReadLine());
                    InserisciNumero(vettore, num, posizione);
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            Console.ReadLine();
        }

        static void CercaNumero(int[] vettore, int numero)
        {
            for (int i = 0; i < vettore.Length; i++)
            {
                if (numero == vettore[i])
                {
                    Console.WriteLine("Il numero è stato trovato nella posizione: " + i);
                    return;
                }
            }
            Console.WriteLine("-1");
        }

        static void CancellaValore(int[] vettore, int index)
        {
            if (index >= 0 && index < vettore.Length)
            {
                for (int i = index; i < vettore.Length - 1; i++)
                {
                    vettore[i] = vettore[i + 1];
                }
                Array.Resize(ref vettore, vettore.Length - 1);
                Console.WriteLine("Valore cancellato");
                for (int i = 0; i < vettore.Length; i++)
                {
                    Console.Write(vettore[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("La posizione non è valida");
            }
        }

        static void InserisciNumero(int[] vettore, int num, int posizione)
        {
            if (posizione >= 0 && posizione < vettore.Length)
            {
                for (int i = vettore.Length - 1; i > posizione; i--)
                {
                    vettore[i] = vettore[i - 1];
                }
                vettore[posizione] = num;
                Console.WriteLine("Valore inserito");
                for (int i = 0; i < vettore.Length; i++)
                {
                    Console.Write(vettore[i] + " ");
                }
            }
            else
            {
                Console.WriteLine("La posizione non è valida");
            }
        }
    }
}
