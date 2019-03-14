using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject player;

    private Vector3 lastPlayerPosition;
    private float distanceToMoveX;
    private float distanceToMoveY;
    void Start() {
        lastPlayerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update() {
        distanceToMoveX = player.transform.position.x - lastPlayerPosition.x;
        distanceToMoveY = player.transform.position.y - lastPlayerPosition.y;

        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMoveY, transform.position.z);

        lastPlayerPosition = player.transform.position;
    }
}
