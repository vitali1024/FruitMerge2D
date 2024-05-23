using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject fruitPrefab;

    [Header(" Settings ")]
    [SerializeField] private Transform fruitYSpawnPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ManagePlayerInput();
    }

    private void ManagePlayerInput()
    {
        Vector2 spawnPosition = GetClickedWorldPosition();
        if (spawnPosition.x <= 2.45 && spawnPosition.x >= -2.45)
        {
            spawnPosition.y = fruitYSpawnPos.position.y;
            GameObject fruit = Instantiate(fruitPrefab, spawnPosition, Quaternion.identity);
            fruit.tag = "Fruit"; // Add a tag to the fruit for collision detection.
        }
    }

    private Vector2 GetClickedWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
