using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Start() {
        transform.position = player.transform.position;
    }

    private void Update() {
        transform.position = player.transform.position + new Vector3(0, 30f, -10f);
    }
}
