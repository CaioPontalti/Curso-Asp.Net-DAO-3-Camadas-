using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaFinanceiro.Controllers
{
    public class ClienteController : Controller
    {
        ClienteNeg objClienteNeg;

        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();
        }

        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> lstClientes = objClienteNeg.findAll();
            return View(lstClientes);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            MensagemInicioRegistrar();
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            cliente.Estado = 0;
            MensagemInicioRegistrar();
            objClienteNeg.create(cliente);
            MensagemErroRegistrar(cliente);
            ModelState.Clear();

            if (cliente.Estado == 99)
                return View();
            else
                return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //mensagem de erro
        public void MensagemErroRegistrar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {

                case 1000://campo cpf com letras
                    ViewBag.MensagemErro = "Erro CPF, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Cliente";
                    break;
                    

                case 60://endereco vazio
                    ViewBag.MensagemErro = "O Endereço do Cliente é obrigatório!";
                    break;

                case 6://erro no endereço
                    ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;


                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Cliente [ " + objCliente.IdCliente + " ] já está registrado no sistema";
                    break;

                case 9://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF [ " + objCliente.CPF + " ] já está registrado no sistema";
                    break;

                case 999://Cliente Salvo com Sucesso
                    ViewBag.MensagemErro = "Erro ao executar o comando no Banco de Dados";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Cliente [ " + objCliente.Nome + " " + " ] foi inserido no sistema";
                    break;
            }

        }

        public void MensagemInicioRegistrar()
        {
            ViewBag.MensagemInicio = "Insira os dados do Cliente e clique em salvar";
        }

        [HttpGet]
        public ActionResult Update(long id)
        {
            mensagemInicialAtualizar();
            Cliente objCliente = new Cliente() { IdCliente = id};
            if (!objClienteNeg.find(objCliente))
            {
                return View(HttpNotFound());
            }
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Update(Cliente objCliente)
        {
            mensagemInicialAtualizar();
            objClienteNeg.update(objCliente);
            MensagemErroAtualizar(objCliente);
            return View();
            //return Redirect("~/Cliente/Index/");
        }

        //Mensagem erro ao atualizar
        public void MensagemErroAtualizar(Cliente objCliente)
        {
            switch (objCliente.Estado)
            {

                case 1000://campo cpf com letras
                    ViewBag.MensagemErro = "Erro CPF, não insira Letras";
                    break;

                case 20://campo nome vazio
                    ViewBag.MensagemErro = "Insira Nome do Cliente";
                    break;

                case 2://erro de nome
                    ViewBag.MensagemErro = "O nome não pode ter mais de 30 caracteres";
                    break;


                case 50://campo cpf vazio
                    ViewBag.MensagemErro = "Insira CPF do Cliente";
                    break;


                case 60://endereco vazio
                    ViewBag.MensagemErro = "O Endereço do Cliente é obrigatório!";
                    break;

                case 6://erro no endereço
                    ViewBag.MensagemErro = "Campo endereço não pode ter mais de 50 caracteres";
                    break;

                case 70://campo telefone vazio
                    ViewBag.MensagemErro = "Insira o telefone do cliente";
                    break;


                case 8://erro de duplicidade
                    ViewBag.MensagemErro = "Cliente [ " + objCliente.IdCliente + " ] já está registrado no sistema";
                    break;

                case 201://erro de duplicidade
                    ViewBag.MensagemErro = "Numero de CPF [ " + objCliente.CPF + " ] já está registrado no sistema";
                    break;

                case 999://Cliente Salvo com Sucesso
                    ViewBag.MensagemErro = "Erro ao executar o comando no Banco de Dados";
                    break;

                case 99://Cliente Salvo com Sucesso
                    ViewBag.MensagemExito = "Cliente [ " + objCliente.Nome + " " + " ] foi atualizado no sistema";
                    break;
            }

        }
        //mensagem Inicial Atualizar
        public void mensagemInicialAtualizar()
        {
            ViewBag.MensagemInicialAtualizar = "Formulario para Atualizar Dados do Cliente";
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }

        [HttpDelete, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.delete(objCliente);
            mostrarMensagemEliminar(objCliente);
            return Redirect("~/Cliente/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(long id)
        {
            mensagemInicialEliminar();
            Cliente objCliente = new Cliente() { IdCliente = id};
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente objCliente)
        {
            mensagemInicialEliminar();
            objClienteNeg.delete(objCliente);
            mostrarMensagemEliminar(objCliente);
            Cliente objCLiente2 = new Cliente();
            return View(objCLiente2);
            //return RedirectToAction("Index");
        }

        //mensagem de erro ao excluir
        private void mostrarMensagemEliminar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                case 1: //ERRO DE EXISTENCIA
                    ViewBag.MensagemErro = "Cliente [" + objCliente.IdCliente + "] Não está registrado no sistema ";
                    break;

                case 33://CLIENTE NAO EXISTE
                    ViewBag.MensagemErro = "Cliente: [" + objCliente.Nome + " ]já foi excluido";
                    break;
                case 34:
                    ViewBag.MensagemErro = "Não se pode apagar o Cliente [" + objCliente.Nome + "] Tem vendas relacionadas ao cliente!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensagemExito = "Cliente [" + objCliente.Nome + "] Foi Excluido!!!";
                    break;

                default:
                    ViewBag.MensagemErro = "===Deu Erro ???===";
                    break;
            }
        }
        public void mensagemInicialEliminar()
        {
            ViewBag.MensagemInicialEliminar = "Formulario de Exclusão";
        }

        public ActionResult Find(long id)
        {
            Cliente objCliente = new Cliente() { IdCliente = id};
            objClienteNeg.find(objCliente);

            return View(objCliente);
        }

        [HttpGet]
        public ActionResult BuscarClientes()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }
        [HttpPost]
        public ActionResult BuscarClientes(string txtnome, string txtcpf, long txtcliente = 0)
        {
            Cliente objCliente = new Cliente() { Nome = txtnome, CPF = txtcpf, IdCliente = txtcliente};

            List<Cliente> cliente = objClienteNeg.findAll();

            if (txtnome != "")
                return View(cliente.Where(c => c.Nome.Contains(txtnome)).ToList());
            else if (txtcpf != "")
                return View(cliente.Where(c => c.CPF.Contains(txtcpf)).ToList());
            else if (txtcliente != 0)
                return View(cliente.Where(c => c.IdCliente.Equals(txtcliente)).ToList());
            else
                return View(cliente.ToList());
        }
    }
}