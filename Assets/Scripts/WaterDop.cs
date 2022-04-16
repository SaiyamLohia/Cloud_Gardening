using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDop : MonoBehaviour
{
    //Script attached to the droplet of water.
    [SerializeField] float sideForce = 1f;
    [SerializeField] float upForce = 0.1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cloud")) return;
        if (collision.CompareTag("RainDrop")) return;

        if(collision.CompareTag("Flower"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        try
        {
            if (transform.parent.GetComponent<ExplodingCloud>() != null)
            {
                RandomForce();
            }
        }
        catch(System.NullReferenceException) { return; }
    }

    void RandomForce()
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(upForce/2f , upForce);
        Vector2 force = new Vector2(xForce, yForce);

        GetComponent<Rigidbody2D>().velocity = force;
    }
}
