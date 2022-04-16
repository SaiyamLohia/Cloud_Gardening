using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingCloud : MonoBehaviour
{
    //Script on the launched cloud projectile.

    CloudShooter shooter;
    Rigidbody2D rb;

    [SerializeField] float launchForce;
    bool hasExploded;

    [SerializeField] GameObject rainDrop;
    void Start()
    {
        shooter = FindObjectOfType<CloudShooter>();
        rb = GetComponent<Rigidbody2D>();

        rb.AddForce(shooter.transform.forward * launchForce * 1000);
        StartCoroutine(Explode());
    }

    private void FixedUpdate()
    {
        if (!hasExploded) return;

        StartCoroutine(WaterExplodeTimer());
        SpawnRaindrops();
    }

    private void SpawnRaindrops()
    {
        for(int i = 0; i < 15; i++)
        {
            Instantiate(rainDrop, gameObject.transform);
        }
    }

    IEnumerator WaterExplodeTimer()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().forceRenderingOff = true;
        hasExploded = false;
    }
    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        hasExploded = true;
    }

}
