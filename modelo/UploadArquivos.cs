namespace Selection_Register.modelo
{
    public class UploadArquivos
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public byte[] Dados { get; set; }
        public string  ContentType { get; set; }
    }
}