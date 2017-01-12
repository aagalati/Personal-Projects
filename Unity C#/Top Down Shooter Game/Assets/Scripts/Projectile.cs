using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    float speed = 10;
    float lifetime = 15;
    float damage = 1;
    float starttime;

    public LayerMask collisionMask;

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

    public void setLifetime(float newLifetime)
    {
        lifetime = newLifetime;
    }

    void Start()
    {

        starttime = Time.time;   

    } 

    void Update()
    {

        if (Time.time > starttime + lifetime)
            Destroy(this.gameObject);

        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);

    }


    void CheckCollisions(float moveDistance)
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            //hit Object
            OnHitObject(hit);

        }


    }

    void OnHitObject(RaycastHit hit)
    {
        print(hit.collider.gameObject.name);
        IDamageable damageableObject = hit.collider.GetComponent<IDamageable>();
        if (damageableObject != null)
            damageableObject.TakeHit(damage, hit);
        Destroy(this.gameObject);
    }

}

