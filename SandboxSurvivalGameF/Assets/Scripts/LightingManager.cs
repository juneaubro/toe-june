using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class LightingManager : MonoBehaviour
{
    //References 
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset preset;
    //Variables
    [SerializeField, Range(0, 24)]
    private float timeOfDay;
    //public Text clockText;
    public Transform player;

    private void Update()
    {
        if (preset == null)
            return;

        if (Application.isPlaying)
        {
            if (player.position.y <= -500)
            {
                timeOfDay += Time.deltaTime * 0.1f;
            }
            else
            {
                timeOfDay += Time.deltaTime * 0.1f;
            }
            
            timeOfDay %= 24; //Clamp between 0-24
            UpdateLighting(timeOfDay / 24f);
            string hour = LeadingZero((int)timeOfDay);
            string minute = LeadingZero((int)((timeOfDay - (int)timeOfDay) * 60));
            //clockText.text = hour + ":" + minute;
        }
        else
        {
            UpdateLighting(timeOfDay / 24f);
        }
    }

    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = preset.fogColor.Evaluate(timePercent);

        if (directionalLight != null)
        {
            directionalLight.color = preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }

    //Try to find a directional light to use if we haven't set one
    private void OnValidate()
    {
        if (directionalLight != null)
            return;

        //Search for lightining tab sun
        if(RenderSettings.sun != null)
        {
            directionalLight = RenderSettings.sun;
        }
        //Search scene for light that fits criteria (directional)
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    directionalLight = light;
                    return;
                }
            }
        }
    }

    string LeadingZero (int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}
