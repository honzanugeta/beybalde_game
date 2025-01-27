using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMManager : MonoBehaviour
{
    private Cinemachine.CinemachineVirtualCamera cm;
    private void Start()
    {
        GameManager.Instance.OnPlayerSpawned += OnPlayerSpawned;
        cm = GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }

    private void OnPlayerSpawned()
    {
        cm.Follow = GameManager.Instance.Player.transform;
        cm.LookAt = GameManager.Instance.Player.transform;
    }

    private void OnDestroy() => GameManager.Instance.OnPlayerSpawned -= OnPlayerSpawned;
}
