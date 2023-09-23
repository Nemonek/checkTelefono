# Check Telefono

Lo scopo di questo programma è ricevere in input un array di stringhe che rappresentano dei numeri di telefono e ritornare il primo numero di cellulare italiano valido.<br>
I parametri per far sì che un numero sia valido sono che:
* può iniziare con +39 e deve essere lungo 13 caratteri;
* può iniziare con 0039 (equivalente di +39) ed il numero deve essere composto da 14 caratteri;
* con o senza prefisso deve iniziare con 3.
* La lunghezza minima del numero è 10 caratteri (il numero senza prefisso internazionale);
* il numero non deve per nessuna ragione avere, in nessun punto, un carattere diverso da un numero, a parte il + nel caso del prefisso +39. <br>

Per esempio: 
se l'input è un array contenente "05417373", "3367726712",  "778823" bisogna ritornare "3367726712".
