﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
	public static bool isPauseMenuInactive;
	public static bool decreaseSound;
	public static bool slowMusic;

    GameObject[] pauseObjects;

	//flag to notification of sound effects
    SpawnInstructions spawnInstructions;

    public Button resumePlay;
    public Button quit;
	public Button pauseButton;

    public Button up;
    public Button down;
    public Button left;
    public Button right;
    public Button clear;
    public Button submit;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();

        Button resumeBtn = resumePlay.GetComponent<Button>();
        Button quitBtn = quit.GetComponent<Button>();
		Button pause = pauseButton.GetComponent<Button> ();
        spawnInstructions = GetComponent<SpawnInstructions>() ;

        resumeBtn.onClick.AddListener(ResumeOnClick);
        quitBtn.onClick.AddListener(QuitOnClick);
		pause.onClick.AddListener (pauseMenu);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void pauseControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f) //Paused
            {
                Time.timeScale = 0f;
                up.interactable = false;
                down.interactable = false;
                left.interactable = false;
                right.interactable = false;
                submit.interactable = false;
                clear.interactable = false;
                showPaused();

				isPauseMenuInactive = true;
            }
            else if (Time.timeScale == 0f) //Unpaused
            {
                Time.timeScale = 1f;
                up.interactable = true;
                down.interactable = true;
                left.interactable = true;
                right.interactable = true;
                submit.interactable = true;
                clear.interactable = true;
                hidePaused();

				isPauseMenuInactive = false;
            }
        }
    }

    public void hidePaused()
    {
		slowMusic = false;
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void showPaused()
    {
		slowMusic = true;

        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    void ResumeOnClick()
    {
        Time.timeScale = 1f;
        up.interactable = true;
        down.interactable = true;
        left.interactable = true;
        right.interactable = true;
        submit.interactable = true;
        clear.interactable = true;
        hidePaused();

		isPauseMenuInactive = false;
    }

    void QuitOnClick()
    {
		decreaseSound = true;
        Application.Quit();
    }


	void pauseMenu()
	{
		showPaused();

		 if(Time.timeScale == 1f)
			{
				Time.timeScale = 0f;
                up.interactable = false;
                down.interactable = false;
                left.interactable = false;
                right.interactable = false;
                submit.interactable = false;
                clear.interactable = false;
                showPaused();

			    isPauseMenuInactive = true;
			}
			else if(Time.timeScale == 0f)
			{
				Time.timeScale = 1;
                up.interactable = true;
                down.interactable = true;
                left.interactable = true;
                right.interactable = true;
                submit.interactable = true;
                clear.interactable = true;
                hidePaused();

			   isPauseMenuInactive = false;
			}
		}
}
