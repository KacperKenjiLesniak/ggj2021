using System.Collections;
using System.Collections.Generic;
using MutableObjects.Bool;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UIElements;

public class OilLantern : MonoBehaviour
{
    [SerializeField] private float maxOilSeconds = 20f;
    [SerializeField] private float oilSeconds = 20f;
    [SerializeField] private float fullLanternRadius;
    [SerializeField] private float innerLightRadius;
    [SerializeField] private float dimmingLightThreshold = 10f;
    [SerializeField] private float refillSpeed = 2.6f;
    [SerializeField] private MutableBool movementActive;

    private Light2D light;
    private float ratio;
    
    void Start()
    {
        light = GetComponent<Light2D>();
        fullLanternRadius = light.pointLightOuterRadius;
        innerLightRadius = light.pointLightInnerRadius;
        ratio = innerLightRadius / fullLanternRadius;
    }

    void Update()
    {
        if (oilSeconds > 0f)
        {
            oilSeconds -= Time.deltaTime;
        }

        if (oilSeconds < dimmingLightThreshold)
        {
            light.pointLightOuterRadius = fullLanternRadius * (oilSeconds / dimmingLightThreshold);
            if (Input.GetKey(KeyCode.Space))
            {
                movementActive.Value = false;
                oilSeconds += Time.deltaTime * refillSpeed;
                if (oilSeconds >= dimmingLightThreshold)
                {
                    oilSeconds = maxOilSeconds;
                    light.pointLightOuterRadius = fullLanternRadius;
                }
            }

            light.pointLightInnerRadius = ratio * light.pointLightOuterRadius;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            movementActive.Value = true;
        }
    }
}