# Check Telefono

## Cosa chiede l'esercizio
Lo scopo di questo programma è ricevere in input un array di stringhe che rappresentano dei numeri di telefono e ritornare il primo numero di cellulare italiano valido.<br>
I parametri per far sì che un numero sia valido sono che:
* può iniziare con +39 e deve essere lungo 13 caratteri;
* può iniziare con 0039 (equivalente di +39) ed il numero deve essere composto da 14 caratteri;
* con o senza prefisso deve iniziare con 3.
* La lunghezza minima del numero è 10 caratteri (il numero senza prefisso internazionale);
* il numero non deve per nessuna ragione avere, in nessun punto, un carattere diverso da un numero, a parte il + nel caso del prefisso +39.

## Esempio
Se l'input è un array contenente "05417373", "3367726712",  "778823" bisogna ritornare "3367726712".

## Struttura della soluzione
La soluzione proposta si compone di 3 elementi principali: un controllo preliminare sulla lunghezza dell'input, un costrutto iterativo foreach che scorre gli elementi contenuti in input, e la funzione 'CheckNumber()' che, chiamata nel foreach sopra menzionato, è incaricata di determinare se il numero in analisi è valido.

## Il codice
La soluzione proposta è strutturate in due parti principali: la prima, che esegue un controllo preliminare sulla lunghezza dell'array in input, per evitare che venga passato un array con 0 elementi: se la lunghezza è di 0 elementi,viene ritornato subito "" interrompendo l'esecuzione della funzione 'Check()'
``` C#
if( input.Length == 0 )
    return "";
```
<br>
E la seconda, dove dopo il controllo precedente, se passato, si entra in un foreach che scorre 1 ad 1 gli elementi del vettore passandoli alla funzione 'CheckNumber()', che, chiamata in un if annidato nel foreach, deve determinare se il numero è valido: se il valore di ritorno è true, il programma entra nell'if e ritorna il numero poiché è stata determinata la sua validità, altrimenti, non fa nulla ed il ciclo continua o fino a che non trova un numero valido, o fino a che non finiscono gli elementi,e, uscendo dal foreach, viene ritornato "".

``` C#
foreach (string number in input)
    if (CheckNumber(number))
        return number;

return "";
```
Per quanto riguarda la funzione 'CheckNumber()', la prima cosa che fa è eseguire un controllo sulla lunghezza del numero: se il numero è lungo 10, 13 o 14 allora si procede con i successivi controlli, altrimenti viene considerato non valido e viene ritornato 'false'.
``` C#
if ( l != 10 && l != 14 && l != 13 )
    return false;
```
Dopo il controllo sulla lunghezza un foreach scorre ogni carattere del numero e controlla che o sia un numero, o sia un + nel caso del prefisso +39: se incontra un char che non sia uno di quelli appena menzionai la funzione ritorna 'false'.
``` C#
foreach (char c in numberToCheck)
    if ((c < 48 || c > 57) && c != 43 )
        return false;
```
Se i primi due controlli sono passati a questo punto si entra in un if, che controlla se la lunghezza è maggiore di 10: se lo è ci sono 3 casi possibili: il numero è lungo 14 ed inizia con '0039', oppure il numero è lungo 13 ed inizia con '+39'; se uno dei due casi sopra è verificato significa che c'è un prefisso, e viene rimosso, in modo che l'ultimo controllo possa controllare se il numero inizia con 3. Nel caso in cui nessuna delle due condizioni sia verificata ritorna falso.
``` C#
    if (l == 14 && numberToCheck[..4] == "0039") {  
        numberToCheck = numberToCheck[4..];
    }
    else if (l == 13 && numberToCheck[..3] == "+39") {         // Come sopra, solo per cose tipo +93
        numberToCheck = numberToCheck[3..];
    }
    else {
        // Serve per evitare casi tipo 33393505050505 cha passerebbe tutti i precedenti controlli in quanto non rispetterebbe le condizioni nei precedenti if;
        // tutela anche i casi sopra indicati.
        return false;
    }
```
NOTA BENE: il numero modificato nella funzione non è il numero ritornato dal programma; quello modificato non è altro che una copia.
<br>
<br>
Nel caso di numeri telefonici lunghi 10 caratteri, il programma non entra nell'if sopra menzionato e va direttamente all'ultimo controllo, che controlla che la cifra iniziale del numero sia 3, e ritorna 'true'; in caso contrario viene ritornato 'false'.

``` C#
if (numberToCheck[0] == '3')
    return true;

return false;
```