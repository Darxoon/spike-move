using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rect view;

    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Camera mainCam;

    [SerializeField] private CameraBounds cameraBounds;
    [SerializeField] private RectTransform camMovementPane;

    private Rect currentView;
    private Vector3 currentCamPos;

    private Vector3 camVelocity;

    private Vector3 camMovementPaneSize;
    private Vector3 camMovementPanePos;

    private void Start()
    {
        currentView.width = view.width;
        currentView.height = view.height;
    }

    private void Update()
    {
        // ---- move the camera ----
        Vector3 mouseVector = (Input.mousePosition - camMovementPane.position) / camMovementPane.rect.width * 2;
        Vector3 movementVector = new Vector3(curve.Evaluate(mouseVector.x), curve.Evaluate(mouseVector.y), 0f);

        // check for negative values
        bool xNegative = mouseVector.x < 0;
        bool yNegative = mouseVector.y < 0;
        // if there were negative values, make them negative
        if (xNegative)
            movementVector.x = -movementVector.x;
        if (yNegative)
            movementVector.y = -movementVector.y;
        // add movement vector to velocity
        camVelocity += movementVector;
        // apply velocity
        transform.position += camVelocity * Time.deltaTime;
        // decrease velocity 
        camVelocity *= 0.9f;


        // ---- update the 'view' field ----
        UpdateView(); 

        // ---- clamp the camera pos ----
        if(currentView != view)
        {
            // Horizontal
            if (view.x < cameraBounds.camBounds.x || view.x + view.width > cameraBounds.camBounds.x + cameraBounds.camBounds.width)
            {
                // going past the border
                view.x = currentView.x;
                transform.position = new Vector3(currentCamPos.x, transform.position.y, transform.position.z);
            }
            else
            {
                // staying inside the border
                currentView.x = view.x;
                currentCamPos.x = transform.position.x;
            }
            // Vertical
            if (view.y < cameraBounds.camBounds.y || view.y + view.height > cameraBounds.camBounds.y + cameraBounds.camBounds.height)
            {
                // going past the border
                view.y = currentView.y;
                transform.position = new Vector3(transform.position.x, currentCamPos.y, transform.position.z);
            }
            else
            {
                // staying inside the border
                currentView.y = view.y;
                currentCamPos.y = transform.position.y;
            }
        }

    }

    private void UpdateView()
    {
        camMovementPanePos = mainCam.ScreenToWorldPoint(new Vector3(camMovementPane.position.x, camMovementPane.position.y, 0f));
        camMovementPaneSize = mainCam.ScreenToWorldPoint(new Vector3(camMovementPane.rect.width + camMovementPanePos.x, camMovementPane.rect.height + camMovementPanePos.y, 0f));
        view.width = (camMovementPaneSize.x - camMovementPanePos.x) * 2;
        view.height = (camMovementPaneSize.y - camMovementPanePos.y) * 2;
        view.x = transform.position.x - view.width / 2;
        view.y = transform.position.y - view.height / 2; 

        Debug.DrawLine(new Vector3(view.x + view.width, view.y), new Vector3(view.x, view.y + view.height), Color.red); 
    } 

    private Vector3 DivideVector3(Vector3 a, Vector3 b)
    {
        return new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);
    }
}
