using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultButtons : MonoBehaviour
{
    public void GoToStartGame()
    {
        GameManager.Instance.StartGamePanel.SetActive(true);
        GameManager.Instance.ResultPanel.SetActive(false);
    }

    public void PlayAgain()
    {
        GameManager.Instance.ResultPanel.SetActive(false);
        GameManager.Instance.GameStartedPanel.SetActive(true);
        GameManager.Instance.StartNewGame();
    }
}
