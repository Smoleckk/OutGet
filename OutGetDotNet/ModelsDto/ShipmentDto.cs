using OutGetDotNet.Models;

namespace OutGetDotNet.ModelsDto
{
    public class ShipmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
    }
}
