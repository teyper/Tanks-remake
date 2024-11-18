using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellmove : MonoBehaviour
{
    [SerializeField] float Speed = 4f;
    [SerializeField] float LifeTime = 3f;
    [SerializeField] Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.velocity = new Vector3(Speed, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        //transform.Translate(Speed * Time.deltaTime, 0f, 0f);

    }

    private void OnTriggerEnter2D(Collider2D collision) //destroy on collision
    {
        Destroy(gameObject);
    }
}
