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

            case TileEvent.TileDamage1:
                Debug.Log("brudah brauch pflaster");
                player.health--;
                break;

            case TileEvent.TileGoal:
                Debug.Log("goal goal goal!");
                break;

            case TileEvent.TileHeart:
                player.health++;
                break;

            case TileEvent.TileSafe:
                break;

            default:
                break;

        }
    }
}
