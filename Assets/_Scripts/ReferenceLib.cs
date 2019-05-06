using UnityEngine;
using UnityEngine.Tilemaps;

public class ReferenceLib : MonoBehaviour
{
    #region Singleton
    public static ReferenceLib instance;
    private void Awake()
    {
        if (instance)
            Destroy(instance.gameObject);
        instance = this;
    }
    #endregion 

    public Player player;
    public TileEventInit tileEventInit;

    public FollowMouse selection;

    public Camera mainCam;

    public TooltipContent tooltipContent;
    public TooltipFollow tooltipFollow;

    public Grid grid;
    public Tilemap tilemap;

    [Space]

    public HealthBar healthBar;
}
