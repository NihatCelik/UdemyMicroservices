namespace FreeCourse.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
