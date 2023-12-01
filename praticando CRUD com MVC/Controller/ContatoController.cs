using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praticando_CRUD_com_MVC.Controller
{
    internal class ContatoController
    {
        MySqlConnection conn;
        string sql = "datasource=localhost;username=root;password=123456;database=db_agenda";

        public void AdicionarContato(Model.ContatoView contato)
        {
            conn = new MySqlConnection(sql);
            conn.Open();

            var comInsert = new MySqlCommand();
            comInsert.Connection = conn;

            comInsert.CommandText = "INSERT INTO contato (nome, email, telefone) " +
                    "VALUES (@nome, @email, @telefone) ";
            comInsert.Parameters.AddWithValue("@nome", contato.nome);
            comInsert.Parameters.AddWithValue("@email", contato.email);
            comInsert.Parameters.AddWithValue("@telefone", contato.telefone);

            comInsert.Prepare();

            comInsert.ExecuteNonQuery();

            MessageBox.Show("Contato salvo");

        }
    }
}
