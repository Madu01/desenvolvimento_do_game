using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Linq;

public class CarregarJogo : MonoBehaviour{
    //Esse script serve para carregar a última fase salva

    public Button continuar_jogo;
    // Start is called before the first frame update
    void Start(){ //Caso não exista nenhuma fase salva, o botão "Continuar Jogo" estará inativado
        //Abrindo a conexão com o Banco de Dados
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        //Pesquisando o ID da última tela de jogo salva
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT tela_salva FROM ultimo_save"; //Selecionando todos os itens da nossa tabela no Banco de Dados
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        string fase = System.String.Empty;

        while(reader.Read()){ //Armazenando o último valor da coluna "tela_salva" na nossa string
            fase = reader[0].ToString();
        }    

        if(fase == ""){ //Caso não tenha nenhum jogo salvo ainda...
            continuar_jogo.interactable = false; //O botão estará inativado!
            Debug.Log("Não há nenhuma fase salva!");
        }
    }

    public void Carregar_Jogo(){
        //Abrindo a conexão com o Banco de Dados
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        //Pesquisando o ID da última tela de jogo salva
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT tela_salva FROM ultimo_save"; //Selecionando todos os itens da nossa coluna "tela_salva" no Banco de Dados
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        string fase = System.String.Empty;

        while(reader.Read()){ //Armazenando o último valor da coluna "tela_salva" na nossa string
            fase = reader[0].ToString();
        }    

        if(fase != ""){ //Caso exista alguma fase salva, o botão estará ativado!
            continuar_jogo.interactable = true; //O botão estará inativado!
            if(fase == "1"){ //Caso a última fase salva seja o Puzzle1, estaremos direcionando o usuário para esta tela
                FindObjectOfType<LevelManager>().LoadScene("puzzle1");
            } else if(fase == "2"){ //Caso a última fase salva seja o Puzzle2, estaremos direcionando o usuário para esta tela
                FindObjectOfType<LevelManager>().LoadScene("puzzle2");
            } else if(fase == "3"){ //Caso a última fase salva seja o Puzzle3, estaremos direcionando o usuário para esta tela
                FindObjectOfType<LevelManager>().LoadScene("puzzle3");
            } else { //Apenas para casos excepcionais, caso eventualmente dê algo errado
                Debug.Log("Erro! Nenhuma fase foi encontrada!");
            }
        }
    }
}
