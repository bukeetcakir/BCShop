namespace BCShop.Entity.Concrete;
using BCShop.Entity.Abstract;

public class Product : BaseEntity
{
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int StockAmount { get; set; }
    public int Quantity { get; set; }
    public bool Popular { get; set; }
    public bool IsActive { get; set; }
    public string Image { get; set; }
    public int CategoryId { get; set; }
    public virtual Category Category {get; set;}

}
