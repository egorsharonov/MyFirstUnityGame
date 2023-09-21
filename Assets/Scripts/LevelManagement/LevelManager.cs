using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField, Range(0, 3000f)] private float scoreToFinish;

    [SerializeField] private float score;
    [SerializeField] private TMP_Text scoreText;
    private float Score { get => score;  set {score = value; scoreText.text = value.ToString();} }

    private void Start()
    {
        Score = 0;
        Debug.Log(PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 0));
    }

    public void AddScore(float amount)
    {
        Score += amount;
    }

    public bool Finish()
    {
        string message = (Score >= scoreToFinish) ? "Pobeda" : "Ne polychilos'";
        Debug.Log(message);

        if (score > PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name, Score);
        }

        return Score >= scoreToFinish;
    }
}