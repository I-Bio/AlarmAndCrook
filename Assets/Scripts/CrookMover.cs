using UnityEngine;

public class CrookMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _path;
    
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        CollectPathPoints();
        SetRotation();
    }

    private void Update()
    {
        Move();
    }

    public void SetNextPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Length)
        {
            _currentPoint = 0;
        }
        
        SetRotation();
    }

    private void CollectPathPoints()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    private void SetRotation()
    {
        Vector3 moveDirection = (_points[_currentPoint].position - transform.position).normalized;
        float angleOfRotation = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        
        if (angleOfRotation < 0)
        {
            angleOfRotation += 360;
        }
        
        transform.eulerAngles = new Vector3(0, angleOfRotation,0);
    }
    
    private void Move()
    {
        Transform target = _points[_currentPoint];

        transform.position =  Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
    }
}
