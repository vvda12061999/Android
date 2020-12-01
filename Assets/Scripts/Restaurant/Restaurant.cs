using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Restaurant 
{
    public int ID;
    public string Name;
    public string RestaurantType;
    public string TimeVisit;
    public int CleanessRating;
    public int ServicesRating;
    public int FoodQualityRating;
    public int OverallRating;
    public string Description;

    public Restaurant(int id, string name, string type, string timeVisit, int overall, int cleaness, int servicesRating,
        int foodQuality, string note)
    {
        this.ID = id;
        this.Name = name;
        this.RestaurantType = type;
        this.TimeVisit = timeVisit;
        this.OverallRating = overall;
        this.CleanessRating = cleaness;
        this.ServicesRating = servicesRating;
        this.FoodQualityRating = foodQuality;
        this.Description = note;
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