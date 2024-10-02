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
        double jumpCooldown = 3;
        if (Input.GetKeyDown(KeyCode.W) && Time.time > jumpCooldown)
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            jumpCooldown = Time.time + 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x - 0.01f, this.GetComponent<Transform>().position.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.GetComponent<Transform>().position = new Vector2(this.GetComponent<Transform>().position.x + 0.01f, this.GetComponent<Transform>().position.y);
        }
    }
}
