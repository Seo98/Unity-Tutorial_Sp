using UnityEngine;

public interface IItemObject
{
    ItemManager2 Inventory { get; set; }
    GameObject Obj { get; set; }
    string ItemName { get; set; }
    Sprite Icon { get; set; } 

     void Get();
     void Use();
}
