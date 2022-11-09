using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMover : MonoBehaviour
{   
    public bool IsPickedUp { get; set; }
  
    [SerializeField] BoxCollider _collider;
    [SerializeField] TargetInputController _inputController;
    [SerializeField] Money _money;
    Transform _moneyTransform;
    Transform _middleTransform;
    Vector3 _startPosition;
    Vector3 _middlePosition;
    Vector3 _targetPosition;
    Vector3 _moneyInitialPosition;
    Vector3 _middleInitialPosition;
    float _index;
    float _time;
    float _timeModifier = 1;
    bool _isDropping;
    bool _isPicking;
    const float OffsetX = .1f;
    const float OffsetY = .1f;
    const float OffsetZ = .1f;

    public void Move(Transform moneyTransform, Transform middleTransform, float index)
    {    
        _startPosition = transform.position;
        _moneyTransform = moneyTransform;
        _middleTransform = middleTransform;
        _index = index;     
        _isPicking = true;
    }

    public void Move(Transform moneyTransform)
    {
        _startPosition = transform.position;
        _middlePosition = transform.position + new Vector3(-1, 3, 0);
        _targetPosition = moneyTransform.position;
        _moneyTransform = moneyTransform;
        _isDropping = true;
    }

    public void Move(Transform moneyTransform, Vector3 index)
    {
        float x = index.x * (_collider.size.x + OffsetX);
        float y = index.y * _collider.size.y;
        float z = index.z * (_collider.size.z + OffsetZ);
        Vector3 pos = moneyTransform.localPosition + new Vector3(x, y, z);
        transform.localPosition = pos;
        if (index.y > 0) transform.position = CheckAvailability(transform.position, index.y, y);
        transform.Rotate(moneyTransform.rotation.eulerAngles);
    }

    Vector3 CheckAvailability(Vector3 pos, float indexY, float y)
    {
        if (indexY == 0) return pos;
        else if (!_inputController.IsTargetExist(pos, _collider.size.y))
        {
            indexY--;
            pos -= new Vector3(0, _collider.size.y, 0);
            return CheckAvailability(pos, indexY, y);
        }
        else return pos;
    }
    private void FixedUpdate()
    {
        if (_isDropping)
        {
            DroppingUpdate();

        }
        if (_isPicking) PickingUpdate();
    }

    private void PickingUpdate()
    {
        _moneyInitialPosition = _moneyTransform.position;
        _middleInitialPosition = _middleTransform.position;
        _moneyTransform.position += new Vector3(0, _index * (_collider.size.y + OffsetY), 0);
        _middleTransform.position += new Vector3(0, _index * (_collider.size.y + OffsetY), 0);

        transform.position = Bezier.QuadraticBezierCurveSolver(_time, _startPosition, _middleTransform.position, _moneyTransform.position);
        _time += Time.fixedDeltaTime * _timeModifier;

        if (Vector3.Distance(transform.position, _moneyTransform.position) < 0.001f)
        {
            transform.position = _moneyTransform.position;
            transform.rotation = _moneyTransform.rotation;
            
            _time = 0;
            _isPicking = false;         
        }
        _moneyTransform.position = _moneyInitialPosition;
        _middleTransform.position = _middleInitialPosition;
    }

    private void DroppingUpdate()
    {
        transform.position = Bezier.QuadraticBezierCurveSolver(_time, _startPosition, _middlePosition, _targetPosition);

        _time += Time.fixedDeltaTime * _timeModifier;
        if (Vector3.Distance(transform.position, _targetPosition) < 0.001f)
        {
            transform.position = _targetPosition;
            transform.rotation = Quaternion.identity;
            transform.parent = _moneyTransform;
            _money.Purchase();
            _time = 0;
            _isDropping = false;
        }
    }

}
