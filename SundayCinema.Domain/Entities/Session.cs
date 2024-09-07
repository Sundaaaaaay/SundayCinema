namespace SundayCinema.Domain.Entities;

public class Session
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MovieId { get; set; }
    public int CinemaHallId { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    
    public CinemaHall CinemaHall { get; set; }
    public Movie Movie { get; set; }

    public Session()
    {
        Tickets = new List<Ticket>();
    }
}