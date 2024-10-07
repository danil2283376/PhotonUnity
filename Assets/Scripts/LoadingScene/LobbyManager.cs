using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField nickNameInput;

    public LobbyListItemInfoUI LobbyListItemInfoUI;
    public Transform ParrentContentLobbyList;

    private List<string> adjectives
        = new List<string>() { "Mighty", "Brave", "Swift", "Wise", "Stealthy", "Shadow", "Crimson", "Azure", "Golden", "Silent" };
    private string nickPlayer;

    private void Start()
    {
        string adjective = adjectives[Random.Range(0, adjectives.Count)];
        nickNameInput.text = "NickName: " + adjective;
        nickPlayer = adjective;
        PhotonNetwork.LocalPlayer.NickName = nickPlayer;
    }

    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();

    }

    // Списки слов для генерации ников
    public void CreateRoom() 
    {
        if (PhotonNetwork.IsConnected == false)
            return;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(createInput.text, roomOptions);
    }

    public void JoinRoom() 
    {
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public void SetUpNickName() 
    {
        PhotonNetwork.LocalPlayer.NickName = nickNameInput.text;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Не удалось создать комнату!");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform child in ParrentContentLobbyList) 
        {
            DestroyImmediate(child.gameObject);
        }
        Debug.Log("Комнату создали!");
        foreach (RoomInfo roomInfo in roomList) 
        {
            if (roomInfo.PlayerCount != 0)
            {
                LobbyListItemInfoUI listItem = Instantiate(LobbyListItemInfoUI, ParrentContentLobbyList);
                if (listItem != null)
                {
                    listItem.SetInfo(roomInfo);
                }
            }
        }
    }
}
