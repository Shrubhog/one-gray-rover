using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D roverRigidbody;
    private SpriteRenderer roverRenderer;
    public AudioClip[] jumpSounds;
    private int jumpSelect;
    AudioSource audioSource;

    private Animator animator;

    public LayerMask Objective;

    public Collider2D PlayerCollider;
    // Start is called before the first frame update
    void Start() {
        roverRigidbody = GetComponent<Rigidbody2D>();
        roverRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        PlayerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update() {
        if (Physics2D.IsTouchingLayers(PlayerCollider, Objective)) {
            Debug.Log("GOOOOAL!");
            SceneManager.LoadScene("Win");
        }
        roverRigidbody.velocity = new Vector2(roverRigidbody.velocity.x, roverRigidbody.velocity.y);
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) {
            jumpSelect = Random.Range(0, jumpSounds.Length);
            roverRigidbody.velocity = new Vector2(roverRigidbody.velocity.x, jumpForce);
            audioSource.PlayOneShot(jumpSounds[jumpSelect], 1F);

        } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            roverRenderer.flipX = true;
            roverRigidbody.velocity = new Vector2(-moveSpeed, roverRigidbody.velocity.y);
        } else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            roverRenderer.flipX = false;
            roverRigidbody.velocity = new Vector2(moveSpeed, roverRigidbody.velocity.y);
        }
        animator.SetFloat("vel_x", roverRigidbody.velocity.x);
        animator.SetFloat("vel_y", roverRigidbody.velocity.y);
        if(transform.position.y <= -7.8) {
            Debug.Log("Oops!");
            transform.position = new Vector3(-3.185597f, 1.416982f, 0);
        }
    }
}