using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float waitTime = 2f;
    public float visionRange;
    public float distanceToPlayer;
    private GameObject _target;
    private bool shouldStartCoroutine = false;
    private Animator _animator;
    private Weapon _weapon;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindWithTag("Player");
        Vector2 direction = player.transform.position - transform.position;
        float distanceX = transform.position.x - player.transform.position.x;

        transform.localScale = new Vector3(direction.x < 0 ? -1 : 1, 1, 1);
        
        if (distanceX < visionRange && distanceX > -visionRange)
        {
            StopCoroutine("PatrolToTarget");
            _animator.SetBool("Idle", true);
            _animator.SetTrigger("Shoot");
            float dP = distanceX < 0 ? -distanceToPlayer : distanceToPlayer;
            _target.transform.position = new Vector2(player.transform.position.x + dP, transform.position.y);
            _weapon.Shoot();
            shouldStartCoroutine = true;
        } else if (shouldStartCoroutine)
        {
            UpdateTarget();
            StartCoroutine("PatrolToTarget");
            shouldStartCoroutine = false;
        }
    }

    private void UpdateTarget()
    {
        
        if (_target == null)
        {
            _target = new GameObject("Target");
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }

        if(_target.GetComponent<Transform>().position.x != minX && _target.GetComponent<Transform>().position.x != maxX)
        {
            _target.GetComponent<Transform>().position = new Vector2(minX, transform.position.y);
            return;
        }
        
        if (_target.transform.position.x == minX)
        {
            _target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_target.transform.position.x == maxX)
        {
            _target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private IEnumerator PatrolToTarget()
    {
        while (Vector2.Distance(transform.position, _target.transform.position) > 0.05f)
        {
            _animator.SetBool("Idle", false);

            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);
            transform.localScale = new Vector3(xDirection < 0 ? -1 : 1, 1, 1);
            yield return null;
        }

        Debug.Log("Reached the target");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);
        UpdateTarget();

        _animator.SetBool("Idle", true);

        Debug.Log("Waiting for " + waitTime + " seconds");
        yield return new WaitForSeconds(waitTime);
        
        Debug.Log("Waited enough time");
        StartCoroutine("PatrolToTarget");
    }
}