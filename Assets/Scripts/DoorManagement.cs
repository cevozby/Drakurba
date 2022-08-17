using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorManagement : MonoBehaviour
{
    public GameObject puzzlePanel, gameOverPanel;
    public GameObject player;
    public GameObject puzzleGame;
    public Slider timeSlider;

    public Transform rightDoor, leftDoor;

    float timeCount;

    bool puzzleCheck, doorIsClosed = true;

    public static bool timeIsOver;

    // Start is called before the first frame update
    void Start()
    {
        if(LevelControl.levelNumber == 1)
        {
            timeCount = 30;
        }
        else if (LevelControl.levelNumber == 2)
        {
            timeCount = 45;
        }
        else if (LevelControl.levelNumber == 3)
        {
            timeCount = 60;
        }
        timeSlider.minValue = 0;
        timeSlider.maxValue = timeCount;
        timeSlider.value = timeCount;
        timeIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(puzzleCheck && timeCount > 0)
        {
            
            timeCount -= Time.deltaTime;
            timeSlider.value = timeCount;
        }
        if (KeyControl.lockIsOpen)
        {
            puzzlePanel.SetActive(false);
            StartCoroutine(CharacterMoveAgain());
        }
        if(timeCount <= 0 && !KeyControl.lockIsOpen)
        {
            timeIsOver = true;
            puzzlePanel.SetActive(false);
            puzzleGame.SetActive(false);
            gameOverPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && doorIsClosed)
        {
            CharacterMovement.controlCheck = true;
            player.SetActive(false);
            puzzleGame.transform.position = new Vector3(transform.position.x, transform.position.y - 1.35f, transform.position.z);
            puzzleGame.SetActive(true);
            puzzlePanel.SetActive(true);
            puzzleCheck = true;
            doorIsClosed = false;
        }
    }

    IEnumerator CharacterMoveAgain()
    {
        if(transform.position.x < 3.5f)
        {
            rightDoor.Translate(Vector3.right * Time.deltaTime * 1.15f);
        }
        if (transform.position.x > -3.5f)
        {
            leftDoor.Translate(Vector3.right * Time.deltaTime * -1.15f);
        }
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
        CharacterMovement.controlCheck = false;
        
    }

}
