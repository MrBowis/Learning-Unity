using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageColor : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("I'm attached");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("You have just pressed the play button");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key was pressed");
            this.GetComponent<SpriteRenderer>().color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("G key was pressed");
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B key was pressed");
            this.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Y key was pressed");
            this.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
