using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private Score _scoreCounter;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable()
    {
        _scoreCounter.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _scoreText.text = score.ToString();
    }
}
