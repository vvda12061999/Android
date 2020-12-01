using Newtonsoft.Json;
using Proyecto26;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class ServerIntegrate : MonoBehaviour
{    
    public string url = "";

    
    private void Start()
    {
        GetRestaurantList(url);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetRestaurantList(url);
        }
    }

    [System.Serializable]
    public class RestaurantCollection
    {
        public Restaurant[] collection = new Restaurant[0];
    }

    public RestaurantCollection test;
    private void GetRestaurantList(string url)
    {
        RestClient.Get(url).Then(response => {
            var json = response.Text;
            
            
            json.Substring(0, 2);
            Debug.Log(json);
            //test = JsonUtility.FromJson<Restaurant[]>(json);

            test = JsonUtility.FromJson<RestaurantCollection>(json);
        });
    }
}

public static class IPGetter
{
    public static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }
        return localIP;
    }
}
