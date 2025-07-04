using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager2 Inventory { get; set; }

    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }
    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager2>();

        Obj = this.gameObject;
        ItemName = "Health Potion";
        Icon = GetComponent<SpriteRenderer>().sprite;
    }

    public void Get()
    {
        gameObject.SetActive(false);

        Inventory.GetItem(this);

    }
    public void Use()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
