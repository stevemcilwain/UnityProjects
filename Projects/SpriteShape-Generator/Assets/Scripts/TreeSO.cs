using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TreeSO", menuName = "ScriptableObjects/TreeSO")]
public class TreeSO : ScriptableObject
{
    public Color tint;
    public GameObject Prefab;
}
