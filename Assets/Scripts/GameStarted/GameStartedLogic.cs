using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartedLogic : MonoBehaviour
{
    [SerializeField]
    float TimeCreateEntity = 0.5f;

    float CurrentTime = 0f;

    void Update()
    {
        if(GameManager.GameStarted&&!GameManager.GamePaused)
        {
            CurrentTime -= Time.deltaTime;
            if(CurrentTime<0f)
            {
                GameManager.Instance.CreateEntity();
                CurrentTime = TimeCreateEntity;
            }
            GameManager.Instance.GameTimePass(Time.deltaTime);
        }
    }
}
