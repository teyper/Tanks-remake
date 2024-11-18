using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishRight : MonoBehaviour
{
    [SerializeField] float Speed = 2f;
    [SerializeField] float Ymin = -5f; // lower boundary 
    [SerializeField] float Ymax = 5f; // upper boundary
    [SerializeField] float Xmin = -5f; // left boundary
    [SerializeField] float Xmax = 5f; // right boundary
    [SerializeField] GameObject ShellPrefab;
    [SerializeField] float shell_x_offset = 0f;
    [SerializeField] float shell_y_offset = 0f;

    void Start()
    {
        // Set a static initial position for Player 1 to avoid random relocation
        transform.position = new Vector3(7f, 0f, 0f);
    }

    void Update()
    {
        float x = 0f;
        float y = 0f;

        // Control movement using only Arrow keys for Player 1
        if (Input.GetKey(KeyCode.LeftArrow)) x = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) x = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) y = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) y = -1f;

        transform.Translate(x * Speed * Time.deltaTime, y * Speed * Time.deltaTime, 0f);

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
}
