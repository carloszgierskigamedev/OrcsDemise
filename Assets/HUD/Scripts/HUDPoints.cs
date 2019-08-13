using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDPoints : MonoBehaviour
{
    public int points;

    [SerializeField]
    private TextMeshProUGUI pointsText;

    void Start()
    {
        points = 0;
    }

    void Update()
    {
        pointsText.text = ("Points: " + points);
    }
}
