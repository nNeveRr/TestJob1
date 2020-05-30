using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedButtons : MonoBehaviour
{
    public void ContinueGame()
    {
        if (GameManager.GamePaused)
        {
            GameManager.GamePaused = false;
            GameManager.Instance.GamePausedPanel.SetActive(false);
        }
    }

    public void GoToStartGame()
    {
        GameManager.Instance.AbortGameButton();
    }
}
