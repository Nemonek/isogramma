using System;
using System.Linq;
using System.Text;

public static class Isogramma
{
    public static bool Verifica(string word)
    {
        word = word.ToLower();
        int LettereRimosse = 1; //Contatore di quante lettere vengono teoricamente rimosse (se non ci sono ripetizioni si rimuove una lettera alla volta)
        int Length = 0;         //Lunghezza della stringa senza simboli e spazi


        
        rebuilder(ref word);    //Prima chiamata alla funzione rebuilder per pulire la stringa da spazi e simboli se presenti
        Length = word.Length;
        
        // Il foreach scorre la parola per ogni char presente, poi passa il char alla funzione rebuilder che
        // splitta nuovamente la parola ma questa volta con un parametro diverso: il char assegnato a tmp.
        // se la lunghezza dopo l'esecuzione di rebuilder è diversa dalla lunghezza - i (i viene incrementata a ogni
        // ciclo per tenere traccia dei char rimossi man mano) ritorna falso
        foreach (char item in word)
        {
            rebuilder(ref word, item);
            if (word.Length != Length-LettereRimosse)
                return false;
            LettereRimosse++;
        }

        return true;
    }

        //Ricostruisce la stringa dopo lo split
        private static void rebuilder(ref string word, char c = ' ') {
            StringBuilder sb = new StringBuilder();
            foreach (string item in word.Split('.', '-', '"' ,c))
                sb.Append(item);
            word = sb.ToString();
        }
}
