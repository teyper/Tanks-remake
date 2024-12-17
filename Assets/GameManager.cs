using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text Msg;
    [SerializeField] TMP_Text ScoreText1;
    [SerializeField] TMP_Text ScoreText2;

    public int player1Score = 0;
    public int player2Score = 0;
    public bool gameOver = false;

    void Start()
    {
        gameOver = false;
        Msg.text = "";
        UpdateScoreUI();
    }

    // UpdateScore with 2 arguments (as used in FishLeft and FishRight)
    public void UpdateScore(bool isPlayer1, int points)
    {
        if (gameOver) return; // Prevent score updates after game over

        if (isPlayer1)
        {
            // Player 1 score update
            player1Score += points;

            if (points > 0) // If Player 1 gained points, Player 2 loses points
            {
                player2Score -= points; // Deduct the same amount from Player 2
            }
        }
        else
        {
            // Player 2 score update
            player2Score += points;

            if (points > 0) // If Player 2 gained points, Player 1 loses points
            {
                player1Score -= points; // Deduct the same amount from Player 1
            }
        }

        CheckGameOver(); // Check game over condition
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        ScoreText1.text = "Player 1: " + player1Score;
        ScoreText2.text = "Player 2: " + player2Score;
    }

    void CheckGameOver()
    {
        if (player1Score >= 100 || player2Score >= 100 || player1Score <= -100 || player2Score <= -100)
        {
            gameOver = true;
            Msg.text = "Game Over!";
            Debug.Log("Game Over!");
            Invoke("ReloadSplashScreen", 1f); // Return to splash screen after 3 seconds
        }
    }

    void ReloadSplashScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Splasher");
    }
}

