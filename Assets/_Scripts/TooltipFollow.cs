using UnityEngine;

public class TooltipFollow : MonoBehaviour
{
    [SerializeField] private float transition;
    [SerializeField] private Vector3 offset;
    

    // References

    private FollowMouse selection;
    private Grid grid;
    private Camera mainCam;

    private void Start()
    {
        selection = ReferenceLib.instance.selection;
        grid = ReferenceLib.instance.grid;
        mainCam = ReferenceLib.instance.mainCam;
    }

    private void Update()
    {
        // go to selection
        transform.localPosition = Vector3.Lerp(transform.position, mainCam.ViewportToScreenPoint(mainCam.WorldToViewportPoint(grid.CellToWorld(selection.gridCoords)) + offset), transition);
    }

}
