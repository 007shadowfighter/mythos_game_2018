using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    //public float speed = 5f;
    //public float jumpSpeed = 8f;
    //private float movement = 0f;
    private Rigidbody2D rigidBody;
    //public Transform groundCheckPoint;
    //public float groundCheckRadius;
    //public LayerMask groundLayer;
    //private bool isTouchingGround;
    //private Animator playerAnimation;
    public Vector3 respawnPoint;
    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        //playerAnimation = GetComponent<Animator>();
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FallDetector")
        {
            Debug.Log("hit fall detector!");
            transform.position = respawnPoint;
        }
        if (other.tag == "CheckPoint")
        {
            Debug.Log("hit checkpoint!");
            respawnPoint = other.transform.position;
        }
    }
}