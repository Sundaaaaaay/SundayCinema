namespace Application.Dtos;

public class CreateSessionDto
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public int TotalSeats { get; set; }
}