using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ScriptPecas : MonoBehaviour{
    //Esse Script tem como objetivo randomizar a posição das peças e depois verificar se o usuário as colocou na posição correta

    //Variáveis
    private Vector3 PosicaoCerta; //Esse vetor privado irá armazenar a posição certa das peças do puzzle
    public bool EstaNaPosicaoCerta; //Está na Posição Certa? Sim ou Não (True or False, respectivamente)
    public bool Selecionada;
    public static int contadorPecasCorretas = 0; //Essa variável contará o número de peças que foram colocadas no lugar correto;

    void Start(){ //Esse procedimento "Start" será executado 1x quando o Script for chamado
        PosicaoCerta = transform.position; //Vai alterar a posição das peças de acordo com as coordenadas dadas
        transform.position = new Vector3(Random.Range(1300f,2200f), Random.Range(200, 1250)); //Aqui a posição "transform.position" receberá o "Vector3" com coordenadas aleatórias dentro do espaço dado, sendo o primeiro "Random.Range" referente ao eixo X e o segundo "Random.Range" referente ao eixo Y
        contadorPecasCorretas = 0;
    }

    void Update(){
        if(Vector3.Distance(transform.position, PosicaoCerta) < 100){ //se a posição onde o usuário colocou a peça está a menos de "0.5" (escala arbitrária) de distância da posição certa da peça...
            if(!Selecionada){ //Se não houver nenhuma peça selecionada...
                if(EstaNaPosicaoCerta == false){ //Se a peça ainda não estiver na posição certa... (isto foi colocado para evitar que as tarefas abaixo fiquem rodando a cada frame, mas somente 1x)
                    transform.position = PosicaoCerta; //O jogo colocará a peça automáticamente na posição correta
                    EstaNaPosicaoCerta = true; //E armazenará na variável "EstaNaPosicaoCerta" o "TRUE"
                    contadorPecasCorretas = contadorPecasCorretas + 1; //A cada peça colocada no lugar correto, o contador será incrementado em 1.
                    GetComponent<SortingGroup>().sortingOrder = 0; //E alterará seu "layer" (sua profundidade na tela) para 0, isto é, a posição normal.
                }
            }
        }
    }
}
