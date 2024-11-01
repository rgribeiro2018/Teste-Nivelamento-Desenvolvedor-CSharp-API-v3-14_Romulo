namespace Questao5.InfraCrossCutting.Middleware
{
    public class CustomResponse
    {
        private const string MensagemSucesso = "Executado com sucesso";

        public CustomResponse()
        {
            messages = new();
        }
        public CustomResponse(dynamic data)
        {
            messages = new();
            messages.Add(MensagemSucesso);
            success = false;
        }

        public CustomResponse(List<string> messages, bool success)
        {
            this.messages = messages;
            this.success = success;
        }

        public List<string> messages { get; private set; }
        public bool success { get; private set; }
    }
}
