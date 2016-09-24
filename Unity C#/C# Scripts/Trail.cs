using UnityEngine;
using System.Collections;

public class Trail : MonoBehaviour {

   
    public float life = 2f;
    public float speed = 10f;
    public float coneEffectMultiplier = 2f;
    private float timeToDie = 0f;

    public Transform playerTransform;
    public MeshFilter playerMeshFilter;
    public MeshFilter particleMeshFilter;


    // Update is called once per frame
    void Update () {

        CountDown();
        Move();
    
	}

    public void Activate ()
    {

        spawnPosition();
        timeToDie = Time.time + life - (coneEffectMultiplier * Mathf.Abs(transform.parent.position.x - transform.position.x));
        print(timeToDie);

    }

    private void Deactivate()
    {

        this.gameObject.SetActiveRecursively(false);

    }

   private void CountDown()
    {
        if (timeToDie < Time.time) Deactivate(); 
    }

    private void Move()
    {

        Vector3 velocity = speed * Time.deltaTime * Vector3.back;
        transform.Translate(velocity);
    }

    private void spawnPosition()
    {

        float widthOfPlayer = playerMeshFilter.sharedMesh.bounds.extents.z;
        float heightOfPlayer = playerMeshFilter.sharedMesh.bounds.extents.z;

        Vector3 position = new Vector3(transform.parent.position.x + (Random.Range(-widthOfPlayer + 0.1f, widthOfPlayer - 0.1f)), transform.parent.position.y + (Random.Range(-heightOfPlayer + 0.1f, heightOfPlayer - 0.1f)), transform.parent.position.z + (Random.Range(-heightOfPlayer + 0.1f, heightOfPlayer - 0.1f)));
        transform.position = position;


    }

}
