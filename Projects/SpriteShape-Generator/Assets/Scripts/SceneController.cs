
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public MountainGeneratedEventSO mountainGeneratedEvent;
    public PlayerSO player;
    public Cinemachine.CinemachineVirtualCamera vcam;

    private void OnEnable()
    {
        mountainGeneratedEvent.Publish += OnMountainGenerated;
    }

    private void OnDisable()
    {
        mountainGeneratedEvent.Publish -= OnMountainGenerated;
    }

    public void OnMountainGenerated()
    {
        Debug.Log("Mountain done generated y'all");
        vcam.Follow = Instantiate(player.Prefab, player.StartPosition, Quaternion.identity).transform;
    }
}