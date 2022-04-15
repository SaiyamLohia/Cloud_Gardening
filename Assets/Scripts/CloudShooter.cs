using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloudShooter : MonoBehaviour
{
    [SerializeField] GameObject rainCloud;
    [SerializeField] Camera cam;
    [SerializeField] GameObject aimArrow;
    int cloudCount = 0;
    [SerializeField] int cloudsAllowed = 3;
    [SerializeField] TextMeshProUGUI cloudText;

    private void Start()
    {
        UpdateCloudText();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1) && cloudCount < cloudsAllowed)
        {
            Instantiate(rainCloud, transform.position, Quaternion.identity);
            cloudCount++;
            UpdateCloudText();
        }

        transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
        UpdateAimArrow();
    }

    //Updates the "Clouds Remaining" GUI element.
    void UpdateCloudText()
    {
        cloudText.text = "Clouds left: " + (cloudsAllowed - cloudCount).ToString();
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
