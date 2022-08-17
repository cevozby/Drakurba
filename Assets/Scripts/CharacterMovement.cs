using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    float speed, horizontalSpeed, roadMaxValue;

    public static bool controlCheck;

    float minValue = -1.29f, maxValue = 1.26f, xPos;

    public Slider roadSlider;

    Rigidbody2D playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();

        roadSlider.minValue = transform.position.y;
        roadSlider.maxValue = roadMaxValue;
        roadSlider.value = transform.position.y;

        controlCheck = false;

        if(LevelControl.levelNumber == 1)
        {
            speed = 150;
            horizontalSpeed = 125;
        }
        else if(LevelControl.levelNumber == 2)
        {
            speed += 25;
            horizontalSpeed += 25;
        }
        else if (LevelControl.levelNumber == 3)
        {
            speed += 25;
            horizontalSpeed += 25;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!controlCheck)
        {
            PlayerMovementControl();

        }
        else
        {
            playerRB.velocity = Vector2.zero;
        }
        
    }

    private void Update()
    {
        PlayerStop();
        xPos = Mathf.Clamp(transform.position.x, minValue, maxValue);
        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        roadSlider.value = transform.position.y;
    }

    void PlayerMovementControl()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            playerRB.velocity = new Vector2(Time.deltaTime * horizontalSpeed, Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.velocity = new Vector2(Time.deltaTime * -horizontalSpeed, Time.deltaTime * speed);
        }
        
        playerRB.velocity = new Vector2(playerRB.velocity.x, Time.deltaTime * speed);

    }
    void PlayerStop()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerRB.velocity = new Vector2(0, Time.deltaTime * speed);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerRB.velocity = new Vector2(0, Time.deltaTime * speed);
        }
    }

}
