using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    //[SerializeField] TMP_Text timer;
    [SerializeField] TMP_Text Msg;
    [SerializeField] TMP_Text ScoreText1;
    [SerializeField] TMP_Text ScoreText2;


    int Score = 0;

    public void HitByShell1()
    {
        Score += 10;
       
    }

    public void HitByShell2()
    {
        Score += 10;

    }



    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {

        gameOver = false;
        //timer.text = "hELLO";
        Msg.text = "";
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            return;
        }
        ScoreText1.text = "Score:" + Score.ToString();
        ScoreText2.text = "Score:" + Score.ToString();
        //float time_left = 30 - Time.time;
        //timer.text = "Time:" + time_left.ToString("0");
        //  Debug.Log(30 - Time.time < 0);
        if (Score >= 50)
        {
            //SendMessage.text = "Game Over!";
            gameOver = true;
            Msg.text = "Game Over!";
        }


    }
}
