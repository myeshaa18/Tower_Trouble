using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameOverCollider"))
        {
            Debug.Log("Player hit the game over collider. Transitioning to Game Over screen...");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
