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

    public void UpdateScore(bool isPlayer1, int selfPenalty, int opponentBonus)
    {
        if (gameOver) return; // Prevent score updates after game over

        if (isPlayer1)
        {
            // Player 1 hit something
            player1Score += selfPenalty;       // Player 1 loses points (if hit itself or got hit)
            player2Score += opponentBonus;     // Player 2 gains points if it successfully hit Player 1
        }
        else
        {
            // Player 2 hit something
            player2Score += selfPenalty;       // Player 2 loses points (if hit itself or got hit)
            player1Score += opponentBonus;     // Player 1 gains points if it successfully hit Player 2
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
        if (player1Score >= 50 || player2Score >= 50)
        {
            gameOver = true;
            Msg.text = "Game Over!";
            Debug.Log("Game Over!");
        }
    }
}
