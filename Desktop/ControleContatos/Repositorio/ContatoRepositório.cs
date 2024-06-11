using ControleContatos.Data;
using ControleContatos.Models;

namespace ControleContatos.Repositório
{
    public class ContatoRepositório(BancoContext bancoContext) : IContatoRepositório
    {

        private readonly BancoContext _bancoContext = bancoContext;


        public ContatoModel ListarPorId(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);    
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }


        public ContatoModel Adicionar(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }


        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Ops! Erro ao atualizar um contato.");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);

            if (contatoDB == null) throw new System.Exception("Ops! Erro ao deletar o contato.");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            
            return true;
             
        }
    }
}
