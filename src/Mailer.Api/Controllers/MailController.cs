using System;
using System.Threading.Tasks;
using Mailer.Api.ViewModels;
using Mailer.Data.Entities;
using Mailer.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mailer.Api.Controllers
{
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("/api/v1/mail/add")]
        public async Task<IActionResult> Add([FromBody]MailViewModel mailViewModel)
        {
            try
            {
                var mail = new Mail(mailViewModel.Email, mailViewModel.Subject, mailViewModel.Body);
                
                await _mailService.Sent(mail);

                return Ok(new ResultViewModel
                {
                    Message = "Email enviado com sucesso.",
                    Success = true,
                    Data = mail
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = "Ocorreu algum erro interno na aplicação",
                    Success = false,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("/api/v1/mail/get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(new ResultViewModel
                {
                    Message = "Emails encontrados com sucesso.",
                    Success = true,
                    Data = await _mailService.Get()
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = "Ocorreu algum erro interno na aplicação",
                    Success = false,
                    Data = null
                });
            }
        }


        [HttpGet]
        [Route("/api/v1/mail/get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(new ResultViewModel
                {
                    Message = "Email encontrado com sucesso.",
                    Success = true,
                    Data = await _mailService.Get(id)
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = "Ocorreu algum erro interno na aplicação",
                    Success = false,
                    Data = null
                });
            }
        }

        [HttpGet]
        [Route("/api/v1/mail/get-sents")]
        public async Task<IActionResult> GetSents()
        {
            try
            {
                return Ok(new ResultViewModel
                {
                    Message = "Email encontrado com sucesso.",
                    Success = true,
                    Data = await _mailService.GetSents()
                });
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel
                {
                    Message = "Ocorreu algum erro interno na aplicação",
                    Success = false,
                    Data = null
                });
            }
        }
    }
}
