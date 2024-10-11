using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public float lifeTime = 1f;
    public GameObject prefab;
    public GameObject point;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InstantiateDust()
    {
        GameObject dust = Instantiate(prefab, point.transform.position, Quaternion.identity);
        
        if (lifeTime > 0f)
        {
            Destroy(dust, lifeTime);
        }
    }
}
