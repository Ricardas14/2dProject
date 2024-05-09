using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool chasePlayer = false;
    public Transform startingPoint;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
            

        if(chasePlayer == true)
        {
            Chase();
        }
        else
        {
            ReturntoStartingPoint();
        }


       // LookAtThePlayer();  
        
        
    }
    private void ReturntoStartingPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.transform.position, speed * Time.deltaTime);
    }

    private void Chase()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    //void LookAtThePlayer()
    //{
      //  gameObject.transform.LookAt(player.transform.position.y);
    //}
}
