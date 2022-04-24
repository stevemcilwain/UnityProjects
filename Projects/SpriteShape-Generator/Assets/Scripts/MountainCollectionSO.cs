
using UnityEngine;

/// <summary>
/// Creates a scriptable object asset that holds MountainSO scriptable objects.
/// </summary>

[CreateAssetMenu(fileName = "MountainCollectionSO", menuName = "ScriptableObjects/MountainCollectionSO")]
public class MountainCollectionSO : ScriptableObject
{
    public bool EnableDebug;

    public MountainSO[] Mountains;

    public MountainSO RandomMountain()
    {
        int randomIndex = Random.Range(0, Mountains.Length);
        if (EnableDebug) Debug.LogFormat("MountainCollectionSO: chose random mountain index {0}", randomIndex);
        return Mountains[randomIndex];
    }

}

