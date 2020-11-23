using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SearchBar : MonoBehaviour
{
    [SerializeField] private Dropdown SearchInput;

    private List<Restaurant> tempList;
    private void Start()
    {
        tempList = RestaurantManager.Instance.Restaurants;

        SearchInput.onValueChanged.AddListener((value) =>
        {
            if(value == 0)
            {
                LoadRestaurantList.instance.RemovePrefabs();
                LoadRestaurantList.instance.InstantiatePrefabs();
            }
            else
            {
                LoadRestaurantList.instance.RemovePrefabs();
                RestaurantManager.Instance.LoadJson();

                Debug.Log(SearchInput.options[value].text);
                foreach (var i in Filter(SearchInput.options[value].text))
                {
                    var instance = Instantiate(LoadRestaurantList.instance.RestaurantInstancePrefab, LoadRestaurantList.instance.Parent);
                    RestaurantManager.Instance.LoadRestaurantList(instance, i);
                }
            }
        });
    }
    private List<Restaurant> Filter(string type)
    {
        var list = RestaurantManager.Instance.Restaurants;

        List<Restaurant> displayList = (from item in list
                                        where item.RestaurantType == type
                                        select item).ToList();
        return displayList;
    }
}
