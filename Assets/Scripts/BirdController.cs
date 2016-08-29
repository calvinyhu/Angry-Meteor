using UnityEngine;
using System.Collections;

public class BirdController: MonoBehaviour
{
    public int hitPoints = 2;
    public Sprite damagedSprite;
    public float damageImpactSpeed = 5f;

    private int currentHitPoints;
    private float damageImpactSpeedSqr;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D birdRigidbody2D;
    private Collider2D birdCollider2D;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        birdRigidbody2D = GetComponent<Rigidbody2D>();
        birdCollider2D = GetComponent<Collider2D>();
        currentHitPoints = hitPoints;
        damageImpactSpeedSqr = damageImpactSpeed * damageImpactSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Damager")
            return;
        if (collision.relativeVelocity.sqrMagnitude < damageImpactSpeedSqr)
            return;

        spriteRenderer.sprite = damagedSprite;
        currentHitPoints--;

        if (currentHitPoints <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        spriteRenderer.enabled = false;
        birdCollider2D.enabled = false;
        birdRigidbody2D.isKinematic = true;
    }
}
