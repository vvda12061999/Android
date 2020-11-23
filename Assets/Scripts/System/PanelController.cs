using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [Header("Add Restaurant")]
    [SerializeField] private Button AddRestaurantButton;
    [SerializeField] private GameObject AddRestaurantPanel;
    [Header("Restaurant List")]
    [SerializeField] private Button RestaurantListButton;
    [SerializeField] private GameObject RestaurantLisPanel;

    private void Awake()
    {
        RestaurantListButton.interactable = false;
        RestaurantLisPanel.SetActive(true);
    }

    private void Start()
    {
        AddRestaurantButton.onClick.AddListener(() =>
        {
            AddRestaurantButton.interactable = false;
            AddRestaurantPanel.SetActive(true);

            RestaurantListButton.interactable = true;
            RestaurantLisPanel.SetActive(false);
        });

        RestaurantListButton.onClick.AddListener(() =>
        {
            AddRestaurantButton.interactable = true;
            AddRestaurantPanel.SetActive(false);

            RestaurantListButton.interactable = false;
            RestaurantLisPanel.SetActive(true);
        });

        LoadRestaurantList.instance.RemovePrefabs();
        LoadRestaurantList.instance.InstantiatePrefabs();
    }
}
