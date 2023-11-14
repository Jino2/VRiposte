using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public XRNode inputSource;

    private Vector2 inputAxis;

    private CharacterController characterController;

    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
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
        var direction = new Vector3(inputAxis.x, 0, inputAxis.y);
        characterController.Move(direction * (speed * Time.deltaTime));
    }
}