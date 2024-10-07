using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyListItemInfoUI : MonoBehaviour
{
    public TMP_Text textName;
    public TMP_Text textPlayerCount;

    public void SetInfo(RoomInfo info) 
    {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.PlayerCount;
    }
}
