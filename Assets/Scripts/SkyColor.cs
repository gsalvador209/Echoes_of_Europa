using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyColorUpdater : MonoBehaviour
{
    public Material planetMaterial; // Material con tu shader personalizado
    public Material skyboxMaterial;
    public Light directionalLight; // Material del Skybox

    void Update()
    {
        float angle = directionalLight.transform.rotation.eulerAngles.x;

        float blendFactor = Mathf.InverseLerp(0, 180, angle);

        Color dynamicSkyColor = Color.Lerp(Color.black, skyboxMaterial.GetColor("_SkyTint"), blendFactor);

        planetMaterial.SetColor("_SkyColor", dynamicSkyColor);

    }
}
