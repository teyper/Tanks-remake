using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    [SerializeField] float TranslationSpeed = 2f;
    [SerializeField] float RotationSpeed = 2f;
    [SerializeField] float Ymin = -5f; // lower boundary 
    [SerializeField] float Ymax = 5f; // upper boundary
    [SerializeField] float Xmin = -5f; // left boundary
    [SerializeField] float Xmax = 5f; // right boundary
    [SerializeField] GameObject ShellPrefab;
    [SerializeField] float shell_x_offset = 0f;
    [SerializeField] float shell_y_offset = 0f;

    GameManager gameManager;
    Animator animator;
    AudioSource audiosource;
    GameObject fishy;

    bool Xplode;


    [SerializeField] AudioClip explosion;

    void Start()
    {
        // Set a static initial position for Player 1 to avoid random relocation
        gameManager = FindObjectOfType<GameManager>();
        fishy = GameObject.FindWithTag("fish");
        Xplode = true; //assume fishyR is hit 
        animator = GetComponent<Animator>();

    }

    void Update()
    {

        // Control movement using only Arrow keys for Player 1
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, -0.8f);
            transform.Translate(Vector3.forward * TranslationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, 0.8f);
            transform.Translate(Vector3.forward * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(-RotationSpeed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(RotationSpeed * Time.deltaTime, 0f, 0f);
        }
        //transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0f);

        // Boundary checks for Player 1
        if (transform.position.x > Xmax)
            transform.position = new Vector3(Xmax, transform.position.y, transform.position.z);
        if (transform.position.x < Xmin)
            transform.position = new Vector3(Xmin, transform.position.y, transform.position.z);
        if (transform.position.y > Ymax)
            transform.position = new Vector3(transform.position.x, Ymax, transform.position.z);
        if (transform.position.y < Ymin)
            transform.position = new Vector3(transform.position.x, Ymin, transform.position.z);

        // Instantiate shell on Fire1 button press
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            GameObject obj = Instantiate(ShellPrefab);
            Debug.Log("hi");
            obj.transform.position = transform.position + new Vector3(shell_x_offset, shell_y_offset, 0f);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {

        if (collision.gameObject.tag == "shell")
        {
            if (Xplode == true) //only happens if youre hit
            {
                animator.SetBool("explode", true);
                Destroy(gameObject, 1f);
                //audioSource = GetComponent<AudioSource>();
                //audioSource.Play();
            }
        }
    }
}