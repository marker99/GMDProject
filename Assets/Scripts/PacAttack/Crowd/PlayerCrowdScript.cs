using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCrowdScript : MonoBehaviour
{
    [SerializeField] private GameObject friendUnit;
    [SerializeField] private GameObject enemyBoss;
    //[SerializeField] private GameObject enemyGhost;

    private Animator animator;
    
    private HealthManager friendHealth;
    private HealthManager enemyBossHealth;
    //private HealthManager enemyGhostHealth;
    
    void Start()
    {
        animator = GetComponent<Animator>();

        friendHealth = friendUnit.GetComponent<HealthManager>();
        enemyBossHealth = enemyBoss.GetComponent<HealthManager>();

        enemyBossHealth.HealthChanged += HappyState;
        friendHealth.HealthChanged += SadState;
    }

    private void HappyState(int healthremaining)
    {
        animator.SetInteger("HappyIndex", Random.Range(0, 5));
        animator.SetTrigger("Happy");
    }


    private void SadState(int healthremaining)
    {
        animator.SetInteger("SadIndex", Random.Range(0, 6));
        animator.SetTrigger("Sad");
    }
}