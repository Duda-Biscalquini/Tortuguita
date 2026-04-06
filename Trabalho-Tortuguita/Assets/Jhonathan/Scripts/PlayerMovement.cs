using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovimentoJogador : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public LayerMask ground;

    public float speed, maxSpeed, drag;
    public float rotationSpeed, jumpForce;
    public float limiteQueda = -5f;

    public GameObject telaGameOver;
    public GameObject imagemPreta;
    public GameObject telaVitoria;

    public TextMeshProUGUI textoPontos;

    bool left, forward, backward, right;
    bool grounded, jump;

    Vector3 posicaoInicial;
    Quaternion rotacaoInicial;
    int totalDePontos;
    int pontosAtuais = 0;
    GameObject[] listaDePontos;

    void Start()
    {
        posicaoInicial = transform.position;
        rotacaoInicial = transform.rotation;

        if (telaGameOver != null) telaGameOver.SetActive(false);
        if (imagemPreta != null) imagemPreta.SetActive(false);
        if (telaVitoria != null) telaVitoria.SetActive(false);

        listaDePontos = GameObject.FindGameObjectsWithTag("collectible");
        totalDePontos = listaDePontos.Length;

        AtualizarInterface();
    }

    void Update()
    {
        HandleInput();
        LimitVelocity();
        CheckGrounded();

        if (transform.position.y < limiteQueda)
        {
            Respawn();
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }

    void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position + Vector3.up * .1f, Vector3.down, .2f, ground);
    }

    void HandleRotation()
    {
        if ((new Vector2(rb.velocity.x, rb.velocity.z)).magnitude > .1f)
        {
            Vector3 horizontalDir = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            Quaternion rotation = Quaternion.LookRotation(horizontalDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        }
    }

    void LimitVelocity()
    {
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitedVelocity = horizontalVelocity.normalized * maxSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    void HandleMovement()
    {
        Quaternion dir = Quaternion.Euler(0f, cam.rotation.eulerAngles.y, 0f);

        if (left) { rb.AddForce(dir * Vector3.left * speed); left = false; }
        if (forward) { rb.AddForce(dir * Vector3.forward * speed); forward = false; }
        if (backward) { rb.AddForce(dir * Vector3.back * speed); backward = false; }
        if (right) { rb.AddForce(dir * Vector3.right * speed); right = false; }

        if (jump && grounded)
        {
            transform.position += Vector3.up * .1f;
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.A)) left = true;
        if (Input.GetKey(KeyCode.W)) forward = true;
        if (Input.GetKey(KeyCode.S)) backward = true;
        if (Input.GetKey(KeyCode.D)) right = true;
        if (Input.GetKeyDown(KeyCode.Space) && grounded) jump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collectible"))
        {
            pontosAtuais++;
            other.gameObject.SetActive(false);

            AtualizarInterface();

            if (pontosAtuais >= totalDePontos && totalDePontos > 0)
            {
                Vencer();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Respawn();
        }
    }

    void AtualizarInterface()
    {
        if (textoPontos != null)
        {
            textoPontos.text = "Pontuação: " + pontosAtuais + " / " + totalDePontos;
        }
    }

    void Vencer()
    {
        if (telaVitoria != null) telaVitoria.SetActive(true);
        rb.isKinematic = true;
    }

    void Respawn()
    {
        transform.position = posicaoInicial;
        transform.rotation = rotacaoInicial;

        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        pontosAtuais = 0;
        AtualizarInterface();

        foreach (GameObject ponto in listaDePontos)
        {
            if (ponto != null) ponto.SetActive(true);
        }

        if (telaGameOver != null) telaGameOver.SetActive(true);
        if (imagemPreta != null) imagemPreta.SetActive(true);
        Invoke("EsconderTudo", 1.5f);
    }

    void EsconderTudo()
    {
        if (telaGameOver != null) telaGameOver.SetActive(false);
        if (imagemPreta != null) imagemPreta.SetActive(false);
    }
}