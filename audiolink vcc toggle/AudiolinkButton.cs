
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;
using VRCAudioLink;
using static VRC.SDKBase.VRCShader;

public class AudiolinkButton : UdonSharpBehaviour
{
    [SerializeField] AudioLink udonAudioLink;
    [SerializeField] Image audiolinkButton;
    [SerializeField] RenderTexture audiolinkTexture;
    [SerializeField] Texture2D fakeAudiolinkTexture;
    bool audiolinkToggle = true;

    public void _AudiolinkToggle()
    {
        audiolinkToggle = !audiolinkToggle;
        if (audiolinkToggle)
        {
            SetGlobalTexture(PropertyToID("_AudioTexture"), audiolinkTexture);
            audiolinkButton.color = Color.green;
        }
        else
        {
            SetGlobalTexture(PropertyToID("_AudioTexture"), fakeAudiolinkTexture);
            audiolinkButton.color = Color.red;
        }
    }
}
