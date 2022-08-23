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
            _logger.LogInformation($"### UsuarioService - ${nomeFuncao} - {usuario?.Id} - {usuario?.Nome} - {usuario?.Email} - {usuario?.IdCargo} - {usuario?.IdPermissao} - {usuario?.CodAvatar}");
        }

        private void EscreverLogErro(string nomeFuncao, string mensagem)
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
                    string mensagemErro = $"Propriedade: {failure.PropertyName} não é válido(a), Erro: {failure.ErrorMessage}";
                    EscreverLogErro("CreateUsuario", mensagemErro);
                    throw new Exception(mensagemErro);
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
                    string mensagemErro = $"Propriedade: {failure.PropertyName} não é válido(a), Erro: {failure.ErrorMessage}";
                    EscreverLogErro("EditarUsuario", mensagemErro);
                    throw new Exception(mensagemErro);
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
            return _usuarioRepository.FindAll().ToList();
        }

        public Usuario DeletarUsuario(int idUsuario)
        {
            EscreverLog("DeletarUsuario", null);
            Usuario usuario = GetUsuario(idUsuario);
            return _usuarioRepository.Delete(usuario);
        }
    }
}