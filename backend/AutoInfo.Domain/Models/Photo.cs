using System;

namespace AutoInfo.Domain.Models
{
    public class Photo
    {
        public Guid Id { get; set; }
        public byte[] Value { get; set; }
        
        public string? Description { get; set; }
    }
}