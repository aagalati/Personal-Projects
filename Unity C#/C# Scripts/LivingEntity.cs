using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamageable {

    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;

   protected virtual void Start()
    {
        health = startingHealth;
        //print("Starting health is: " + health);
    }

    public void TakeHit(float damage, RaycastHit hit)
    {

       // print("Health before hit: " + health);

        health -= damage;

        //print("Took damage, health is now: " + health);

        if (health <= 0 && !dead)
            Die();

    }
	

    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
            OnDeath();
        GameObject.Destroy(gameObject);
    }

}
