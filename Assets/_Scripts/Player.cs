using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    [Header("Debugging")]

    [SerializeField] private bool collideWithWalls = true;
    [SerializeField] private bool doTileEvents = true;

    [Header("References")]

    [SerializeField] private Grid grid;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TooltipContent tooltipContent;
    [SerializeField] private TileEventInit tileEventInit;
    [SerializeField] private FollowMouse selection;
    [SerializeField] private HealthBar healthBar;

    [HideInInspector] public Vector3Int gridCoords = new Vector3Int(); 

    [Header("Health")]

    public int maxHealth = 5;
    public int health = 5;
    
    private Tile newTile;
    private TooltipContent.TileDescription tileProperties; 
    private int currentHealth = -1;
     

    private void Update()
    {
        // Move
        if (tooltipContent.leftClickAction == ClickAction.MoveTo && Input.GetMouseButtonDown(0))
        {
            // get the tile
            newTile = tilemap.GetTile(selection.gridCoords) as Tile;
            // check for tile properties
            try
            {
                tileProperties = tooltipContent.Tiles[newTile]; 
            }
            catch (System.Exception)
            {
                tileProperties = tooltipContent.MissingTile;
            }
            // if collision type is set to pass
            if (tileProperties.collisionType == CollisionType.Pass || !collideWithWalls)
            {
                // move
                transform.position = selection.transform.position + offset;

                // update tooltip click action 
                tooltipContent.currentTilePos = new Vector3Int(0, 0, 1);

                // do tile event 

                if (doTileEvents)
                    tileEventInit.DoAction(tileProperties.tileEvent);
            }
            // if collision type is set to wall
            else
                Debug.Log("gegen ne wand geknallt");

        }
        // Set gridCoords
        gridCoords = grid.WorldToCell(transform.position);
        // update health 
        if (health != currentHealth)
        {
            currentHealth = health;
            healthBar.UpdateHealth();

            if (health == 0)
                LevelManager.instance.RestartLevel();
        }
    }
}
