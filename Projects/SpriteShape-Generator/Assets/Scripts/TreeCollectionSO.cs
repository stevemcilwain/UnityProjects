
using UnityEngine;

/// <summary>
/// Creates a scriptable object asset that holds TreeSO scriptable objects.
/// </summary>

[CreateAssetMenu(fileName = "TreeCollectionSO", menuName = "ScriptableObjects/TreeCollectionSO")]
public class TreeCollectionSO : ScriptableObject
{
    public bool EnableDebug;

    public TreeSO[] Trees;

    public GameObject RandomTree()
    {
        int randomIndex = Random.Range(0, Trees.Length);
        if (EnableDebug) Debug.LogFormat("TreeCollectionSO: chose random tree index {0}", randomIndex);
        var tree = Trees[randomIndex];
        tree.Prefab.GetComponent<SpriteRenderer>().color = tree.tint;
        return tree.Prefab;
    }

}

