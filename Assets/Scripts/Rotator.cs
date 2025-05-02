using UnityEngine;

public class Rotator
{
    private readonly Quaternion _rightRotation;
    private readonly Quaternion _leftRotation;
    private readonly Transform _transform;

    private bool _isLookRight;

    public Rotator(Transform transform)
    {
        _rightRotation = Quaternion.Euler(new Vector3(0, 0, 0));
        _leftRotation = Quaternion.Euler(new Vector3(0, 180, 0));
        _transform = transform;
    }

    public void RotateByDirection(float direction)
    {
        if (direction > 0)
            LookRight();
        else if (direction < 0)
            LookLeft();
    }

    private void LookRight()
    {
        if (_isLookRight)
            return;

        _transform.rotation = _rightRotation;

        _isLookRight = true;
    }

    private void LookLeft()
    {
        if (_isLookRight == false)
            return;

        _transform.rotation = _leftRotation;

        _isLookRight = false;
    }
}