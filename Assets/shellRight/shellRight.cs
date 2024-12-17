using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellRight : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float LifeTime = 2f;
    Rigidbody2D Shellrb;
    GameManager gMan;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
        Shellrb = GetComponent<Rigidbody2D>();
        gMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision) //destroy on collision
    {
        if (collision.gameObject.tag == "fishy")
        {
            //Man.HitByShell1();
            if (gMan != null) // Ensure gameManager exists
            {
               // gMan.Score += 10; // Increment score by 10

                Debug.Log("Score Incremented!");
            }
            else
            {
                Debug.LogError("GameManager reference is null.");
            }
           // if (gMan.Score >= 50)
            {
                //SendMessage.text = "Game Over!";
                gMan.gameOver = true;
                Destroy(gameObject);
            }
            if (collision.gameObject.tag == "fishy2")
            {
                //gMan.HitByShell2();
                Destroy(gameObject);
            }
        }
    }
}