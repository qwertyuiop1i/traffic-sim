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

        roads = iR.roads;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(getGridPos(transform.position));
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("road"))
        {
            Debug.Log('e');
            //    string orientation = collision.GetComponent<road>().orientation;

            rb.velocity = new Vector2(0, carSpeed);
            
        }
    }

    public Vector2 getGridPos(Vector2 pos)
    {
        Vector2 coords = new Vector2(Mathf.RoundToInt(pos.x - iR.startRect.x), Mathf.RoundToInt(pos.y - iR.startRect.y));

        return coords;

    }

}

