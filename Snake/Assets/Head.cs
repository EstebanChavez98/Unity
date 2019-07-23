using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    enum Direction
    {
        up,
        down,
        left,
        right
    }

    Direction direction;
    public List<Transform> Tail = new List<Transform>();
    public int i = 0;
    public float frameRate = 0.2f;
    public float step = 0.16f;
    public GameObject TailPrefab;
    public GameObject ScoreSnake = GameObject.FindWithTag("Score");
    public Vector2 HorizontalRange;
    public Vector2 VerticalRange;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", frameRate, frameRate); //Invocar una funcion con un delay inicial y se sigue llamando cada cierto tiempo
    }

    void Move()
    {
        lastPos = transform.position;
        Vector3 nextPos = Vector3.zero;
        if (direction == Direction.up)
            nextPos = Vector2.up;
        else if (direction == Direction.left)
            nextPos = Vector2.left;
        else if (direction == Direction.right)
            nextPos = Vector2.right;
        else if (direction == Direction.down)
            nextPos = Vector2.down;
        nextPos *= step;
        transform.position += nextPos;

        MoveTail();
    }
    Vector3 lastPos;
    void MoveTail()
    {
        for (int i = 0; i <Tail.Count; i++)
        {
            Vector3 temp = Tail[i].position;
            Tail[i].position = lastPos;
            lastPos = temp;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            direction = Direction.up;
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            direction = Direction.down;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            direction = Direction.left;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            direction = Direction.right;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Block"))
        {
            print("Has perdido");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            ScorePoint.scoreValue = 0;
        }
        else if (col.CompareTag("Food"))
        {
            ScorePoint.scoreValue += 2;
            Tail.Add(Instantiate(TailPrefab, Tail[Tail.Count - 1].position, Quaternion.identity).transform);
            col.transform.position = new Vector2(Random.Range(HorizontalRange.x, HorizontalRange.y), Random.Range(VerticalRange.x, VerticalRange.y));
            i++;
            if(i % 3 == 0)
            {

                if (frameRate != 0.01f)
                {
                    if (frameRate == 0.02f)
                        frameRate = 0.1f;
                    else
                    frameRate -= 0.02f;
                }
            }
        }
    }
}
