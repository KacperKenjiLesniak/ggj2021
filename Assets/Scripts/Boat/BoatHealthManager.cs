using System;
using MutableObjects.Int;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boat
{
    public class BoatHealthManager : MonoBehaviour
    {
        [SerializeField] private MutableInt boatHealth;
        
        private void Update()
        {
            if (boatHealth.Value <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}