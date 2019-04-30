using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Rect view;

    [SerializeField] private CameraBounds cameraBounds;

    [SerializeField] private Rect currentView;
    [SerializeField] private Vector3 currentCamPos;

    private void Update()
    {

        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        UpdateView(); 

        if(currentView != view)
        {
            if (view.x < cameraBounds.camBounds.x || view.y < cameraBounds.camBounds.y
                || view.y + view.height > cameraBounds.camBounds.y + cameraBounds.camBounds.height
                || view.x + view.width > cameraBounds.camBounds.x + cameraBounds.camBounds.width)
            {
                // going past the border
                view = currentView;
                transform.position = currentCamPos;
            }
            else
            {
                // staying inside the border
                currentView = view;
                currentCamPos = transform.position;
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
