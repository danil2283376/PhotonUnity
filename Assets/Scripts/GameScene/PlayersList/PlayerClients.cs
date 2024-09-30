using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerClients : MonoBehaviour
{
    public List<PlayerConfiguration> playerConfigurations = new List<PlayerConfiguration>();
    private int countPlayers = 0;
    public void AddNewPlayer(PlayerConfiguration playerConfiguration) 
    {
        playerConfigurations.Add(playerConfiguration); 
        //Debug.Log("playerConfigurations.Count: " + playerConfigurations.Count);
        //Debug.Log("Player: " + playerConfigurations[countPlayers].namePlayer);
        //for (int i = 0; i < playerConfigurations.Count; i++) 
        //{
        //    Debug.Log(playerConfigurations[i].namePlayer);
        //}
        countPlayers++;
    }

    public void DisableCameraNotMainPlayer(PlayerConfiguration playerConfiguration) 
    {
        foreach (PlayerConfiguration player in playerConfigurations) 
        {
            if (player.namePlayer != playerConfiguration.namePlayer)
            {
                player.CinemachineVirtualCamera.Priority = 9;
            }
        }
    }
}
