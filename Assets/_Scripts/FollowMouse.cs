using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [Header("Standard")]

    [SerializeField] private bool alignToGrid = true;

    [SerializeField] private Vector3 offset;

    [SerializeField] private float interpolation = 1f;

    [Header("Align to grid")]

    [SerializeField] private Camera mainCam = null;
    [SerializeField] private Grid grid = null;
    
    [HideInInspector] public Vector3Int gridCoords;

    private void Update()
    {
        if (alignToGrid)
        {
            gridCoords = grid.WorldToCell(mainCam.ScreenToWorldPoint(Input.mousePosition));
            transform.position = Vector3.Lerp(transform.position, grid.CellToWorld(gridCoords) + offset, interpolation);
        }
        else
            transform.position = Vector3.Lerp(transform.position, mainCam.ScreenToWorldPoint(Input.mousePosition) + offset, interpolation);
        
    }
}
