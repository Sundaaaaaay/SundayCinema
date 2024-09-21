namespace Domain.Entities;

public class Ticket
{
    public int Id { get; set; }
    public int SessionId { get; set; }
    public string BookedBy { get; set; } = string.Empty;
    public int SeatNumber { get; set; }
    
    public Session Session { get; set; }
}