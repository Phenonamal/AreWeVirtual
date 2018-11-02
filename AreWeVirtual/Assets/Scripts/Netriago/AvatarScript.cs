using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarScript : MonoBehaviour {
    new Rigidbody rigidbody;
    Vector3 moveDirection;
    float moveSpeed = 10f;
    new Camera camera;
    Vector3 cameraOffset;
    bool jump; float jumpVelocity = 5f;

    public bool isHacking;
    public System.Action<bool> OnHackingStateChangeEvent;

    // ==================================

    void OnEnable () {
        Initialize();

    }
	
	void Update () {
        HandleInput();

    }

    void LateUpdate()
    {
        UpdateCamera();
    }

    void FixedUpdate()
    {
        HandleMovement(Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        LevelComplete levelComplete = collider.GetComponent<LevelComplete>();
        if (levelComplete != null) levelComplete.CompleteLevel(this);
    }

    // ==================================

    public void SetHackingState(bool value)
    {
        isHacking = value;
        if (OnHackingStateChangeEvent != null) OnHackingStateChangeEvent(value);
    }

    // ==================================

    void Initialize()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        if (rigidbody == null) rigidbody = this.gameObject.AddComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        if (camera == null) camera = Camera.main;
        cameraOffset = camera.transform.position - this.transform.position;
    }

    void HandleInput()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        moveDirection = Vector3.ClampMagnitude(input, 1f);
        if (isHacking) moveDirection = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return)) SetHackingState(!isHacking);
        if (Input.GetKeyDown(KeyCode.Escape)) SetHackingState(false);

        if(Input.GetKeyDown(KeyCode.Space))jump = true;
    }

    void HandleMovement(float deltaTime)
    {
        Vector3 p = transform.position + moveDirection * deltaTime * moveSpeed;
        rigidbody.MovePosition(p);

        if (jump) { jump = false;rigidbody.AddForce(Vector3.up*jumpVelocity, ForceMode.VelocityChange); }

        if (p.y < -2f) SceneManager.LoadScene(0);
    }

    void UpdateCamera()
    {
        Vector3 p = this.transform.position + cameraOffset;
        //p.x = 0f;
        camera.transform.position = p;
    }
}
