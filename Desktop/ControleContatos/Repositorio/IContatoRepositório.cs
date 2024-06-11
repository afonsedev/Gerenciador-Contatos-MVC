using ControleContatos.Models;

namespace ControleContatos.Repositório
{
    public interface IContatoRepositório
    {
        ContatoModel ListarPorId(int id);

        List<ContatoModel> BuscarTodos();

        ContatoModel Adicionar(ContatoModel contato);

        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);


    }
}
