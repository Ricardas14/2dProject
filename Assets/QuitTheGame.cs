using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuitTheGame : MonoBehaviour
{
    public GameObject quitButton;
    public TextMeshProUGUI trollText;

    public void FakeQuit()
    {
        trollText.text = "Get trolled, you ain't quiting today";
        quitButton.SetActive(false);
    }
}
