using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace OutGetDotNet.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<Shipment> SentShipments { get; set; } = new List<Shipment>();
        public ICollection<Shipment> ReceivedShipments { get; set; } = new List<Shipment>();
    }
}
