using BRD_API_REGRAS.Services.Interfaces;
using Microsoft.Win32;
using Swashbuckle.Swagger;
using System.Drawing;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;

namespace BRD_API_REGRAS.Services
{
    public class LayoutFpg240Service : ILayoutFpg240Service
    {
        #region CONSTANTES
        // FPG240
        const string registroFpg240Tipo0 = "REGISTRO_TIPO_0"; // Header de arquivo
        const string registroFpg240Tipo9 = "REGISTRO_TIPO_9"; // Trailer de arquivo
        const string registroFpg240Tipo1 = "REGISTRO_TIPO_1"; // Header de lote
        const string registroFpg240Tipo3A = "REGISTRO_TIPO_3A"; // Detalhe
        const string registroFpg240Tipo3B = "REGISTRO_TIPO_3B"; // Detalhe
        const string registroFpg240Tipo3C = "REGISTRO_TIPO_3C"; // Detalhe
        const string registroFpg240Tipo5 = "REGISTRO_TIPO_5"; // Trailer de arquivo
        #endregion
        public dynamic MontarJsonFpg240(dynamic dynamicList, string codigoArquivo) // MULTIPAG 240
        {
            #region LEGENDAS
            //------------------------------------------------------------------------------
            // : Posição inicial
            // : Tamanho
            // : Tipo A = ALFANUMÉRICO / N = NUMÉRICO
            // : Obrigatório (R = REQUERIDO / V = VAZIO / Z = ZERADO)
            // : Parentesco (0 = PAI / 1 = FILHO)
            // : Posição no manual do bradesco
            // : Valor fixo
            // : Mensagem própria
            // : Campo Data (D)
            // : Lista de opções do campo
            //------------------------------------------------------------------------------
            #endregion

            // SEGMENTOS : A , B, C , 5 , Z

            #region OBJETOS
            dynamic cdObject0 = new ExpandoObject(); // Header de arquivo
            dynamic cdObject9 = new ExpandoObject(); // Trailer de arquivo

            dynamic cdObject1 = new ExpandoObject(); // Header de lote
            dynamic cdObject5 = new ExpandoObject(); // Trailer de lote

            dynamic cdObjectSegmentoA = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoB = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoC = new ExpandoObject(); //  Tipo 3

            #endregion

            #region HEADER ARQUIVO
            // Header de Arquivo (Registro Tipo 0) - Versão Corrigida
            cdObject0.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject0.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject0.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject0.CNAB1 = "9:009:A:R:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.TipoInscrição = "18:001:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject0.NúmeroInscrição = "19:014:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObject0.Convênio = "33:020:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObject0.Agência = "53:005:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObject0.AgênciaDV = "58:001:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObject0.Conta = "59:012:N:R:0:59-70::Erro - Número de Conta Corrente::G010";
            cdObject0.ContaDV = "71:001:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObject0.AgContaDV = "72:001:A:R:0:72-72::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject0.NomeEmpresa = "73:030:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObject0.NomeBanco = "103:030:A:R:0:103-132::Erro - Nome do Banco::G014";
            cdObject0.CNAB2 = "133:010:A:R:0:133-142::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.CódigoRemessa = "143:001:N:R:0:143-143::Erro - Código Remessa/Retorno::G015";
            cdObject0.DataGeração = "144:008:N:R:0:144-151::Erro - Data de Geração do Arquivo:D:G016";
            cdObject0.HoraGeração = "152:006:N:R:0:152-157::Erro - Hora de Geração do Arquivo::G017";
            cdObject0.NúmeroSequencial = "158:006:N:R:0:158-163::Erro - Número Sequencial do Arquivo::G018";
            cdObject0.VersãoLayout = "164:003:N:R:0:164-166::Erro - Nº da Versão do Layout do Arquivo::G019";
            cdObject0.Densidade = "167:005:N:R:0:167-171::Erro - Densidade de Gravação do Arquivo::G020";
            cdObject0.ReservadoBanco = "172:020:A:R:0:172-191::Erro - Para Uso Reservado do Banco::G021";
            cdObject0.ReservadoEmpresa = "192:020:A:R:0:192-211::Erro - Para Uso Reservado da Empresa::G022";
            cdObject0.CNAB_Final = "212:029:A:R:0:212-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";

            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo0, cdObject0);
            #endregion

