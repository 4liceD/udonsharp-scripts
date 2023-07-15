
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class intensitySynced : UdonSharpBehaviour
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
    [UdonSynced] float syncedValue = 1.0f;
    void Start()
    {
        screenIndex = ltcgi._GetIndex(ltcgiEmitter);
        EmissionRenderer = ltcgiEmitter.GetComponent<MeshRenderer>();
        propertyBlock = new MaterialPropertyBlock();
        screenColor = ltcgi._GetColor(screenIndex);
    }
    public void OnValueChange()
    {
        if (!Networking.IsOwner(Networking.LocalPlayer, gameObject)) Networking.SetOwner(Networking.LocalPlayer, gameObject);
        syncedValue = intensitySlider.value;
        screenUpdate = screenColor * intensitySlider.value;
        ltcgi._SetColor(screenIndex, screenUpdate);
        EmissionRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_EmissionColor", screenUpdate.gamma);
        EmissionRenderer.SetPropertyBlock(propertyBlock);
    }
    public override void OnDeserialization()
    {
        intensitySlider.SetValueWithoutNotify(syncedValue);
        screenUpdate = screenColor * intensitySlider.value;
        ltcgi._SetColor(screenIndex, screenUpdate);
        EmissionRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetColor("_EmissionColor", screenUpdate.gamma);
        EmissionRenderer.SetPropertyBlock(propertyBlock);
    }
}
