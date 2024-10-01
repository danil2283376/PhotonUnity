using Cinemachine;
using CraftingAnims;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    //public float speed;
    public Animator animator;
    public Transform LockAtCameraObject;
    public CinemachineVirtualCamera CinemachineVirtualCameraPrefab;
    public MouseLook MouseLook;
    public Transform BodyPlayer;
    public Rigidbody PlayerBody;

    private PhotonView view;
    private IMoving moving;
    private CinemachineVirtualCamera instanceVirtualCamera;
    private PlayerConfiguration PlayerConfiguration;
    private PlayerClients PlayerClients;
    private void Start()
    {
        view = GetComponent<PhotonView>();
        SetupCharacter();
        ChangeState(new IdleState());
        //Debug.Log("Nick: " + PhotonNetwork.LocalPlayer.NickName);

    }

    private void SetupCharacter() 
    {
        if (view.IsMine)
        {
            PlayerClients = Camera.main.GetComponent<PlayerClients>();

            GameObject virtualCamera = Instantiate(CinemachineVirtualCameraPrefab.gameObject, transform.position, Quaternion.identity, BodyPlayer);
            instanceVirtualCamera = virtualCamera.GetComponent<CinemachineVirtualCamera>();
            instanceVirtualCamera.Follow = LockAtCameraObject;
            instanceVirtualCamera.LookAt = LockAtCameraObject;

            PlayerConfiguration playerConfiguration = new PlayerConfiguration();
            playerConfiguration.CinemachineVirtualCamera = instanceVirtualCamera;
            playerConfiguration.namePlayer = PhotonNetwork.LocalPlayer.NickName;
            PlayerClients.AddNewPlayer(playerConfiguration);
            PlayerConfiguration = playerConfiguration;
            MouseLook.Init(BodyPlayer, view, this);
            //PlayerClients.DisableCameraNotMainPlayer(PlayerConfiguration);

        }
        if (animator)
        {
            animator.gameObject.AddComponent<PlayerAnimatorContollers>();
        }
    }

    public void ChangeState(IMoving _moving) 
    {
        if (view.IsMine)
        {
            if (moving != null)
            {
                moving.Stop();
            }
            moving = _moving;
            moving.Init(this);
        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            moving.DoFixedUpdate();
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            moving.DoUpdate();
        }
    }

    private void LateUpdate()
    {
        if (view.IsMine)
        {
            moving.DoLateUpdate();
        }
    }

    public PhotonView GetPhotonView() 
    {
        return view;
    }
}