            #region TRAILER ARQUIVO
            cdObject9.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject9.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject9.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject9.CNAB1 = "9:009:A:R:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject9.QtdeLotes = "18:006:N:R:0:18-23::Erro - Quantidade de Lotes do Arquivo::G049";
            cdObject9.QtdeRegistros = "24:006:N:R:0:24-29::Erro - Quantidade de Registros do Arquivo::G056";
            cdObject9.QtdeContasConcil = "30:006:N:R:0:30-35::Erro - Qtde de Contas p/ Conc. (Lotes)::G037";
            cdObject9.CNAB2 = "36:205:A:R:0:36-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo9, cdObject9);
            #endregion

            #region HEADER LOTE
            cdObject1.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject1.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject1.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject1.TipoOperação = "9:001:A:R:0:9-9::Erro - Tipo da Operação::G028";
            cdObject1.TipoServiço = "10:002:N:R:0:10-11::Erro - Tipo do Serviço::G025";
            cdObject1.FormaLancamento = "12:002:N:R:0:12-13::Erro - Forma de Lançamento::G029";
            cdObject1.VersãoLayout = "14:003:N:R:0:14-16::Erro - Nº da Versão do Layout do Lote::G030";
            cdObject1.CNAB1 = "17:001:A:R:0:17-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.TipoInscrição = "18:001:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject1.NúmeroInscrição = "19:014:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObject1.Convênio = "33:020:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObject1.Agência = "53:005:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObject1.Conta = "59:012:N:R:0:59-70::Erro - Número da Conta Corrente::G010";
            cdObject1.ContaDV = "71:001:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObject1.AgContaDV = "72:001:A:R:0:72-72::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject1.NomeEmpresa = "73:030:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObject1.Mensagem = "103:040:A:R:0:103-142::Erro - Mensagem::G031";
            cdObject1.Logradouro = "143:030:A:R:0:143-172::Erro - Nome da Rua, Av. Pça, Etc::G032";
            cdObject1.NúmeroEndereço = "173:005:N:R:0:173-177::Erro - Número do Local::G032";
            cdObject1.Complemento = "178:015:A:R:0:178-192::Erro - Casa, Apto, Sala, Etc::G032";
            cdObject1.Cidade = "193:020:A:R:0:193-212::Erro - Nome da Cidade::G033";
            cdObject1.CEP = "213:005:N:R:0:213-217::Erro - CEP::G034";
            cdObject1.ComplementoCEP = "218:003:A:R:0:218-220::Erro - Complemento do CEP::G035";
            cdObject1.Estado = "221:002:A:R:0:221-222::Erro - Sigla do Estado::G036";
            cdObject1.CNAB2 = "223:008:A:R:0:223-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.Ocorrências = "231:010:A:R:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo1, cdObject1);
            #endregion

            #region TRAILER DE LOTE

