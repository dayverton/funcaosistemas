using FI.AtividadeEntrevista.BLL;
using FI.AtividadeEntrevista.DML;
using FI.WebAtividadeEntrevista.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAtividadeEntrevista.Models;

namespace FI.WebAtividadeEntrevista.Controllers
{
    public class BeneficiarioController : Controller
    {

        [HttpPost]
        public JsonResult Incluir(BeneficiarioModel model)
        {
            try
            {
                BoBeneficiario bo = new BoBeneficiario();

                if (!this.ModelState.IsValid)
                {
                    List<string> erros = (from item in ModelState.Values
                                          from error in item.Errors
                                          select error.ErrorMessage).ToList();

                    Response.StatusCode = 400;
                    return Json(string.Join(Environment.NewLine, erros));
                }
                else
                {

                    model.Id = bo.Incluir(new Beneficiario()
                    {
                        Nome = model.Nome,
                        CPF = model.CPF,
                        IdCliente = model.IdCliente
                    });

                    if (model.Id == 0)
                    {
                        Response.StatusCode = 400;
                        return Json("CPF " + model.CPF + " já cadastrado para o cliente");
                    }
                }

                return Json("Cadastro efetuado com sucesso");

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json("Erro ao incluir registro " + ex.Message);
            }
        }

        [HttpPost]
        public JsonResult Alterar(BeneficiarioModel model)
        {
            try
            {
                String CPF = model.CPF;
                String Nome = model.Nome;
                long IdCliente = model.IdCliente;

                BoBeneficiario bo = new BoBeneficiario();

                if (!this.ModelState.IsValid)
                {
                    List<string> erros = (from item in ModelState.Values
                                          from error in item.Errors
                                          select error.ErrorMessage).ToList();

                    Response.StatusCode = 400;
                    return Json(string.Join(Environment.NewLine, erros));
                }
                else
                {

                    bool alterado = bo.Alterar(new Beneficiario()
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        CPF = model.CPF,
                        IdCliente = model.IdCliente
                    });

                    if (!alterado)
                    {
                        Response.StatusCode = 400;
                        return Json("CPF " + model.CPF + " já cadastrado para o cliente");
                    }

                    return Json("Cadastro alterado com sucesso");

                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json("Erro ao alterar registro " + ex.Message);
            }
        }


        [HttpPost]
        public JsonResult Listar(long IdCliente)
        {
            try
            {
                var beneficiarios = new BoBeneficiario().Listar(IdCliente);

                return Json(new { Result = "OK", Records = beneficiarios });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Excluir(long Id)
        {
            try
            {
                new BoBeneficiario().Excluir(Id);

                return Json("Cadastro excluído com sucesso");
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return Json("Erro ao excluir " + ex.Message);
            }
        }

    }
}