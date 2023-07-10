using Domain.Entities.Abstract;

namespace Domain.Entities;

public class Genre : EntityBase
{
	public string Name { get; set; }
	public IList<Game> Games { get; set; } = new List<Game>();
}