using System;
using UnityEngine;
using Zenject;

public class Level: IInitializable
{
    public event Action Defeat;

    public void Start()
    {
        Debug.Log("Start level");
    }

    public void Restart()
    {
        Start();
    }

    public void OnDefeat()
    {
        Defeat?.Invoke();
    }

    public void Initialize()
    {
        Start();
    }
}

