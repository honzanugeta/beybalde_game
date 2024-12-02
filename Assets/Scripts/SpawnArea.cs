using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    private BoxCollider boxCollider;

    [SerializeField] private float raycastHeight = 20f;
    [SerializeField] private LayerMask maskForRaycast = 1 << 0; // Default layer

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public Vector3 GetRandomPointInBounds()
    {
        Vector3 center = boxCollider.bounds.center;
        Vector3 size = boxCollider.bounds.size;


        float height = center.y + size.y / 2 + raycastHeight;
        Vector3 randomPoint = new Vector3(
            Random.Range(center.x - size.x / 2, center.x + size.x / 2),
            height, // Spawn the ray above the area
            Random.Range(center.z - size.z / 2, center.z + size.z / 2)
        );

        Ray ray = new Ray(randomPoint, Vector3.down);
        Debug.DrawRay(randomPoint, Vector3.down * height, Color.green, 3); //Debug
        if (Physics.Raycast(ray, out RaycastHit hit, height, maskForRaycast))
        {
            randomPoint.y = hit.point.y;
        }
        else
        {
            Debug.LogWarning("Raycast did not hit any surface. Using original height.");
        }

        return randomPoint;
    }
}
