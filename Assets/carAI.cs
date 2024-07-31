using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carAI : MonoBehaviour
{
    public List<Vector2> turns= new List<Vector2>();

    public Vector2 destination;
    public Vector2 finalDestination;
    //"U", "R", "D", "L", "UR", "RU","UL", "LU", "DL", "LD", "DR", "RD"
    public Rigidbody2D rb;

    public float carSpeed;

    public bool direction = true;

    public interpretRoads ?iR;

    public int[,] ?roads;
    public float initCarSpeed;
    public float steerSpeed=0f;

    public float raycastDistance = 10f;

    public bool seenCar = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //       roads = iR.roads;


        initCarSpeed = carSpeed;
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.up * raycastDistance);
    }

        // Update is called once per frame
        void Update()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, transform.up, raycastDistance);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null && hit.collider.CompareTag("cars"))
            {
                Debug.Log("Car ahead!");
                seenCar = true;
                break;
            }
            else
            {
                seenCar = false;
            }
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {


        roads = iR.roads;
        roads = iR.roads;
        if (collision.gameObject.CompareTag("road"))
        {
            Vector2Int gridPos = getGridPos((Vector2)collision.transform.position);

            if (iR != null && roads != null && gridPos.x >= 0 && gridPos.x < roads.GetLength(0) && gridPos.y >= 0 && gridPos.y < roads.GetLength(1))
            {
                int roadData = iR.roads[gridPos.x, gridPos.y];
                Debug.Log(roadData);

                float targetAngle = 0f;

                switch (roadData)
                {
                    case 1:
                        targetAngle = 0f;
                        break;

                    case 2:
                        targetAngle = 180f;
                        break;

                    case 3:
                        targetAngle = -90f;
                        break;

                    case 4:
                        targetAngle = 90f;
                        break;
                }


                rb.rotation = Mathf.LerpAngle(rb.rotation, targetAngle, steerSpeed * Time.deltaTime);

                rb.velocity = transform.up * carSpeed;
            }
        }
        if (collision.gameObject.CompareTag("light"))
        {
            if (collision.GetComponent<trafficLight>().color == 2) { carSpeed = 0f; }
            else
            {
                if (collision.GetComponent<trafficLight>().color == 1)
                {
                    carSpeed = initCarSpeed*0.25f;

                }
                else
                {
                    carSpeed = initCarSpeed;
                }
            }
        }
        else { carSpeed = initCarSpeed; }
        if (seenCar)
        {
            carSpeed =initCarSpeed* 0.05f;
        }
  
    }


    public Vector2Int getGridPos(Vector2 pos)
    {
        Vector2Int coords = new Vector2Int(Mathf.RoundToInt(pos.x - iR.startRect.x-0.5f), Mathf.RoundToInt(pos.y - iR.startRect.y-0.5f));
      //  Debug.Log(coords);
        return coords;

    }

}

