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
### La funzione CheckNumber() 
