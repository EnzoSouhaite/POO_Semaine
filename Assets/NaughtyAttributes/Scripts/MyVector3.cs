using UnityEngine;

public struct MyVector3
{
    private float _x;
    private float _y;
    private float _z;

    public float X
    {
        get => _x;
        set => _x = value;
    }

    public float Y
    {
        get => _y;
        set => _y = value;
    }

    public float Z
    {
        get => _z;
        set => _z = value;
    }

    public float Magnitude => Mathf.Sqrt(_x * _x + _y * _y + _z * _z);

    public float SqrtMagnitude => _x * _x + _y * _y + _z * _z;

    public void Normalize()
    {
        float magnitude = Magnitude;
        if (magnitude > 0)
        {
            _x = _x / magnitude;
            _y = _y / magnitude;
            _z = _z / magnitude;
        }
    }

    public static MyVector3 operator +(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a._x + b._x, a._y + b._y, a._z + b._z);
    }

    public static MyVector3 operator *(MyVector3 a, MyVector3 b)
    {
        return new MyVector3(a._x * b._x, a._y * b._y, a._z * b._z);
    }

    public MyVector3(float x, float y, float z)
    {
        _x = x;
        _y = y;
        _z = z;
    }
}
