using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rotationSpeed;
    public float movementSpeed;
    public Bullet bulletPrefab;
    public GameObject DeathEffect;


    // public float cooldown = 1f;

    private void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody2D>().AddForce(transform.up * movementSpeed);

        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody2D>().AddForce(transform.up * -movementSpeed);


        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up * rotationSpeed);
            GetComponent<Rigidbody2D>().AddTorque(rotationSpeed * movementSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed);
            GetComponent<Rigidbody2D>().AddTorque(-rotationSpeed * movementSpeed);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }

    }

}