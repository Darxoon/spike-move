using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [Header("Debugging")]

    [SerializeField] private bool collideWithWalls = true;
    [SerializeField] private bool doTileEvents = true; 

    [Header("Misc")]
    [SerializeField] private Vector3 offset;

    
    [Header("Health")]

    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int health = 5;

    // health properties 

    public int MaxHealth => maxHealth;
    public int Health { get => health; set => HealthUpdate(value); }



    [HideInInspector] public Vector3Int gridCoords = new Vector3Int(); 



    private Tile newTile;
    private TooltipContent.TileDescription tileProperties; 
    private int currentHealth = -1;
    

    private void Update()
    {
        // Move
        if (ReferenceLib.instance.tooltipContent.leftClickAction == ClickAction.MoveTo && Input.GetMouseButtonDown(0))
        {
            // get the tile
            newTile = ReferenceLib.instance.tilemap.GetTile(ReferenceLib.instance.selection.gridCoords) as Tile;
            // check for tile properties
            try
            {
                tileProperties = ReferenceLib.instance.tooltipContent.Tiles[newTile]; 
            }
            catch (System.Exception)
            {
                tileProperties = ReferenceLib.instance.tooltipContent.MissingTile;
            }
            // if collision type is set to pass
            if (tileProperties.collisionType == CollisionType.Pass || !collideWithWalls)
            {
                // move
                transform.position = ReferenceLib.instance.selection.transform.position + offset;

                // update tooltip click action 
                ReferenceLib.instance.tooltipContent.currentTilePos = new Vector3Int(0, 0, 1);

                // Set gridCoords
                gridCoords = ReferenceLib.instance.grid.WorldToCell(transform.position);

                // do tile event 

                if (doTileEvents)
                    ReferenceLib.instance.tileEventInit.DoAction(tileProperties.tileEvent);
            }
            // if collision type is set to wall
            else
                Debug.Log("gegen ne wand geknallt");

        }
    } 

    private void HealthUpdate(int newHealth)
    {
        health = newHealth;
        ReferenceLib.instance.healthBar.UpdateHealth();

        if (health == 0)
            LevelManager.instance.RestartLevel();
    }
}
