using UnityEngine;

public class StudyMaterial : MonoBehaviour
{
    public Material mat; // Assign this in the inspector

    public string hexCode;
    void Start()
    {
        // GetComponent<Material>() = mat; // ÀÌ°Ç Àß¸øµÊ
        //GetComponent<MeshRenderer>().material = mat;
        //GetComponent<MeshRenderer>().sharedMaterial = mat;
        //GetComponent<MeshRenderer>().material.color = Color.green;
        //GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
        //GetComponent<MeshRenderer>().material.color = new Color(130f/255f, 20f/255f, 70f/255f, 1);
        mat = GetComponent<MeshRenderer>().material;
        Color outputColor;

        if (ColorUtility.TryParseHtmlString(hexCode, out outputColor))
        {
            mat.color = outputColor;
        }
    }

}
