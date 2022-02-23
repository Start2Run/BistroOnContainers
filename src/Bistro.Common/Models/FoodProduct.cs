namespace Bistro.Common.Models;

public record FoodProduct
{
    public string Id { get; init; }
    public string Category { get; set; }
    public byte[] Image { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
}
