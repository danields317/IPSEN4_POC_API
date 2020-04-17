using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProfileData.Models
{
    public class Profile
    {
        [Key]
        public int profile_id { get; set; }
        [Required]
        public string first_name { get; set; }
        public bool enabled { get; set; }

    }
}
