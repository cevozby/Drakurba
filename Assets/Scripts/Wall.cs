using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    public GameObject gameOverPanel;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterMovement.controlCheck = true;
            gameOverPanel.SetActive(true);
        }
    }

}
