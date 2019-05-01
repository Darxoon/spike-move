using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rect view;

    [SerializeField] private CameraBounds cameraBounds;
    

    private Rect currentView;
    private Vector3 currentCamPos; 

    private void Start()
    {
        currentView.width = view.width;
        currentView.height = view.height;
    }

    private void Update()
    {
        // move the camera 

        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // update the 'view' field
        UpdateView(); 

        // clamp the camera pos
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
        view.x = transform.position.x - view.width / 2;
        view.y = transform.position.y - view.height / 2;
        Debug.DrawLine(new Vector3(view.x + view.width, view.y), new Vector3(view.x, view.y + view.height), Color.red); 
    }
}
