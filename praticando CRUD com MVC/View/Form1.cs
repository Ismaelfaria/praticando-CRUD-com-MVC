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
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            var contatoPessoa = new ContatoView(txtNome.Text, txtEmail.Text, txtTelefone.Text);
            var contatoController = new ContatoController();
            contatoController.AdicionarContato(contatoPessoa);
        }
    }
}
