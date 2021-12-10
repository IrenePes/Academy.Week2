//Si vuole progettare un sistema per la gestione di una biblioteca. 

//I documenti in biblioteca sono caratterizzati da id, codice identificativo 
//di tipo stringa (ISBN per i libri, numero seriale per i DVD), 
//titolo, autore, anno, settore(storia, matematica, economia, …),
//stato (In Prestito, Disponibile), tipo (DVD, libro).
//Per i libri si ha in aggiunta il numero di pagine,
//mentre per i dvd la durata. 

//Immaginare di voler salvare i record in un'unica tabella documenti.

//L'utente del sistema è caratterizzato da:
//- codice 
//- nome 
//- cognome
//- email 
//- password
//- recapito telefonico
//- flag admin/non admin

//All'accesso al programma, l'utente può autenticarsi
//con email e password o registrarsi.  
//In base al tipo di utente (amministratore/non)
//vedrà il menu corrispondente.
//Se non è un utente registrato, si supppone sia un 
//utente non ammnistratore. 

//Gli utenti AMMINISTRATORI possono:
//- aggiungere nuovi documenti 

//Gli utenti NON AMMINISTRATORI possono: 
//- registrarsi al sistema, fornendo tutti i dati.
//Amministratore = false;
//Il sistema per ogni nuovo utente genera un codice cliente.

//- eseguire ricerche per codice ISBN o numero seriale e 
//effettuare dei prestiti di documenti (libri o DVD), solo se disponibili. 

//- restituire un documento (data di fine prestito = data del giorno)

//Il sistema per ogni nuovo prestito determina un numero
//PROGRESSIVO di tipo alfanumerico. 

//Il prestito è caratterizzato, quindi, dal numero progressivo,
//dalla data di inizio e dalla data di fine
//e dal riferimento al documento e all'utente.
//Per ogni nuovo prestito, la data di fine è null.

//Aggiungere eventuali entità utili.

using Academy.Week2.Library;

Queries.MyQueries();