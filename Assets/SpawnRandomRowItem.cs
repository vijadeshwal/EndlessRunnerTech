using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRowItem : MonoBehaviour
{
    [SerializeField] private GameObject[] items; // Array of items (assumes exactly 3 items are assigned in the Inspector)
    [SerializeField] private GameObject goodItem; // The special good item

    private float[] positions = new float[] { -1f, 0f, 1f }; // Fixed positions on the X-axis

    // Start is called before the first frame update
    void Start()
    {
        SetupItems(); // Set up items at the start
    }

    void SetupItems()
    {
        // Shuffle positions to randomly select where to place the good item
        List<int> availablePositions = new List<int> { 0, 1, 2 };
        int goodItemPositionIndex = Random.Range(0, availablePositions.Count);
        goodItem.transform.localPosition = new Vector3(positions[goodItemPositionIndex], goodItem.transform.localPosition.y, goodItem.transform.localPosition.z);

        // Remove the chosen position for the good item from available positions
        availablePositions.RemoveAt(goodItemPositionIndex);

        // Enable and position the two items
        int firstItemIndex = availablePositions[0];
        int secondItemIndex = availablePositions[1];

        items[0].SetActive(true); // Ensure the first item is active
        items[0].transform.localPosition = new Vector3(positions[firstItemIndex], items[0].transform.localPosition.y, items[0].transform.localPosition.z);

        items[1].SetActive(true); // Ensure the second item is active
        items[1].transform.localPosition = new Vector3(positions[secondItemIndex], items[1].transform.localPosition.y, items[1].transform.localPosition.z);

        // Disable the third item
        items[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Optional: add real-time interactions or reconfigurations
    }
}
