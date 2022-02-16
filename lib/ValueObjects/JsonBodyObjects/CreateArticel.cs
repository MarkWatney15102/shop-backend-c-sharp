namespace Shop_Backend.lib.ValueObjects.JsonBodyObjects
{
    public class CreateArticel
    {
        public string title { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public string userId { get; set; }
        public int active { get; set; }
        public string image { get; set; }
        public float price { get; set; }
        public float shippingCoast { get; set; }
    }
}
