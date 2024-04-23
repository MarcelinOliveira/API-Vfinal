namespace WebApplication1.Helpers
{
    public class SalvaImagem        
    {
        public string pathimagenss { get; set; }
        public SalvaImagem(string pathimagens)
        {
            try
            {
                pathimagenss = pathimagens;
                // Certifique-se de que o diretório de saída existe, ou crie-o se não existir
                if (!Directory.Exists(pathimagens))
                {
                    Directory.CreateDirectory(pathimagens);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao salvar a imagem: " + ex.Message);
            }
        }

        public void SalvarImagem(byte[] imagebytes)
        {
            string filename = "Capim_Amargoso" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";

            // Combine o diretório de saída com o nome do arquivo para obter o caminho completo
            string filePath = Path.Combine(pathimagenss, filename);

            // Escreva os bytes no arquivo
            File.WriteAllBytes(filePath, imagebytes);

            Console.WriteLine("Imagem salva com sucesso em: " + filePath);
        }
    }
}
