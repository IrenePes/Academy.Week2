using Academy.Week2.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week2.Library
{
    internal class Queries
    {
        //liste di entità (dati di prova)

        //query
        //Raggruppare i documenti per settore e specificare quanti documenti
        //ci sono per ogni settore.

        public static void MyQueries()
        {
            List<Doc> docs = new List<Doc>() {
            new Book() { Id = 1, Author = "Mario Rossi", Type = (TypeEnum)2,
             Category = CategoryEnum.Economy, Pages = 200, Status = StatusEnum.InLoan,
             Year = 2010},
            new Book() { Id = 2, Author = "Mario Rossi", Type = (TypeEnum)2,
             Category = CategoryEnum.Economy, Pages = 100, Status = StatusEnum.Available,
             Year = 2009},
            new Dvd() { Id = 3, Author = "Marco Bianchi", Type = (TypeEnum)2,
             Category = CategoryEnum.History, Min = 100,
                Status = StatusEnum.Available,Year = 2007},
            };

            List<User> user = new List<User>()
            {
                new User() { Id = 1, Email = "Tizio@gmail.com", Password = "1234",
                 FirstName = "Tizio", LastName = "Caio", Phone = "3332211222",
                 IsAdmin = false}
            };

            List<Loan> loans = new List<Loan>()
            {
                new Loan()
                {
                     Code = "L1",
                     StartDate = new DateTime(2021,12,1),
                     DocId = 1,
                     UserId = 1
                }
            };


            var list = docs.GroupBy(d => d.Category)
                .Select(x => new //x -> chiave CategoryEnum, gruppo di documenti di 
                                 //quella categoria
                {
                    Categoria = x.Key,
                    NumeroDocumenti = x.Count()
                });

            foreach (var item in list)
                Console.WriteLine(item.Categoria + " " + item.NumeroDocumenti);
        }
    }
}
