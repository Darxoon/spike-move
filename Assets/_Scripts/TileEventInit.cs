using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEventInit : MonoBehaviour
{
    [Header("Tiles")]

    [SerializeField] private Tile tileHeartUsed;

    // References

    private Player player;
    private Tilemap tilemap; 
    private Grid grid; 
    private FollowMouse selection;

    private void Start()
    {
        player = ReferenceLib.instance.player;
        tilemap = ReferenceLib.instance.tilemap;
        grid = ReferenceLib.instance.grid;
        selection = ReferenceLib.instance.selection;
    }

    public void DoAction(TileEvent tileEvent)
    {
        switch(tileEvent)
        {

            // Tile Damage 1
            case TileEvent.TileDamage1:
                Debug.Log("brudah brauch pflaster");
                player.Health--;
                break;

            // Tile Goal
            case TileEvent.TileGoal:
                LevelManager.instance.LoadExit(0);
                break;
            case TileEvent.TileGoal2:
                LevelManager.instance.LoadExit(1);
                break;
            case TileEvent.TileGoal3:
                LevelManager.instance.LoadExit(2);
                break;

            // Tile Heart
            case TileEvent.TileHeart:
                player.Health = player.MaxHealth;
                tilemap.SetTile(player.gridCoords, tileHeartUsed);
                break;
            
            // Tiles that do nothing, so: TileSafe (including TileHeartUsed and TileStart) and Missing
            case TileEvent.TileSafe:
            case TileEvent.Missing:
            default:
                break;


        }
    }
}
