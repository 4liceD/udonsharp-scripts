
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class Intensity : UdonSharpBehaviour
{
    public LTCGI_UdonAdapter ltcgi;
    public GameObject ltcgiEmitter;
    int screenIndex;
    float intensityValue = 1.0f;
    MaterialPropertyBlock propertyBlock;
    Renderer EmissionRenderer;
    Color screenColor;
    Color screenUpdate;
    public Slider intensitySlider;
    void Start()
    {
        screenIndex = ltcgi._GetIndex(ltcgiEmitter);
        EmissionRenderer = ltcgiEmitter.GetComponent<MeshRenderer>();
        propertyBlock = new MaterialPropertyBlock();
        screenColor = ltcgi._GetColor(screenIndex);
    }
    public void _OnValueChange()
    {
        screenUpdate = screenColor * intensitySlider.value;
        ltcgi._SetColor(screenIndex, screenUpdate);
        EmissionRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_EmissionColor", screenUpdate.gamma);
        EmissionRenderer.SetPropertyBlock(propertyBlock);
    }
}
