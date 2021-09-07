using System;
using System.Collections;
using UnityEngine;

public struct Movie
{

    public string Name { get; }
    public DateTime Date { get; }
    public string ImageUrl { get; }
    public int MinutesLength { get; }

    public string Id { get; }

    public Movie(string name, DateTime date, string imageUrl, int minutesLength, string id)
    {
        Name = name;
        Date = date;
        ImageUrl = imageUrl;
        MinutesLength = minutesLength;
        Id = id;
    }
}


