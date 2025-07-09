using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
    [SerializeField]
    private float delayLoadScene = 1f;
    [SerializeField]
    private ParticleSystem finishEffect;
    [SerializeField]
    private AudioSource winSource;

    void Start()
    {
        winSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("You've finished");
            finishEffect.Play();
            winSource.Play();
            Invoke(nameof(ReloadScene), delayLoadScene);
        }
    }

    //TODO: Refactor duplicate
    private void ReloadScene()
    {
        SceneManager.LoadScene("SnowBoarder");
    }
}
