using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{

    [SerializeField] private int odds;
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
    }

    void LightningOff()
    {
        animator.SetBool("ActiveLight", false);
    }
}
