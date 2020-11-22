using UnityEngine.Analytics;
using UnityEngine;
using System.Collections.Generic;

public class AnalyticsManager : MonoBehaviour {

    public static void ReportRateApp(int stars)
    {
        Analytics.CustomEvent("rate_app", new Dictionary<string, object>
        {
            { "rate_app", stars }
        });
    }
}
