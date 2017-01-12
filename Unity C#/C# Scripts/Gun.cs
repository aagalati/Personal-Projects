using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{


    public Transform firePoint;
    public Projectile bullet;

    public float fireVelocity = 35;

    public float msBetweenShots = 100;
    private float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000f;
            Projectile newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as Projectile;
            newBullet.setSpeed(fireVelocity);

        }
    }

}
