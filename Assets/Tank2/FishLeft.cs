using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLeft : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] float Ymin = -5f; // lower boundary 
    [SerializeField] float Ymax = 5f; // upper boundary
    [SerializeField] float Xmin = -5f; // left boundary
    [SerializeField] float Xmax = 5f; // right boundary
    [SerializeField] GameObject ShellPrefab;
    [SerializeField] float shell_x_offset = 0f;
    [SerializeField] float shell_y_offset = 0f;

    //SHELL HIT
    bool hit;
    GameObject shell;
    //GM
    GameManager gameManager;

    //sound
    [SerializeField] AudioClip hit1;
    [SerializeField] AudioClip shoot1;
    AudioSource audioSource;


    //explpsion ani
    Animator animator;
    //[SerializeField] float MaxRotationSpeed = 20f;

    void Start()
    {
        shell = GameObject.FindWithTag("shell1");
        hit = true;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        // control movement using only WASD keys for Player 2
        if (Input.GetKey(KeyCode.A)) x = -1f;
        if (Input.GetKey(KeyCode.D)) x = 1f;
        if (Input.GetKey(KeyCode.W)) y = 1f;
        if (Input.GetKey(KeyCode.S)) y = -1f;

        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0f);

        // boundary checks for Player 2
        if (transform.position.x > Xmax)
            transform.position = new Vector3(Xmax, transform.position.y, transform.position.z);
        if (transform.position.x < Xmin)
            transform.position = new Vector3(Xmin, transform.position.y, transform.position.z);
        if (transform.position.y > Ymax)
            transform.position = new Vector3(transform.position.x, Ymax, transform.position.z);
        if (transform.position.y < Ymin)
            transform.position = new Vector3(transform.position.x, Ymin, transform.position.z);


       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hi");
            GameObject obj = Instantiate(ShellPrefab);
            obj.transform.position = transform.position + new Vector3(shell_x_offset, shell_y_offset, 0f);
        }
        /* void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "shell2")
            {
                if (hit == true) return;

                shell = collision.gameObject;
                hit = true;
                gameManager.HitByShell2();
            }
        if(collision.gameObject.tag== "player2")
            {
                animator.SetBool("explode", true);
                Destroy(gameObject, 1f);
                audioSource = GetComponent<AudioSource>();
                audioSource.Play();
            }
    }*/
}
}
