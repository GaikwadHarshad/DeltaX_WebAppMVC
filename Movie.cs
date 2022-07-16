using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeltaX_WebApp.Models
{
  public class Movie
  {
    public string MovieID { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Name { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfRelease { get; set; }

    [StringLength(60, MinimumLength = 3)]
    public string Producer { get; set; }
    public virtual IList<MovieActor> MovieActors { get; set; }
  }
}
