using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;
    private Camera _camera;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * -torque);
            }
        }
        
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = _camera.ScreenToViewportPoint(Input.mousePosition);
                
            Debug.Log(mousePosition);
            float torque = Time.deltaTime * _rotateSpeed;

            if (mousePosition.x < 0.5f)
            {
                _rigidbody.AddTorque(Vector3.up * torque);
            }
            else
            {
                _rigidbody.AddTorque(Vector3.up * -torque);

            }
        }
    }
}
