using OutGetDotNet.Models;

namespace OutGetDotNet.ModelsDto
{
    public class AddShipmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
    }
}
