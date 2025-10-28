using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float     decal;
    public float     accel;
    public float     loadingSpeed = 1;
    public KeyCode   key          = KeyCode.Space;
    public Rigidbody rb;


    public bool keyUp;
    public bool push;
    public bool canPush;

    void Update()
    {
        if (Input.GetKeyUp(key))
        {
            keyUp = true;

            canPush = false;
            push    = false;
        }

        if (canPush && Input.GetKey(key))
        {
            push = true;
        }
    }

    void FixedUpdate()
    {
        if (keyUp)
        {
            rb.isKinematic = false;

            keyUp = false;
        }

        if (push)
        {
            rb.isKinematic = false;

            if (transform.localPosition.y > decal)
            {
                //allows down movement

                rb.linearVelocity += -transform.up * loadingSpeed * Time.deltaTime;
            }
            else
            {
                //constraint when push is true

                rb.linearVelocity    = Vector3.zero;
                rb.isKinematic = true;
            }
        }
        else
        {
            if (transform.localPosition.y < 0)
            {
                //allows up movement

                rb.linearVelocity += transform.up * accel * Time.deltaTime;
            }
            else
            {
                //constraint when push is false

                rb.isKinematic          = true;
                transform.localPosition = Vector3.zero;

                canPush = true;
            }
        }

        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
    }
}