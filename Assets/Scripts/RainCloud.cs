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
        StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform tr in transform) children.Add(tr);

        Instantiate(rainDrop, children[Random.Range(0, children.Count)].position, Quaternion.identity);

        yield return new WaitForSeconds(0.1f);

        StartCoroutine(Rain());
    }
}
