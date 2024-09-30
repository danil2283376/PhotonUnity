using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : /*MonoBehaviour,*/ IMoving
{
    private PlayerHandler PlayerHandler;
    private PhotonView view;

    private float _walkSpeed = 25f;
    private float _runSpeed = 50f;

    private float _currentSpeedPlayer = 0f;
    private Rigidbody _playerBody;

    private const float _maxMagnitudeForRun = 4f;
    private const float _maxMagnitudeForWalk = 2f;
    public void Init(PlayerHandler playerHandler)
    {
        PlayerHandler = playerHandler;
        _playerBody = PlayerHandler.PlayerBody;
        view = playerHandler.GetPhotonView();
        //Debug.Log("Персонаж Перешел в стадию бега");
    }
    public void DoFixedUpdate()
    {
        
    }

    public void DoUpdate()
    {
        
    }

    public void DoLateUpdate()
    {
        //Debug.Log("Персонаж бежит");
        if (view.IsMine)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = PlayerHandler.transform.right * horizontalInput + PlayerHandler.transform.forward * verticalInput;//new Vector3(horizontalInput, 0f, verticalInput);

            movement.Normalize();

            if (movement != Vector3.zero)
            {
                PlayerHandler.animator.SetBool("Moving", true);
                // Use run
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    verticalInput = Mathf.Clamp(verticalInput, -1f, 1f);
                    horizontalInput = Mathf.Clamp(horizontalInput, -0.5f, 0.5f);
                    _currentSpeedPlayer = _runSpeed;
                    if (_playerBody.velocity.magnitude < _maxMagnitudeForRun)
                        _playerBody.AddForce(movement * _currentSpeedPlayer * Time.deltaTime, ForceMode.VelocityChange);
                }
                else // use walk 
                {
                    verticalInput = Mathf.Clamp(verticalInput, -0.5f, 0.5f);
                    //horizontalInput = Mathf.Clamp(horizontalInput, -0.25f, 0.25f);
                    horizontalInput = Mathf.Clamp(horizontalInput, -0.5f, 0.5f);
                    _currentSpeedPlayer = _walkSpeed;
                    if (_playerBody.velocity.magnitude < _maxMagnitudeForWalk)
                        _playerBody.AddForce(movement * _currentSpeedPlayer * Time.deltaTime, ForceMode.VelocityChange);
                }
                PlayerHandler.animator.SetFloat("Velocity Z", verticalInput);
                PlayerHandler.animator.SetFloat("Velocity X", horizontalInput);
            }
            else
            {
                PlayerHandler.ChangeState(new IdleState());
            }
        }
    }

    public void Stop()
    {
        //Debug.Log("Персонаж перестал бежать");
        PlayerHandler.animator.SetBool("Moving", false);
        PlayerHandler.animator.SetFloat("Velocity Z", 0);
        PlayerHandler.animator.SetFloat("Velocity X", 0);
    }

}
