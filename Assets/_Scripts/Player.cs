using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [Header("Debugging")]

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
    private TileEvent tileEvent; 
    private int currentHealth = -1;
     

    private void Update()
    {
        // Move
        if (tooltipContent.leftClickAction == ClickAction.MoveTo && Input.GetMouseButtonDown(0))
        {
            transform.position = selection.transform.position + new Vector3(0f, 0.61f, -2f);
            // correct
            newTile = tilemap.GetTile(selection.gridCoords) as Tile;
            // not working
            try
            {
                tileEvent = tooltipContent.Tiles[newTile].tileEvent; 
            }
            catch (System.Exception)
            {
                tileEvent = TileEvent.Missing;
            }

            Debug.Log(tileEvent);
            if (doTileEvents)
                tileEventInit.DoAction(tileEvent);

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
