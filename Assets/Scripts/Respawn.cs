using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("DeadZone"))
        {
            SceneManager.LoadScene(1);

        }
    }
}
