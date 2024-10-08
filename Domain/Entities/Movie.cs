﻿using Domain.Enums;

namespace Domain.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public MovieGenre Genre { get; set; }
    
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}