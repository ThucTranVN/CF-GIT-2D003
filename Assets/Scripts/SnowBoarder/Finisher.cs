using UnityEngine;
using UnityEngine.SceneManagement;

public class Finisher : MonoBehaviour
{
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
            FindFirstObjectByType<SBGameManager>()?.ReloadScene();


            //SBGameManager sBGameManager = FindFirstObjectByType<SBGameManager>();
            //if(sBGameManager != null)
            //{
            //    sBGameManager.ReloadScene();
            //}
        }
    }

}
