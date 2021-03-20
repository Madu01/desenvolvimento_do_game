using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrastarESoltar : MonoBehaviour{
    //Breve Resumo: Esse script é responsável pela "física" das peças do puzzle e dos toques na tela (entradas), ...
    //...onde podemos "Clicar e Arrastar" as peças pela tela.

    //Variáveis
    public GameObject PecaSelecionada; //Variável "Peça Selecionada"

    //Procedimentos
    void Start(){ 
        
    }

    void Update(){ //Esse procedimento será realizado repetidamente e constantemente quando o script for usado
        if(Input.GetMouseButtonDown(0)){ //Se o jogo detectar um "clique"...
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero); //Selecionando a peça
            if(hit.transform.CompareTag("Puzzle")){ //Note que estamos identificando as peças selecionadas pela 'Tag' criada exclusivamente para elas: "Puzzle". O objetivo é 
                if(!hit.transform.GetComponent<ScriptPecas>().EstaNaPosicaoCerta){ //Se a peça selecionada NÃO ESTÁ NA POSIÇÃO CERTA...
                    PecaSelecionada = hit.transform.gameObject; //Dando à variável "PecaSelecionada" a peça que foi selecionada ("clicada") pelo usuário (isto é, o usuário só poderá mover a peça se ela não estiver na posição certa)
                    PecaSelecionada.GetComponent<ScriptPecas>().Selecionada = true; //Retorna à variável "Selecionada" do script "ScriptPecas" que há uma peça selecionada (true);
                }
                
            }
        }
        if(Input.GetMouseButtonUp(0)){ //Quando o jogador clicar na tela...
            PecaSelecionada.GetComponent<ScriptPecas>().Selecionada = false; //Retorna à variável "Selecionada" do script "ScriptPecas" que não há nenhuma peça selecionada (false);
            PecaSelecionada = null; //...nenhuma peça estará "selecionada", isto é, quando o jogador "soltar o clique", a peça selecionada será "solta"
        }
        if(PecaSelecionada != null){ //Se há uma peça selecionada
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Passando as coordenadas do mouse para o vetor "MousePoint"
            PecaSelecionada.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0); //Movimentando a peça selecionada
        }
    }
}
