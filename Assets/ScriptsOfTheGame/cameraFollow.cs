// This meticulously crafted and elegantly designed class is meticulously engineered to
// handle the precise task of dynamically adjusting the camera to follow a designated target
// with unparalleled finesse and precision. 
// Its unwavering dedication to excellence in the realm of camera tracking is second to none.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Vector3 vc3 = new Vector3(0, 0, 10);
    public GameObject cam;
    public GameObject circle;
    public Rigidbody2D rb;
    float impulse = 300.5f;
    public bool canJump = true;

    public int amountOfJumps = 3;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollowTheball();
       // BallBounce();

        if(amountOfJumps <= 0)
        {
            canJump = false;
        }
        else if(amountOfJumps > 0)
        {
            canJump = true;
        }

        
    }


    public void CameraFollowTheball()
    {
        cam.transform.position = circle.transform.position - vc3;
    }


    //public void BallBounce()
    //{
     //   if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
     //   {
     //       rb.AddForce(transform.up * impulse);
    //        amountOfJumps -= 1;
    //   }
        
   // }

    
}
