namespace SundayCinema.Application.Dtos;

public class CreateTicketDto
{
    public int SessionId { get; set; }
    public int MovieId { get; set; }
    public string BookedBy { get; set; } = string.Empty;
    public int SeatId { get; set; }
    
}