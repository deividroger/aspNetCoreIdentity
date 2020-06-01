using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Extensions;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]

    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("ERRO");
         
            return View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Secret()
        {
            return View();
        }

        [Authorize(Policy =  "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos","Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();
            
            modelError.ErroCode = id;

            if (id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte.";
                modelError.Titulo = "Ocorreu um erro!";
            }
            if (id == 404)
            {
                modelError.Mensagem = "A página que você estava procurando não existe <br/> Em caso de dúvidas entre em contato com o nosso suporte.";
                modelError.Titulo = "Ops! Página não encontrada.";
            
            }
            if (id == 403)
            {
                modelError.Mensagem = "Você não tem permissão para fazer isso.";
                modelError.Titulo = "Acesso negado";
            }

            return View("Error", modelError);
        }
    }
}
