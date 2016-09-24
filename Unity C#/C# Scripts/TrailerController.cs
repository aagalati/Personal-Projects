using UnityEngine;
using System.Collections;

public class TrailerController : MonoBehaviour {

    public float speed = 7;
    float screenHalfWidth = 3.25f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float velocityX = inputX * speed * Time.deltaTime;
        float velocityZ = inputZ * speed * Time.deltaTime;

        transform.Translate(velocityX, 0, velocityZ);

    }

    public void checkVelocity()
    {



    }
}
