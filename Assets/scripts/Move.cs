using UnityEngine;
using System.Collections;

using Panda;
namespace Panda.Examples.Move
{
    public class Move : MonoBehaviour
    {

        float speed = 2.0f; // current speed
        static float t = 0.0f;
        public float minimum = -10.0F;
        public float maximum = 10.0F;

        // variable to hold a reference to our SpriteRenderer component            
        private SpriteRenderer mySpriteRenderer;
        private Vector2 startPoint;
        private float destination;
        private Rigidbody rb;

        // This function is called just one time by Unity the moment the game loads
        private void Awake()
        {
            // get a reference to the SpriteRenderer component on this gameObject
            mySpriteRenderer = GetComponent<SpriteRenderer>();
            startPoint = transform.position;
            rb = GetComponent<Rigidbody>();
        }

        //void Update()
        //{
        //    transform.hasChanged = true;
        //}

        /*
         * Move to the (x,y) position at the current speed.
         */
        [Task]
        void MoveTo(float x, float y)
        {
            Debug.Log("MoveTo called.");



            // animate the position of the game object...
            transform.position = new Vector3(Mathf.Lerp(x, y, t), 0, 0);


            // .. and increate the t interpolater
            //t += 0.5f * Time.deltaTime;

            // now check if the interpolator has reached 1.0
            // and swap maximum and minimum so game object moves
            // in the opposite direction.
            //if (t > 1.0f)
            //{
            //    float temp = x;
            //    x = y;
            //    y = temp;
            //    t = 0.0f;
            //}

            Task.current.Succeed();

            //Vector3 destination = new Vector3(x, y, 0.0f);
            //Vector3 delta = (destination - transform.position);
            //Vector3 velocity = speed * delta.normalized;

            //transform.position = transform.position + velocity * Time.deltaTime;

            //Vector3 newDelta = (destination - transform.position);
            //float d = newDelta.magnitude;

            //if (Task.isInspected)
            //    Task.current.debugInfo = string.Format("d={0:0.000}", d);

            //if (Vector3.Dot(delta, newDelta) <= 0.0f || d < 1e-3)
            //{
            //    transform.position = destination;
            //    Task.current.Succeed();
            //    d = 0.0f;
            //    Task.current.debugInfo = "d=0.000";
            //}

        }

    /*
     * flip the character.
     */
    [Task]
        void Flip(bool enable)
        {
            Debug.Log("Flip called.");
            mySpriteRenderer.flipX = enable;
            Task.current.Succeed();
        }



        // This structure is used to store data for rotation tweening.
        struct RotateTween
        {
            public Quaternion startRotation;
            public Quaternion endRotation;
            public float startTime;
        }

        /*
         * Rotate about the given angle for the given duration. 
         */
        [Task]
        void Rotate(float angle, float duration)
        {
            var task = Task.current; // shortcut to the current task.
            RotateTween rt;

            // The Task.isStarting property is true on the first tick of a task.
            // We used it to perform initialization.
            if (task.isStarting)
            {
                // Compute tweeing data
                rt.startTime = Time.time;
                rt.startRotation = this.transform.localRotation;
                rt.endRotation = Quaternion.AngleAxis(angle, Vector3.forward) * transform.localRotation;

                // Task.item is a placeholder attached to a Task.
                // It is useful for storing any data used for the progression of a task.
                // We use it here to hold the tweening data.
                task.item = rt;
            }

            rt = (RotateTween)task.item; // Retrieve the tweening data.

            // Interpolate for the current rotation
            float elapsedTime = Time.time - rt.startTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            this.transform.localRotation = Quaternion.Lerp(rt.startRotation, rt.endRotation, t);


            // Display the tweening progression withing the code viewer in the Inspector.
            if (Task.isInspected)
                task.debugInfo = string.Format("t={0:0.00}", t);

            // Succeed the task when the tweening is complete.
            if (t == 1.0f)
            {
                task.debugInfo = "t=1.00";
                task.Succeed();
            }


        }

    }   
    }
