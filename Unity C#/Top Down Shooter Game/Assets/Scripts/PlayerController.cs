using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(GunController))]
public class PlayerController : LivingEntity {

    public float moveSpeed = 7;

    Camera mainCamera;
    Rigidbody myRigidBody;
    GunController gunController;

    Vector3 moveVelocity;

   // public Gun gun;

	protected override void Start () {
        base.Start();
        myRigidBody = GetComponent<Rigidbody>();
        gunController = GetComponent<GunController>();
        mainCamera = FindObjectOfType<Camera>();
    }
	
	void Update () {

        //Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        //Look input
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); //abstract ground plane looking up at the origin
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        //Weapon Input
        if (Input.GetMouseButton(0))
            gunController.Shoot();

	}


    void FixedUpdate()
    {

        myRigidBody.velocity = moveVelocity;

    }

}
