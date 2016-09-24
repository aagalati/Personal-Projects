using UnityEngine;
using System.Collections;

public class BulletSpawn : MonoBehaviour {

    public GameObject bullet;
    public Transform playerTransform;
    public float bulletSpeed = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPosition = new Vector3(playerTransform.transform.position.x + 1.25f, playerTransform.transform.position.y + 1f, playerTransform.transform.position.z);
            Vector3 spawnRotation = new Vector3(-90, 0, 0);

            GameObject newBullet = (GameObject)Instantiate(bullet, spawnPosition, Quaternion.Euler(spawnRotation));
            newBullet.transform.parent = transform;

            Rigidbody bulletRigidBody = newBullet.AddComponent<Rigidbody>();
            bulletRigidBody.velocity = transform.TransformDirection(Vector3.up * bulletSpeed);

        }

	}
}
