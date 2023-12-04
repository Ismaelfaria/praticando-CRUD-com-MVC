using praticando_CRUD_com_MVC.Controller;
using praticando_CRUD_com_MVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praticando_CRUD_com_MVC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listContato.View = View.Details;
            listContato.LabelEdit = true;
            listContato.AllowColumnReorder = true;
            listContato.FullRowSelect = true;
            listContato.GridLines = true;

            listContato.Columns.Add("Id", 30, HorizontalAlignment.Left);
            listContato.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            listContato.Columns.Add("Email", 150, HorizontalAlignment.Left);
            listContato.Columns.Add("Telefone", 150, HorizontalAlignment.Left);


            var contatoController = new ContatoController();
            contatoController.ReadContato(listContato);
        }
        ContatoController contatoController = new ContatoController();

        private void Salvar_Click(object sender, EventArgs e)
        {
            var contatoPessoa = new ContatoModel(txtNome.Text, txtEmail.Text, txtTelefone.Text);
            contatoController.CreateContato(contatoPessoa);

            contatoController.ReadContato(listContato);
        }

        private void Excluir_Click(object sender, EventArgs e)
        {
            var contatoPessoa = new ContatoModel();
            contatoController.DeleteContato();

            contatoController.ReadContato(listContato);
        }

        private void Atualizar_Click(object sender, EventArgs e)
        {
            var contatoPessoa = new ContatoModel(txtNome.Text, txtEmail.Text, txtTelefone.Text);
            contatoController.UpdateContato(contatoPessoa);

            contatoController.ReadContato(listContato);
        }

        private void listContato_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            var contatoPessoa = new ContatoModel();
            contatoController.MostrarItemsSelecionados(listContato, contatoPessoa);

            txtNome.Text = contatoPessoa.nome;
            txtEmail.Text = contatoPessoa.email;
            txtTelefone.Text = contatoPessoa.telefone;
        }
    }
}
