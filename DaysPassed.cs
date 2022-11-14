using UdonSharp;
using UnityEngine;
using TMPro;
using System;
using VRC.SDKBase;
using VRC.Udon;

public class DaysPassed : UdonSharpBehaviour
{
    [SerializeField] int _start;
    TextMeshPro mText;
    private double epochStart;
    private double timestamp;
    private double difference;
    private double days;
    void Start()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        var difference = (timestamp - _start);
        var days = (difference / 86400);
        TextMeshPro mText = GetComponent<TextMeshPro>();
        mText.text = "Day " + Math.Round(days);

    }
}
