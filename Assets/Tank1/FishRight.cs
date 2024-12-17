using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 1.5f;
    [SerializeField] float TranslationSpeed = 2f;
    [SerializeField] float shellSpeed = 5f;

    // public GameObject shellPrefab;

    [SerializeField] float Ymin = -5f;
    [SerializeField] float Ymax = 5f;
    [SerializeField] float Xmin = -8f;
    [SerializeField] float Xmax = 8f;

    [SerializeField] GameObject ShellPrefab;

    [SerializeField] float shell_x_offset = 0.5f; // Offset for bullet spawn
    [SerializeField] float shellLifetime = 2f;    // Time before shell gets destroyed

    Rigidbody2D rb;
    GameManager gMan;
    Animator animator;
    AudioSource audi;




    void Start()
    {
        // Set a static initial position for Player 1 to avoid random relocation
        gMan = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            FishShooting();
        }
        KeepInBounds();


        // Control movement using only Arrow keys for Player 1
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -0.8f);
            transform.Translate(Vector3.forward * TranslationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
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



        void FishShooting()
        {
            // Shoot shell when space key is pressed
            //if (Input.GetKeyDown(KeyCode.Space))

            //                float angle = rb.rotation * Mathf.Deg2Rad;
            Debug.Log("Shell fired!");


            // Calculate spawn position offset relative to player
            Vector3 spawnPosition = transform.position + transform.right * shell_x_offset;

            // Instantiate the shell
            GameObject shell = Instantiate(ShellPrefab, spawnPosition, transform.rotation);

            // Add velocity to the shell
            Rigidbody2D shellRb = shell.GetComponent<Rigidbody2D>();

            //shellRb.velocity = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            // Move the shell forward
            Debug.Log("Shell velocity set: ");
            shellRb.AddForce(transform.right * shellSpeed);




        }

        void KeepInBounds()
        {
            // Clamp player position to stay within screen boundaries
            float clampedX = Mathf.Clamp(transform.position.x, Xmin, Xmax);
            float clampedY = Mathf.Clamp(transform.position.y, Ymin, Ymax);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "shell")
        {
            animator.SetBool("explode", true);
            animator.Play("explode", 0, 0f);
            //animator.SetBool("fishSwim", false);


        }

        if (collision.gameObject.tag == "shell2")
        {
            animator.SetBool("explode", true);
            animator.Play("explode", 0, 0f);
            // animator.SetBool("fishSwim", false);
            Destroy(ShellPrefab, 3f);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        StartCoroutine(ResetAnimation());
    }

    IEnumerator ResetAnimation()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("fishSwim", true);
        animator.SetBool("explode", false);

    }




}


