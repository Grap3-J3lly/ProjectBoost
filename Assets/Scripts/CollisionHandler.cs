using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    private AudioSource audioSource;

    [SerializeField] float reloadDelay = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip deathExplosion;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem explosionParticles;

    bool isTransitioning = false;

    private void Start() 
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {

        if(isTransitioning) {return;}

        switch (other.gameObject.tag)
        {
            case "Friendly":
            break;
            case "Finish":
            StartSuccessSequence();
            break;
            default:
            StartCrashSequence();
            break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        // todo add SFX upon crash
        audioSource.Stop();
        audioSource.PlayOneShot(success);
        // todo add particle effect upon crash
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", reloadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        // todo add SFX upon crash
        audioSource.Stop();
        audioSource.PlayOneShot(deathExplosion);
        // todo add particle effect upon crash
        explosionParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", reloadDelay);
    }

    void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

    void NextLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
    }
}

