using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Processors;
using UnityEngine.ProBuilder.MeshOperations;
using UnityEngine.UIElements;
public class PlayerScript : MonoBehaviour
{
    private float _equal;
    private float _lookCap;
    public float cursorSpread;
    [SerializeField]
    float sensitivityPercent =75f;
    [SerializeField]
    float runSpeed = 7f;
    [SerializeField]
    float jumpForce = 7f;
    [SerializeField]
    GameObject capsule;
    [SerializeField]
    GameObject camera;
    Rigidbody rigidbody;
    Vector2 look;
    Vector2 move;
    [SerializeField]
    float speed = 7f;
    private float _securespeed;
    // Start is called before the first frame update
    private void Awake() 
    {
        rigidbody = capsule.GetComponent<Rigidbody>();
    }
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        _securespeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(sensitivityPercent,1,1000);
        capsule.transform.Translate(-move.y*speed *Time.deltaTime,0,move.x*speed *Time.deltaTime);
        capsule.transform.Rotate(0,look.x*sensitivityPercent/100,0);
        camera.transform.Rotate(-look.y*sensitivityPercent/100,0,0);
         _lookCap += -look.y*sensitivityPercent/100;
        if (_lookCap > 90)
        {
            _equal = 90 -_lookCap;
            camera.transform.Rotate(_equal,0,0);
            _lookCap += _equal;
        }
        else if (_lookCap < -90)
        {
            _equal = -90 -_lookCap;
            camera.transform.Rotate(_equal,0,0);
            _lookCap += _equal;
        }
        _equal = 0;

    }
    void OnWalk(InputValue movment)
    {
        move = movment.Get<Vector2>();
    }
    void OnLook(InputValue looking)
    {
        look = looking.Get<Vector2>();
    }
    void OnJump(InputValue jump)
    {
        
        if (jump.Get<float>()>0)
        {
            rigidbody.AddForce(Vector3.up * jumpForce);
            cursorSpread += 0.2f;
        }
        else
        {
            cursorSpread -= 0.2f;
        }
    }
    void OnRun(InputValue runing)
    {
        if (runing.Get<float>()>0)
        {
            speed = speed+runSpeed;
            cursorSpread += 0.2f;
        }
        else
        {
            speed = _securespeed;
            cursorSpread -=0.2f;
        }
        
    }
}