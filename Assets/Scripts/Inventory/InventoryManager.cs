using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager instance;
    private Item selectedItem;
    
    public Inventory myBag;
    public GameObject slotGrid;
    public Slot slotPrefab;
    public Text itemInfomation;
    
    
    
    /// <summary>
    /// 初始化背包内容
    /// </summary>
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInfomation.text = "";
    }
    
    /// <summary>
    /// 动态更新面板道具信息显示
    /// </summary>
    /// <param name="itemDescription"></param>
    public static void UpdateItemInfo(string itemDescription)
    {
        instance.itemInfomation.text = itemDescription;
        
    }
    
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }
    /// <summary>
    /// 初始化item内容，并且赋值
    /// </summary>
    /// <param name="item"></param>
    public static void CreateNewItem(Item item)
    {
        if (item.itemCount == 0)
        {
            return;
        }
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        // 将new Item 放置到bag当中
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemCount.ToString();
    }
    
    /// <summary>
    /// 点击使用物品后进行移除
    /// </summary>
    /// <param name="item"></param>
    public static void RemoveItem(Item item)
    {
        instance.myBag.itemList.Remove(item);
    }

    /// <summary>
    /// 更新先删除再进行创建
    /// </summary>
    public static void RefreshItem()
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            // 先删除在进行 创建进行更新
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }
        
        for (int i = 0; i < instance.myBag.itemList.Count; i++)
        {
            CreateNewItem(instance.myBag.itemList[i]);
        }
    }
}
