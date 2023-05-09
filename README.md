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

### Funzione Verifica
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
Dopo la dichiarazione e l'inizializzazione delle variabili viene chiamata una prima volta la funzione rebuilder (vedi <a href="#F">qui</a> per maggiori dettagli

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
Una volta splittata la stringa essa viene ricostruita tramite l'uso di uno <b>StringBuilder</b>.




La soluzione qua pubblicata prevede prima di tutto di portare la stringa in input tutta a caratteri minuscoli usanto la funzione <b>.ToLower();</b> della classe string di C#.
Una volta che la stringa contiene solo simboli e/o caratteri minuscoli verrà passata ad una funzione <b>rebuilder</b> il cui scopo è splittare, dividere la stringa secondo dei determinati parametri, per poi ricostruirla (per maggiori informazioni, vedi sotto).
Il controllo che verifica che la parola sia o non sia un isogramma avviene tramite un costrutto iterativo <b>foreach</b> che si occupa di ciclare ogni carattere della stringa e passarlo alla funzione rebuilder come nuovo parametro dello split.
Dopo ogni chiamata alla funzione rebuilder viene controllato che la lunghezza della nuova stringa sia uguale alla lunghezza iniziale (lenght1) - i, e, se non è uguale, significa che la funzione ha rimosso più di un carattere e che c'era una lettera ripetuta: in questo caso, la funzione ritorna falso, altrimenti, se arriva alla fine del ciclo, ritorna vero.
