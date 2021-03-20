using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastarESoltar : MonoBehaviour{
    //Breve Resumo: Esse script é responsável pela "física" das peças do puzzle e dos toques na tela (entradas), ...
    //...onde podemos "Clicar e Arrastar" as peças pela tela.

    //Variáveis
    public GameObject SelectedPiece; //Variável "Peça Selecionada"

    //Procedimentos
    void Start(){ 
        
    }

    void Update(){ //Esse procedimento será realizado repetidamente e constantemente quando o script for usado
        if(Input.GetMouseButtonDown(0)){ //Se o jogo detectar um "clique"...
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //Selecionando a peça
            if(hit.transform.CompareTag("Puzzle")){ //Note que estamos identificando as peças selecionadas pela 'Tag' criada exclusivamente para elas: "Puzzle". O objetivo é 
                SelectedPiece = hit.transform.gameObject; //Dando à variável "SelectedPiece" a peça que foi selecionada ("clicada") pelo usuário
            }
        }
        if(Input.GetMouseButtonUp(0)){ //Quando o jogador clicar na tela...
            SelectedPiece = null; //...nenhuma peça estará "selecionada", isto é, quando o jogador "soltar o clique", a peça selecionada será "solta"
        }
        if(SelectedPiece != null){ //Se há uma peça selecionada
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Passando as coordenadas do mouse para o vetor "MousePoint"
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0); //Movimentando a peça selecionada
        }
    }
}
