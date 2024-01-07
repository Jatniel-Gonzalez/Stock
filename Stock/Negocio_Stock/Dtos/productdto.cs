namespace Stock.Models.Dtos
{
    public class productdto
    {

        public int IdProduct { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? AmountProduct { get; set; }
        public int IdCategory { get; set; }
        public string? Category_name { get; set; }
        public int idMotion { get; set; }
        public string? TypeMotion { get; set; }
        public DateTime? DateAndTime { get; set; }




    }
}
