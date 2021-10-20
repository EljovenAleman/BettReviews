using System;
using System.Collections;
using UnityEngine;

public struct Movie
{

    public string Name { get; }
    public string Year { get; }
    public string ImageUrl { get; }
    public string MinutesLength { get; }

    public string Id { get; }

    public Movie(string name, string date, string imageUrl, string minutesLength, string id)
    {
        Name = name;
        Year = date;
        ImageUrl = imageUrl;
        MinutesLength = minutesLength;
        Id = id;
    }
}


