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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("road"))
        {
            Debug.Log('e');
            string orientation = collision.GetComponent<road>().orientation;

            rb.AddForce(new Vector2(0f,50f), ForceMode2D.Force);
            
        }
    }

}

