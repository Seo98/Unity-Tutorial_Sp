using UnityEngine;

public interface IDropItem
{    
    void Grab(Transform grabpos);
    void Use();
    void Drop();

}
