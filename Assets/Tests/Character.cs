using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Character : MonoBehaviour
{
    private const float Speed = 5f;

    [SerializeField] 
    private MonoBehaviour _inputSourceBehaviour;
    private ICharacterInputSource _inputSource;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _inputSource = (ICharacterInputSource)_inputSourceBehaviour;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var movement = new Vector2(_inputSource.MovementInput.x, _inputSource.MovementInput.y);
        movement *= Speed;
        _rigidbody.velocity = movement;
    }

    private void OnValidate()
    {
        if (_inputSourceBehaviour && !(_inputSourceBehaviour is ICharacterInputSource))
        {
            Debug.LogError(nameof(_inputSourceBehaviour) + " needs to implement " + nameof(ICharacterInputSource));
            _inputSourceBehaviour = null;
        }
    }
}