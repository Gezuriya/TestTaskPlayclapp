using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InterfaceController : MonoBehaviour
{
    bool startStop = false;
    public Text buttonText;
    public TMP_InputField distText, speedText, timeText;
    public GameController gameCont;
    public GameObject incorrect;
    public void StartStopButton()
    {
        if (startStop)
        {
            gameCont.StopAllCoroutines();
            buttonText.text = "Start spawn";
        }
        else
        {
            gameCont.StartCoroutine("SpawnCubes");
            buttonText.text = "Stop spawn";
        }
        startStop = !startStop;
    }
    public void EditDistance()
    {
        if (float.TryParse(distText.text, out float result))
        {
            gameCont.distance = result;
        }
        else
            distText.text = null;
    }
    public void EditMoveSpeed()
    {
        if (float.TryParse(speedText.text, out float result))
        {
            gameCont.moveSpeed = result;
        }
        else
            speedText.text = null;
    }
    public void EditTimeToSpawn()
    {
        if (float.TryParse(timeText.text, out float result))
        {
            gameCont.timeToSpawn = result;
        }
        else
            timeText.text = null;
    }
}
