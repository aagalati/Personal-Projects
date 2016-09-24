using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    
    
    public bool move = false;
    public float speed = 7f;

    private Vector3 endPoint;
    private Vector3 velocity;
    private float initialDistance;
    private float currentDistance;

   


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (move)
        {
            Move();
            VelocityCalculator();
        }
        

	}

    public void GetEndPoint(Vector3 mousePosition, string wall)
    {


        if (wall == "Left Wall" || wall == "Right Wall")
        {
            endPoint = new Vector3(0, mousePosition.y, 0);
            initialDistance = transform.position.y - mousePosition.y;
            print("Initial Distance: " + initialDistance);

        }

        if (wall == "Top Wall" || wall == "Bottom Wall")
        {
            endPoint = new Vector3(mousePosition.x, 0, 0);
            initialDistance = transform.position.x - mousePosition.x;
            print("Initial Distance: " + initialDistance);
        }

    }

    private void Move()
    {

        transform.Translate(velocity);
    }

    private void VelocityCalculator()
    {
        float velocityRatio;

        if (endPoint.y != 0)
        {
            currentDistance = transform.position.y - endPoint.y;

            velocityRatio = Mathf.Abs(currentDistance / initialDistance);

            velocity = speed * Time.deltaTime * new Vector3(0, velocityRatio, 0);


            print("Current Distance: " + currentDistance);
            print("Velocity Ratio: " + velocityRatio);
           

        }
        else if (endPoint.x != 0)
        {

            currentDistance = transform.position.x - endPoint.x;

            velocityRatio = currentDistance / initialDistance;

            velocity = speed * Time.deltaTime * new Vector3(velocityRatio, 0, 0);

            print("Current Distance: " + currentDistance);
            print("Velocity Ratio: " + velocityRatio);

        }

        

    }

    void OnCollisionEnter()
    {
        move = false;
        Physics.gravity = Vector3.zero;
    }

}
