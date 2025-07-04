using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private IItemObject item;
    [SerializeField] private Image itemImage;
    [SerializeField] private Button slotButton;

    public bool isEmpty = true;


    private void Awake()
    {
        slotButton.onClick.AddListener(UseItem);
    }

    private void OnEnable()
    {
        

        /*
        if(isEmpty)
        {
            slotButton.interactable = false;
            itemIcon.gameObject.SetActive(false);
        }
        else
        {
            slotButton.interactable = true;
            itemIcon.gameObject.SetActive(true);
        }*/
        
        // 
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }

    public void Additem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false;
        itemImage.sprite = newItem.Icon;
        itemImage.SetNativeSize();

    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty;
        itemImage.gameObject.SetActive(!isEmpty);
    }
}
