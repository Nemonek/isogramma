# Isogramma

### Consegna
Lo scopo di questo esercizio è creare una funzione che determini se una parola è o non è un isogramma: per come lo intendiamo in questo esercizio, un isogramma è una parola o una in cui non vi sono ripetizioni di lettere. <br>
In un isogramma sono ammessi segni di punteggiatura e spazi ripetuti.
Esempi di isogrammi:
* lumberjacks;
* background;
* downstream;
* six-year-old.

Per maggiori informazioni sugli isogrammi, consulta [Isogrammi su wikipedia](https://it.wikipedia.org/wiki/Isogramma).

### Soluzione
Questa soluzione si basa sul semplice fatto che splittando la stringa, ogni volta, con un suo char fino alla fine, se non ci sono ripetizioni di lettere, la sua 
lunghezza diminuirà sempre di 1 alla volta, e, in caso contrario, cioè se la lunghezza diminuisse di più di uno, una lettera si sarebbe ripetuta, e la parola non 
sarebbe palindroma.

### Codice

#### Funzione Verifica
```C#
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
```
In questa funzione la prima cosa che viene fatta è portare tutte le lettere in minuscolo, poi, vengono dichiarate due variabili, la prima (LettereRimosse) fungerà da 
contatore per quante lettere dovrebbero venir rimosse ad ogni ciclo; la seconda servirà per fare il confronto tra la lunghezza della stringa pulita e la lunghezza 
della stringa splittata con una delle sue lettere.
Dopo la dichiarazione e l'inizializzazione delle variabili viene chiamata una prima volta la funzione rebuilder (vedi <a href="#F">qui</a> per dettagli) per ripulire   la stringa da simboli e spazi. <b>Nota bene:</b> la funzione rebuilder accetta due parametri, ma il secondo è facoltativo.
Una volta pulita la stringa si entra in un ciclo <b>foreach</b> che chiama ad ogni ciclo la funzione rebuilder, passandole come parametro, che verrà poi usato nello 
split, uno dei char della parola: dopo che la funzione ha splittato la stringa secondo quel char viene fatto un controllo per determinare se la lunghezza è diminuita 
di più di uno: se è vero, la funzione Verifica ritorna falso. Altrimenti, una volta fuori dal ciclo, ritorna vero. 

#### <a name="F">Funzione rebuilder</a>
```C#
  private static void rebuilder(ref string word, char c = ' ') {
      StringBuilder sb = new StringBuilder();
      foreach (string item in word.Split('.', '-', '"' ,c))
          sb.Append(item);
      word = sb.ToString();
  }
```
Questa funzione chiede un parametro obbligatorio passato per riferimento, poi, chiede un parametro facoltativo, passato per valore, che verrà usato come parametro  
della funzione split.
Una volta splittata la stringa essa viene ricostruita tramite l'uso di uno <b>StringBuilder</b> e la nuova stringa viene sovrascritta alla vecchia.
