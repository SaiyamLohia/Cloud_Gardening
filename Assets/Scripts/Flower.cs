using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    bool hasUpdated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("RainDrop") && !hasUpdated)
        {
            hasUpdated = true;
            SceneOrganizer organizer = FindObjectOfType<SceneOrganizer>();
            organizer.UpdateFlowerDoneCount();
        }
    }
}
