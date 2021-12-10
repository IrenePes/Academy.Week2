namespace Academy.Week2.Library.Entities
{
    public class Doc
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public CategoryEnum Category { get; set; }
        public StatusEnum Status { get; set; }
        public TypeEnum Type { get; set; }
    }

    public enum TypeEnum
    {
        DVD = 1,
        Book = 2
    }
    public enum StatusEnum
    {
        InLoan = 1,
        Available = 2
    }
    public enum CategoryEnum
    {
        History = 1,
        Math = 2,
        Economy = 3
    }
}
