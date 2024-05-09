using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playTransition : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform player;
    public int sceneBuildIndex;
    public void PS()
    {
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }

    public void Respawn()
    {
        player.transform.position = spawnPoint.transform.position;
    }
}
