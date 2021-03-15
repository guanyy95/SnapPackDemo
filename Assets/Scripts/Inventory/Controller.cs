using UnityEngine;

public class Controller : MonoBehaviour
{
    private bool isOpen;
    [SerializeField] private Item sword;
    [SerializeField] private Item boosters;
    [SerializeField] private Item armor;

    [SerializeField] private Inventory playerInventory;


    [SerializeField] private GameObject bag;

    void Update()
    {
        OpenMyBag();
        AddItem();
    }

    private void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            isOpen = !isOpen;
            bag.SetActive(isOpen);
        }
    }

    private void AddItem()
    {
        // 处理sword item 操作
        if (Input.GetKeyDown(KeyCode.A))
        {
            sword.itemCount++;
            if (!playerInventory.itemList.Contains(sword))
            {
                playerInventory.itemList.Add(sword);
                InventoryManager.CreateNewItem(sword);
            }
            InventoryManager.RefreshItem();
        }

        // 处理booster item操作
        if (Input.GetKeyDown(KeyCode.S))
        {
            boosters.itemCount++;
            if (!playerInventory.itemList.Contains(boosters))
            {
                playerInventory.itemList.Add(boosters);
                InventoryManager.CreateNewItem(boosters);
            }
            InventoryManager.RefreshItem();
        }

        // 处理armor 操作
        if (Input.GetKeyDown(KeyCode.D))
        {
            armor.itemCount++;
            if (!playerInventory.itemList.Contains(armor))
            {
                playerInventory.itemList.Add(armor);
            }
            InventoryManager.RefreshItem();
        }
    }
}
