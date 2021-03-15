using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Text slotNum;
    
    public void ItemOnClicked()
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
        Debug.Log(slotItem);
        
        if (slotItem.itemCount > 0)
        {
            slotItem.itemCount--;
        }
        else
        {
            InventoryManager.RemoveItem(slotItem);
        }
        InventoryManager.RefreshItem();
    }
}
