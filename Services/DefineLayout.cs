using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class DefineLayout
    {
        public string MontarJson(string codigoArquivo)
        {
            dynamic dynamicList = new ExpandoObject();

            if (codigoArquivo == "COB400")
            {
                JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD0", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD1", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD2", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD3", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD6", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD7", new ExpandoObject());
                //JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD9", new ExpandoObject());

                dynamic cdObject = new ExpandoObject();
                dynamic cdObject1 = new ExpandoObject();

                //----------------------------------------
                // "0:1:N:0:U"
                //----------------------------------------
                //   Posição inicial
                // : Posição final
                // : Tipo
                // : Conteúdo (R = REQUERIDO / V = VAZIO)
                // : Nível (0 = PAI / 1 = FILHO)
                // : Posição no manual 
                //----------------------------------------

                cdObject.IdentificacaoRegistro = "0:1:N:R:0:001-001";        // linha.Substring(0, 1);
                cdObject.IdentificacaoArquivoRemessa = "1:1:N:1:0:002-002";  // linha.Substring(1, 1);
                cdObject.LiteralRemessa = "2:7:C:REMESSA:0:003-009";         // linha.Substring(2, 7);
                cdObject.CodigoServico = "9:2:N:01:0:010-011";               // linha.Substring(9, 2);
                cdObject.LiteralServico = "11:15:C:COBRANCA:0:012-026";      // linha.Substring(11, 15);
                cdObject.CodigoEmpresa = "26:20:N:R:0:027-046";              // linha.Substring(26, 20);
                cdObject.NomeEmpresa = "46:30:C:R:0:047-076";                // linha.Substring(46, 30);
                cdObject.NumeroBradescoCompensacao = "76:3:N:237:0:077-079"; // linha.Substring(76, 3);
                cdObject.NomeBancoExtenso = "79:15:C:Bradesco:0:080-094";    // linha.Substring(79, 15);
                cdObject.DataGravacaoArquivo = "94:6:N:190225:0:095-100";    // linha.Substring(94, 6);
                cdObject.Branco1 = "100:8:C:V:0:101-108";                    // linha.Substring(100, 8);
                cdObject.IdentificacaoSistema = "108:2:C:MX:0:109-110";      // linha.Substring(108, 2);
                cdObject.NumeroSequencialRemessa = "110:7:N:R:0:111-117";    // linha.Substring(110, 7);
                cdObject.Branco2 = "117:277:C:V:0:118-394";                  // linha.Substring(117, 277);
                cdObject.NumeroSequencialRegistro = "394:6:N:R:0:395-400";   // linha.Substring(394, 6);

                JsonCdProdutoGenerator.AddProperty(dynamicList, "RECORD0", cdObject);

                cdObject1.IdentificacaoRegistroTipo1 = "0:1:N:R:0:001-001"; //linha.Substring(0, 1);
                cdObject1.AgenciaDebito = //linha.Substring(1, 5);
                cdObject1.DigitoAgencia = //linha.Substring(6, 1);
                cdObject1.RazaoContaCorrente = //linha.Substring(7, 5);
                cdObject1.ContaCorrente = //linha.Substring(12, 7);
                cdObject1.DigitoContaCorrente = //linha.Substring(19, 1);
                cdObject1.IdEmpresaBeneficiariaNanco = //linha.Substring(20, 17);
                cdObject1.NumeroControlePaticipante = //linha.Substring(37, 25);
                cdObject1.CodigoBancoDebitadoCamaraCompensacao = //linha.Substring(62, 3);
                cdObject1.CampoMulta = //linha.Substring(65, 1);
                cdObject1.PercentualMulta = //linha.Substring(66, 4);
                cdObject1.IdentificacaoTituloBanco = //linha.Substring(70, 11);
                cdObject1.DigitoAutoconferenciaNumeroBancario = //linha.Substring(81, 1);
                cdObject1.DescontoBonificacaoDia = //linha.Substring(82, 10);
                cdObject1.CondicaoEmissaoPapeletaCobranca = //linha.Substring(92, 1);
                cdObject1.IdentEmiteBoletoDebitoAutomaticao = //linha.Substring(93, 1);
                cdObject1.IdentificacaoOperacaoBanco = //linha.Substring(94, 10);
                cdObject1.IndicadorRateioCredito = //linha.Substring(104, 1);
                cdObject1.EnderecamentoAvisoDebitoAutomaticoContaCorrente = //linha.Substring(105, 1);
                cdObject1.QuantidadePagamentos = //linha.Substring(106, 2);
                cdObject1.IdentificacaoOcorrencia = //linha.Substring(108, 2);
                cdObject1.NumeroDocumento = //linha.Substring(110, 10);
                cdObject1.DataVencimentoTitulo = //linha.Substring(120, 6);
                cdObject1.ValorTitulo = //linha.Substring(126, 13);
                cdObject1.BancoEncarregadoCobranca = //linha.Substring(139, 3);
                cdObject1.AgenciaDepositaria = //linha.Substring(142, 5);
                cdObject1.EspecieTitulo = //linha.Substring(147, 2);
                cdObject1.Identificacao = //linha.Substring(149, 1);
                cdObject1.DataEmissaoTitulo = //linha.Substring(150, 6);
                cdObject1.PrimeiraInstrucao = //linha.Substring(156, 2);
                cdObject1.SegundaInstrucao = //linha.Substring(158, 2);
                cdObject1.ValorCobradoDiaAtraso = //linha.Substring(160, 13);
                cdObject1.DataLimiteConcessaoDesconto = //linha.Substring(173, 6);
                cdObject1.ValorDesconto = //linha.Substring(179, 13);
                cdObject1.ValorIof = //linha.Substring(192, 13);
                cdObject1.ValorAbatimentoConcedidoOuCancelado = //linha.Substring(205, 13);
                cdObject1.IdentificacaoTipoInscricaoPagador = //linha.Substring(218, 2);
                cdObject1.NumeroInscricaoPagador = //linha.Substring(220, 14);
                cdObject1.NomeDoPagador = //linha.Substring(234, 40);
                cdObject1.EnderecoCompleto = //linha.Substring(274, 40);
                cdObject1.PrimeiraMensagem = //linha.Substring(314, 12);
                cdObject1.Cep = //inha.Substring(326, 5);
                cdObject1.SufixoCep = //linha.Substring(331, 3);
                cdObject1.BeneficiarioFinalSegundaMensagem = //linha.Substring(334, 60);
                cdObject1.NumeroSequencialRegistroTipo1 = //linha.Substring(394, 6);
            }

            // Serializando para JSON
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(dynamicList);

            // Retornando o JSON como resposta
            return jsonResult;
        }
    }
}