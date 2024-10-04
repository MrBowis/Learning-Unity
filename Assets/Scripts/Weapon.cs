using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform _firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _firePoint = transform.Find("FirePoint");
        bulletPrefab.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;
        if (GetComponent<SpriteRenderer>().flipX)
            bulletPrefab.GetComponent<Bullet>().direction = new Vector2(-1, 0);
        else
            bulletPrefab.GetComponent<Bullet>().direction = new Vector2(1, 0);

        if(Input.GetKeyDown(KeyCode.F))
        Instantiate(bulletPrefab, _firePoint.transform.position, Quaternion.identity);
    }
}
