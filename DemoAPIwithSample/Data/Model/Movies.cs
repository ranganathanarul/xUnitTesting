using System.ComponentModel.DataAnnotations;
using System;

namespace DemoAPIwithSample.Model
{
    public class Movies
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Director { get; set; }
        public string Description { get; set; }
    }
}
