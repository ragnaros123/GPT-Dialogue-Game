//PARTS of this file is taken from https://github.com/trevermock/save-load-system, 


using System;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
        }
        instance = this;
    }

    public event Action onStageChange;
    public void StageChange()
    {
        if (onStageChange != null)
        {
            onStageChange();
        }
    }

  
}