using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused=false;
    [SerializeField] private GameObject pauseMenu,generalMenu,settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&isPaused==false)
        {
            setPause(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
        {
            if(generalMenu.activeSelf)
            {
                setPause(false);
            }
            else if(settingsMenu.activeSelf)
            {
                generalMenu.SetActive(true);
                settingsMenu.SetActive(false);
            }
            
        }


    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Single);
    }

    public void setPause(bool newState)
    {
        pauseMenu.SetActive(newState);
        isPaused = newState;
        if (newState)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


}
