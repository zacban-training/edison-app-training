using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razor_App.Models;

public class Friendship
{
public int Id { get; set; }
public string UserId { get; set; }
public string FriendId  { get; set; }

public DateTime CreatedDate { get; set; }

public virtual ApplicationUser User { get; set; }
public virtual ApplicationUser Friend { get; set; }
}