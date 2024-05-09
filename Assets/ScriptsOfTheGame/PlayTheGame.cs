using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayTheGame : MonoBehaviour
{
    public GameObject gameMenu;

    public void Play()
    {
        gameMenu.SetActive(false);
    }


}
