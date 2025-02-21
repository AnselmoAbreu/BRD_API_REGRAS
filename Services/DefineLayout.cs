using System.Dynamic;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class DefineLayout
    {
        #region Constantes
        const string registroZero = "RECORD0";
        const string registroUm = "RECORD1";
        const string registroDois = "RECORD2";
        const string registroTres = "RECORD3";
        const string registroSeis = "RECORD6";
        const string registroSete = "RECORD7";
        const string registroNove = "RECORD9";
        #endregion

        public string MontarJson(string codigoArquivo)
        {
            dynamic dynamicList = new ExpandoObject();

            if (codigoArquivo == "COB400")
            {
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroZero, new ExpandoObject());
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroUm, new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, registroDois, new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, registroTres, new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, registroSeis, new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, registroSete, new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, registroNove, new ExpandoObject());

                dynamic cdObject = new ExpandoObject();
                dynamic cdObject1 = new ExpandoObject();

                //-------------------------------------------------------
                // : Posição inicial
                // : Tamanho
                // : Tipo
                // : Conteúdo (R = REQUERIDO / V = VAZIO / Z = ZERADO)
                // : Nível (0 = PAI / 1 = FILHO)
                // : Posição no manual 
                // : Valor fixo
                // : Mensagem
                //-------------------------------------------------------

                cdObject.IdentificacaoRegistro = "0:1:N:R:0:001-001:0:Campo deve conter [0]";
                cdObject.IdentificacaoArquivoRemessa = "1:1:N:R:0:002-002:1:Campo deve conter [1]";
                cdObject.LiteralRemessa = "2:7:C:R:0:003-009:REMESSA:Campo deve conter [REMESSA]";
                cdObject.CodigoServico = "9:2:N:R:0:010-011:01:Campo deve conter [01]";
                cdObject.LiteralServico = "11:15:C:R:0:012-026:COBRANCA:Campo deve conter [COBRANCA]";
                cdObject.CodigoEmpresa = "26:20:N:R:0:027-046::Campo não pode ser igual a zero";
                cdObject.NomeEmpresa = "46:30:C:R:0:047-076::Campo não pode estar em branco";
                cdObject.NumeroBradescoCompensacao = "76:3:N:R:0:077-079:237:Campo deve conter [237]";
                cdObject.NomeBancoExtenso = "79:15:C:R:0:080-094:BRADESCO:Campo deve conter [BRADESCO]";
                cdObject.DataGravacaoArquivo = "94:6:N:R:0:095-100::Campo deve conter uma data válida";
                cdObject.Branco1 = "100:8:C:V:0:101-108::Campo deve estar em branco";
                cdObject.IdentificacaoSistema = "108:2:C:R:0:109-110:MX:Campo deve conter [MX]";
                cdObject.NumeroSequencialRemessa = "110:7:N:R:0:111-117::Campo deve conter um número";
                cdObject.Branco2 = "117:277:C:V:0:118-394::Campo deve estar em branco";
                cdObject.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número";

                JsonCdProdutoGenerator.AddProperty(dynamicList, registroZero, cdObject);

                // ========================================================================

                cdObject1.IdentificacaoRegistro = "0:1:N:R:0:001-001:1:Campo deve conter [1]";
                cdObject1.AgenciaDebito = "1:5:N:R:0:002-006::Campo não pode ser igual a zero";
                cdObject1.DigitoAgencia = "6:1:C:V:0:007-007::";
                cdObject1.RazaoContaCorrente = "7:5:N:Z:0:008-012::";
                cdObject1.ContaCorrente = "12:7:N:Z:0:013-019::";
                cdObject1.DigitoContaCorrente = "19:1:C:V:0:020-020::Erro genérico";
                cdObject1.IdEmpresaBeneficiariaBanco = "20:17:C:R:0:021-037::Campo não pode estar vazio";
                cdObject1.NumeroControlePaticipante = "37:25:C:R:0:038-062::Campo não pode estar vazio";
                cdObject1.CodigoBancoDebitadoCamaraCompensacao = "62:3:N:R:0:063-065:237:Campo deve conter [237]";
                cdObject1.CampoMulta = "65:1:N:R:0:066-066:0,2:Campo deve conter [0 ou 2]"; //<<<<<<<<<
                cdObject1.PercentualMulta = "66:4:N:R:1:067-070::Campo não pode estar vazio"; //<<<<<<<<<
                cdObject1.IdentificacaoTituloBanco = "70:11:N:R:0:071-081::Campo não deve ser preenchido com zeros"; //<<<<<<<<<
                cdObject1.DigitoAutoconferenciaNumeroBancario = "81:1:C:R:0:082-082::Campo não pode estar vazio"; //<<<<<<<<<
                cdObject1.DescontoBonificacaoDia = "82:10:N:Z:0:083-092::"; //<<<<<<<<<
                cdObject1.CondicaoEmissaoPapeletaCobranca = "92:1:N:R:0:093-093:0,1,2:Campo deve conter [0,1,2]";
                cdObject1.IdentEmiteBoletoDebitoAutomaticao = "93:1:C:R:0:094-094::";
                cdObject1.IdentificacaoOperacaoBanco = "94:10:C:V:0:095-104::Campo deve estar em branco"; //<<<<<<<<<
                cdObject1.IndicadorRateioCredito = "104:1:C:R:0:105-105:R:Campo deve conter [R]";
                cdObject1.EnderecamentoAvisoDebitoAutomaticoContaCorrente = "105:1:N:R:0:106-106::Campo não deve estar em branco";//<<<<<<<<<
                cdObject1.QuantidadePagamentos = "106:2:C:R:0:107-108::Campo não deve estar em branco";
                cdObject1.IdentificacaoOcorrencia = "108:2:N:R:0:109-110::Campo não deve ser preenchido com zeros";//<<<<<<<<<
                cdObject1.NumeroDocumento = "110:10:C:R:0:111-120::Campo não deve estar em branco";
                cdObject1.DataVencimentoTitulo = "120:6:N:R:0:121-126::Campo deve conter uma data válida";
                cdObject1.ValorTitulo = "126:13:N:R:0:127-139::Campo não pode ser igual a zero";//<<<<<<<<<
                cdObject1.BancoEncarregadoCobranca = "139:3:N:R:0:140-142:000:Campo deve conter [000]";
                cdObject1.AgenciaDepositaria = "142:5:N:R:0:143-147:00000:Erro genérico";
                cdObject1.EspecieTitulo = "147:2:N:R:0:148-149:01,02,03,05,10,11,12,31,32,33,99:Campo deve conter [01,02,03,05,10,11,12,31,32,33,99]";//<<<<<<<<<
                cdObject1.Identificacao = "149:1:C:R:0:150-150:N:Campo deve conter [N]";
                cdObject1.DataEmissaoTitulo = "150:6:N:R:0:151-156::Campo deve conter uma data válida";
                cdObject1.PrimeiraInstrucao = "156:2:N:R:0:157-158::Campo não deve estar em branco";//<<<<<<<<<
                cdObject1.SegundaInstrucao = "158:2:N:R:0:159-160::Campo não deve estar em branco";//<<<<<<<<<
                cdObject1.ValorCobradoDiaAtraso = "160:13:N:R:0:161-173::Campo não deve estar em branco";//<<<<<<<<<
                cdObject1.DataLimiteConcessaoDesconto = "173:6:N:R:0:174-179::Campo deve conter uma data válida";
                cdObject1.ValorDesconto = "179:13:N:R:0:180-192::Campo não deve estar em branco";
                cdObject1.ValorIof = "192:13:N:R:0:193-205::Campo não deve estar em branco";
                cdObject1.ValorAbatimentoConcedidoOuCancelado = "205:13:N:R:0:206-218::Campo não deve estar em branco";
                cdObject1.IdentificacaoTipoInscricaoPagador = "218:2:N:R:0:219-220:01,02:Campo deve conter [01,02]";//<<<<<<<<<
                cdObject1.NumeroInscricaoPagador = "220:14:N:R:0:221-234::Campo não deve estar em branco";
                cdObject1.NomeDoPagador = "234:40:C:R:0:235-274::Campo não deve estar em branco";
                cdObject1.EnderecoCompleto = "274:40:C:R:0:275-314::Campo não deve estar em branco";
                cdObject1.PrimeiraMensagem = "314:12:C:R:0:315-326::Campo não deve estar em branco";
                cdObject1.Cep = "326:5:N:R:0:327-331::Campo não deve estar em branco";
                cdObject1.SufixoCep = "331:3:N:R:0:332-334::Campo não deve estar em branco";
                cdObject1.BeneficiarioFinalSegundaMensagem = "334:60:C:R:0:335-394:DECOMPOSIÇÃO:Campo não deve estar em branco";//<<<<<<<<<
                cdObject1.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número";

                JsonCdProdutoGenerator.AddProperty(dynamicList, registroUm, cdObject1);

                // ========================================================================
            }

            // Serializando para JSON
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(dynamicList);

            // Retornando o JSON como resposta
            return jsonResult;
        }
    }
}