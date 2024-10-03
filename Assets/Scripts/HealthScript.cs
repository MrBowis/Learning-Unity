using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("TakeDamage", 1f, 1f);
    }

    void TakeDamage()
    {
        this.GetComponent<SpriteRenderer>().size = new Vector2(this.GetComponent<SpriteRenderer>().size.x + this.GetComponent<SpriteRenderer>().size.x, this.GetComponent<SpriteRenderer>().size.y);
    }
}
