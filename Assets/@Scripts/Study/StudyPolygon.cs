using UnityEngine;

public class StudyPolygon : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[] // 점4개 찍기
        {
            new Vector3(0, 0, 0), // Vertex 0
            new Vector3(1, 0, 0), // Vertex 1
            new Vector3(0, 1, 0), // Vertex 2
            new Vector3(1, 1, 0), // Vertex 3
        };

        int[] triangles = new int[] //삼각형 순서
        {
            0, 2, 1, // First triangle
            2, 3, 1  // Second triangle
        };

        Vector2[] uv = new Vector2[] // 면의 방향
        {
            new Vector2(0, 0), // UV for Vertex 0
            new Vector2(1, 0), // UV for Vertex 1
            new Vector2(0, 1), // UV for Vertex 2
            new Vector2(1, 1)  // UV for Vertex 3
        };
        // mesh 위에서 만든점, 삼각형 순서 , uv 데이터를 적용
        mesh.vertices = vertices; // Mesh에 점들 넣기
        mesh.triangles = triangles; // Mesh에 삼각형 순서 넣기
        mesh.uv = uv; // Mesh에 UV 좌표 넣기

        // meshfilter 에 mesh 할당
        MeshFilter meshFilter = this.gameObject.AddComponent<MeshFilter>(); // MeshFilter 컴포넌트 추가
        meshFilter.mesh = mesh; 

        //meshrenderer 에 material 할당
        MeshRenderer meshRenderer = this.gameObject.AddComponent<MeshRenderer>(); // MeshRenderer 컴포넌트 추가
        meshRenderer.material = new Material(Shader.Find("Sprites/Default")); // MeshRenderer에 Material 할당

    }

}
