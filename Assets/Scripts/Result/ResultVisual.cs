using UnityEngine;
using UnityEngine.UI;

public class ResultVisual : MonoBehaviour
{
    public static ResultVisual Instance;

    [SerializeField]
    Text FinalScoreText;

    void Awake()
    {
        Instance = this;
    }

    public void ShowFinalScore(int score)
    {
        FinalScoreText.text = "Счет: " + score;
    }
}
