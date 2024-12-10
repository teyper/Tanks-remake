using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLeft : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 1.5f;
    [SerializeField] float TranslationSpeed = 2f;
    [SerializeField] float Ymin = -5f; // lower boundary 
    [SerializeField] float Ymax = 5f; // upper boundary
    [SerializeField] float Xmin = -8f; // left boundary
    [SerializeField] float Xmax = 8f; // right boundary
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
        //float x = 0f;
        //float y = 0f;

        // control movement using only WASD keys for Player 2
        if (Input.GetKey(KeyCode.A)) 
        {
            transform.Rotate(0f, 0f, 0.8f);
            transform.Translate(Vector3.forward * TranslationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Rotate(0f, 0f, -0.8f);
            transform.Translate(Vector3.forward * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W)) 
        {
            transform.Translate(RotationSpeed * Time.deltaTime, 0f, 0f);
            //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(-RotationSpeed * Time.deltaTime, 0f, 0f);
        }
      
        
        //boundary checks
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
            obj.transform.rotation = transform.rotation;
            obj.transform.Translate(obj.transform.right);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "shell2")
        {
            if (hit == true) return;

            shell = collision.gameObject;
            hit = true;
            gameManager.HitByShell2();
        }
        if (collision.gameObject.tag == "player2")
        {
            animator.SetBool("explode", true);
            Destroy(gameObject, 1f);
            //shell = GetComponent<AudioSource>();
           // audioSource.Play();
        }

    }
}