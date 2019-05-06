using UnityEngine;

public class TooltipFollow : MonoBehaviour
{
    [SerializeField] private float transition;
    [SerializeField] private Vector3 offset;
    
    

    private void Update()
    {
        // go to selection
        transform.localPosition = Vector3.Lerp(transform.position, ReferenceLib.instance.mainCam.ViewportToScreenPoint(ReferenceLib.instance.mainCam.WorldToViewportPoint(ReferenceLib.instance.grid.CellToWorld(ReferenceLib.instance.selection.gridCoords)) + offset), transition);
    }

}
