using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.CameraMovement
{
    public class CameraController: MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float _minDistance;
        [SerializeField] private float _maxDistance;
        
        
        [SerializeField] private float _minOrthographicDistance;
        [SerializeField] private float _maxOrthographicDistance;
        
        [SerializeField] private float _zoomSpeed;
        [SerializeField] private float _rotationSpeed;
        
        [SerializeField] private float _minVerticalAngle;
        [SerializeField] private float _maxVerticalAngle;

        private float _currentDistance;
        private float _currentOrthographicDistance = 6f;
        private Vector3 _lastMousePosition;
        
        private float _currentX;
        private float _currentY;
        private Camera _camera;
        private bool _isDragging;

        private void Start()
        {
            _camera = Camera.main;
            
            _currentDistance = Vector3.Distance(transform.position, target.position);
            _currentDistance = Mathf.Clamp(_currentDistance, _minDistance, _maxDistance);
            
            Vector3 angles = transform.eulerAngles;
            _currentX = angles.y;
            _currentY = angles.x;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                _isDragging = true;
                _lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _isDragging = false;
            }
        }

        private void LateUpdate()
        {
            HandleZoom();
            if (_isDragging)
            {
                RotateCamera();
            }
            UpdateCameraTransform();
        }

        private void HandleZoom()
        {
            if (_camera.orthographic)
            {
                var scrollDelta = Input.mouseScrollDelta.y;
                _currentOrthographicDistance -= scrollDelta * _zoomSpeed * Time.deltaTime;
                _currentOrthographicDistance = Mathf.Clamp(_currentOrthographicDistance, _minOrthographicDistance,
                    _maxOrthographicDistance);

                _camera.orthographicSize = _currentOrthographicDistance;
            }
            else
            {
                var scrollDelta = Input.mouseScrollDelta.y;
                _currentDistance -= scrollDelta * _zoomSpeed * Time.deltaTime;
                _currentDistance = Mathf.Clamp(_currentDistance, _minDistance, _maxDistance);
            }
        }

        private void RotateCamera()
        {
            if (_camera.orthographic) return;

            Vector3 delta = Input.mousePosition - _lastMousePosition;
            _currentX += delta.x * _rotationSpeed * Time.deltaTime;
            _currentY -= delta.y * _rotationSpeed * Time.deltaTime;
            _currentY = Mathf.Clamp(_currentY, _minVerticalAngle, _maxVerticalAngle);
            _lastMousePosition = Input.mousePosition;
        }

        private void UpdateCameraTransform()
        {
            Quaternion rotation = Quaternion.Euler(_currentY, _currentX, 0);
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -_currentDistance);
            Vector3 position = rotation * negDistance + target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}