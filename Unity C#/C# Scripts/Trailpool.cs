using UnityEngine;
using System.Collections;

public class Trailpool : MonoBehaviour {

    GameObject[] trail = null;
    public GameObject particle;
    public int numOfParticles = 50;

    public Material yellowMat;
    public Material orangeMat;
    public Material redMat;
    public Material brownMat;
    Renderer rend;


    // Use this for initialization
    void Start () {

        trail = new GameObject[numOfParticles];
        InstantiateParticles();
        //rend = particle.GetComponent<Renderer>();
       // rend.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {


        MultipleParticleActivate(4);

        transform.position = transform.parent.position;
    

	}

    private void InstantiateParticles()
    {

        print("Instantiating Particles..");

        for (int i = 0; i < numOfParticles; i++)
        {

            trail[i] = Instantiate(particle) as GameObject;
            trail[i].transform.parent = transform;
            trail[i].SetActiveRecursively(false);
            rend = trail[i].GetComponent<Renderer>();
            rend.material = GenerateMaterial();

        }

    }

    private void MultipleParticleActivate(int numMade)
    {

        while(numMade > 0)
        {
            ActivateParticle();
            numMade--;
        }

    }

    private void ActivateParticle()
    {

            for (int i = 0; i < numOfParticles; i++)
            {
                if (trail[i].active == false)
                {
                    trail[i].SetActiveRecursively(true);

                    trail[i].GetComponent<Trail>().Activate();
                    return;
                }


            }

    }

    private Material GenerateMaterial()

    {

        print("Assigning material..");

        switch (Random.Range(0, 10))
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return redMat;
                break;
            case 4:
            case 5:
            case 6:
                return yellowMat;
                break;
            case 7:
            case 8:
                return orangeMat;
                break;
            case 9:
                return brownMat;
                break;


        }
        return redMat;

    }

}
