using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiredRedFish : MonoBehaviour
{
    public float force = 50f;
    public float hmoveSpeed = 500f;
    public float vmoveSpeed = 500f;
    private Rigidbody rb;
    private float timer;
    public float setTime = 3f;
    private bool up = true;
    
    private void Start()
    {
        timer = Random.Range(0, setTime);
        Debug.Log(timer.ToString());
        
        int randomDie = Random.Range(0, 2);
        if (randomDie == 0)
        {
            up = true;
        }
        else
        {
            up = false;
        }
        
        rb = GetComponent<Rigidbody>();
        
        //rb.velocity = Vector3.up * force;
        
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        //move forward
        rb.velocity = transform.forward * (setTime - timer) * Time.deltaTime * hmoveSpeed;

        if (up)
        {
            //move upward
            rb.AddForce(Vector3.up * (setTime - timer) * Time.deltaTime * vmoveSpeed);
        }
        else
        {
            rb.AddForce(Vector3.down * (setTime - timer) * Time.deltaTime * vmoveSpeed * 0.3f );
        }
        
        
        
        
            
        if (timer >= setTime)
        {
            Debug.Log("change");
            
            //rb.velocity = Vector3.up * force;

            int random = Random.Range(-1, 2);
            Quaternion newRotation = Quaternion.Euler(new Vector3(0,random * 100,0));
            transform.rotation *= newRotation;
            
            timer = 0;
            
            Vector3 accumulatedForce = rb.GetAccumulatedForce();
            rb.AddForce(-1f * accumulatedForce);

            up = !up;
            //Debug.Log(rb.GetAccumulatedForce().y.ToString());
            //Debug.Log(accumulatedForce.x.ToString() + " / " + accumulatedForce.y.ToString() + " / "+ accumulatedForce.z.ToString());
        }

        //if we change the position directly, they will not bounce back
        // if (up)
        // {
        //     Vector3 newPos = Vector3.Lerp(transform.position, transform.position + Vector3.down, Time.deltaTime * (setTime - timer));
        //     transform.position = newPos;
        //
        //     if (timer >= setTime)
        //     {
        //         up = !up;
        //         timer = 0;
        //     }
        // }
        // else
        // {
        //     Vector3 newPos = Vector3.Lerp(transform.position, transform.position + Vector3.up, Time.deltaTime * (setTime - timer));
        //     transform.position = newPos;
        //
        //     if (timer >= setTime)
        //     {
        //         up = true;
        //         timer = 0;
        //     }
        // }
        
    }
}
