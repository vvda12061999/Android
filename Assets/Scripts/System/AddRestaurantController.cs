using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class AddRestaurantController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Button ImageButton;
    [SerializeField] private Text NameInputField;
    [SerializeField] private Dropdown RestaurantType;
    [SerializeField] private Rate CleanessRating;
    [SerializeField] private Rate ServicesRating;
    [SerializeField] private Rate FoodQualityRating;
    [SerializeField] private Rate OverallRating;
    [SerializeField] private Text Description;
    [SerializeField] private Text ErrorText;
    [SerializeField] private Text SaveText;
    [SerializeField] private Button SaveButton;

    private void Start()
    {
        Init();
        SaveText.gameObject.SetActive(false);
        AddListener();
    }

    private void Init()
    {
        ImageButton.image = null;
        RestaurantType.value = 0;
        CleanessRating.Init(0);
        ServicesRating.Init(0);
        FoodQualityRating.Init(0);
        OverallRating.Init(0);
        Description.text = "";
        ErrorText.gameObject.SetActive(false);
    }

    private void AddListener()
    {
        SaveButton.onClick.AddListener(() =>
        {
            if(CheckNullText(NameInputField) && CheckNullInt(CleanessRating.rated) && CheckNullInt(ServicesRating.rated) &&
               CheckNullInt(FoodQualityRating.rated) && CheckNullInt(OverallRating.rated))
            {
                RestaurantManager.Instance.SaveRestaurant(new Restaurant(
                    RestaurantManager.Instance.Restaurants.Count - 1, NameInputField.text, RestaurantType.options[RestaurantType.value].text,
                    DateTime.Now, OverallRating.rated, CleanessRating.rated, ServicesRating.rated, FoodQualityRating.rated, Description.text,
                    new Reporter()));
                SaveText.gameObject.SetActive(true);
                Init();
            }
            else
            {
                Debug.Log("Please Fill all");
            }
        });
    }

    private bool CheckNullText(Text uiText)
    {
        if (string.IsNullOrEmpty(uiText.text))
        {
            ErrorText.gameObject.SetActive(true);
            SaveText.gameObject.SetActive(false);
            return false;
        }
        else
        {
            ErrorText.gameObject.SetActive(false);
            SaveText.gameObject.SetActive(true);
            return true;
        }
    }
    private bool CheckNullInt(int rate)
    {
        if (rate > 0)
        {
            return true;
            SaveText.gameObject.SetActive(true);
            ErrorText.gameObject.SetActive(false);
        }
        else
        {
            SaveText.gameObject.SetActive(false);
            ErrorText.gameObject.SetActive(true);
            return false;
        }
    }
}
