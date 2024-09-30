using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : /*MonoBehaviour,*/ IMoving
{
    private PlayerHandler PlayerHandler;
    private PhotonView view;
    public void Init(PlayerHandler playerHandler)
    {
        ////Debug.Log("Персонаж стоит");
        PlayerHandler = playerHandler;
        view = playerHandler.GetPhotonView();
        PlayerHandler.animator.SetBool("Moving", false);
        PlayerHandler.animator.SetFloat("Velocity Z", 0);
        PlayerHandler.animator.SetFloat("Velocity X", 0);
    }
    public void DoFixedUpdate()
    {
        
    }

    public void DoUpdate()
    {
        
    }

    public void DoLateUpdate()
    {
        if (view.IsMine)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

            movement.Normalize();

            if (movement != Vector3.zero)
            {
                PlayerHandler.ChangeState(new RunState());
            }
        }
    }


    public void Stop()
    {
        
    }

}
