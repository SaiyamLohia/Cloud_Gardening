using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDop : MonoBehaviour
{
    //Script attached to the droplet of water.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //returning if the droplet collides with the cloud.
        if (collision.CompareTag("Cloud")) return;

        //Checking if it collided with a flower
        if(collision.CompareTag("Flower"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }

        Destroy(gameObject);
    }
}
