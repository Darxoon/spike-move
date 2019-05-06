using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    [SerializeField] private bool alignToGrid = true;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float interpolation = 1f;



    [HideInInspector] public Vector3Int gridCoords;


    private Camera mainCam;
    private Grid grid;

    private void Start()
    {
        mainCam = ReferenceLib.instance.mainCam;
        grid = ReferenceLib.instance.grid;
    }

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
