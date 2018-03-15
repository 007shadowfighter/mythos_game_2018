using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hero : MonoBehaviour {
    private Rigidbody2D myRigidbody;

    [SerializeField]
    private float movementspeed;
	// Use this for initialization
	void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void fixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
       
       
            HandleMovement(horizontal);
    }
    private void HandleMovement(float horizontal)
    {

        myRigidbody.velocity = new Vector2(horizontal * movementspeed, myRigidbody.velocity.y);
    }
    
}
