using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizonalLength;

    void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        groundHorizonalLength = groundCollider.size.x;
    }

    private void RepositionBackground()
    {
        transform.Translate(Vector2.right * groundHorizonalLength * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -groundHorizonalLength)
        {
            RepositionBackground();
        }
    }
}
