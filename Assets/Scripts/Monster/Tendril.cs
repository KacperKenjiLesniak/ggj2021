using System;
using GameEvents.Game;
using MutableObjects.Int;
using MutableObjects.Vector3;
using UnityEngine;

namespace Monster
{
    public class Tendril : MonoBehaviour
    {
        [SerializeField] private GameEvent monsterRisingEvent;
        [SerializeField] private GameEvent monsterAttackEvent;
        [SerializeField] private MutableVector3 boatPosition;
        [SerializeField] private MutableInt boatHealth;
        [SerializeField] private float tendrilSpeed;
        [SerializeField] private float scaleSpeed;
        [SerializeField] private float maxScale;
        [SerializeField] private float attackCooldown;

        public bool active { get; set; }
        
        private bool nextToPlayer;
        private bool attacking;
        private float attackCooldownTimer;
        private bool disappearing;
        private bool risingSoundPlayed;
        private bool attackSoundPlayed;

        private void Update()
        {
            if (disappearing)
            {
                transform.localScale *= (1 - 5*(scaleSpeed * Time.deltaTime));
                return;
            }
            
            if (active)
            {
                if (!nextToPlayer)
                {                
                    transform.position += (boatPosition.Value - transform.position).normalized * (tendrilSpeed * Time.deltaTime);
                }
                else
                {
                    if (!risingSoundPlayed)
                    {
                        risingSoundPlayed = true;
                        monsterRisingEvent.RaiseGameEvent();
                    }
                    
                    if (transform.localScale.x <= maxScale)
                    {
                        transform.localScale += new Vector3(1f, 1f, 0f) * (scaleSpeed * Time.deltaTime);
                    }
                    else
                    {
                        GetComponent<Animator>().SetTrigger("Chomp");
                        attacking = true;
                        Invoke(nameof(Disappear), 2f);
                    }
                }
            }

            if (attackCooldownTimer >= 0f)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                nextToPlayer = true;
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (attacking && attackCooldownTimer <= 0f && other.CompareTag("Player"))
            {
                if (!attackSoundPlayed)
                {
                    monsterAttackEvent.RaiseGameEvent();
                    attackSoundPlayed = true;
                }
                boatHealth.Value -= 1;
                Debug.Log("Bralwhahlh tendril attacks!");
                Debug.Log("Boat health: " + boatHealth.Value);
                attackCooldownTimer = attackCooldown;
            }
        }

        private void Disappear()
        {
            disappearing = true;
        }
    }
}