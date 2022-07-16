using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_WebApp.Models
{
  public class Actor
  {
    public string ActorID { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }
    public virtual IList<MovieActor> MovieActors { get; set; }
  }
}
