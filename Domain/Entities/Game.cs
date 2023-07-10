using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Game : EntityBase
{
	public string Name { get; set; }
	public string DevStudio { get; set; }
	public IList<Genre> Genres { get; set; } = new List<Genre>();

}