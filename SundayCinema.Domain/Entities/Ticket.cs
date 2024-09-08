namespace SundayCinema.Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int SeatId { get; set; }
    public int SessionId { get; set; }
    public bool IsBooked { get; set; }
    public string BookedBy { get; set; } = string.Empty;
    
    public Session Session { get; set; }
}