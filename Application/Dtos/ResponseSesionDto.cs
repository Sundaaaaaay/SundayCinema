namespace Application.Dtos;

public class ResponseSesionDto
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int CinemaHallId { get; set; }
    public string MovieName { get; set; }
}