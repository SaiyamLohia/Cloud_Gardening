using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloud : MonoBehaviour
{
    //Script on the launched cloud projectile.

    CloudShooter shooter;
    Rigidbody2D rb;

    [SerializeField] float launchForce;

    [SerializeField] GameObject rainDrop;
    void Start()
    {
        shooter = FindObjectOfType<CloudShooter>();
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(shooter.transform.forward * launchForce * 1000);
    }

    //Method by Unity, run when the cloud is left clicked on. 
    private void OnMouseDown()
    {
        Vector2 pos = transform.position;
        Instantiate(rainDrop, pos, Quaternion.identity);
    }
}
