using ControleContatos.Models;
using ControleContatos.Repositório;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {

        private readonly IContatoRepositório _contatoRepositorio;

        public ContatoController(IContatoRepositório contatorRepositório)
        {
            _contatoRepositorio = contatorRepositório;
        }


        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar( int id)
        {
           ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }


        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);

                if(apagado)
                {
                    TempData["MensagemSucesso"] = "Contato deletado";
                }
                else
                {
                    TempData["MensagemErro"] = $"Procedimento não foi concluído.";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Procedimento não foi concluído. Mais informações: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }

            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Procedimento não foi concluído. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato editado.";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível editar o contato. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
     
    }
}
