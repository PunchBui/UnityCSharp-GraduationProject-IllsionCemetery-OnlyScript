using System.Linq;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public Team Team => _team;
    [SerializeField] private Team _team;
    [SerializeField] private LayerMask _layerMask;
    private float _attackRange = 2f;
    private float _rayDistance = 3.0f;
    private float _stoppingDistance = 1f;
    
    private Vector3 _destination;
    private Quaternion _desiredRotation;
    private Vector3 _direction;
    private Drone _target;
    private DroneState _currentState;
    public GameObject CutScene;
    public GameObject CameraMainAc;
    public GameObject Pa;
    private void Update()
    {
        switch (_currentState)
        {
            case DroneState.Wander:
            {
              
                
           
                    var rayColor = IsPathBlocked() ? Color.red : Color.green;
                Debug.DrawRay(transform.position, _direction * _rayDistance, rayColor);

                while (IsPathBlocked())
                {
                    Debug.Log("Path Blocked");
              
                }

                var targetToAggro = CheckForAggro();
                if (targetToAggro != null)
                {
                    _target = targetToAggro.GetComponent<Drone>();
                    _currentState = DroneState.Chase;
                }
                
                break;
            }
            case DroneState.Chase:
            {
                if (_target == null)
                {
                    _currentState = DroneState.Wander;
                    return;
                }
                
            
                if (Vector3.Distance(transform.position, _target.transform.position) < _attackRange)
                {
                    _currentState = DroneState.Attack;
                }
                break;
            }
            case DroneState.Attack:
            {
                if (_target != null)
                {
                    Destroy(_target.gameObject);
                }
                
                // play laser beam
                
                _currentState = DroneState.Wander;
                break;
            }
        }
    }

    private bool IsPathBlocked()
    {
        Ray ray = new Ray(transform.position, _direction);
        var hitSomething = Physics.RaycastAll(ray, _rayDistance, _layerMask);
        return hitSomething.Any();
    }

 

    private bool NeedsDestination()
    {
        if (_destination == Vector3.zero)
            return true;

        var distance = Vector3.Distance(transform.position, _destination);
        if (distance <= _stoppingDistance)
        {
            return true;
        }

        return false;
    }
    
    
    
    Quaternion startingAngle = Quaternion.AngleAxis(-60, Vector3.up);
    Quaternion stepAngle = Quaternion.AngleAxis(5, Vector3.up);
    
    private Transform CheckForAggro()
    {
        float aggroRadius = 1f;
        
        RaycastHit hit;
        var angle = transform.rotation * startingAngle;
        var direction = angle * Vector3.forward;
        var pos = transform.position;
        for(var i = 0; i < 50; i++)
        {
            if(Physics.Raycast(pos, direction, out hit, aggroRadius))
            {
            
                if (hit.collider.gameObject.tag == "Player")
                {
                    Debug.Log("hit");
                    Debug.DrawRay(pos, direction * hit.distance, Color.red);
                    
                }   
                else
                {
                    Debug.DrawRay(pos, direction * hit.distance, Color.yellow);
                }
            }
            else
            {
                Debug.DrawRay(pos, direction * aggroRadius, Color.white);
            }
            direction = stepAngle * direction;
        }

        return null;
    }
}

public enum Team
{
    Red,
    Blue
}

public enum DroneState
{
    Wander,
    Chase,
    Attack
}