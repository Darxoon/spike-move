using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    [SerializeField] private Grid grid;
    [SerializeField] private TooltipContent tooltipContent;
    [SerializeField] private FollowMouse selection;
    [SerializeField] private TileEventInit tileEventInit;
    [SerializeField] private Tilemap tilemap;

    [HideInInspector] public Vector3Int gridPos = new Vector3Int();
    public int health = 5;
    
    private Tile newTile;
    private TileEvent tileEvent;
     

    private void Update()
    {
        if (tooltipContent.leftClickAction == ClickAction.MoveTo && Input.GetMouseButtonDown(0))
        {
            transform.position = selection.transform.position + new Vector3(0f, 0.61f, -2f);

            newTile = tilemap.GetTile(selection.gridCoords) as Tile;


            try
            {
                tileEvent = tooltipContent.Tiles[newTile].tileEvent;
            }
            catch (System.Exception)
            {
                tileEvent = TileEvent.TileSafe;
            }


            tileEventInit.DoAction(tileEvent);
            
        }

        gridPos = grid.WorldToCell(transform.position);
    } 
}
