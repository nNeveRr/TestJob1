using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultInput : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.StartGamePanel.SetActive(true);
            GameManager.Instance.ResultPanel.SetActive(false);
        }
    }
}
