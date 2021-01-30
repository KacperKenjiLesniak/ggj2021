using System.Collections;
using System.Collections.Generic;
using MutableObjects.Bool;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private MutableBool movementActive;

    public void DisableMovement()
    {
        movementActive.Value = false;
    }
    
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
