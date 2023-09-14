using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ripasso___gestione_file
{

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] vettore = new int[100]; //dichiaro l'array rinominato vettore
            int c, n, p;
            bool r = false;
            string file_html = @"sito.html";
            

            do
            {
                Console.WriteLine("inserisci il numero di elementi iniziale dell'array(compreso tra 0 e 25)"); // numero di elementi 
                c = int.Parse(Console.ReadLine()); // assegno il valore in input di c

            } while (c < 0 || c > 25);


            for (byte i = 0; i < c; i++) // ciclo for per l'inserimento degli elementi nell'array
            {
                Console.WriteLine("inserisci l'elemento in poszione " + i); // richiesta inserimento degli elemneti per l'utente
                vettore[i] = int.Parse(Console.ReadLine());
            }

            Console.Clear();



            Console.WriteLine("Scegli un'operazione: ");
            Console.WriteLine(" ");
            Console.WriteLine("R. per ricercare un elemento all'interno dell'array");
            Console.WriteLine(" ");
            Console.WriteLine("C. Cancella un valore in una posizione");
            Console.WriteLine(" ");
            Console.WriteLine("I. Inserisci un numero in una posizione");
            Console.WriteLine(" ");
            Console.WriteLine("U. uscita dal programma ");
            Console.WriteLine(" ");
            Console.WriteLine("V. visualizzare l'array in HTML");



            string scelta = Convert.ToString(Console.ReadLine());

            switch (scelta)
            {
                case "R":
                    Console.WriteLine("Inserisci un numero da cercare:");
                    int numero = Convert.ToInt32(Console.ReadLine());
                    CercaNumero(vettore, numero);
                    break;

                case "C":
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

                case "V": // la stringa è stata scritta sul file
                    Sito(vettore, ref c, file_html);
                    Console.WriteLine("il vettore è stato scritto nel file html");
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
            if (posizione >= 0  && posizione < vettore.Length)
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



        static void Sito(int[] array, ref int indice, string file)
        {

            string s;
            s = "<!DOCTYPE HTML>\r\n <HTML lang=\"it\">\r\n <title\r\n <title> visualizzazione dell'array <\title> \r\n <head>\r\n <body>\r\n <table>\r\n <tr>";
            for (int i = 0; i < indice; i++)
            {
                s += $"<td>{array[i]}<\td>";
                
            }
            using (StreamWriter sw = new StreamWriter(file)) // stream writer non va chiuso perchè viene attivato soltanto qua. ti scrive la stringta s nel file che abbiamo messo in html così si potrà vedere direttamente da browser
            {
                sw.WriteLine(s); // scrive il codice html sulla riga 
            }
        }

    }
}
