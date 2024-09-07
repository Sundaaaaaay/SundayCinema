namespace SundayCinema.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public int SeatNumber { get; set; }
    public bool IsBooked { get; set; }
    
    public Session Session { get; set; }
}