using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEventInit : MonoBehaviour
{

    [SerializeField] private Player player;


    public void DoAction(TileEvent tileEvent)
    {
        switch(tileEvent)
        {

            // Tile Damage 1
            case TileEvent.TileDamage1:
                Debug.Log("brudah brauch pflaster");
                player.health--;
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

            // Tile Goal
            case TileEvent.TileHeart:
                player.health++;
                break;
            
            // Tiles that do nothing, so: TileSafe (including TileHeartUsed and TileStart) and Missing
            case TileEvent.TileSafe:
            case TileEvent.Missing:
            default:
                break;


        }
    }
}
