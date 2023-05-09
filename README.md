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
Questa soluzione si basa sul semplice fatto che splittando la stringa, ogni volta, con un suo char fino alla fine, se non ci sono ripetizioni di lettere, la sua lunghezza diminuirà sempre di 1 alla volta, e, in caso contrario, cioè se la lunghezza diminuisse di più di uno, una lettera si sarebbe ripetuta, e la parola non sarebbe palindroma.
Nel


La soluzione qua proposta si basa sull'uso di una funzione (rebuilder) che, tramite la funzione <b>.Split(); </b> divide la stringa in base a dei parametri, poi, la ricostruisce: una volta che la stringa in input è ripulita da simboli e spazi il programma entra in un ciclo foreach ed invia alla funzione rebuilder l'input ripulito (word) ed un char memorizzato nella variabile temporanea <b>tmp</b>, che verrà poi utilizzato come parametro per la funzione Split. Una volta ricevuta la stringa splittata secondo il char, viene fatto un confronto tra la nuova lunghezza e la lunghezza iniziale - una variabile contatore i, che tiene conto di quante lettere sono state rimosse fino a quel momento.
Se la nuova lunghezza è uguale alla lunghezza iniziale - i, allora il ciclo continua, altrimenti la funzione si interrompe e ritorna falso.

La soluzione qua pubblicata prevede prima di tutto di portare la stringa in input tutta a caratteri minuscoli usanto la funzione <b>.ToLower();</b> della classe string di C#.
Una volta che la stringa contiene solo simboli e/o caratteri minuscoli verrà passata ad una funzione <b>rebuilder</b> il cui scopo è splittare, dividere la stringa secondo dei determinati parametri, per poi ricostruirla (per maggiori informazioni, vedi sotto).
Il controllo che verifica che la parola sia o non sia un isogramma avviene tramite un costrutto iterativo <b>foreach</b> che si occupa di ciclare ogni carattere della stringa e passarlo alla funzione rebuilder come nuovo parametro dello split.
Dopo ogni chiamata alla funzione rebuilder viene controllato che la lunghezza della nuova stringa sia uguale alla lunghezza iniziale (lenght1) - i, e, se non è uguale, significa che la funzione ha rimosso più di un carattere e che c'era una lettera ripetuta: in questo caso, la funzione ritorna falso, altrimenti, se arriva alla fine del ciclo, ritorna vero.
