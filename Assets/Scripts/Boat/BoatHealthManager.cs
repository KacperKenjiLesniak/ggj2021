using System;
using MutableObjects.Bool;
using MutableObjects.Int;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boat
{
    public class BoatHealthManager : MonoBehaviour
    {
        [SerializeField] private MutableInt boatHealth;
        [SerializeField] private MutableBool movementActive;

        private bool dead;
        
        private void Update()
        {
            if (boatHealth.Value <= 0)
            {
                if (!dead)
                {
                    GetComponent<Animator>().SetTrigger("die");
                }
                movementActive.Value = false;
                dead = true;
                Invoke(nameof(ReloadLevel), 4f);
            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
}