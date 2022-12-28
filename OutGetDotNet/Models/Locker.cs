using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutGetDotNet.Models
{
    public class Locker
    {

        public int LockerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public ICollection<Shipment> FromLockerDelivery { get; set; } = new List<Shipment>();
        public ICollection<Shipment> ToLockerDelivery { get; set; } = new List<Shipment>();
    }
}
