namespace Amma.Core.Domain.Error
{
    public class ErrorField
    {

        public ErrorField()
        {

        }

        public ErrorField(string campoNome, string descricao)
        {
            this.Descricao = descricao;
            this.CampoNome = campoNome;
        }

        public string Descricao { get; set; }
        public string CampoNome { get; set; }

    }
}
