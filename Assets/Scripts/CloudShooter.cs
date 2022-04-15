using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudShooter : MonoBehaviour
{
    [SerializeField] GameObject rainCloud;
    [SerializeField] Camera cam;
    [SerializeField] GameObject aimArrow;

    private void Start()
    {

    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Instantiate(rainCloud, transform.position, Quaternion.identity);
        }

        transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
        UpdateAimArrow();
    }

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
