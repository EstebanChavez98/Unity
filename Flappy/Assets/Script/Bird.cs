using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead;
    private Rigidbody2D rb2d;
    public float upForce = 200f;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D Col)
    {
        isDead = true;
    }
}
