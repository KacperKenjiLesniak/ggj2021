using System.Collections;
using System.Collections.Generic;
using MutableObjects.Bool;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class OilLantern : MonoBehaviour
{
    [SerializeField] private float maxOilSeconds = 20f;
    [SerializeField] private float oilSeconds = 20f;
    [SerializeField] private float fullLanternRadius;
    [SerializeField] private float dimmingLightThreshold = 10f;
    [SerializeField] private MutableBool movementActive;

    void Start()
    {
        fullLanternRadius = GetComponent<Light2D>().pointLightOuterRadius;
    }

    void Update()
    {
        if (oilSeconds > 0f)
        {
            oilSeconds -= Time.deltaTime;
        }

        if (oilSeconds < dimmingLightThreshold)
        {
            GetComponent<Light2D>().pointLightOuterRadius = fullLanternRadius * (oilSeconds / dimmingLightThreshold);
            if (Input.GetKey(KeyCode.Space))
            {
                movementActive.Value = false;
                oilSeconds += Time.deltaTime*2;
                if (oilSeconds >= dimmingLightThreshold)
                {
                    oilSeconds = maxOilSeconds;
                    GetComponent<Light2D>().pointLightOuterRadius = fullLanternRadius;
                }
            }
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            movementActive.Value = true;
        }
    }
}
