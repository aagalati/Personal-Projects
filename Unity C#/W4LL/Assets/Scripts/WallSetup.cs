using UnityEngine;
using System.Collections;

public class WallSetup : MonoBehaviour {

    float screenHeight;
    float screenHalfHeight;
    float screenWidth;
    float screenHalfWidth;

	// Use this for initialization
	void Start () {

        screenHalfHeight = Camera.main.orthographicSize;
        screenHeight = screenHalfHeight * 2f;

        screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        screenWidth = screenHalfWidth * 2f;

        print("Height: " + screenHeight + " and Width: " + screenWidth + " and HalfHeight: " + screenHalfHeight + " and HalfWidth: " + screenHalfWidth);

        GenerateWalls();


    }

    // Update is called once per frame
    void Update () {
	
	}

    void GenerateWalls()
    {

        transform.Find("Left Wall").position = LeftWallPosition();
        transform.Find("Left Wall").localScale = LeftRightWallScale();

        transform.Find("Right Wall").position = RightWallPosition();
        transform.Find("Right Wall").localScale = LeftRightWallScale();

        transform.Find("Top Wall").position = TopWallPosition();
        transform.Find("Top Wall").localScale = TopBottomWallScale();

        transform.Find("Bottom Wall").position = BottomWallPosition();
        transform.Find("Bottom Wall").localScale = TopBottomWallScale();

        transform.Find("Rear Wall").position = new Vector3(0, 0, 1);
        transform.Find("Rear Wall").localScale = RearWallScale();

    }

    public Vector3 LeftWallPosition()
    {

        return new Vector3(-screenHalfWidth, 0, 0);

    }

    public Vector3 RightWallPosition()
    {

        return new Vector3(screenHalfWidth, 0, 0);

    }

    public Vector3 LeftRightWallScale()
    {

        return new Vector3(1, screenHeight - 1, 1);

    }

    public Vector3 TopWallPosition()
    {

        return new Vector3(0, screenHalfHeight, 0);

    }

    public Vector3 BottomWallPosition()
    {

        return new Vector3(0, -screenHalfHeight, 0);

    }

    public Vector3 TopBottomWallScale()
    {

        return new Vector3(screenWidth, 1, 1);

    }

    public Vector3 RearWallScale()
    {

        return new Vector3(screenWidth, screenHeight, 1);

    }

}
