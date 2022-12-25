﻿using System.ComponentModel.DataAnnotations.Schema;

namespace OutGetDotNet.Models
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public int? SenderId { get; set; }
        public User Sender { get; set; }
        public int? ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}