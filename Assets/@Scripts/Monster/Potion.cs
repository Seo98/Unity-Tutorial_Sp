using UnityEngine;

public class Potion : MonoBehaviour, Iitem
{
    private Inventory inventory; // Reference to the inventory script
    public GameObject Obj { get; set; }

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }
    public enum PotionType
    {
        Red,
        Blue
    }
    public PotionType potionType;

    void OnMouseDown()
    {
        Get();
    }

    public void Get()
    {
        Debug.Log("Potion collected!");
        inventory.AddItem(this); // Add the potion to the inventory
        gameObject.SetActive(false); // Hide the potion after collection
    }
}
