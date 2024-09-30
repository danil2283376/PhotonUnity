using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LoadingScenePhoton : MonoBehaviourPunCallbacks
{
    public void Init() 
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    //public override void OnConnectedToMaster()
    //{
    //    SceneManager.LoadScene("Menu");
    //}
}
