
using UdonSharp;
using UnityEngine;
using TMPro;
using System;
using VRC.SDKBase;
using VRC.Udon;

public class DaysCountdown : UdonSharpBehaviour
{
    [SerializeField] int _stop;
    TextMeshPro mText;
    private double epochStart;
    private double timestamp;
    private double difference;
    private double days;
    void Start()
    {
        var epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        var timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;
        var difference = (_stop - timestamp);
        var days = (difference / 86400);
        TextMeshPro mText = GetComponent<TextMeshPro>();
        mText.text = Math.Round(days) + " Days left";

    }
}
