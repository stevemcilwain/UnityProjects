
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "MountainGeneratedEventSO", menuName = "ScriptableObjects/MountainGeneratedEventSO")]
public class MountainGeneratedEventSO : ScriptableObject
{
    public Action Publish;
}
