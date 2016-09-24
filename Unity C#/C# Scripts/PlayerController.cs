using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 7;
    float screenHalfWidth = 3.25f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

       if (transform.position.x < (-screenHalfWidth - 2.4f))
        {
            transform.position = new Vector3((-screenHalfWidth - 2.4f), transform.position.y, transform.position.z);
       }

       if (transform.position.x > screenHalfWidth)
       {
            transform.position = new Vector3(screenHalfWidth, transform.position.y, transform.position.z);
       }

    }
}
