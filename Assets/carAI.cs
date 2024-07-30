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

    public interpretRoads iR;

    public int[,] roads;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
 //       roads = iR.roads;
       
    }

    // Update is called once per frame
    void Update()
    {
      //Debug.Log(getGridPos(transform.position));
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("road"))
        {
            Vector2Int gridPos = getGridPos((Vector2)collision.transform.position);
            int roadData = iR.roads[gridPos.x,gridPos.y];

            switch (roadData)
            {
                case 1:
                    rb.velocity = new Vector2(0, carSpeed);
                    break;

                case 2:
                    rb.velocity =-1* new Vector2(0, carSpeed);
                    break;
            }
            
            
        }
    }

    public Vector2Int getGridPos(Vector2 pos)
    {
        Vector2Int coords = new Vector2Int(Mathf.RoundToInt(pos.x - iR.startRect.x), Mathf.RoundToInt(pos.y - iR.startRect.y));

        return coords;

    }

}

