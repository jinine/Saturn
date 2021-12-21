using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    public float max_distance = 10.0f;
    public GameObject hitEffect;

    public void Project(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
        Destroy(this.gameObject, max_distance);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(hitEffect, 5.0f);
        Destroy(this.gameObject);
    }

}
