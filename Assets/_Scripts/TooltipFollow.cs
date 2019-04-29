using UnityEngine;

public class TooltipFollow : MonoBehaviour
{
    [Header("Follow")] 

    [SerializeField] private FollowMouse selection;
    [SerializeField] private float transition;
    [SerializeField] private Grid grid;

    [Header("World Coords to Canvas Coords")]

    [SerializeField] private Vector3 offset;
    [SerializeField] private Canvas canvas;
    [SerializeField] private float scale;


    private void Update()
    {
        // go to selection
        transform.localPosition = Vector3.Lerp(transform.position, grid.CellToWorld(selection.gridCoords) + offset, transition) * canvas.scaleFactor * scale;
    }
}
