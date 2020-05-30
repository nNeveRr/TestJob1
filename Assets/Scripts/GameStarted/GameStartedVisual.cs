using UnityEngine;
using UnityEngine.UI;

public class GameStartedVisual : MonoBehaviour
{
    public static GameStartedVisual Instance;

    public RectTransform BordersObject;

    [SerializeField]
    Text ScoreText;

    [SerializeField]
    Text TimeText;


    void Awake()
    {
        Instance = this;
    }

    public void SetVisualScore(int score)
    {
        ScoreText.text = "Счет: " + score;
    }

    public void SetVisualTime(float time)
    {
        TimeText.text = string.Format("Время: {0:N1}", time);
    }
}
