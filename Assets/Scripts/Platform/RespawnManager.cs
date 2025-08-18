using System.Collections;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField]
    private float respawnTime;

    [SerializeField]
    private Transform playerTf;

    [SerializeField]
    private Transform respawnPoint;

    public void Respawn()
    {
        StartCoroutine(RespawnCo());

        //StopCoroutine(RespawnCo());
        //StopAllCoroutines();
    }

    private IEnumerator RespawnCo()
    {
        playerTf.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnTime);
        playerTf.position = respawnPoint.position;
        playerTf.gameObject.SetActive(true);

        if(UIManager.Instance != null)
        {
            UIManager.Instance.GamePanel.ResetHealth();
        }
    }

    public void SetRespawnPoint(Transform newRespawnPosition)
    {
        respawnPoint.position = newRespawnPosition.position;
    }
}
