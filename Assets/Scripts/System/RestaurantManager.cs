using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class RestaurantManager : Singleton<RestaurantManager>
{
    public List<Restaurant> Restaurants;
    
    [HideInInspector] public string folderPath = "";

    private void Awake()
    {
        folderPath =
            (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer
                ? Application.persistentDataPath
                : Application.dataPath) + "/Resources/";

        if (File.Exists(folderPath + "Data.json"))
        {
            LoadJson();
        }
    }

    public void SaveRestaurant(Restaurant restaurant)
    {
        Restaurants.Add(restaurant);
        SaveJson();
    }
    public void LoadRestaurantList(GameObject prefab, Restaurant restaurant)
    {
        var instance = prefab.GetComponent<RestaurantInstance>();
        instance.Name.text = restaurant.Name;
        instance.Type.text = restaurant.RestaurantType;
        instance.Cleaness.GetRate(restaurant.CleanessRating);
        instance.Services.GetRate(restaurant.ServicesRating);
        instance.Food.GetRate(restaurant.FoodQualityRating);
        instance.Overall.GetRate(restaurant.OverallRating);
        instance.Description.text = restaurant.Description;
    }

    public void SaveJson()
    {
        using (StreamWriter file = File.CreateText(@folderPath + "Data.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, Restaurants);
        }
    }
    public void LoadJson()
    {
        string lJson = File.ReadAllText(@folderPath + "Data.json");
        var _l = JsonConvert.DeserializeObject <List<Restaurant>> (lJson);
        Restaurants = _l;
    }
}
