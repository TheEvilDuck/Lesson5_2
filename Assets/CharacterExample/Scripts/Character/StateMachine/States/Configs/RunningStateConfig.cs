using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 10)] private float _speed;
    [SerializeField, Range(0,1)]private float _walkSpeedMultiplier;
    [SerializeField, Range(1,10)]private float _fastRunSpeedMultiplier;

    public float Speed => _speed;
    public float WalkSpeedMultiplier => _walkSpeedMultiplier;
    public float FastRunSpeedMultiplier => _fastRunSpeedMultiplier;
}
