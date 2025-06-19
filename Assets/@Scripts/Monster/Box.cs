using UnityEngine;

public class Box : MonoBehaviour, Iitem
{

    private Inventory inventory; // Reference to the inventory script
    public GameObject Obj { get; set; }

    private void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
        Obj = gameObject;
    }
    public enum BoxType
    {
        Random1,
        Random2
    }
    public BoxType boxType;

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
