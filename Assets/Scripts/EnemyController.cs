using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class Enemycontroller : MonoBehaviour
{
    public float speed;
    public float minX;
    public float maxX;
    public float waitTime = 2f;
    public float distanceToTarget;
    public float distanceToPlayer;

    private GameObject _target;
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
        if (_target == null)
        {
            _target = new GameObject("Target");
        }

        if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
        
        if (distanceX < distanceToTarget && distanceX > -distanceToTarget)
        {
            StopCoroutine("PatrolToTarget");
            float dP = distanceX < 0 ? -distanceToPlayer : distanceToPlayer;
            _target.transform.position = new Vector2(player.transform.position.x + dP, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, speed * Time.deltaTime);
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
            Vector2 direction = _target.transform.position - transform.position;
            float xDirection = direction.x;

            transform.Translate(direction.normalized * speed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Reached the target");
        transform.position = new Vector2(_target.transform.position.x, transform.position.y);

        Debug.Log("Waiting for " + waitTime + " seconds");
        yield return new WaitForSeconds(waitTime);
        
        Debug.Log("Waited enough time");
        UpdateTarget();
        StartCoroutine("PatrolToTarget");
    }
}