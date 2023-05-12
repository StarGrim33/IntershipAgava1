using UnityEngine;

public class KickingBall : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRigidbody;
    [SerializeField] private Transform _ballSpawnPoint;
    [SerializeField] private float _hifForce = 10.0f;
    [SerializeField] private GameObject _player;
    [SerializeField] private AnimatorPlayer _playerAnimator;
    [SerializeField] private ParticleSystem _playerPrefab;

    private Vector3 _hitDirection = Vector3.forward;
    private bool _isMouseDown = false;
    private bool _isPlayerActive = true;

    private void OnEnable()
    {
        _playerAnimator.OnKickedAnimationFinished += OnKickedAnimationFinished;
    }

    private void OnDisable()
    {
        _playerAnimator.OnKickedAnimationFinished -= OnKickedAnimationFinished;
    }

    private void OnKickedAnimationFinished()
    {
        _playerPrefab.Play();
        _ballRigidbody.AddForce(_hitDirection * _hifForce, ForceMode.Impulse);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isMouseDown = true;
            Time.timeScale = 0.8f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1; 
            _isMouseDown = false;
        }

        if (_isMouseDown)
        {
            float mouseX = Input.GetAxis("Mouse X");
            _player.transform.Rotate(0, mouseX * 5.0f, 0);
            Quaternion rotation = Quaternion.Euler(0, mouseX * 5.0f, 0);
            _hitDirection = rotation * _hitDirection;
        }
    }
}
