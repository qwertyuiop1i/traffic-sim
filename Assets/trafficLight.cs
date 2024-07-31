using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    public int color = 0;//0 is green, 1 is yellow, 2 is red.
    public float timer = 5f;
    public float time = 0f;
    // Start is called before the first frame update

    public Sprite red;
    public Sprite yellow;
    public Sprite green;
    public SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0f;
            color = (color + 1) % 3;

            switch (color) {
                case 0:
                    sr.sprite = green;
                    break;
                case 1:
                    sr.sprite = yellow;
                    break;
                case 2:
                    sr.sprite = red;
                    break;
            }

        }
    }
}
