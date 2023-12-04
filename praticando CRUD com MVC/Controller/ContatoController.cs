using MySql.Data.MySqlClient;
using praticando_CRUD_com_MVC.Model;
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
        public int? idSelecionado = null;

        public void CreateContato(Model.ContatoModel contato)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }

        }
        public void ReadContato(ListView listView)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var comSelect = new MySqlCommand();
                comSelect.Connection = conn;

                comSelect.CommandText = "SELECT * FROM contato ORDER BY id DESC ";

                comSelect.Prepare();

                listView.Items.Clear();

                MySqlDataReader reader = comSelect.ExecuteReader();

                while (reader.Read())
                {
                    string[] row =
                    {
                    reader.GetString(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    };

                    var linhaListView = new ListViewItem(row);
                    listView.Items.Add(linhaListView);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }
        }
        public void UpdateContato(Model.ContatoModel contato)
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var comUpdate = new MySqlCommand();
                comUpdate.Connection = conn;

                comUpdate.CommandText = "UPDATE contato SET " +
                                          "nome=@nome, email=@email, telefone=@telefone " +
                                          "WHERE id = @id ";
                comUpdate.Parameters.AddWithValue("@nome", contato.nome);
                comUpdate.Parameters.AddWithValue("@email", contato.email);
                comUpdate.Parameters.AddWithValue("@telefone", contato.telefone);
                comUpdate.Parameters.AddWithValue("@id", idSelecionado);

                comUpdate.Prepare();

                comUpdate.ExecuteNonQuery();

                MessageBox.Show("Contato Atualizado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }

        }
        public void DeleteContato()
        {
            try
            {
                conn = new MySqlConnection(sql);
                conn.Open();

                var comRemeve = new MySqlCommand();
                comRemeve.Connection = conn;

                comRemeve.CommandText = "DELETE FROM contato WHERE id=@id";

                comRemeve.Parameters.AddWithValue("@id", idSelecionado);

                comRemeve.Prepare();

                comRemeve.ExecuteNonQuery();

                MessageBox.Show("Contato Excluido");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK);
            }
            finally
            {
                conn.Close();
            }

        }
        public void MostrarItemsSelecionados(ListView listContato, Model.ContatoModel contato)
        {
            ListView.SelectedListViewItemCollection itemselecionado = listContato.SelectedItems;


            foreach (ListViewItem item in itemselecionado)
            {
                idSelecionado = Convert.ToInt32(item.SubItems[0].Text);

                contato.nome = item.SubItems[1].Text;
                contato.email = item.SubItems[2].Text;
                contato.telefone = item.SubItems[3].Text;
            }

        }
    }
}
