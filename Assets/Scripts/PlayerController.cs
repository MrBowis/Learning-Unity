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

        if (Input.GetKeyDown(KeyCode.A))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
    }
}
