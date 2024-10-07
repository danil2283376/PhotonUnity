using DG.Tweening;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public float damping = 0.9f; // Коэффициент затухания инерции

    //private float xRotation = 0f;
    private bool _init = false;
    private Transform _playerBody;
    private PhotonView _view;
    private PlayerHandler _playerHandler;
    private Vector3 lastMousePosition;

    public void Init(Transform bodyPlayer, PhotonView view, PlayerHandler playerHandler)
    {
        // лочит курсор
        //Cursor.lockState = CursorLockMode.Locked;
        _playerBody = bodyPlayer;
        _playerHandler = playerHandler;
        lastMousePosition = Input.mousePosition;
        _view = view;
        _init = true;
        //mouseSensitivity = 5f;
    }

    private void FixedUpdate()
    {
        if (_init && _view.IsMine)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
            if (mouseX != 0 || mouseY != 0)
            {
                // Вращаем Rigidbody по горизонтали
                _playerHandler.PlayerBody.AddTorque(Vector3.up * mouseX * mouseSensitivity);
            }

            _playerHandler.PlayerBody.angularVelocity *= damping;

        }
    }
}
