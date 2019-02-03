using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Apis.Drive.v3;
using GoodHealth.Model.Dto;

namespace GoodHealth.Util
{
    public class GoogleDrive
    {
        private UserCredential Credential { get; set; }
        private DriveService DriveService { get; set; }

        public GoogleDrive()
        {
            Credential = Autenticar();
            DriveService = AbrirServico(Credential);
        }
        private static UserCredential Autenticar()
        {
            UserCredential credenciais;
            var diretorioAtual = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var diretorioCredenciais = Path.Combine(diretorioAtual, "credential");
           
            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credenciais = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile },
                    "user",
                    System.Threading.CancellationToken.None,
                    new Google.Apis.Util.Store.FileDataStore(diretorioCredenciais, true)).Result;
            }

            return credenciais;
        }

        private static UserCredential Autenticar(bool changeScope = false)
        {
            string scope = DriveService.Scope.DriveReadonly;
            UserCredential credenciais;
            var diretorioAtual = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var diretorioCredenciais = Path.Combine(diretorioAtual, "credential");
            if (changeScope)
            {
                DirectoryInfo dir = new DirectoryInfo(diretorioCredenciais);
                FileInfo[] files = dir.GetFiles();
                if (files.Any())
                {
                    foreach (var item in files)
                        item.Delete();

                    scope = DriveService.Scope.Drive;
                }
            }

            using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                credenciais = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { scope },
                    "user",
                    System.Threading.CancellationToken.None,
                    new Google.Apis.Util.Store.FileDataStore(diretorioCredenciais, true)).Result;
            }

            return credenciais;
        }

        private static DriveService AbrirServico(UserCredential credenciais)
        {
            return new DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais
            });
        }
        public string[] ProcurarArquivoId(string nome, bool procurarNaLixeira = false)
        {
            var retorno = new List<string>();

            var request = DriveService.Files.List();
            request.Q = string.Format("name = '{0}'", nome);
            if (!procurarNaLixeira)
                request.Q += " and trashed = false";

            request.Fields = "files(id)";
            var resultado = request.Execute();
            var arquivos = resultado.Files;

            if (arquivos != null && arquivos.Any())
            {
                foreach (var arquivo in arquivos)
                    retorno.Add(arquivo.Id);
            }

            return retorno.ToArray();
        }

        public List<Google.Apis.Drive.v3.Data.File> ListarArquivos()
        {
            var request = DriveService.Files.List();
            request.Fields = "files(id, name)";
            request.Q = "trashed=false";
            var resultado = request.Execute();
            var arquivos = resultado.Files;

            return arquivos.ToList();
        }
        public void Upload(string caminhoArquivo)
        {
            var arquivo = new Google.Apis.Drive.v3.Data.File();
            arquivo.Name = Path.GetFileName(caminhoArquivo);
            arquivo.MimeType = MimeTypes.MimeTypeMap.GetMimeType(Path.GetExtension(caminhoArquivo));
            arquivo.Parents = new List<string>() { "1fVxBD7-pDLU5778bBlB6ExSEZpQ8yPQe" } ;
            //  id=1fVxBD7-pDLU5778bBlB6ExSEZpQ8yPQe
            using (var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read))
            {
                var ids = ProcurarArquivoId(arquivo.Name);
                Google.Apis.Upload.ResumableUpload<Google.Apis.Drive.v3.Data.File, Google.Apis.Drive.v3.Data.File> request;

                if (ids == null || !ids.Any())
                    request = DriveService.Files.Create(arquivo, stream, arquivo.MimeType);
                else
                    request = DriveService.Files.Update(arquivo, ids.First(), stream, arquivo.MimeType);

                request.Upload();
            }
        }
    }
}
