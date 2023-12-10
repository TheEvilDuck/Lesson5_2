using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Testing : MonoBehaviour
{
    private Level _level;

    [Inject]
    public void Construct(Level level)
    {
        _level = level;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _level.OnDefeat();
    }
}
