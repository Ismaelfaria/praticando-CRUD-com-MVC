using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace praticando_CRUD_com_MVC.Model
{
    public class ContatoModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public int id { get; set; }

        public ContatoModel(string nome, string email, string telefone)
        {
            this.nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.email = email ?? throw new ArgumentNullException(nameof(email));
            this.telefone = telefone ?? throw new ArgumentNullException(nameof(telefone));
        }

        public ContatoModel()
        {
        }

        public ContatoModel(string nome, string email, string telefone, int id) : this(nome, email, telefone)
        {
            this.id = id;
        }

        public ContatoModel(int id)
        {
            this.id = id;
        }

    }
}
