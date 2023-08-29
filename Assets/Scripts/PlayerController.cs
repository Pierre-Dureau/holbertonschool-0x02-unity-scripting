using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    [SerializeField] private int health = 5;
    private int score = 0;

    [SerializeField] private GameObject firstTeleporter;
    [SerializeField] private GameObject secondTeleporter;
    private bool canTeleport = true;

    private void Update() {
        GetInputs();

        if (health == 0) {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void GetInputs() {
        Vector2 inputVector = new(0, 0);

        if (Input.GetKey(KeyCode.W)) {
            inputVector.y = 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            inputVector.y = -1;
        }
        if (Input.GetKey(KeyCode.A)) {
            inputVector.x = -1;
        }
        if (Input.GetKey(KeyCode.D)) {
            inputVector.x = 1;
        }

        inputVector = inputVector.normalized;

        Vector3 moveDir = new(inputVector.x, 0, inputVector.y);
        transform.position += playerSpeed * Time.deltaTime * moveDir;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Pickup")) {
            score++;
            Debug.Log($"Score: {score}");
            Destroy(other.gameObject);
        } else if (other.CompareTag("Trap")) {
            health--;
            Debug.Log($"Health: {health}");
        } else if (other.CompareTag("Goal")) {
            Debug.Log("You win!");
        } else if (other.CompareTag("Teleporter")) {
            if (canTeleport) {
                if (other.gameObject == firstTeleporter) {
                    transform.position = new Vector3(secondTeleporter.transform.position.x, transform.position.y, secondTeleporter.transform.position.z);
                } else {
                    transform.position = new Vector3(firstTeleporter.transform.position.x, transform.position.y, firstTeleporter.transform.position.z);
                }
                canTeleport = false;
                Invoke(nameof(ResetTeleportCooldown), 0.1f);
            }
            
        }
    }

    private void ResetTeleportCooldown() {
        canTeleport = true;
    }
}
