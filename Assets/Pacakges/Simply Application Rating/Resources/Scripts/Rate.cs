using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UI;



// mailFrom must be Gmail or you have to change smtpServer properties to your mail provider
// mailFrom must have enabled "Allow less secure applications" in google account and I recommend use for it new mail account for safety
// https://myaccount.google.com/lesssecureapps
// mailTo can be from any mail provider


public class Rate : MonoBehaviour {

    [Header("Variables")]
    public int rated;

    [Header("References")]
    // PanelAppRating
    public Button[] starButton;
    public void Init(int gameOpenCounter)
    {

        rated = 0;
        RateApplication(0);
    }
    public void GetRate(int rate)
    {
        rated = rate;

        for (int i = 0; i < rate; i++)
        {
            foreach (Transform t in starButton[i].transform)
            {
                t.gameObject.SetActive(false);
                starButton[i].transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    public void RateApplication(int rate)
    {
        rated = rate;

        // enable stars equal than user rated
        for (int i = 0; i < rate; i++)
        {
            foreach (Transform t in starButton[i].transform)
            {
                t.gameObject.SetActive(true);
                starButton[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }

        // enable stars greater than user rated
        for (int i = rate; i < starButton.Length; i++)
        {
            foreach (Transform t in starButton[i].transform)
            {
                t.gameObject.SetActive(false);
                starButton[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    public void AcceptRating()
    {
        // analytics rating
        AnalyticsManager.ReportRateApp(rated);
    }


}
