using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public FPSController playerController;

    // creating a list containing the Prefabs of all the available items
    public PickItem[] availableItems;
    int[] itemSlots = new int[3];

    // Pick up item
    PickItem detectedItem;
    int detectedItemIndex;

    private void Update()
    {
        if (detectedItem && detectedItemIndex > -1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Add the item to inventory
                int slotToAddTo = -1;
                for (int i = 0; i < itemSlots.Length; i++)
                {
                    if (itemSlots[i] == -1)
                    {
                        slotToAddTo = i;
                        break;
                    }
                }
                if (slotToAddTo > -1)
                {
                    itemSlots[slotToAddTo] = detectedItemIndex;
                    detectedItem.PickUpItem();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // Detect if the player is looking at an item
        RaycastHit hit;
        // Returns a ray going from the camera object through the middle of the viewport (hence the 0.5 on the x and 0.5 on the y)
        Ray ray = playerController.playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, 2.5f))
        {
            Transform objectHit = hit.transform;

            if (objectHit.CompareTag("PickUp"))
            {
                if ((detectedItem == null || detectedItem.transform != objectHit) && objectHit.GetComponent<PickItem>() != null)
                {
                    PickItem itemTmp = objectHit.GetComponent<PickItem>();

                    // Check if item is in availableItemsList
                    for (int i = 0; i < availableItems.Length; i++)
                    {
                        if (availableItems[i].itemName == itemTmp.itemName)
                        {
                            detectedItem = itemTmp;
                            detectedItemIndex = i;
                        }
                    }
                }
            }
            else
            {
                detectedItem = null;
            }
        }
        else
        {
            detectedItem = null;
        }
    }

    private void OnGUI()
    {
        if (detectedItem)
        {
            GUI.color = new Color(0, 0, 0, 0.84f);
            GUI.Label(new Rect(Screen.width / 2 - 75 + 1, Screen.height / 2 - 50 + 1, 150, 20), "Press 'F' to pick up " + detectedItem.itemName);
            GUI.color = Color.green;
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 20), "Press 'F' to pick up " + detectedItem.itemName);
        }
    }
}
