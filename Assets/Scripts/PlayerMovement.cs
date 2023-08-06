using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float gravity = -10f;
    public Joystick joystick;
    public Transform cameraTarget;

    private Vector3 move;
    private Vector3 velocity;

    // Multiplayer
    private RealtimeView _realtimeView;

    private CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
        _realtimeView = GetComponent<RealtimeView>();
        if (_realtimeView.isOwnedLocallyInHierarchy)
            LocalStart();
    }

    private void LocalStart()
    {
        // Request ownership of the Player and the character RealtimeTransforms
        GetComponent<RealtimeTransform>().RequestOwnership();
        character.GetComponent<RealtimeTransform>().RequestOwnership();
    }

    void Update()
    {
        if (_realtimeView.isOwnedLocallyInHierarchy)
            LocalUpdate();
    }

    private void LocalUpdate()
    {
        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        move = transform.right * x + transform.forward * z;

        character.Move(move * speed * Time.deltaTime);

        velocity.y = -1f;
        velocity.y += gravity * Time.deltaTime;

        character.Move(velocity * Time.deltaTime);
        character.transform.position = new Vector3(character.transform.position.x, 1f, character.transform.position.z);
    }
}
