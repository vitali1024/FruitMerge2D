using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private bool isMerging = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the same tag "Fruit" and is not already merging
        if (collision.gameObject.CompareTag("Fruit") && !isMerging)
        {
            // Get the Fruit script of the other fruit
            Fruit otherFruitScript = collision.gameObject.GetComponent<Fruit>();

            // Ensure the other fruit is not null and is of the same size
            if (otherFruitScript != null && !otherFruitScript.isMerging && AreSameSize(otherFruitScript))
            {
                // Merge the fruits
                MergeFruits(collision.gameObject);
            }
        }
    }

    private bool AreSameSize(Fruit otherFruit)
    {
        // Compare the sizes of the two fruits
        return Mathf.Approximately(transform.localScale.x, otherFruit.transform.localScale.x) &&
               Mathf.Approximately(transform.localScale.y, otherFruit.transform.localScale.y);
    }

    private void MergeFruits(GameObject otherFruit)
    {
        // Prevent the other fruit from initiating another merge
        Fruit otherFruitScript = otherFruit.GetComponent<Fruit>();
        if (otherFruitScript != null)
        {
            otherFruitScript.isMerging = true;

            // Increase the size of this fruit
            transform.localScale *= 1.2f; // Increase size by 20%

            // Destroy the other fruit
            Destroy(otherFruit);
        }
    }
}
