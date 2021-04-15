using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Linq;

public class botaoSalvar : MonoBehaviour{
    //Função responsável por salvar o jogo!
    public void salvarJogo(int id_da_fase){
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        IDbCommand cmnd = dbcon.CreateCommand(); //Criando variável para receber comando
        cmnd.CommandText = "INSERT INTO ultimo_save (tela_salva) VALUES ("+id_da_fase+")"; //Aqui, estamos armazenando o ID da fase salva no nosso Banco de DAdos
        cmnd.ExecuteNonQuery(); //Executando o comando anterior

         //Retornando para o Console os valores salvos na tabela, apenas para teste!
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader;

        string query = "SELECT * FROM ultimo_save"; //Selecionando todos os itens da nossa tabela no Banco de Dados
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();

        while(reader.Read()){ //Mostrando todos os valores salvos na tabela
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("última tela salva: " + reader[1].ToString());
        }

        //Fechando a conexão com o Banco de Dados
        dbcon.Close();
          
    }

    //Função responsável por limpar todos os valores presentes na tabela! Serve para apagar todos os itens (fases) salvos!
    public void limparTabela(){ 
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "DELETE FROM ultimo_save";
        cmnd.ExecuteNonQuery(); //Executando comando da linha anterior, onde deletaremos todos os itens da nossa tabela "ultimo_save"

        //Fechando nossa conexão
        dbcon.Close();
    }
}
