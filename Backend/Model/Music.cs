using System;
using System.Text.Json.Serialization;

namespace Backend.Model
{
    public class Music
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }

        [JsonIgnore]
        public Album Album { get; set; }
    }
}