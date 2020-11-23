using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicScroll : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollView;
    [SerializeField] GameObject scrollContain;

    private void Start()
    {
        scrollView.verticalNormalizedPosition = 1;
    }
}
