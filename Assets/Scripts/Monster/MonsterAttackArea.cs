using System;
using System.Linq;
using UnityEngine;

namespace Monster
{
    public class MonsterAttackArea : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponentsInChildren<Tendril>().ToList().ForEach(tendril => tendril.active = true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponentsInChildren<Tendril>().ToList().ForEach(tendril => tendril.active = false);
            }
        }
    }
}