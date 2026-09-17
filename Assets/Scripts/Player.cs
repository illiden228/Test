using System;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed; // поле со скоростью
    public float JumpForce;
    [SerializeField] private string Name;
    private Rigidbody _rb;
    [SerializeField] private int _health;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Animator _animtor;
    [SerializeField] private Transform _target;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Camera _camera;
    private bool _isMoving = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        
    }

    void Start() // запустится 1 раз на старте
    {
        // gameObject // - Объект
        // transform // компонент Transform Объекта
    }

    void Update()
    {
        _isMoving = false;

        if (Input.GetMouseButtonDown(0)) // лкм нажали
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition); // берутся координаты мыши и преобразуются в луч

            if (Physics.Raycast(ray, out RaycastHit hit)) // кидаем луч, если столкнулись с чем то, идем дальше
            {
                if (hit.collider.gameObject.layer == 7) // если столкнулись с землей, идем дальше
                {
                    _target.position = hit.point; // устанавливаем цели позицию столкновения земли с лучом
                }
            }
        }
        

        Vector3 direction = _target.position - transform.position; // направление к конечной точке
        
        if (direction.magnitude > 0.5f)
        {
            _controller.Move(Speed * Time.deltaTime * direction.normalized); // двигаемся по направлению со скоростью
            transform.forward = direction; // устанавливаем поворот по направлению
            _isMoving = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Произошла атака");
            _animtor.SetTrigger("Attack");
        }
        
        _animtor.SetBool("IsMoving", _isMoving);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthText.text = _health.ToString();

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
