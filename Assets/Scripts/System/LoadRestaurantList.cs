using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadRestaurantList : MonoBehaviour
{
    public static LoadRestaurantList instance;

    public GameObject RestaurantInstancePrefab;
    public Transform Parent;
    [Space]
    [SerializeField] private Button RestaurantListButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        RestaurantListButton.onClick.AddListener(() =>
        {
            RemovePrefabs();
            InstantiatePrefabs();
        });
    }

    public void RemovePrefabs()
    {
        foreach (Transform i in Parent.transform)
        {
            Destroy(i.gameObject);
        }
    }

    public void InstantiatePrefabs()
    {
        RestaurantManager.Instance.LoadJson();
        foreach (var i in RestaurantManager.Instance.Restaurants)
        {
            var instance = Instantiate(RestaurantInstancePrefab, Parent);
            RestaurantManager.Instance.LoadRestaurantList(instance, i);
        }
    }
}
