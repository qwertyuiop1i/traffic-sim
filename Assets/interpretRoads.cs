using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interpretRoads : MonoBehaviour
{
    public Vector2 startRect;
    public Vector2 endRect;

    public int[,] roads;

    void Start()
    {
        roads = new int[(int)(startRect.x - endRect.x), (int)(startRect.y - endRect.y)];

        foreach (GameObject child in transform)
        {
            int childCode;

                int gridX = (int)(child.transform.position.x-startRect.x);
                int gridY = (int)(child.transform.position.y-startRect.y);

            if (child.GetComponent<road>().direction)
            {
                childCode = 1;
            }
            else
            {

                    childCode = 2;
                

                
            }

            roads[gridX, gridY] = childCode;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
