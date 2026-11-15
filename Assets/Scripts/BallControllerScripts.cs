using System;
using System.Timers;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class BallControllerScripts : MonoBehaviour
{
    public float rollSpeed = 1f;
    public TextMeshProUGUI scoreText, timeText;
    public int score = 0;
    public float timeCounting = 10f;
    public GameObject gameOverPanel, winPanel;
    public InputAction playerInput;
    
    private bool _isPlaying = true;
    private Rigidbody _rb;

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 inputMovement = playerInput.ReadValue<Vector2>();

        if (_isPlaying)
        {
            Vector3 movement = new Vector3(inputMovement.x, 0, inputMovement.y);
            _rb.AddForce(movement * rollSpeed);
            scoreText.text = $"Score: {score}";
        }
        
        if (timeCounting > 0 && _isPlaying)
        {
            timeCounting -= Time.deltaTime;
            timeText.text = $"Timer: {Math.Round(timeCounting)}";
        }
        else
        {
            _isPlaying = false;
        }

        if (score < 10 && timeCounting <= 0)
        {
            gameOverPanel.SetActive(true);
        }

        if (score == 10)
        {
            _isPlaying = false;
            winPanel.SetActive(true);
        }

    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Coin") && _isPlaying)
        {
            coll.gameObject.SetActive(false);
            score++;
        }
    }
}
