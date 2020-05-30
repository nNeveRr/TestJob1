using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartedButtons : MonoBehaviour
{
    public void GoToPauseMenu()
    {
        if (!GameManager.GamePaused)
        {
            GameManager.Instance.PauseGameButton();
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            GoToPauseMenu();
        }
    }
}
