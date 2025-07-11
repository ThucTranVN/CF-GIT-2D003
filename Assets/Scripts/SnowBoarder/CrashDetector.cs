using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem crashEffect;
    [SerializeField]
    private AudioSource losseSource;

    private void Start()
    {
        losseSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("Hit my head");
            crashEffect.Play();
            losseSource.Play();
            FindFirstObjectByType<SBGameManager>()?.ReloadScene();
        }
    }
}
