using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellRight : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float LifeTime = 2f;

    GameManager gMan;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    
    private void OnTriggerEnter2D(Collider2D collision) //destroy on collision
    {
        if (collision.gameObject.tag == "fishy")
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
