using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    [SerializeField] private bool alignToGrid = true;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float interpolation = 1f;



    [HideInInspector] public Vector3Int gridCoords;

    

    private void Update()
    {
        if (alignToGrid)
        {
            gridCoords = ReferenceLib.instance.grid.WorldToCell(ReferenceLib.instance.mainCam.ScreenToWorldPoint(Input.mousePosition));
            transform.position = Vector3.Lerp(transform.position, ReferenceLib.instance.grid.CellToWorld(gridCoords) + offset, interpolation);
        }
        else
            transform.position = Vector3.Lerp(transform.position, ReferenceLib.instance.mainCam.ScreenToWorldPoint(Input.mousePosition) + offset, interpolation);
        
    }
}
