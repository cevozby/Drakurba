using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ButtonManager : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject playButton;
    public GameObject pauseButton;
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public GameObject musicManager;

    public AudioMixer audioMixer;

    bool menuCheck = false, soundCheck = true;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        audioMixer.SetFloat("volume", PlayerPrefs.GetFloat("AudioVolume"));
    }

    public void StartButton()
    {
        SceneManager.LoadScene(LevelControl.levelNumber);
        Debug.Log("Scene Index: " + LevelControl.levelNumber);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        playButton.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        playButton.SetActive(false);
        pauseButton.SetActive(true);
    }

    public void MenuButton()
    {
        if (!menuCheck)
        {
            pauseButton.SetActive(true);
            restartButton.SetActive(true);
            homeButton.SetActive(true);
            menuCheck = true;
            if (soundCheck)
            {
                soundOffButton.SetActive(true);
            }
            else
            {
                soundOnButton.SetActive(true);
            }
        }
        else
        {
            pauseButton.SetActive(false);
            restartButton.SetActive(false);
            homeButton.SetActive(false);
            if (soundCheck)
            {
                soundOffButton.SetActive(false);
            }
            else
            {
                soundOnButton.SetActive(false);
            }
            menuCheck = false;
        }
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
        LevelControl.levelNumber = 1;
    }

    public void RetryButton()
    {
        KeyControl.lockIsOpen = false;
        SceneManager.LoadScene(LevelControl.levelNumber);
    }

    public void NextLevelButton()
    {
        KeyControl.lockIsOpen = false;
        
        SceneManager.LoadScene(LevelControl.levelNumber + 1);
        
        LevelControl.levelNumber++;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
    /*
    public void SoundOnButton()
    {
        soundCheck = true;
        soundOnButton.SetActive(false);
        soundOffButton.SetActive(true);
        musicManager.SetActive(true);
    }

    public void SoundOffButton()
    {
        soundCheck = false;
        soundOffButton.SetActive(false);
        soundOnButton.SetActive(true);
        musicManager.SetActive(false);
    }*/

    public void SetVolume(float volume)
    {
        Debug.Log("Volume: " + volume);
        PlayerPrefs.SetFloat("AudioVolume", volume);
        audioMixer.SetFloat("volume", volume);
    }

}
