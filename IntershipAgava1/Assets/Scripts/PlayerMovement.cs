using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (transform.position != _ball.transform.position)
            {
                transform.position = _ball.transform.position;
                _particleSystem.Play();
                _ball.StopMoving();
            }
        }
    }
}
