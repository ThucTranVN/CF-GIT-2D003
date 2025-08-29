using System;
using System.Collections;
using UnityEngine;

public class RespawnManager : BaseManager<RespawnManager>
{
    [SerializeField]
    private float respawnTime;

    [SerializeField]
    private Transform playerTf;

    [SerializeField]
    private Transform respawnPoint;

    [SerializeField]
    private Transform defaultPos;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        playerTf = GameObject.FindGameObjectWithTag("Player").transform;
        defaultPos.position = playerTf.position;
        SetRespawnPoint(playerTf);
    }

    public void Respawn(Action onComplete = null)
    {
        StartCoroutine(RespawnCo(onComplete));
    }

    private IEnumerator RespawnCo(Action onComplete = null)
    {
        playerTf.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        playerTf.position = respawnPoint.position;
        playerTf.gameObject.SetActive(true);

        if(UIManager.HasInstance)
        {
            UIManager.Instance.GamePanel.ResetHealth();
        }

        onComplete?.Invoke();
    }

    public void SetRespawnPoint(Transform newRespawnPosition)
    {
        respawnPoint.position = newRespawnPosition.position;
    }

    public void SetDefaultPosition()
    {
        respawnPoint.position = defaultPos.position;
    }

}
