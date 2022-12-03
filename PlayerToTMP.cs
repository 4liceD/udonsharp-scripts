
using UdonSharp;
using TMPro;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class PlayerToTMP : UdonSharpBehaviour
{
    TextMeshPro mText;
    string playerName;
    void Start()
    {
        var playerName = Networking.LocalPlayer.displayName;
        TextMeshPro mText = GetComponent<TextMeshPro>();
        mText.text = playerName;
    }
}
