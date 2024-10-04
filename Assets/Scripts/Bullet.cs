using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1.5f;
    public Vector2 direction = new Vector2(1, 0);
    public float lifeTime = 2f;
    public Color initialColor = Color.white;
    public Color finalColor;

    private SpriteRenderer _spriteRenderer;
    private float _timeAlive = 0f;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _timeAlive = Time.time;
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = direction.normalized * speed * Time.deltaTime;
        transform.Translate(direction * speed * Time.deltaTime);

        float _timeSinceStarted = Time.time - _timeAlive;
        float _percentage = _timeSinceStarted / lifeTime;

        _spriteRenderer.color = Color.Lerp(initialColor, finalColor, _percentage);
    }
}
