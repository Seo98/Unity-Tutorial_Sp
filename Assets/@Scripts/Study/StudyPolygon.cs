using UnityEngine;

public class StudyPolygon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[] // ��4�� ���
        {
            new Vector3(0, 0, 0), // Vertex 0
            new Vector3(1, 0, 0), // Vertex 1
            new Vector3(0, 1, 0), // Vertex 2
            new Vector3(1, 1, 0), // Vertex 3
        };

        int[] triangles = new int[] //�ﰢ�� ����
        {
            0, 2, 1, // First triangle
            2, 3, 1  // Second triangle
        };

        Vector2[] uv = new Vector2[] // ���� ����
        {
            new Vector2(0, 0), // UV for Vertex 0
            new Vector2(1, 0), // UV for Vertex 1
            new Vector2(0, 1), // UV for Vertex 2
            new Vector2(1, 1)  // UV for Vertex 3
        };
        // mesh ������ ������, �ﰢ�� ���� , uv �����͸� ����
        mesh.vertices = vertices; // Mesh�� ���� �ֱ�
        mesh.triangles = triangles; // Mesh�� �ﰢ�� ���� �ֱ�
        mesh.uv = uv; // Mesh�� UV ��ǥ �ֱ�

        // meshfilter �� mesh �Ҵ�
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>(); // MeshFilter ������Ʈ �߰�
        meshFilter.mesh = mesh; 

        //meshrenderer �� material �Ҵ�
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>(); // MeshRenderer ������Ʈ �߰�
        meshRenderer.material = new Material(Shader.Find("Sprites/Default")); // MeshRenderer�� Material �Ҵ�

    }

}
