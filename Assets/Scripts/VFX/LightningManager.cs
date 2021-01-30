using System.Collections;
using System.Collections.Generic;
using GameEvents.Game;
using GameEvents.String;
using UnityEngine;

public class LightningManager : MonoBehaviour
{

    [SerializeField] private StringGameEvent thunderEvent;
    [SerializeField] private int maxLightningInterval;
    [SerializeField] private Animator animator;
    private int randomNumber;
    [SerializeField] private float xPosLimit;
    [SerializeField] private float yPosLimit;


    void Start()
    {
        Invoke(nameof(Lighting), Random.Range(1, maxLightningInterval));
    }


    void Lighting()
    {
        transform.position = new Vector3(Random.Range(-1 * (xPosLimit), xPosLimit), Random.Range(-1 * (yPosLimit), yPosLimit), transform.position.z);
        animator.SetBool("ActiveLight", true);

        Invoke(nameof(Lighting), Random.Range(1, maxLightningInterval));
        Invoke(nameof(LightningOff), 0.5f);
        thunderEvent.RaiseGameEvent(Random.Range(0, 1) >= 0.5f ? "thunder1" : "thunder2");
    }

    void LightningOff()
    {
        animator.SetBool("ActiveLight", false);
    }
}
