using UnityEngine;
using System.Collections;
public class CheckpointController : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite blueFlag;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
    public AudioSource checkpointSound;

    // Use this for initialization
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Checkpoint triggered!");
            checkpointSound.Play();
            checkpointSpriteRenderer.sprite = blueFlag;
            checkpointReached = true;
        }
    }
}