using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeltaX_WebApp.Models
{
  public class MovieActor
  {
    public string MovieId { get; set; }
    public Movie Movie { get; set; }
    public string ActorId { get; set; }
    public Actor Actor { get; set; }
  }
}
