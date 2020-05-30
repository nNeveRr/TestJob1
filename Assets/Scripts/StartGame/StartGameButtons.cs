using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtons : MonoBehaviour
{
    public void StartNewGameButton()
    {
        GameManager.Instance.StartGamePanel.SetActive(false);
        GameManager.Instance.GameStartedPanel.SetActive(true);
        GameManager.Instance.StartNewGame();
    }
}
