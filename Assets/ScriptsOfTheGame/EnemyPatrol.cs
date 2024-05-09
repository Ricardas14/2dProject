using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    public float speed;

    [Space]

    public Transform playerTransform;
    public bool isChasing = false;
    public float chaseDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (isChasing == true)
        {
            if (transform.position.x > playerTransform.position.x)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (transform.position.x < playerTransform.position.x)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) <= chaseDistance)
            {
                isChasing = true;
            }

            if (currentPoint == pointB.transform)
            {
                rb.velocity = new Vector2(speed, 0);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
            {
                currentPoint = pointA.transform;
            }
            if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
            {
                currentPoint = pointB.transform;
            }
            Vector2 point = currentPoint.position - transform.position;
        }

        
        
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
