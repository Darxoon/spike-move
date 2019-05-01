using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class HoveringRectTransform : MonoBehaviour
{

    public RectTransform rectTransform;
    public RectTransform uiGroup;
    public bool hovering => rect.Contains(Input.mousePosition);

    private Rect rect;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnDrawGizmos()
    {
        rect = rectTransform.rect;
        rect.x = rectTransform.position.x - rectTransform.rect.width / 2;
        rect.y = rectTransform.position.y - rectTransform.rect.height / 2;
        

        #region Draw Rect

        Gizmos.color = Color.white;

        Gizmos.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x + rect.width, rect.y));
        Gizmos.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x, rect.y + rect.height));

        Gizmos.DrawLine(new Vector3(rect.x + rect.width, rect.y), new Vector3(rect.x + rect.width, rect.y + rect.height));
        Gizmos.DrawLine(new Vector3(rect.x, rect.y + rect.height), new Vector3(rect.x + rect.width, rect.y + rect.height));

        Gizmos.DrawLine(new Vector3(rect.x, rect.y), new Vector3(rect.x + rect.width, rect.y + rect.height));

        #endregion
    }


}
