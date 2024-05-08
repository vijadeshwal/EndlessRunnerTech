using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomRowItem : MonoBehaviour
{
    [SerializeField] private GameObject[] items; // Array of items (assumes exactly 4 items are assigned in the Inspector)
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

        int firstItem = Random.Range(0, items.Length); // Generate a random index for the first item
        int secondItem;

        do
        {
            secondItem = Random.Range(0, items.Length); // Generate a random index for the second item
        } while (secondItem == firstItem); // Keep generating until the second item index is different from the first one

        items[firstItem].SetActive(true); // Activate the first item
        items[firstItem].transform.localPosition = new Vector3(positions[firstItemIndex], items[firstItem].transform.localPosition.y, items[firstItem].transform.localPosition.z);

        items[secondItem].SetActive(true); // Activate the second item
        items[secondItem].transform.localPosition = new Vector3(positions[secondItemIndex], items[secondItem].transform.localPosition.y, items[secondItem].transform.localPosition.z);


    }

    // Update is called once per frame
    void Update()
    {
        // Optional: add real-time interactions or reconfigurations
    }
}
