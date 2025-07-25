using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rig;
    public float force = 10f;
    private void OnValidate()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        rig.velocity = Vector2.zero;
        rig.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ObjectPooler.Instance.ReturnToPool("Bullet", gameObject);
        }
    }
}
