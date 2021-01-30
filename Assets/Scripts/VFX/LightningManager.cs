using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningManager : MonoBehaviour
{

    [SerializeField] private int odds;
    [SerializeField] private int Scenarios;
    [SerializeField] private Animator animator;
    [SerializeField] private int randomNumber;
    [SerializeField] private float xPosLimit;
    [SerializeField] private float yPosLimit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(0, Scenarios);

        if(randomNumber<odds)
        {
            transform.position = new Vector3(Random.Range(-1 * (xPosLimit), xPosLimit), Random.Range(-1 * (yPosLimit), yPosLimit), transform.position.z);
            animator.SetBool("ActiveLight", true);
        }
        else
        {
            animator.SetBool("ActiveLight", false);
        }
    }
}
