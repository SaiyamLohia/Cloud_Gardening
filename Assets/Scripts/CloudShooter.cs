using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloudShooter : MonoBehaviour
{
    [SerializeField] GameObject rainCloud;
    [SerializeField] Camera cam;
    [SerializeField] GameObject aimArrow;
    bool hasShot = false;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !hasShot)
        {
            Instantiate(rainCloud, transform.position, Quaternion.identity);
            hasShot = true;
        }

        transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
        UpdateAimArrow();
    }

    //Updates the arrow used for aiming
    void UpdateAimArrow()
    {

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        aimArrow.transform.up = direction;
    }
}
