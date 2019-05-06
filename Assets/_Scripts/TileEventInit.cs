using UnityEngine;
using UnityEngine.Tilemaps;

public class TileEventInit : MonoBehaviour
{
    [Header("Tiles")]

    [SerializeField] private Tile tileHeartUsed;
    

    public void DoAction(TileEvent tileEvent)
    {
        switch(tileEvent)
        {

            // Tile Damage 1
            case TileEvent.TileDamage1:
                Debug.Log("brudah brauch pflaster");
                ReferenceLib.instance.player.Health--;
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
                ReferenceLib.instance.player.Health = ReferenceLib.instance.player.MaxHealth;
                ReferenceLib.instance.tilemap.SetTile(ReferenceLib.instance.player.gridCoords, tileHeartUsed);
                break;
            
            // Tiles that do nothing, so: TileSafe (including TileHeartUsed and TileStart) and Missing
            case TileEvent.TileSafe:
            case TileEvent.Missing:
            default:
                break;


        }
    }
}
