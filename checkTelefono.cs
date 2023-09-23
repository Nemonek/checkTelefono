using System;
using System.Collections.Generic;

public static class Telefono
{

    public static string Check(string[] input)
    {
        // Per evitare spreco di risorse si controlla se l'array è vuoto
        if( input.Length == 0 )
            return "";

        foreach (string number in input)
            if (CheckNumber(number))
                return number;
    
        return "";
    }

    static bool CheckNumber(string numberToCheck) {
    
        int l = numberToCheck.Length;

        // Un numero è considerato valido per l'elaborazione solo se la lunghezza è 10, 13 o 14
        if ( l != 10 && l != 14 && l != 13 )
            return false;

        // I caratteri nella stringa possono essere solo i numeri da 0(48) a 9(57) ed il carattere +(43): se c'è un altro il numero viene subito escluso.
        foreach (char c in numberToCheck)
            if ((c < 48 || c > 57) && c != 43 )
                return false;


        if (l > 10)
        {
            // I controlli della lunghezza vengono rifatti per evitare casi tipo 0039323456789 dove il prefisso è corretto, ma manca un numero: passa quindi tutti i controlli della lunghezza
            // e passerebbe anche controlli basati solo sulle prime 4 cifre.
            // La stessa cosa vale per casi del tipo +3932345678911 dove c'è un numero di troppo, quindi 14 caratteri ma il numero inizia con +39.
            if (l == 14 && numberToCheck[..4] == "0039") {  // Non vengono rimosse direttamente le prime 4 cifre per evitare che qualcuno scriva qualcosa tipo 6639
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
        }

        // Siccome la lunghezza non è maggiore di 10, e grazie ad un controllo fatto sopra non è neanche minore, dovrebbe essere un numero senza prefisso internazionale, e viene
        // quindi controllata la prima cifra. 
        if (numberToCheck[0] == '3')
            return true;

        return false;
    }
}