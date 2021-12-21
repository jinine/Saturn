using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public Sprite[] sprites;

    public float size;
    public float minSize;
    public float speed = 50.0f;
    public float maxSize;

    public float max_lifespan = 30.0f;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, Random.value * 360.0f);

        this.transform.localScale = Vector3.one * this.size;

        GetComponent<Rigidbody2D>().mass = this.size;

    }

    public void SetTrajectory(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
        Destroy(this.gameObject, max_lifespan);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            FindObjectOfType<GameManager>().AsteroidDestroyed(this);
            Destroy(this.gameObject);
        }
    }

    // private void CreateSplit()
    // {
    //     Vector2 position = this.transform.position;
    //     position += Random.insideUnitCircle * 0.5f;
    //     Asteroid half = Instantiate(this, position, this.transform.rotation);
    //     half.size = this.size * 0.0f;
    //     half.SetTrajectory(Random.insideUnitCircle.normalized * speed);
    // }

}
