using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensitivity = 0.5f;
    public float rotationLimit = 90f;
    public Transform orientation;

    private float yRotation;

    // Multiplayer
    private RealtimeView _realtimeView;

    void Start()
    {
        _realtimeView = GetComponent<RealtimeView>();
    }

    void Update()
    {
        if (_realtimeView.isOwnedLocallyInHierarchy)
        {
            float mouseX = 0;
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                mouseX = Input.GetTouch(0).deltaPosition.x;
            }

            mouseX *= mouseSensitivity;

            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, -rotationLimit, rotationLimit);

            // Only horizontal rotation
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
