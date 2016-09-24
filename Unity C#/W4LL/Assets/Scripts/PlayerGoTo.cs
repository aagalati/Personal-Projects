using UnityEngine;
using System.Collections;

public class PlayerGoTo : MonoBehaviour {

    PlayerMovement player;
    public float gravity = 9.81f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                

                if (hit.transform.tag == "Wall")
                {
                    print("You clicked on " + hit.transform.name);
                    TriggerMovement(hit.transform.name);
                }

                

            }

        }
 
	}

    void TriggerMovement(string wall)
    {

        if (wall == "Left Wall")
        {
            Physics.gravity = new Vector3(-gravity, 0, 0);
        }
        else if (wall == "Right Wall")
        {
            Physics.gravity = new Vector3(gravity, 0, 0);
        }
        else if (wall == "Top Wall")
        {
            Physics.gravity = new Vector3(0, gravity, 0);
        }
        else if (wall == "Bottom Wall")
        {
            Physics.gravity = new Vector3(0, -gravity, 0);
        }

        player = FindObjectOfType<PlayerMovement>();
        player.GetEndPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), wall);
        player.move = true;

    }
}
