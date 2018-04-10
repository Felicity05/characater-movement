using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    GameObject[] pauseObjects;
    public Button resumePlay;
    public Button quit;
	public Button pauseButton;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();

        Button resumeBtn = resumePlay.GetComponent<Button>();
        Button quitBtn = quit.GetComponent<Button>();
		Button pause = pauseButton.GetComponent<Button> ();

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
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                showPaused();
            }
            else if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                hidePaused();
            }
        }
    }

    public void hidePaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    public void showPaused()
    {
        foreach(GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    void ResumeOnClick()
    {
        Time.timeScale = 1f;
        hidePaused();
    }

    void QuitOnClick()
    {
        Application.Quit();
    }


	void pauseMenu()
	{
		showPaused();

		 if(Time.timeScale == 1f)
			{
				Time.timeScale = 0f;
				showPaused();
			}
			else if(Time.timeScale == 0f)
			{
				Time.timeScale = 1;
				hidePaused();
			}
		}
}
