using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public void ExitApplication()
    {
        Application.Quit();
    }

    public void PauseGame(bool isPause)
    {
        if(isPause)
        {
            Time.timeScale = 0.0f;
        }
        else if(!isPause)
        {
            Time.timeScale = 1.0f;
        }
    }
}
