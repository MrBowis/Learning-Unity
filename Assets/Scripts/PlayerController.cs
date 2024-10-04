using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePrueba : MonoBehaviour
{
    public float speed = 1.5f;
    public Vector2 direction = new Vector2(1, 0);
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");

        // if (Input.GetAxis("Vertical") > 0)
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }

        // if (Input.GetAxis("Horizontal") < 0)
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            camera.transform.position = new Vector3((camera.transform.position.x - 0.01f) * Time.deltaTime, camera.transform.position.y, -1);
            transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
        }

        // if (Input.GetAxis("Horizontal") > 0)
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            camera.transform.position = new Vector3((camera.transform.position.x + 0.01f) * Time.deltaTime, camera.transform.position.y, -1);
            transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
        }
    }
}
