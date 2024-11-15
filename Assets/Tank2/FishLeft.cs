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

    //[SerializeField] float MaxRotationSpeed = 20f;

    void Start()
    {
        // set a static initial position for Player 2 to avoid random relocation
        //
        //
        //transform.position = new Vector3(-7f, 0f, 0f);
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


       // float rotation;
       // rotation = MaxRotationSpeed * Time.deltaTime * transform.position.z;
       // transform.Rotate(0f, 0f, rotation);

        // instantiate shell on Fire2 button press (custom mapping if needed)
        //if (Input.GetButtonDown("Fire2")) // Ensure "Fire2" is mapped to a different key/button

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hi");
            GameObject obj = Instantiate(ShellPrefab);
            obj.transform.position = transform.position + new Vector3(shell_x_offset, shell_y_offset, 0f);
        }
    }
}
