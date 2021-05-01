using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ScriptMusica : MonoBehaviour{
    private AudioSource musica1; //variável que armazenará a música
    private GameObject[] ObjetosMusicas; //Vetor de variáveis do tipo "GameObject"
    private bool JaTocou = false; //Variável que informará se a música já está tocando
    
    private void Awake(){
        ObjetosMusicas = GameObject.FindGameObjectsWithTag("Musica"); //Armazenando em nosso vetor os "GameObject" que possuem a Tag "Musica" (conferir na Unity)

        foreach(GameObject instancia in ObjetosMusicas){ //Para cada (for each) instancia do nosso vetor "ObjetosMusicas" que existir, o bloco de comandos da instrução será executado uma vez
            if (instancia.scene.buildIndex == -1){ //Essa condição "instancia.scene.buildIndex" nos retornará o índice da nossa instância da "musica1" menos 1, isto é, caso já exista uma instância da música tocando, ele será armazenado no índice 0 e, consequentemente, nos retornará o valor "-1"
                JaTocou = true;  //Já existe uma instância da nossa música tocando
            }
        }

        DontDestroyOnLoad(transform.gameObject); //Fazendo com que a instância da música tocando não seja destruída ao mudar a cena
        musica1 = GetComponent<AudioSource>(); //Recebendo o componente "musica1"

        if (JaTocou == true){ //Caso já exista uma instância da música tocando...
            Destroy(gameObject); //... ela será finalizada
            Debug.Log("A música já tocou");
        }
    }

    public void TocarMusica(){ //Tocar música
        if(musica1.isPlaying){ 
            return;
        }
        musica1.Play();
    }

    public void PararMusica(){ //Parar música
        musica1.Stop();
    }
}   
