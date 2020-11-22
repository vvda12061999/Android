using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Restaurant 
{
    public int ID;
    public string Name;
    public RestaurantType RestaurantType;
    public DateTime TimeVisit;
    public int OverallRating;
    public int CleanessRating;
    public int FoodQualityRating;
    public string Note;
    public Reporter Reporter;

    public void AddRestaurant(int id, string name, RestaurantType type, DateTime timeVisit, int overall, int cleaness,
        int foodQuality, string note, Reporter reporter)
    {
        this.ID = id;
        this.Name = name;
        this.RestaurantType = type;
        this.TimeVisit = timeVisit;
        this.OverallRating = overall;
        this.CleanessRating = cleaness;
        this.FoodQualityRating = foodQuality;
        this.Note = note;
        this.Reporter = reporter;
    }
}

[System.Serializable]
public class RestaurantType
{
    public List<Type> Types;

    public void AddType(string type)
    {
        var i = Types.Count - 1;

        Types.Add(new  Type(i, type));
    }
}

[System.Serializable]
public class Type
{
    public int ID;
    public string RestaurantType;

    public Type(int id, string type)
    {
        this.ID = id;
        this.RestaurantType = type;
    }
}