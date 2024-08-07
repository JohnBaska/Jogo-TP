using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeamController : MonoBehaviour
{
    public Transform target;  // O alvo para onde o feixe de luz será direcionado
    private LineRenderer lineRenderer;
    public float moveSpeed = 3f;
    public Transform posInicial;
    public GameObject objectToDuplicate;
    [HideInInspector]
    public int direcao_move_x;
    public int direcao_move_y;
    GameObject objetoAtual;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        direcao_move_x = 1;
        direcao_move_y = 0;
    }

    void moverLightBeam (){
        // Movimento com setas do teclado
        float moveX = direcao_move_x * moveSpeed * Time.deltaTime;
        float moveY = direcao_move_y * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, moveY, 0);

        // Atualiza a posição do feixe de luz
        lineRenderer.SetPosition(0, posInicial.position);
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
    }

    // Método chamado quando uma colisão 2D termina
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colidiu");
        Debug.Log(lineRenderer.positionCount);
        lineRenderer.positionCount += 1;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, transform.position);
        if (collision.gameObject.name.Contains("Refletor_right_up"))
        {
            if (direcao_move_x == 1 && direcao_move_y == 0)
            {
                direcao_move_x = 0;
                direcao_move_y = 1;
            }else{
                direcao_move_x = -1;
                direcao_move_y = 0;
            }
        }else if(collision.gameObject.name.Contains("Refletor_right_down")){
            if (direcao_move_x == 1 && direcao_move_y == 0)
            {
                direcao_move_x = 0;
                direcao_move_y = -1;
            }else{
                direcao_move_x = -1;
                direcao_move_y = 0;
            }
        }else if(collision.gameObject.name.Contains("Refletor_up_right")){
            if (direcao_move_x == -1 && direcao_move_y == 0)
            {
                direcao_move_x = 0;
                direcao_move_y = 1;
            }else{
                direcao_move_x = 1;
                direcao_move_y = 0;
            }
        }else if(collision.gameObject.name.Contains("Refletor_down_right")){
            if (direcao_move_x == 0 && direcao_move_y == 1)
            {
                direcao_move_x = 1;
                direcao_move_y = 0;
            }else{
                direcao_move_x = 0;
                direcao_move_y = -1;
            }
        }
    }
}
