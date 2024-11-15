using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamepad : MonoBehaviour
{
    [SerializeField] float Speed = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame



    void Update()
    {
        float x;
        float y;

        x = Input.GetAxis("Horizontal");
        transform.Translate(x * Speed * Time.deltaTime, 0f, 0f);
        y = Input.GetAxis("Vertical");
        transform.Translate(0f, y * Speed * Time.deltaTime, 0f);
        //Debug.Log(x);
    }
}