            cdObject5.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject5.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject5.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject5.CNAB1 = "9:009:A:R:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject5.QtdeRegistros = "18:006:N:R:0:18-23::Erro - Quantidade de Registros do Lote::G057";
            cdObject5.ValorTotal = "24:018:N:R:0:24-41::Erro - Somatória dos Valores::P007"; // 16+2 decimais
            cdObject5.QtdeMoeda = "42:018:N:R:0:42-59::Erro - Somatória de Quantidade de Moedas::G058"; // 13+5 decimais
            cdObject5.NúmeroAvisoDébito = "60:006:N:R:0:60-65::Erro - Número Aviso de Débito::G066";
            cdObject5.CNAB2 = "66:165:A:R:0:66-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject5.Ocorrências = "231:010:A:R:0:231-240::Erro - Códigos das Ocorrências para Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo5, cdObject5);
            #endregion

            #region SEGMENTO A 

            cdObjectSegmentoA.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoA.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoA.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObjectSegmentoA.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoA.Segmento = "14:001:A:R:0:14-14::Erro - Código de Segmento do Reg. Detalhe::G039";
            cdObjectSegmentoA.TipoMovimento = "15:001:N:R:0:15-15::Erro - Tipo de Movimento::G060";
            cdObjectSegmentoA.CódigoInstrução = "16:002:N:R:0:16-17::Erro - Código da Instrução p/ Movimento::G061";
            cdObjectSegmentoA.CâmaraCentralizadora = "18:003:N:R:0:18-20::Erro - Código da Câmara Centralizadora::P001";
            cdObjectSegmentoA.BancoFavorecido = "21:003:N:R:0:21-23::Erro - Código do Banco do Favorecido::P002";
            cdObjectSegmentoA.AgênciaFavorecido = "24:005:N:R:0:24-28::Erro - Ag. Mantenedora da Cta do Favor.::G008";
            cdObjectSegmentoA.AgênciaFavorecidoDV = "29:001:A:R:0:29-29::Erro - Dígito Verificador da Agência::G009";
            cdObjectSegmentoA.ContaFavorecido = "30:012:N:R:0:30-41::Erro - Número da Conta Corrente::G010";
            cdObjectSegmentoA.ContaFavorecidoDV = "42:001:A:R:0:42-42::Erro - Dígito Verificador da Conta::G011";
            cdObjectSegmentoA.AgContaFavorecidoDV = "43:001:A:R:0:43-43::Erro - Dígito Verificador da AG/Conta::G012";
            cdObjectSegmentoA.NomeFavorecido = "44:030:A:R:0:44-73::Erro - Nome do Favorecido::G013";
            cdObjectSegmentoA.SeuNúmero = "74:020:A:R:0:74-93::Erro - Nº do Documento::G084";
            cdObjectSegmentoA.DataPagamento = "94:008:N:R:0:94-101::Erro - Data do Pagamento:D:P009";
            cdObjectSegmentoA.TipoMoeda = "102:003:A:R:0:102-104::Erro - Tipo da Moeda::G040";
            cdObjectSegmentoA.QuantidadeMoeda = "105:015:N:R:0:105-119::Erro - Quantidade da Moeda::G041"; // 10+5 decimais
            cdObjectSegmentoA.ValorPagamento = "120:015:N:R:0:120-134::Erro - Valor do Pagamento::P010"; // 13+2 decimais
            cdObjectSegmentoA.NossoNúmero = "135:020:A:R:0:135-154::Erro - Nº do Documento::G043";
            cdObjectSegmentoA.DataRealPagamento = "155:008:N:R:0:155-162::Erro - Data Real da Efetivação Págio:D:P003";
            cdObjectSegmentoA.ValorRealPagamento = "163:015:N:R:0:163-177::Erro - Valor Real da Efetivação do Págio::P004"; // 13+2 decimais
            cdObjectSegmentoA.InformaçõesAdicionais = "178:040:A:R:0:178-217::Erro - Outras Informações::G031";
            cdObjectSegmentoA.CódigoFinalidadeDoc = "218:002:A:R:0:218-219::Erro - Compl. Tipo Serviço::P005";
            cdObjectSegmentoA.CódigoFinalidadeTED = "220:005:A:R:0:220-224::Erro - Código finalidade da TED::P011";
            cdObjectSegmentoA.CNAB = "225:005:A:R:0:225-229::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectSegmentoA.AvisoFavorecido = "230:001:N:R:0:230-230::Erro - Aviso ao Favorecido::P006";
            cdObjectSegmentoA.Ocorrências = "231:010:A:R:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo3A, cdObjectSegmentoA);
            #endregion

            #region SEGMENTO B 
            
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo3B, cdObjectSegmentoB);
            #endregion

            #region SEGMENTO C 
            
            JsonObjectsGenerator.AddProperty(dynamicList, registroFpg240Tipo3C, cdObjectSegmentoC);
            #endregion

            return dynamicList;

        }
    }
}