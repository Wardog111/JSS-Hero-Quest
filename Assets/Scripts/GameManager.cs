using UnityEngine;
using UnityEngine.UI; // For UI components
using TMPro;

public class GameManager : MonoBehaviour
{
  //  [SerializeField] private Text timerText; // Drag TimerText here
    //[SerializeField] private Text resultText; // Drag ResultText here
    [SerializeField] private float countdownTime = 30f;
    [SerializeField] private int totalSlimesToKill = 20;
    [SerializeField] private TextMeshProUGUI timerText; // Drag TimerText here
    [SerializeField] private TextMeshProUGUI resultText; // Drag ResultText here

    private float remainingTime;
    private int slimesKilled = 0;
    private bool isGameOver = false;

    private void Start()
    {
        remainingTime = countdownTime;
        UpdateTimerUI();
        resultText.text = ""; // Ensure result text is initially empty
    }

    private void Update()
    {
        if (isGameOver) return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            remainingTime = 0;
            EndGame(false); // Time's up
        }

        UpdateTimerUI();
    }

    public void IncrementSlimeKillCount()
    {
        if (isGameOver) return;

        slimesKilled++;
        if (slimesKilled >= totalSlimesToKill)
        {
            EndGame(true); // Player wins
        }
    }

    private void EndGame(bool playerWon)
    {
        isGameOver = true;
        resultText.text = playerWon ? "You Win!" : "Game Over";
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(remainingTime) + "s";
    }
}
