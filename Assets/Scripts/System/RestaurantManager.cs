using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class RestaurantManager : Singleton<RestaurantManager>
{
    public List<Restaurant> Restaurants;

    private string folderPath = "";

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
   
    public void SaveJson()
    {
        using (StreamWriter file = File.CreateText(@folderPath + "Data.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, Restaurants);
        }
    }
    private void LoadJson()
    {
        string lJson = File.ReadAllText(@folderPath + "Data.json");
        var _l = JsonConvert.DeserializeObject <List<Restaurant>> (lJson);
        Restaurants = _l;
    }
}
