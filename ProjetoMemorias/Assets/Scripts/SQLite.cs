using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLite : MonoBehaviour{
    //Esse script é responsável por realizar a conexão entre o banco de dados e o jogo!
    public static int id_do_save = 1;
    
    // Start is called before the first frame update
    void Start(){
        //CRIANDO A CONEXÃO COM O BANCO DE DADOS
        string connection = "URI=file:"+Application.persistentDataPath+"/BD_Proj_Memorias"; //Adicionando à variável "connection" o caminho para o nosso Banco de Dados "BD_Proj_Memorias"
        IDbConnection dbcon = new SqliteConnection(connection); //Comunicando com o nosso banco de dados cujo caminho está sendo passado como parâmetro pela variável "connection"
        dbcon.Open(); //Abrindo a conexão com o banco de dados

        //CRIANDO UMA TABELA
        IDbCommand dbcmd; //Variável responsável por armazenar comandos que serão passados ao banco de dados
        IDataReader leitor; //Variável responsável por receber o que for retornado (valores...) do banco de dados

        dbcmd = dbcon.CreateCommand(); //Criando um comando para o banco de dados 
        string criar_tabela = "CREATE TABLE IF NOT EXISTS ultimo_save (id INTEGER PRIMARY KEY, tela_salva INTEGER )"; //Escrevendo o comando a ser executado no BD, no caso, será criada uma tabela "ultimo_save" com as colunas "id" e "tela_salva"
        dbcmd.CommandText = criar_tabela; //Executando o comando da última linha
        leitor = dbcmd.ExecuteReader();

    }

    // Update is called once per frame
    void Update(){
        
    }
}
