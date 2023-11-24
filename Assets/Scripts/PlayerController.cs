using UnityEngine;
using UnityEngine.XR;

public class PlayerController : MonoBehaviour
{
    public XRNode inputSource;

    private Vector2 inputAxis;

    private CharacterController characterController;
    private GameManager gameManager;

    [SerializeField] private float speed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.GetInstance();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        var device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        if (gameManager.isGamePaused) return; // 실제 device상 환경이랑 동작이 다름 테스트 필요
        var direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        characterController.Move(direction * (speed * Time.deltaTime));
    }
}