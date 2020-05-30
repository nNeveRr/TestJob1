using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;


    public GameObject StartGamePanel;
    public GameObject GameStartedPanel;
    public GameObject GamePausedPanel;
    public GameObject ResultPanel;

    public GameObject CreateEntityParent;

    public static bool GamePaused;

    public static bool GameStarted;

    [SerializeField]
    int MaxEntities = 10;

    int GamePoints = 0;

    float GameTime = 0f;

    List<EntityClass> AllEntities = new List<EntityClass>();

    void Awake()
    {
        Instance = this;
    }

    public int GetEntitiesCount()
    {
        return AllEntities.Count;
    }

    public void CreateEntity()
    {
        if (AllEntities.Count < MaxEntities)
        {
            float RandResult = Random.Range(0f, 100f);

            //25%
            if (RandResult >= 75f)
            {
                AllEntities.Add(new GoodEntity(5f));
            }
            //75%
            else
            {
                AllEntities.Add(new EnemyEntity(Random.Range(1f, 15f)));
            }
        }
    }


    public void GameTimePass(float DeltaTime)
    {
        GameTime -= DeltaTime;
        GameStartedVisual.Instance.SetVisualTime(GameTime);

        if (GameTime < 0f)
        {
            FinishGame();
        }
    }

    void FinishGame()
    {

        AbortGame();

        GameStartedPanel.SetActive(false);
        ResultPanel.SetActive(true);
        ResultVisual.Instance.ShowFinalScore(GamePoints);

    }

    public void AbortGameButton()
    {
        AbortGame();
        GamePaused = false;
        StartGamePanel.SetActive(true);
        GamePausedPanel.SetActive(false);
        GameStartedPanel.SetActive(false);
    }

    public void PauseGameButton()
    {
        GamePaused = true;
        GamePausedPanel.SetActive(true);
    }

    void AbortGame()
    {
        GameStarted = false;

        foreach (var i in AllEntities)
        {
            i.DestroyMe(false);
        }
        AllEntities.Clear();

    }

    public void StartNewGame()
    {
        GamePoints = 0;
        GameStartedVisual.Instance.SetVisualScore(GamePoints);

        GameTime = 30f;
        GameStartedVisual.Instance.SetVisualTime(GameTime);

        GameStarted = true;
    }

    public void AddGamePoints(int Points)
    {
        GamePoints += Points;
        GameStartedVisual.Instance.SetVisualScore(GamePoints);
    }

    public void RemoveEntity(EntityClass ent)
    {
        if (AllEntities.Contains(ent))
        {
            AllEntities.Remove(ent);
        }
    }
}
