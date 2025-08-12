namespace technical_tests_backend_ssr.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class SaveProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
