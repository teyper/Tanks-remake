using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellmove : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float LifeTime = 3f;
     Rigidbody2D Shellrb;
    GameManager gMan;
    


    // Start is called before the first frame update
    void Start()
    {
      Destroy(gameObject, LifeTime);
       Shellrb = GetComponent<Rigidbody2D>();
       gMan = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

        //Shellrb.velocity = Speed * transform.forward;
    }


    private void OnCollisionEnter2D(Collision2D collision) //destroy on collision
    {
        
        if(collision.gameObject.tag == "fishy")
        {
            gMan.HitByShell1();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "fishy2")
        {
            gMan.HitByShell2();
            Destroy(gameObject);
        }
    }
}
