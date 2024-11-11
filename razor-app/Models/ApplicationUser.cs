using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Razor_App.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        public string City {get; set;} = string.Empty;
        public string Municipal {get; set;} = string.Empty;

        public virtual ICollection<Friendship> Friendships { get; set; }

        public virtual ICollection<Friendship> FriendOf { get; set; }
    }
}