using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BgMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float _bounce;
    [SerializeField] private bool _moveUp;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (_moveUp)
            MoveUp();
        else
            MoveDown();
    }

    private void MoveUp()
    {
        transform.position += new Vector3(0, _movementSpeed * Time.deltaTime);

        if (transform.position.y > _bounce)
            Loop();
    }

    private void MoveDown()
    {
        transform.position -= new Vector3(0, _movementSpeed * Time.deltaTime);

        if (transform.position.y < _bounce)
            Loop();
    }

    private void Loop()
    {
        transform.position = new Vector3(transform.position.x, -_bounce);
    }
}