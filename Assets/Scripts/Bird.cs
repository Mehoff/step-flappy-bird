using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool IsAlive = true;
    public float Force;
    public float FloatForce;

    public ParticleSystem particle;

    void Start()
    {
        Force = 5000f;
        FloatForce = 100f;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 2;

    }
    void Update()
    {
        if (!IsAlive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * Force * Time.fixedDeltaTime);
            GenerateParticle();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * FloatForce * Time.fixedDeltaTime);
            GenerateParticle();
        }
    }

    void GenerateParticle()
    {
        particle.Play();
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Enemy":
                Die();
                break;
            case "Score":
                {
                    GameController.AddScore(1);
                    Destroy(other.gameObject);
                }
                break;
        }
        Debug.Log($"<!>Collision: {other.gameObject.name}");
    }

    void Die()
    {
        IsAlive = false;
    }
}
