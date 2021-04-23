using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class botaoContinuar : MonoBehaviour{
    public GameObject btnContinuar;
    public bool botaoAparece;
    private static int contador = 0;

    // Start is called before the first frame update
    void Start(){
        btnContinuar.SetActive(false); //Desativando o botão "Continuar"
        botaoAparece = false;
    }

    // Update is called once per frame
    void Update(){
        if(contador != ScriptPecas.contadorPecasCorretas){ 
            contador = ScriptPecas.contadorPecasCorretas; //Recebendo o número de peças que já foram colocadas no lugar correto
            Debug.Log("Aqui chegou "+contador);
        }
        if(contador == 36 && botaoAparece == false){ //Se todas as peças estiverem no lugar correto...
            btnContinuar.SetActive(true); //O botão será ativado!
            botaoAparece = true;
        }
    }
}
