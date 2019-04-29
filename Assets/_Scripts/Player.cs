using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Grid grid;
    [SerializeField] private TooltipContent tooltipContent;

    [HideInInspector] public Vector3Int gridPos = new Vector3Int(); 
     

    private void Update()
    {
        if (tooltipContent.leftClickAction == ClickAction.MoveTo && Input.GetMouseButtonDown(0))
        {
            Debug.Log("moving");
        }

        gridPos = grid.WorldToCell(transform.position);
    }
}
