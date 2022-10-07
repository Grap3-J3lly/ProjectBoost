using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    int currentSceneIndex = 0;

    private void OnCollisionEnter(Collision other) {
        switch (other.gameObject.tag)
        {
            case "Friendly":
            Debug.Log("Landed on Friendly object");
            break;
            case "Fuel":
            Debug.Log("Collided with Fuel object");
            break;
            case "Finish":
            NextLevel();
            break;
            default:
            ReloadLevel();
            break;
        }
    }

    void ReloadLevel() {
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }

    void NextLevel() {
        currentSceneIndex++;
        SceneManager.LoadScene(currentSceneIndex, LoadSceneMode.Single);
    }
}
