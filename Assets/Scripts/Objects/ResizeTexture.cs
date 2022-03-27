using UnityEngine;

namespace RoomEscape.UI
{
    public class ResizeTexture : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            MeshRenderer renderer = GetComponent<MeshRenderer>();

            Bounds bounds = meshFilter.mesh.bounds;

            Vector3 size = Vector3.Scale(bounds.size, transform.localScale) * .4f;

            renderer.material.mainTextureScale = size;

        }

    }
}
