using System;
using System.Linq;
using System.Text;

public static class Isogramma
{
    public static bool Verifica(string word)
    {
        word = word.ToLower();
        int i = 1;
        char tmp=' '; //variabile di appoggio
        int lenght1 = 0;

        //creazione di una funzione che ricostruisce la parola rimuovendo i simboli e usando lo strongbuilder
        static void rebuilder(ref string word, ref char tmp) {
            StringBuilder sb = new StringBuilder();
            foreach (string item in word.Split('.', '-', ' ', '"' ,tmp))
                sb.Append(item);
            word = sb.ToString();
        }
        
        // parametri passati per referenza
        rebuilder(ref word, ref tmp);
        lenght1 = word.Length;
        // Il foreach scorre la parola per ogni char presente, poi passa il char alla funzione rebuilder che
        // splitta nuovamente la parola ma questa volta con un parametro diverso: il char assegnato a tmp.
        // se la lunghezza dopo l'esecuzione di rebuilder è diversa dalla lunghezza - i (i viene incrementata a ogni
        // ciclo per tenere traccia dei char rimossi man mano) ritorna falso
        foreach (char item in word)
        {
            tmp = item;
            rebuilder(ref word, ref tmp);
            if (word.Length != lenght1-i)
            {
                return false;
            }
            i++;
        }

        return true;
    }

}
