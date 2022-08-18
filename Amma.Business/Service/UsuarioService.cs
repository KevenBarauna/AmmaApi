using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amma.Business.Service.Interfaces;
using Amma.Business.Validations.Usuario;
using Amma.Core.Domain.Entities;
using Amma.Core.Domain.Error;
using Amma.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Amma.Business.Service
{
    public class UsuarioService: IUsuarioService
    {
        private readonly ILogger<UsuarioService> _logger;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogger<UsuarioService> logger)
        {
            _logger = logger;
            _usuarioRepository = usuarioRepository;
        }

        private void EscreverLog(string nomeFuncao, Usuario? usuario)
        {
            _logger.LogInformation($"### UsuarioService - ${nomeFuncao} - {usuario?.Id} - {usuario?.Nome} - {usuario?.Email} - {usuario?.Senha} - {usuario?.Cargo} - {usuario?.IdPermissao} - {usuario?.CodAvatar}");
        }

        private void EscreverErro(string nomeFuncao, string mensagem)
        {
            _logger.LogError($"### UsuarioService - ${nomeFuncao} - {mensagem}");
        }

        public Usuario CreateUsuario(Usuario usuario)
        {
            EscreverLog("CreateUsuario", usuario);
            UsuarioValidation validator = new UsuarioValidation();
            var result = validator.Validate(usuario);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    EscreverErro($"CreateUsuario", $"Quantidade de erros na validação");
                    throw new Exception("Deu erro");
                }
            }

            return _usuarioRepository.Create(usuario);
        }

        public Usuario EditarUsuario(Usuario usuario)
        {
            EscreverLog("EditarUsuario", usuario);
            UsuarioValidation validator = new UsuarioValidation();
            var result = validator.Validate(usuario);
            if (!result.IsValid)
            {
                foreach (var failure in result.Errors)
                {
                    Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                    EscreverErro($"CreateUsuario", $"Quantidade de erros na validação");
                    throw new Exception("Deu erro");
                }
            }
            return _usuarioRepository.Update(usuario);
        }

        public Usuario GetUsuario(int idUsuario)
        {
            EscreverLog("GetUsuario", null);
            return _usuarioRepository.GetById(idUsuario);
        }

        public Usuario GetUsuarioByLogin(string usuarioNome, string usuarioSenha)
        {
            EscreverLog("GetUsuarioByLogin", null);
            return _usuarioRepository.GetByNomeSenha(usuarioNome, usuarioSenha);
        }

        public List<Usuario> GetAllUsuarios()
        {
            EscreverLog("GetAllUsuarios", null);
            var usuarios = _usuarioRepository.FindAll();
            return usuarios.Include(x => x.permissao).ToList();
        }

        public Usuario DeletarUsuario(int idUsuario)
        {
            EscreverLog("DeletarUsuario", null);
            Usuario usuario = GetUsuario(idUsuario);
            return _usuarioRepository.Delete(usuario);
        }
    }
}