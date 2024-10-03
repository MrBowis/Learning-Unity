using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptDePrueba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.FindWithTag("Main Camera");

        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            camera.transform.position = new Vector3(camera.transform.position.x - 0.01f, camera.transform.position.y, -1);
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x - 0.01f, GetComponent<Transform>().position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            camera.transform.position = new Vector3(camera.transform.position.x + 0.01f, camera.transform.position.y, -1);
            GetComponent<Transform>().position = new Vector2(GetComponent<Transform>().position.x + 0.01f, GetComponent<Transform>().position.y);
        }
    }
}
