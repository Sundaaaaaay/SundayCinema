namespace Domain.Entities;

public class Session
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public int MovieId { get; set; }
    public int HallId { get; set; }
    public int TotalSeats { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public Movie Movie { get; set; }

    public Session()
    {
        Tickets = new List<Ticket>();
    }
    

    public bool IsFull()
    {
        return Tickets.Count >= TotalSeats;
    }

    public bool IsSeatExist(int seatNumber)
    {
        if (seatNumber < 1 || seatNumber > TotalSeats)
        {
            return false;
        }

        return true;
    }
}