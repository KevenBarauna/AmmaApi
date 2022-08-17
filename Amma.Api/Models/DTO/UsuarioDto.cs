namespace Amma.Api.Models.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }     
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int CodAvatar { get; set; }
        public int Idpermissao { get; set; }
    }

    public class UsuarioCadastrarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Cargo { get; set; }
        public int CodAvatar { get; set; }
        public int Idpermissao { get; set; }
    }
}