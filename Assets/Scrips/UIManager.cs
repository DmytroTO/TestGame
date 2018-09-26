using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Выход из игры
    /// </summary>
    public void ExitApplication()
    {
        Application.Quit();
    }

    /// <summary>
    /// Уствановка паузы
    /// </summary>
    /// <param name="isPause">true - пауза / false - не пауза</param>
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
