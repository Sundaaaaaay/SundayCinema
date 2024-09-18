namespace Domain.Entities;

public class Seat
{
    public int Id { get; set; }
    public int CinemaHallId { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    public CinemaHall CinemaHall { get; set; }
}