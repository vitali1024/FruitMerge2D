using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenMousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
        Vector3 currentPosition = transform.position;
        currentPosition.x = worldMousePosition.x;
        if (worldMousePosition.x <= 2.45 && worldMousePosition.x >= -2.45)
        {
            transform.position = currentPosition;
        }
        else if (worldMousePosition.x > 2.45)
        {
            currentPosition.x = 2.45f;
            transform.position = currentPosition;
        }
        else if (worldMousePosition.x < -2.45)
        {
            currentPosition.x = -2.45f;
            transform.position = currentPosition;
        }
    }
}
