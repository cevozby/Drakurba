using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControl : MonoBehaviour
{
    public bool moveCheck = true;

    float speed = 300;

    public static bool lockIsOpen;

    Rigidbody2D keyRB;

    Vector3 keyStartPos;

    public GameObject closedLock, openLock;

    public GameObject puzzleGame;

    public GameObject player;

    Vector3 keyPos;

    // Start is called before the first frame update
    void Start()
    {
        keyRB = GetComponent<Rigidbody2D>();
        keyStartPos = transform.position;
        lockIsOpen = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveCheck && !DoorManagement.timeIsOver)
        {
            
            KeyMovementControl();
            
        }
        if (DoorManagement.timeIsOver)
        {
            keyRB.velocity = Vector2.zero;
        }
    }


    void KeyMovementControl()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            keyRB.velocity = new Vector2(Time.deltaTime * speed, 0);
            moveCheck = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            keyRB.velocity = new Vector2(Time.deltaTime * -speed, 0);
            moveCheck = false;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            keyRB.velocity = new Vector2(0, Time.deltaTime * speed);
            moveCheck = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            keyRB.velocity = new Vector2(0, Time.deltaTime * -speed);
            moveCheck = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            keyRB.velocity = Vector2.zero;
            moveCheck = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lock"))
        {
            keyRB.velocity = Vector2.zero;
            
            StartCoroutine(Win());
        }
        /*if (collision.gameObject.CompareTag("Obstacle"))
        {
            keyRB.velocity = Vector2.zero;
            keyPos = transform.position;
            moveCheck = true;
        }*/
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            
            moveCheck = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Map"))
        {
            transform.position = keyStartPos;
            keyRB.velocity = Vector2.zero;
            moveCheck = true;
        }
    }

    IEnumerator Win()
    {
        closedLock.SetActive(false);
        openLock.SetActive(true);
        yield return new WaitForSeconds(1);
        lockIsOpen = true;
        DoorSýralama.index++;
        player.SetActive(true);

        puzzleGame.SetActive(false);
    }

}
