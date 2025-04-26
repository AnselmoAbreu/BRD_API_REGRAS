using System;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class LayoutCob400Service
    {
        #region CONSTANTES

        const string descricaoRegistroHeaderArquivoZero = "REGISTRO_HEADER_ARQUIVO_(0)"; // Header de arquivo
        const string descricaoRegistroHeaderArquivoNove = "REGISTRO_TRAILER_ARQUIVO_(9)"; // Trailer de arquivo

        // SEGMENTOS PARA PAGAMENTO ATRAVÉS DE CRÉDITO EM CONTA, CHEQUE,OP, DOC, TED OU
        // PAGAMENTO COM AUTENTICAÇÃO
        const string segmentoVariosA = "SEGMENTO_PGTOS_DIVERSOS_A";
        const string segmentoVariosB = "SEGMENTO_PGTOS_DIVERSOS_B";
        const string segmentoVariosC = "SEGMENTO_PGTOS_DIVERSOS_C";
        const string segmentoVarios5 = "SEGMENTO_PGTOS_DIVERSOS_5";
        const string segmentoVariosZ = "SEGMENTO_PGTOS_DIVERSOS_Z";
        const string descricaoRegistroUm_PgVarios = "REGISTRO_PGTOS_DIVERSOS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_PgVarios = "REGISTRO_PGTOS_DIVERSOS_TRAILER_LOTE_(5)"; // Trailer de lote

        // SEGMENTOS PARA PAGAMENTO DE TÍTULOS
        const string segmentoPgTit_J = "PGTO_TITULO_SEGMENTO_J";
        const string segmentoPgTit_J52 = "PGTO_TITULO_SEGMENTO_J52";
        const string segmentoPgTit_5 = "PGTO_TITULO_SEGMENTO_5";
        const string segmentoPgTit_Z = "PGTO_TITULO_SEGMENTO_Z";
        const string descricaoRegistroUm_PgTitulos = "REGISTRO_PGTO_TITULOS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_PgTitulos = "REGISTRO_PGTO_TITULOS_TRAILER_LOTE_(5)"; // Trailer de lote

        // SEGMENTOS PGTOS TRIBUTOS : O , N, N1 GPS , N2 DARF , N3 DARF SIMPLES , N4 GARE SP , W , W1 , 5 , Z
        const string segmentoPgTrib_O = "PGTO_TRIBUTOS_SEGMENTO_O";
        const string segmentoPgTrib_N = "PGTO_TRIBUTOS_SEGMENTO_N";
        const string segmentoPgTrib_N1 = "PGTO_TRIBUTOS_SEGMENTO_N1";
        const string segmentoPgTrib_N2 = "PGTO_TRIBUTOS_SEGMENTO_N2";
        const string segmentoPgTrib_N3 = "PGTO_TRIBUTOS_SEGMENTO_N3";
        const string segmentoPgTrib_N4 = "PGTO_TRIBUTOS_SEGMENTO_N4";
        const string segmentoPgTrib_W = "PGTO_TRIBUTOS_SEGMENTO_W";
        const string segmentoPgTrib_W1 = "PGTO_TRIBUTOS_SEGMENTO_W1";
        const string segmentoPgTrib_5 = "PGTO_TRIBUTOS_SEGMENTO_5";
        const string segmentoPgTrib_Z = "PGTO_TRIBUTOS_SEGMENTO_Z";
        const string descricaoRegistroUm_PgTributos = "REGISTRO_PGTO_TRIBUTOS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_PgTributos = "REGISTRO_PGTO_TRIBUTOS_TRAILER_LOTE_(5)"; // Trailer de lote

        // SEGMENTOS PARA BLOQUETO ELETRÔNICO G, H, Y03, Y51
        const string segmentoBloquetoEletronico_G = "BLOQUETO_ELETRONICO_SEGMENTO_G";
        const string segmentoBloquetoEletronico_H = "BLOQUETO_ELETRONICO_SEGMENTO_H";
        const string segmentoBloquetoEletronico_Y03 = "BLOQUETO_ELETRONICO_SEGMENTO_Y3";
        const string segmentoBloquetoEletronico_Y51 = "BLOQUETO_ELETRONICO_SEGMENTO_Y51";
        const string descricaoRegistroUm_BloquetoEletronico = "REGISTRO_BLOQUETO_ELETRONICO_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_BloquetoEletronico = "REGISTRO_BLOQUETO_ELETRONICO_TRAILER_LOTE_(5)"; // Trailer de lote

        // SEGMENTOS PARA ALEGAÇÃO DO SACADO Y2
        const string segmentoAlegacaoSacado_Y2 = "ALEGACAO_SACADO_SEGMENTO_Y2";
        const string descricaoRegistroUm_AlegacaoSacado = "REGISTRO_ALEGACAO_SACADO_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_AlegacaoSacado = "REGISTRO_ALEGACAO_SACADO_TRAILER_LOTE_(5)"; // Trailer de lote

        // BASES DOS SISTEMAS
        const string segmento1_BasesSistemas = "BASES_SISTEMAS_SEGMENTO_1";
        const string segmento2_BasesSistemas = "BASES_SISTEMAS_SEGMENTO_2";
        const string segmento3_BasesSistemas = "BASES_SISTEMAS_SEGMENTO_3";
        const string descricaoRegistroUm_BasesSistemas = "REGISTRO_BASES_SISTEMAS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_BasesSistemas = "REGISTRO_BASES_SISTEMAS_TRAILER_LOTE_(5)"; // Trailer de lote

        #endregion

        public dynamic MontarJsonCob400(dynamic dynamicList, string codigoArquivo) // COB400
        {
            //JsonObjectsGenerator.AddProperty(dynamicList, registroZero, new ExpandoObject());
            //JsonObjectsGenerator.AddProperty(dynamicList, registroUm, new ExpandoObject());
            ////JsonObjectsGenerator.AddProperty(dynamicList, registroDois, new ExpandoObject());
            ////JsonObjectsGenerator.AddProperty(dynamicList, registroTres, new ExpandoObject());
            ////JsonObjectsGenerator.AddProperty(dynamicList, registroSeis, new ExpandoObject());
            ////JsonObjectsGenerator.AddProperty(dynamicList, registroSete, new ExpandoObject());
            ////JsonObjectsGenerator.AddProperty(dynamicList, registroNove, new ExpandoObject());

            //dynamic cdObject = new ExpandoObject();
            //dynamic cdObject1 = new ExpandoObject();

            ////-------------------------------------------------------
            //// : Posição inicial
            //// : Tamanho
            //// : Tipo
            //// : Obrigatório (R = REQUERIDO / V = VAZIO / Z = ZERADO)
            //// : Parentesco (0 = PAI / 1 = FILHO)
            //// : Posição no manual do bradesco
            //// : Valor fixo
            //// : Mensagem própria
            //// : Campo Data (D)
            ////-------------------------------------------------------

            //cdObject.IdentificacaoRegistro = "0:1:N:R:0:001-001:0:Campo deve conter [0]::";
            //cdObject.IdentificacaoArquivoRemessa = "1:1:N:R:0:002-002:1:Campo deve conter [1]::";
            //cdObject.LiteralRemessa = "2:7:C:R:0:003-009:REMESSA:Campo deve conter [REMESSA]::";
            //cdObject.CodigoServico = "9:2:N:R:0:010-011:01:Campo deve conter [01]::";
            //cdObject.LiteralServico = "11:15:C:R:0:012-026:COBRANCA:Campo deve conter [COBRANCA]::";
            //cdObject.CodigoEmpresa = "26:20:N:R:0:027-046::Campo não pode ser igual a zero::";
            //cdObject.NomeEmpresa = "46:30:C:R:0:047-076::Campo não pode estar em branco::";
            //cdObject.NumeroBradescoCompensacao = "76:3:N:R:0:077-079:237:Campo deve conter [237]::";
            //cdObject.NomeBancoExtenso = "79:15:C:R:0:080-094:BRADESCO:Campo deve conter [BRADESCO]::";
            //cdObject.DataGravacaoArquivo = "94:6:N:R:0:095-100::Campo deve conter uma data válida:D";
            //cdObject.Branco1 = "100:8:C:V:0:101-108::Campo deve estar em branco::";
            //cdObject.IdentificacaoSistema = "108:2:C:R:0:109-110:MX:Campo deve conter [MX]::";
            //cdObject.NumeroSequencialRemessa = "110:7:N:R:0:111-117::Campo deve conter um número::";
            //cdObject.Branco2 = "117:277:C:V:0:118-394::Campo deve estar em branco::";
            //cdObject.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número::";

            //JsonObjectsGenerator.AddProperty(dynamicList, registroZero, cdObject);

            //// ========================================================================

            //cdObject1.IdentificacaoRegistro = "0:1:N:R:0:001-001:1:Campo deve conter [1]::";
            //cdObject1.AgenciaDebito = "1:5:N:R:0:002-006::Campo não pode ser igual a zero::";
            //cdObject1.DigitoAgencia = "6:1:C:V:0:007-007::::";
            //cdObject1.RazaoContaCorrente = "7:5:N:Z:0:008-012:::";
            //cdObject1.ContaCorrente = "12:7:N:Z:0:013-019:::";
            //cdObject1.DigitoContaCorrente = "19:1:C:V:0:020-020::Erro genérico:";
            //cdObject1.IdEmpresaBeneficiariaBanco = "20:17:C:R:0:021-037::Campo não deve estar em branco:";
            //cdObject1.NumeroControlePaticipante = "37:25:C:R:0:038-062::Campo não deve estar em branco:";
            //cdObject1.CodigoBancoDebitadoCamaraCompensacao = "62:3:N:R:0:063-065:237:Campo deve conter [237]:";
            //cdObject1.CampoMulta = "65:1:N:R:0:066-066:0,2:Campo deve conter [0 ou 2]:";
            //cdObject1.PercentualMulta = "66:4:N:R:1:067-070::Campo não deve estar em branco:";
            //cdObject1.IdentificacaoTituloBanco = "70:11:N:R:0:071-081::Campo não deve ser preenchido com zeros:";
            //cdObject1.DigitoAutoconferenciaNumeroBancario = "81:1:C:R:0:082-082::Campo não deve estar em branco:";
            //cdObject1.DescontoBonificacaoDia = "82:10:N:Z:0:083-092:::";
            //cdObject1.CondicaoEmissaoPapeletaCobranca = "92:1:N:R:0:093-093:0,1,2:Campo deve conter [0,1,2]:";
            //cdObject1.IdentEmiteBoletoDebitoAutomaticao = "93:1:C:R:0:094-094:::";
            //cdObject1.IdentificacaoOperacaoBanco = "94:10:C:V:0:095-104::Campo deve estar em branco:";
            //cdObject1.IndicadorRateioCredito = "104:1:C:R:0:105-105:R:Campo deve conter [R]:";
            //cdObject1.EnderecamentoAvisoDebitoAutomaticoContaCorrente = "105:1:N:R:0:106-106::Campo não deve estar em branco:";
            //cdObject1.QuantidadePagamentos = "106:2:C:R:0:107-108::Campo não deve estar em branco:";
            //cdObject1.IdentificacaoOcorrencia = "108:2:N:R:0:109-110::Campo não deve ser preenchido com zeros:";
            //cdObject1.NumeroDocumento = "110:10:C:R:0:111-120::Campo não deve estar em branco:";
            //cdObject1.DataVencimentoTitulo = "120:6:N:R:0:121-126::Campo deve conter uma data válida:D";
            //cdObject1.ValorTitulo = "126:13:N:R:0:127-139::Campo não pode ser igual a zero:";
            //cdObject1.BancoEncarregadoCobranca = "139:3:N:R:0:140-142:000:Campo deve conter [000]:";
            //cdObject1.AgenciaDepositaria = "142:5:N:R:0:143-147:00000:Erro genérico:";
            //cdObject1.EspecieTitulo = "147:2:N:R:0:148-149:01,02,03,05,10,11,12,31,32,33,99:Campo deve conter [01,02,03,05,10,11,12,31,32,33,99]:";
            //cdObject1.Identificacao = "149:1:C:R:0:150-150:N:Campo deve conter [N]:";
            //cdObject1.DataEmissaoTitulo = "150:6:N:R:0:151-156::Campo deve conter uma data válida:D";
            //cdObject1.PrimeiraInstrucao = "156:2:N:R:0:157-158::Campo não deve estar em branco:";
            //cdObject1.SegundaInstrucao = "158:2:N:R:0:159-160::Campo não deve estar em branco:";
            //cdObject1.ValorCobradoDiaAtraso = "160:13:N:R:0:161-173::Campo não deve estar em branco:";
            //cdObject1.DataLimiteConcessaoDesconto = "173:6:N:R:0:174-179::Campo deve conter uma data válida:D";
            //cdObject1.ValorDesconto = "179:13:N:R:0:180-192::Campo não deve estar em branco:";
            //cdObject1.ValorIof = "192:13:N:R:0:193-205::Campo não deve estar em branco:";
            //cdObject1.ValorAbatimentoConcedidoOuCancelado = "205:13:N:R:0:206-218::Campo não deve estar em branco:";
            //cdObject1.IdentificacaoTipoInscricaoPagador = "218:2:N:R:0:219-220:01,02:Campo deve conter [01,02]:";
            //cdObject1.NumeroInscricaoPagador = "220:14:N:R:0:221-234::Campo não deve estar em branco:";
            //cdObject1.NomeDoPagador = "234:40:C:R:0:235-274::Campo não deve estar em branco:";
            //cdObject1.EnderecoCompleto = "274:40:C:R:0:275-314::Campo não deve estar em branco:";
            //cdObject1.PrimeiraMensagem = "314:12:C:R:0:315-326::Campo não deve estar em branco:";
            //cdObject1.Cep = "326:5:N:R:0:327-331::Campo não deve estar em branco:";
            //cdObject1.SufixoCep = "331:3:N:R:0:332-334::Campo não deve estar em branco:";
            //cdObject1.BeneficiarioFinalSegundaMensagem = "334:60:C:R:0:335-394:DECOMPOSIÇÃO:Campo deve conter [DECOMPOSIÇÃO]:";
            //cdObject1.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número:";

            //JsonObjectsGenerator.AddProperty(dynamicList, registroUm, cdObject1);

            //// ========================================================================

            return dynamicList;

        }

        
    }
}