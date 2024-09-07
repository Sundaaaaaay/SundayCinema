﻿namespace SundayCinema.Domain.Entities;

public class CinemaHall
{
    public int Id { get; set; }
    public int TotalSeats { get; set; }
    public ICollection<Session> Sessions { get; set; }

    public CinemaHall()
    {
        Sessions = new List<Session>();
    }
}