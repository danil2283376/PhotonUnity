using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject player;
    public float minX, minY, minZ, maxX, maxY, maxZ;

    private void Start()
    {
        Vector3 randomPosition = 
            new Vector3(
                Random.Range(minX, maxX),
                    Random.Range(minY, maxY),
                        Random.Range(minZ, maxZ));

        PhotonNetwork.Instantiate(
            player.name,
                randomPosition,
                    Quaternion.identity);
    }
}
