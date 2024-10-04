using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    private Transform _firePoint;

    void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null)
        {
            GameObject bulletComponent = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bullet = bulletComponent.GetComponent<Bullet>();

            if (shooter.GetComponent<Transform>().localScale.x < 0)
                bullet.direction = Vector2.left;
            else
                bullet.direction = Vector2.right;
        } else {
            Debug.Log("Something is missing, try setting the bulletPrefab or shooter");
        }
    }
}
