using System;
using System.Drawing;
using System.Dynamic;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class DefineLayoutService
    {
        #region Constantes para nome de registro de arquivo

        const string descricaoRegistroZero = "REGISTRO_HEADER_ARQUIVO_(0)"; // Header de arquivo
        const string descricaoRegistroNove = "REGISTRO_TRAILER_ARQUIVO_(9)"; // Trailer de arquivo

        // Segmentos para Pagamento Através de Crédito em Conta, Cheque,OP, DOC, TED ou Pagamento com Autenticação

        const string segmentoVariosA = "SEGMENTO_PGTOS_DIVERSOS_A";
        const string segmentoVariosB = "SEGMENTO_PGTOS_DIVERSOS_B";
        const string segmentoVariosC = "SEGMENTO_PGTOS_DIVERSOS_C";
        const string segmentoVarios5 = "SEGMENTO_PGTOS_DIVERSOS_5";
        const string segmentoVariosZ = "SEGMENTO_PGTOS_DIVERSOS_Z";
        const string descricaoRegistroUm_PgVarios = "REGISTRO_PGTOS_DIVERSOS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_PgVarios = "REGISTRO_PGTOS_DIVERSOS_TRAILER_LOTE_(5)"; // Trailer de lote


        // Segmentos para Pagamento de Títulos

        const string segmentoPgTit_J = "PGTO_TITULO_SEGMENTO_J";
        const string segmentoPgTit_J52 = "PGTO_TITULO_SEGMENTO_J52";
        const string segmentoPgTit_5 = "PGTO_TITULO_SEGMENTO_5";
        const string segmentoPgTit_Z = "PGTO_TITULO_SEGMENTO_Z";
        const string descricaoRegistroUm_PgTitulos = "REGISTRO_PGTO_TITULOS_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_PgTitulos = "REGISTRO_PGTO_TITULOS_TRAILER_LOTE_(5)"; // Trailer de lote

        // Segmentos para Pagamento de tributos

        // SEGMENTOS : O , N, N1 GPS , N2 DARF , N3 DARF SIMPLES , N4 GARE SP , W , W1 , 5 , Z
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

        // Segmentos para Bloqueto Eletrônico G/H/Y03/Y51/
        const string segmentoBloquetoEletronico_G = "BLOQUETO_ELETRONICO_SEGMENTO_G";
        const string segmentoBloquetoEletronico_H = "BLOQUETO_ELETRONICO_SEGMENTO_H";
        const string segmentoBloquetoEletronico_Y03 = "BLOQUETO_ELETRONICO_SEGMENTO_Y3";
        const string segmentoBloquetoEletronico_Y51 = "BLOQUETO_ELETRONICO_SEGMENTO_Y51";
        const string descricaoRegistroUm_BloquetoEletronico = "REGISTRO_BLOQUETO_ELETRONICO_HEADER_LOTE_(1)"; // Header de lote
        const string descricaoRegistroCinco_BloquetoEletronico = "REGISTRO_BLOQUETO_ELETRONICO_TRAILER_LOTE_(5)"; // Trailer de lote

        #endregion

        public string MontarJson(string codigoArquivo)
        {
            dynamic dynamicList = new ExpandoObject();
            switch (codigoArquivo)
            {
                case "COB400":
                    MontarJsonCob400(dynamicList, codigoArquivo);
                    break;
                case "MTP240":
                    MontarJsonMtp240(dynamicList, codigoArquivo);
                    break;
                default:
                    throw new ArgumentException("Código de arquivo inválido.");
            }

            // Serializando para JSON
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(dynamicList);

            // Retornando o JSON como resposta
            return jsonResult;
        }

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

            //cdObject.IdentificacaoRegistro = "0:1:N:R:0:001-001:0:Campo deve conter [0]:";
            //cdObject.IdentificacaoArquivoRemessa = "1:1:N:R:0:002-002:1:Campo deve conter [1]:";
            //cdObject.LiteralRemessa = "2:7:C:R:0:003-009:REMESSA:Campo deve conter [REMESSA]:";
            //cdObject.CodigoServico = "9:2:N:R:0:010-011:01:Campo deve conter [01]:";
            //cdObject.LiteralServico = "11:15:C:R:0:012-026:COBRANCA:Campo deve conter [COBRANCA]:";
            //cdObject.CodigoEmpresa = "26:20:N:R:0:027-046::Campo não pode ser igual a zero:";
            //cdObject.NomeEmpresa = "46:30:C:R:0:047-076::Campo não pode estar em branco:";
            //cdObject.NumeroBradescoCompensacao = "76:3:N:R:0:077-079:237:Campo deve conter [237]:";
            //cdObject.NomeBancoExtenso = "79:15:C:R:0:080-094:BRADESCO:Campo deve conter [BRADESCO]:";
            //cdObject.DataGravacaoArquivo = "94:6:N:R:0:095-100::Campo deve conter uma data válida:D";
            //cdObject.Branco1 = "100:8:C:V:0:101-108::Campo deve estar em branco:";
            //cdObject.IdentificacaoSistema = "108:2:C:R:0:109-110:MX:Campo deve conter [MX]:";
            //cdObject.NumeroSequencialRemessa = "110:7:N:R:0:111-117::Campo deve conter um número:";
            //cdObject.Branco2 = "117:277:C:V:0:118-394::Campo deve estar em branco:";
            //cdObject.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número:";

            //JsonObjectsGenerator.AddProperty(dynamicList, registroZero, cdObject);

            //// ========================================================================

            //cdObject1.IdentificacaoRegistro = "0:1:N:R:0:001-001:1:Campo deve conter [1]:";
            //cdObject1.AgenciaDebito = "1:5:N:R:0:002-006::Campo não pode ser igual a zero:";
            //cdObject1.DigitoAgencia = "6:1:C:V:0:007-007:::";
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

        public dynamic MontarJsonMtp240(dynamic dynamicList, string codigoArquivo) // MULTIPAG 240
        {
            #region LEGENDAS
            //------------------------------------------------------------------------------
            // : Posição inicial
            // : Tamanho
            // : Tipo
            // : Obrigatório (R = REQUERIDO / V = VAZIO / Z = ZERADO)
            // : Parentesco (0 = PAI / 1 = FILHO)
            // : Posição no manual do bradesco
            // : Valor fixo
            // : Mensagem própria
            // : Campo Data (D)
            //------------------------------------------------------------------------------
            #endregion

            #region PGTO ATRAVÉS DE CRÉDITO EM CONTA,CHEQUE,OP,DOC,TED,PGTO. COM AUTENTICAÇÃO
            // SEGMENTOS : A , B, C , 5 , Z

            #region OBJETOS
            dynamic cdObject0 = new ExpandoObject(); // Header de arquivo
            dynamic cdObject9 = new ExpandoObject(); // Trailer de arquivo

            dynamic cdObject1 = new ExpandoObject(); // Header de lote
            dynamic cdObject5 = new ExpandoObject(); // Trailer de lote

            dynamic cdObjectSegmentoA = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoB = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoC = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmento5 = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoZ = new ExpandoObject(); //  Tipo 3
            #endregion

            #region HEADER ARQUIVO
            cdObject0.CodigoBancoCompensacao = "1:3:N:V:0:1-3::Erro - Código do Banco na Compensação:";
            cdObject0.LoteServico = "4:4:N:R:0:4-7:0000:Erro - Lote de Serviço:";
            cdObject0.TipoRegistro = "8:1:N:R:0:8-8:0:Erro - Tipo de Registro:";
            cdObject0.UsoExclusivoFebrabanCnab1 = "9:9:C:V:0:9-17:         :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject0.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa:";
            cdObject0.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa:";
            cdObject0.CodigoConvenioBanco = "33:20:C:R:0:33-52::Erro - Código do Convênio no Banco:";
            cdObject0.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta:";
            cdObject0.DigitoVerificadorAgencia = "58:1:C:R:0:58-58::Erro - Dígito Verificador da Agência:";
            cdObject0.NumeroConta = "59:12:N:R:0:59-70::Erro - Número de Conta:";
            cdObject0.DigitoVerificadorConta = "71:1:C:R:0:71-71::Erro - Digito Verificador da Conta:";
            cdObject0.DigitoVerificadorAgenciaConta = "72:1:C:R:0:72-72::Erro - Digito Verificador da Agência/Conta:";
            cdObject0.NomeEmpresa = "73:30:C:V:0:73-102::Erro - Nome da Empresa:";
            cdObject0.NomeBanco = "103:30:C:V:0:103-132::Erro - Nome do Banco:";
            cdObject0.UsoExclusivoFebrabanCnab2 = "133:10:C:V:0:133-142:          :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject0.CodigoRemessaRetorno = "143:1:N:V:0:143-143::Erro - Código Remessa/Retorno:";
            cdObject0.DataGeracaoArquivo = "144:8:N:V:0:144-151::Erro - Data de Geração do Arquivo:D";
            cdObject0.HoraGeracaoArquivo = "152:6:N:V:0:152-157::Erro - Hora de Geração do Arquivo:";
            cdObject0.NumeroSequencialArquivo = "158:6:N:R:0:158-163::Erro - Número Sequencial do Arquivo:";
            cdObject0.VersaoLayoutArquivo = "164:3:N:R:0:164-166:089:Erro - Versão do Layout do Arquivo:";
            cdObject0.DensidadeGravacao = "167:5:N:V:0:167-171::Erro - Densidade de Gravação:";
            cdObject0.ReservadoBanco = "172:20:C:V:0:172-191::Erro - Reservado Banco:";
            cdObject0.ReservadoEmpresa = "192:20:C:V:0:192-211::Erro - Reservado Empresa:";
            cdObject0.UsoExclusivoFebrabanCnab3 = "212:29:C:V:0:212-240:                             :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroZero, cdObject0);
            #endregion

            #region TRAILER ARQUIVO
            cdObject9.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObject9.LoteServico = "4:4:N:R:0:4-7:9999:Erro - Lote de Serviço:";
            cdObject9.TipoRegistro = "8:1:N:R:0:8-8:9:Erro - Tipo de Registro:";
            cdObject9.UsoExclusivoFebrabanCnab1 = "9:9:C:V:0:9-17:         :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject9.QuantidadeLotesArquivo = "18:6:N:R:0:18-23::Erro - Quantidade de Lotes do Arquivo:"; //<<<<<<<<<
            cdObject9.QuantidadeRegistrosArquivo = "24:6:N:R:0:24-29::Erro - Quantidade de Registros do Arquivo:"; //<<<<<
            cdObject9.QuantidadeContasConcilLotes = "30:6:N:R:0:30-35::Erro - Qtde de Contas p/ Conc. (Lotes):"; //<<<<<
            cdObject9.UsoExclusivoFebrabanCnab2 = "36:205:C:V:0:36-240:" + new string(' ', 205) + ":Erro - Uso Exclusivo FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroNove, cdObject9);
            #endregion

            #region HEADER LOTE
            cdObject1.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObject1.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObject1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro:";
            cdObject1.TipoOperacao = "9:1:C:R:0:9-9:C:Erro - Tipo da Operação:";
            cdObject1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço:";
            cdObject1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento:";
            cdObject1.VersaoLayoutLote = "14:3:N:R:0:14-16:045:Erro - Nº da Versão do Layout do Lote:";
            cdObject1.UsoExclusivoFebrabanCnab1 = "17:1:C:V:0:17-17: :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa:";
            cdObject1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa:";
            cdObject1.CodigoConvenioBanco = "33:20:C:R:0:33-52::Erro - Código do Convênio no Banco:";
            cdObject1.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta:";
            cdObject1.DigitoVerificadorAgencia = "58:1:C:R:0:58-58::Erro - Dígito Verificador da Agência:";
            cdObject1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Número da Conta Corrente:";
            cdObject1.DigitoVerificadorConta = "71:1:C:R:0:71-71::Erro - Dígito Verificador da Conta:";
            cdObject1.DigitoVerificadorAgenciaConta = "72:1:C:R:0:72-72::Erro - Dígito Verificador da Agência/Conta:";
            cdObject1.NomeEmpresa = "73:30:C:R:0:73-102::Erro - Nome da Empresa:";
            cdObject1.Mensagem = "103:40:C:V:0:103-142::Erro - Mensagem:";
            cdObject1.Logradouro = "143:30:C:V:0:143-172::Erro - Logradouro:";
            cdObject1.NumeroLocal = "173:5:N:V:0:173-177::Erro - Número do Local:";
            cdObject1.Complemento = "178:15:C:V:0:178-192::Erro - Complemento:";
            cdObject1.Cidade = "193:20:C:V:0:193-212::Erro - Cidade:";
            cdObject1.CEP = "213:5:N:V:0:213-217::Erro - CEP:";
            cdObject1.ComplementoCEP = "218:3:C:V:0:218-220::Erro - Complemento do CEP:";
            cdObject1.Estado = "221:2:C:V:0:221-222::Erro - Estado:";
            cdObject1.IndicativoFormaPagamento = "223:2:N:R:0:223-224:01:Erro - Indicativo de Forma de Pagamento:";
            cdObject1.UsoExclusivoFebrabanCnab2 = "225:6:C:V:0:225-230:      :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject1.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgVarios, cdObject1);
            #endregion

            #region TRAILER DE LOTE
            cdObject5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObject5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObject5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro:";
            cdObject5.UsoExclusivoFebrabanCnab1 = "9:9:C:V:0:9-17:         :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject5.QuantidadeRegistrosLote = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote:";
            cdObject5.SomatoriaValores = "24:16:N:R:0:24-41::Erro - Somatória de Valores:";
            cdObject5.SomatoriaQuantidadeMoedas = "42:13:N:R:0:42-59::Erro - Somatória de Quantidade de Moedas:";
            cdObject5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Número Aviso de Débito:";
            cdObject5.UsoExclusivoFebrabanCnab2 = "66:165:C:V:0:66-230:" + new string(' ', 165) + ":Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObject5.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgVarios, cdObject5);
            #endregion

            #region SEGMENTO A 
            cdObjectSegmentoA.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoA.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoA.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoA.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote:";
            cdObjectSegmentoA.CodigoSegmento = "14:1:C:R:0:14-14:A:Erro - Código de Segmento:";
            cdObjectSegmentoA.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento:";
            cdObjectSegmentoA.CodigoInstrucaoMovimento = "16:2:N:V:0:16-17::Erro - Código da Instrução:";
            cdObjectSegmentoA.CodigoCamaraCentralizadora = "18:3:N:R:0:18-20::Erro - Código da Câmara Centralizadora:";
            cdObjectSegmentoA.CodigoBancoFavorecido = "21:3:N:R:0:21-23::Erro - Código do Banco do Favorecido:";
            cdObjectSegmentoA.AgenciaFavorecido = "24:5:N:R:0:24-28::Erro - Agência do Favorecido:";
            cdObjectSegmentoA.DVAgenciaFavorecido = "29:1:C:R:0:29-29::Erro - DV Agência:";
            cdObjectSegmentoA.ContaCorrenteFavorecido = "30:12:N:R:0:30-41::Erro - Conta Corrente:";
            cdObjectSegmentoA.DVContaFavorecido = "42:1:C:R:0:42-42::Erro - DV Conta:";
            cdObjectSegmentoA.DVAgenciaContaFavorecido = "43:1:C:R:0:43-43::Erro - DV Agência/Conta:";
            cdObjectSegmentoA.NomeFavorecido = "44:30:C:R:0:44-73::Erro - Nome do Favorecido:";
            cdObjectSegmentoA.NumeroDocumentoEmpresa = "74:20:C:V:0:74-93::Erro - Nº Documento Empresa:";
            cdObjectSegmentoA.DataPagamento = "94:8:N:R:0:94-101::Erro - Data Pagamento:D";
            cdObjectSegmentoA.TipoMoeda = "102:3:C:R:0:102-104::Erro - Tipo Moeda:";
            cdObjectSegmentoA.QuantidadeMoeda = "105:15:N:V:0:105-119::Erro - Quantidade Moeda:";
            cdObjectSegmentoA.ValorPagamento = "120:15:N:R:0:120-134::Erro - Valor Pagamento:";
            cdObjectSegmentoA.NossoNumero = "135:20:C:V:0:135-154::Erro - Nosso Número:";
            cdObjectSegmentoA.DataRealPagamento = "155:8:N:V:0:155-162::Erro - Data Real Pagamento:D";
            cdObjectSegmentoA.ValorRealPagamento = "163:15:N:V:0:163-177::Erro - Valor Real Pagamento:";
            cdObjectSegmentoA.InformacoesAdicionais = "178:40:C:V:0:178-217::Erro - Informações Adicionais:";
            cdObjectSegmentoA.CodigoFinalidadeDoc = "218:2:C:V:0:218-219::Erro - Finalidade Doc:";
            cdObjectSegmentoA.CodigoFinalidadeTED = "220:5:C:R:0:220-224::Erro - Finalidade TED:";
            cdObjectSegmentoA.ComplementoFinalidade = "225:2:C:V:0:225-226::Erro - Complemento Finalidade:";
            cdObjectSegmentoA.UsoExclusivoFebraban1 = "227:3:C:V:0:227-229:   :Erro - Uso FEBRABAN:";
            cdObjectSegmentoA.AvisoFavorecido = "230:1:N:V:0:230-230::Erro - Aviso Favorecido:";
            cdObjectSegmentoA.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosA, cdObjectSegmentoA);
            #endregion

            #region SEGMENTO B 
            cdObjectSegmentoB.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco:";
            cdObjectSegmentoB.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoB.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo Registro:";
            cdObjectSegmentoB.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote:";
            cdObjectSegmentoB.CodigoSegmento = "14:1:C:R:0:14-14:B:Erro - Segmento:";
            cdObjectSegmentoB.UsoExclusivoFebraban1 = "15:3:C:V:0:15-17:   :Erro - Uso FEBRABAN 1:";
            cdObjectSegmentoB.TipoInscricaoFavorecido = "18:1:N:R:0:18-18::Erro - Tipo Inscrição:";
            cdObjectSegmentoB.NumeroInscricaoFavorecido = "19:14:N:R:0:19-32::Erro - Nº Inscrição:";
            cdObjectSegmentoB.Logradouro = "33:30:C:V:0:33-62::Erro - Logradouro:";
            cdObjectSegmentoB.NumeroLocal = "63:5:N:V:0:63-67::Erro - Número Local:";
            cdObjectSegmentoB.Complemento = "68:15:C:V:0:68-82::Erro - Complemento:";
            cdObjectSegmentoB.Bairro = "83:15:C:V:0:83-97::Erro - Bairro:";
            cdObjectSegmentoB.Cidade = "98:20:C:V:0:98-117::Erro - Cidade:";
            cdObjectSegmentoB.CEP = "118:5:N:V:0:118-122::Erro - CEP:";
            cdObjectSegmentoB.ComplementoCEP = "123:3:C:V:0:123-125::Erro - Compl. CEP:";
            cdObjectSegmentoB.Estado = "126:2:C:V:0:126-127::Erro - Estado:";
            cdObjectSegmentoB.DataVencimento = "128:8:N:V:0:128-135::Erro - Vencimento:D";
            cdObjectSegmentoB.ValorDocumento = "136:15:N:V:0:136-150::Erro - Valor Documento:";
            cdObjectSegmentoB.ValorAbatimento = "151:15:N:V:0:151-165::Erro - Abatimento:";
            cdObjectSegmentoB.ValorDesconto = "166:15:N:V:0:166-180::Erro - Desconto:";
            cdObjectSegmentoB.ValorMora = "181:15:N:V:0:181-195::Erro - Mora:";
            cdObjectSegmentoB.ValorMulta = "196:15:N:V:0:196-210::Erro - Multa:";
            cdObjectSegmentoB.CodigoDocumentoFavorecido = "211:15:C:V:0:211-225::Erro - Cód. Documento:";
            cdObjectSegmentoB.AvisoFavorecido = "226:1:N:V:0:226-226::Erro - Aviso:";
            cdObjectSegmentoB.CodigoUGCentralizadora = "227:6:N:V:0:227-232::Erro - Cód. UG:";
            cdObjectSegmentoB.CodigoISPB = "233:8:N:V:0:233-240::Erro - Cód. ISPB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosB, cdObjectSegmentoB);
            #endregion

            #region SEGMENTO C 
            cdObjectSegmentoC.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco:";
            cdObjectSegmentoC.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoC.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoC.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote:";
            cdObjectSegmentoC.CodigoSegmento = "14:1:C:R:0:14-14:C:Erro - Segmento:";
            cdObjectSegmentoC.UsoExclusivoFebraban1 = "15:3:C:V:0:15-17:   :Erro - Uso FEBRABAN 1:";
            cdObjectSegmentoC.ValorIR = "18:15:N:V:0:18-32::Erro - Valor IR:";
            cdObjectSegmentoC.ValorISS = "33:15:N:V:0:33-47::Erro - Valor ISS:";
            cdObjectSegmentoC.ValorIOF = "48:15:N:V:0:48-62::Erro - Valor IOF:";
            cdObjectSegmentoC.OutrasDeducoes = "63:15:N:V:0:63-77::Erro - Outras Deduções:";
            cdObjectSegmentoC.OutrosAcrescimos = "78:15:N:V:0:78-92::Erro - Outros Acréscimos:";
            cdObjectSegmentoC.AgenciaFavorecido = "93:5:N:R:0:93-97::Erro - Agência Favorecido:";
            cdObjectSegmentoC.DVAgenciaFavorecido = "98:1:C:R:0:98-98::Erro - DV Agência:";
            cdObjectSegmentoC.NumeroContaCorrente = "99:12:N:R:0:99-110::Erro - Conta Corrente:";
            cdObjectSegmentoC.DVContaFavorecido = "111:1:C:R:0:111-111::Erro - DV Conta:";
            cdObjectSegmentoC.DVAgenciaContaFavorecido = "112:1:C:R:0:112-112::Erro - DV Agência/Conta:";
            cdObjectSegmentoC.ValorINSS = "113:15:N:V:0:113-127::Erro - Valor INSS:";
            cdObjectSegmentoC.UsoExclusivoFebraban2 = "128:113:C:V:0:128-240:" + new string(' ', 113) + ":Erro - Uso FEBRABAN 2:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosC, cdObjectSegmentoC);
            #endregion

            #region SEGMENTO 5 ( ***** ESTÁ ERRADO NO MANUAL ***** )
            cdObjectSegmento5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco:";
            cdObjectSegmento5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmento5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmento5.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote:";
            cdObjectSegmento5.CodigoSegmento = "14:1:C:R:0:14-14:5:Erro - Segmento:";
            cdObjectSegmento5.UsoExclusivoBradesco1 = "15:3:C:V:0:15-17:   :Erro - Uso Bradesco 1:";
            cdObjectSegmento5.ListaDebito = "18:9:N:V:0:18-26:5001:Erro - Lista Débito:";
            cdObjectSegmento5.HorarioDebito = "27:6:N:V:0:27-32:5002:Erro - Horário Débito:";
            cdObjectSegmento5.CodigoLancamentoEspecifico = "33:5:N:V:0:33-37:5003:Erro - Cód. Lançamento:";
            cdObjectSegmento5.SegundaLinhaExtrato = "38:5:N:V:0:38-42:5004:Erro - 2ª Linha Extrato:";
            cdObjectSegmento5.UsoEmpresa = "43:50:C:V:0:43-92:                                                  :Erro - Uso Empresa:";
            cdObjectSegmento5.TipoDocumento = "93:3:N:V:0:93-95:5006:Erro - Tipo Documento:";
            cdObjectSegmento5.NumeroDocumento = "96:15:N:V:0:96-110:5007:Erro - Nº Documento:";
            cdObjectSegmento5.SerieDocumento = "111:2:C:V:0:111-112:5008:Erro - Série Documento:";
            cdObjectSegmento5.UsoExclusivoBradesco2 = "113:15:C:V:0:113-127:               :Erro - Uso Bradesco 2:";
            cdObjectSegmento5.DataEmissaoDocumento = "128:8:N:V:0:128-135:5010:Erro - Emissão Documento:D";
            //cdObjectSegmento5.NomeReclamanteTED = "136:30:C:V:0:136-165:                              :Erro - Nome Reclamante:";
            cdObjectSegmento5.NumeroProcessoTED = "166:25:C:V:0:166-190:                         :Erro - Nº Processo:";
            cdObjectSegmento5.PISPASEPTED = "191:15:N:V:0:191-205:000000000000000:Erro - PIS/PASEP:";
            //cdObjectSegmento5.UsoExclusivoBradesco3 = "136:95:C:V:0:136-230:" + new string(' ', 95) + ":Erro - Uso Bradesco 3:";
            cdObjectSegmento5.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVarios5, cdObjectSegmento5);
            #endregion

            #region SEGMENTO Z 
            cdObjectSegmentoZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco:";
            cdObjectSegmentoZ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoZ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote:";
            cdObjectSegmentoZ.CodigoSegmento = "14:1:C:R:0:14-14:Z:Erro - Segmento:";
            cdObjectSegmentoZ.AutenticacaoLegislacao = "15:64:C:V:0:15-78:" + new string(' ', 64) + ":Erro - Autenticação Legislativa:";
            cdObjectSegmentoZ.ControleBancario = "79:25:C:V:0:79-103:" + new string(' ', 25) + ":Erro - Controle Bancário:";
            cdObjectSegmentoZ.UsoCnabFebraban = "104:127:C:V:0:104-230:" + new string(' ', 127) + ":Erro - Uso CNAB/FEBRABAN:";
            cdObjectSegmentoZ.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosZ, cdObjectSegmentoZ);

            //------------------------------------------------------------------------------
            #endregion
            #endregion

            #region PGTO DE TÍTULOS DE COBRANÇA
            // SEGMENTOS : J , J52, 5 , Z

            #region Objetos
            dynamic cdObjectPgto1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectPgto5 = new ExpandoObject(); // Trailer de lote

            dynamic cdObjectSegmentoPgtoJ = new ExpandoObject();   //  Tipo 3
            dynamic cdObjectSegmentoPgtoJ52 = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoPgto5 = new ExpandoObject();   //  Tipo 3
            dynamic cdObjectSegmentoPgtoZ = new ExpandoObject();   //  Tipo 3
            #endregion

            #region Header Lote
            cdObjectPgto1.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectPgto1.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectPgto1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro:";
            cdObjectPgto1.TipoOperacao = "9:1:C:R:0:9-9:C:Erro - Tipo da Operação:";
            cdObjectPgto1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço:";
            cdObjectPgto1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento:";
            cdObjectPgto1.VersaoLayoutLote = "14:3:N:R:0:14-16:045:Erro - Nº da Versão do Layout do Lote:";
            cdObjectPgto1.UsoExclusivoFebrabanCnab1 = "17:1:C:V:0:17-17: :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObjectPgto1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa:";
            cdObjectPgto1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa:";
            cdObjectPgto1.CodigoConvenioBanco = "33:20:C:R:0:33-52::Erro - Código do Convênio no Banco:";
            cdObjectPgto1.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta:";
            cdObjectPgto1.DigitoVerificadorAgencia = "58:1:C:R:0:58-58::Erro - Dígito Verificador da Agência:";
            cdObjectPgto1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Número da Conta Corrente:";
            cdObjectPgto1.DigitoVerificadorConta = "71:1:C:R:0:71-71::Erro - Dígito Verificador da Conta:";
            cdObjectPgto1.DigitoVerificadorAgenciaConta = "72:1:C:R:0:72-72::Erro - Dígito Verificador da Agência/Conta:";
            cdObjectPgto1.NomeEmpresa = "73:30:C:R:0:73-102::Erro - Nome da Empresa:";
            cdObjectPgto1.Mensagem = "103:40:C:V:0:103-142::Erro - Mensagem:";
            cdObjectPgto1.Logradouro = "143:30:C:V:0:143-172::Erro - Logradouro:";
            cdObjectPgto1.NumeroLocal = "173:5:N:V:0:173-177::Erro - Número do Local:";
            cdObjectPgto1.Complemento = "178:15:C:V:0:178-192::Erro - Complemento:";
            cdObjectPgto1.Cidade = "193:20:C:V:0:193-212::Erro - Cidade:";
            cdObjectPgto1.CEP = "213:5:N:V:0:213-217::Erro - CEP:";
            cdObjectPgto1.ComplementoCEP = "218:3:C:V:0:218-220::Erro - Complemento do CEP:";
            cdObjectPgto1.Estado = "221:2:C:V:0:221-222::Erro - Estado:";
            cdObjectPgto1.IndicativoFormaPagamento = "223:2:N:R:0:223-224:01:Erro - Indicativo de Forma de Pagamento:";
            cdObjectPgto1.UsoExclusivoFebrabanCnab2 = "225:6:C:V:0:225-230:      :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObjectPgto1.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgTitulos, cdObjectPgto1);

            #endregion

            #region TRAILER DE LOTE
            cdObjectPgto5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectPgto5.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectPgto5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro:";
            cdObjectPgto5.UsoExclusivoFebrabanCnab1 = "9:9:C:V:0:9-17:         :Erro - Uso Exclusivo FEBRABAN/CNAB:"; // 9 espaços
            cdObjectPgto5.QuantidadeRegistrosLote = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote:";
            cdObjectPgto5.SomatoriaValores = "24:18:N:V:0:24-41::Erro - Somatória de Valores:"; // 16 inteiros + 2 decimais
            cdObjectPgto5.SomatoriaQuantidadeMoedas = "42:18:N:V:0:42-59::Erro - Somatória de Quantidade de Moedas:"; // 13 inteiros + 5 decimais
            cdObjectPgto5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Número Aviso de Débito:";
            cdObjectPgto5.UsoExclusivoFebrabanCnab2 = "66:165:C:V:0:66-230:".PadRight(165, ' ') + ":Erro - Uso Exclusivo FEBRABAN/CNAB:"; // 165 espaços
            cdObjectPgto5.OcorrenciasRetorno = "231:10:C:R:0:231-240::Erro - Ocorrências para Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgTitulos, cdObjectPgto5);
            #endregion

            #region Segmento J (Detalhe)
            cdObjectSegmentoPgtoJ.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código no Banco da Compensação:";
            cdObjectSegmentoPgtoJ.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoJ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoJ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote:";
            cdObjectSegmentoPgtoJ.CodigoSegmento = "14:1:C:R:0:14-14:J:Erro - Código de Segmento:";
            cdObjectSegmentoPgtoJ.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento:";
            cdObjectSegmentoPgtoJ.CodigoInstrucao = "16:2:N:R:0:16-17::Erro - Código da Instrução p/ Movimento:";
            cdObjectSegmentoPgtoJ.CodigoBarras = "18:44:N:R:0:18-61::Erro - Código de Barras:";
            cdObjectSegmentoPgtoJ.NomeCedente = "62:30:C:R:0:62-91::Erro - Nome do Cedente:";
            cdObjectSegmentoPgtoJ.DataVencimento = "92:8:N:R:0:92-99::Erro - Data do Vencimento:D";
            cdObjectSegmentoPgtoJ.ValorTitulo = "100:15:N:R:0:100-114::Erro - Valor do Título:";
            cdObjectSegmentoPgtoJ.ValorDescontoAbatimento = "115:15:N:R:0:115-129::Erro - Valor do Desconto + Abatimento:";
            cdObjectSegmentoPgtoJ.ValorMoraMulta = "130:15:N:R:0:130-144::Erro - Valor da Mora + Multa:";
            cdObjectSegmentoPgtoJ.DataPagamento = "145:8:N:R:0:145-152::Erro - Data do Pagamento:D";
            cdObjectSegmentoPgtoJ.ValorPagamento = "153:15:N:R:0:153-167::Erro - Valor do Pagamento:";
            cdObjectSegmentoPgtoJ.QuantidadeMoeda = "168:15:N:R:0:168-182::Erro - Quantidade da Moeda:";
            cdObjectSegmentoPgtoJ.ReferenciaSacado = "183:20:C:R:0:183-202::Erro - Referência do Sacado:";
            cdObjectSegmentoPgtoJ.NossoNumero = "203:20:C:R:0:203-222::Erro - Nosso Número:";
            cdObjectSegmentoPgtoJ.CodigoMoeda = "223:2:N:R:0:223-224:09:Erro - Código de Moeda:";
            cdObjectSegmentoPgtoJ.UsoExclusivoFebraban = "225:6:C:V:0:225-230:      :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObjectSegmentoPgtoJ.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_J, cdObjectSegmentoPgtoJ);
            #endregion

            #region Segmento J-52 (Detalhe - Registro Opcional)
            cdObjectSegmentoPgtoJ52.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoJ52.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoJ52.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoJ52.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote:";
            cdObjectSegmentoPgtoJ52.CodigoSegmento = "14:1:C:R:0:14-14:J:Erro - Cód. Segmento do Registro Detalhe:";
            cdObjectSegmentoPgtoJ52.CNAB1 = "15:1:C:V:0:15-15: :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            cdObjectSegmentoPgtoJ52.CodigoMovimento = "16:2:N:R:0:16-17::Erro - Código de Movimento Remessa:";
            cdObjectSegmentoPgtoJ52.CodigoRegistroOpcional = "18:2:N:R:0:18-19:52:Erro - Código Reg. Opcional:";
            cdObjectSegmentoPgtoJ52.TipoInscricaoSacado = "20:1:N:R:0:20-20::Erro - Tipo de Inscrição (Sacado):";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoSacado = "21:15:N:R:0:21-35::Erro - Nº de Inscrição (Sacado):";
            cdObjectSegmentoPgtoJ52.NomeSacado = "36:40:C:R:0:36-75::Erro - Nome do Sacado:";
            cdObjectSegmentoPgtoJ52.TipoInscricaoCedente = "76:1:N:R:0:76-76::Erro - Tipo de Inscrição (Cedente):";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoCedente = "77:15:N:R:0:77-91::Erro - Nº de Inscrição (Cedente):";
            cdObjectSegmentoPgtoJ52.NomeCedente = "92:40:C:R:0:92-131::Erro - Nome do Cedente:";
            cdObjectSegmentoPgtoJ52.TipoInscricaoSacador = "132:1:N:R:0:132-132::Erro - Tipo de Inscrição (Sacador):";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoSacador = "133:15:N:R:0:133-147::Erro - Nº de Inscrição (Sacador):";
            cdObjectSegmentoPgtoJ52.NomeSacador = "148:40:C:R:0:148-187::Erro - Nome do Sacador:";
            cdObjectSegmentoPgtoJ52.CNAB2 = "188:53:C:V:0:188-240:                                                  :Erro - Uso Exclusivo FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_J52, cdObjectSegmentoPgtoJ52);
            #endregion

            #region Segmento 5 (Detalhe - Registro Opcional)
            cdObjectSegmentoPgto5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgto5.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectSegmentoPgto5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgto5.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote:";
            cdObjectSegmentoPgto5.CodigoSegmento = "14:1:C:R:0:14-14:5:Erro - Código de Segmento:";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco1 = "15:3:C:V:0:15-17:   :Erro - Uso Exclusivo BRADESCO/CNAB:";
            cdObjectSegmentoPgto5.NumeroListaDebito = "18:9:N:R:0:18-26:5001:Erro - Número da Lista de Débito:";
            cdObjectSegmentoPgto5.HorarioDebito = "27:6:N:R:0:27-32:5002:Erro - Horário do Débito do Pagamento:";
            cdObjectSegmentoPgto5.CodigoLancamentoEspecifico = "33:5:N:R:0:33-37:5003:Erro - Mensagem da Primeira Linha de Extrato:";
            cdObjectSegmentoPgto5.SegundaLinhaExtrato = "38:5:N:R:0:38-42:5004:Erro - Mensagem de Segunda Linha de Extrato:";
            cdObjectSegmentoPgto5.UsoEmpresa = "43:50:C:R:0:43-92:5005:Erro - Uso da Empresa:";
            cdObjectSegmentoPgto5.TipoDocumento = "93:3:N:R:0:93-95:5006:Erro - Tipo de Documento:";
            cdObjectSegmentoPgto5.NumeroDocumento = "96:15:N:R:0:96-110:5007:Erro - Número do documento:";
            cdObjectSegmentoPgto5.SerieDocumento = "111:2:C:R:0:111-112:5008:Erro - Série do Documento:";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco2 = "113:15:C:V:0:113-127:               :Erro - Uso Exclusivo BRADESCO/CNAB:";
            cdObjectSegmentoPgto5.DataEmissaoDocumento = "128:8:N:R:0:128-135::Erro - Data de Emissão do Documento:D";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco3 = "136:95:C:V:0:136-230:                                                                                               :Erro - Uso Exclusivo BRADESCO/CNAB:";
            cdObjectSegmentoPgto5.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_5, cdObjectSegmentoPgto5);
            #endregion

            #region Segmento Z 
            cdObjectSegmentoPgtoZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código no Banco da Compensação:";
            cdObjectSegmentoPgtoZ.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Registro Detalhe de Lote:";
            cdObjectSegmentoPgtoZ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote:";
            cdObjectSegmentoPgtoZ.CodigoSegmento = "14:1:C:R:0:14-14:Z:Erro - Código de Segmento:";
            cdObjectSegmentoPgtoZ.AutenticacaoLegislacao = "15:64:C:R:0:15-78::Erro - Autenticação para atender Legislação:";
            cdObjectSegmentoPgtoZ.AutenticacaoBancaria = "79:25:C:R:0:79-103::Erro - Autenticação Bancária/Protocolo:";
            cdObjectSegmentoPgtoZ.UsoExclusivoFebraban = "104:127:C:V:0:104-230:                                                                                                                               :Erro - Uso CNAB/FEBRABAN:";
            cdObjectSegmentoPgtoZ.OcorrenciasRetorno = "231:10:C:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_Z, cdObjectSegmentoPgtoZ);
            #endregion
            #endregion

            #region PGTO DE TRIBUTOS
            // SEGMENTOS : O , N, N1 GPS , N2 DARF , N3 DARF SIMPLES , N4 GARE SP , W , W1 , 5 , Z

            #region Objetos
            dynamic cdObjectPgtoTrib1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectPgtoTrib5 = new ExpandoObject(); // Trailer de lote
            dynamic cdObjectSegmentoPgtoTribO = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribN = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribN1 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribN2 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribN3 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribN4 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribW = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribW1 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTrib5 = new ExpandoObject();
            dynamic cdObjectSegmentoPgtoTribZ = new ExpandoObject();
            #endregion

            #region HEADER DE LOTE
            cdObjectPgtoTrib1.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectPgtoTrib1.LoteServico = "4:4:N:R:0:4-7:0000:Erro - Lote de Serviço:";
            cdObjectPgtoTrib1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro:";
            cdObjectPgtoTrib1.TipoOperacao = "9:1:A:R:0:9-9:C:Erro - Tipo da Operação:";
            cdObjectPgtoTrib1.TipoServico = "10:2:N:R:0:10-11:20:Erro - Tipo do Serviço:"; // 20 = Pagamento a Fornecedores/Tributos
            cdObjectPgtoTrib1.FormaLancamento = "12:2:N:R:0:12-13:41:Erro - Forma de Lançamento:"; // 41 = DOC/TED
            cdObjectPgtoTrib1.VersaoLayoutLote = "14:3:N:R:0:14-16:012:Erro - Versão do Layout do Lote:";
            cdObjectPgtoTrib1.UsoExclusivoFebraban1 = "17:1:A:V:0:17-17: :Erro - Uso FEBRABAN/CNAB:";
            cdObjectPgtoTrib1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18:2:Erro - Tipo Inscrição (1-CPF/2-CNPJ):";
            cdObjectPgtoTrib1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - CNPJ/CPF da Empresa:";
            cdObjectPgtoTrib1.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio:";
            cdObjectPgtoTrib1.AgenciaMantenedora = "53:5:N:R:0:53-57::Erro - Agência Mantenedora:";
            cdObjectPgtoTrib1.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - DV Agência:";
            cdObjectPgtoTrib1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Conta Corrente:";
            cdObjectPgtoTrib1.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - DV Conta:";
            cdObjectPgtoTrib1.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - DV Ag/Conta:";
            cdObjectPgtoTrib1.NomeEmpresa = "73:30:A:R:0:73-102::Erro - Nome da Empresa:";
            cdObjectPgtoTrib1.Mensagem1 = "103:40:A:V:0:103-142::Erro - Mensagem:";
            cdObjectPgtoTrib1.Logradouro = "143:30:A:V:0:143-172::Erro - Logradouro:";
            cdObjectPgtoTrib1.Numero = "173:5:N:V:0:173-177::Erro - Número:";
            cdObjectPgtoTrib1.Complemento = "178:15:A:V:0:178-192::Erro - Complemento:";
            cdObjectPgtoTrib1.Cidade = "193:20:A:V:0:193-212::Erro - Cidade:";
            cdObjectPgtoTrib1.CEP = "213:5:N:V:0:213-217::Erro - CEP:";
            cdObjectPgtoTrib1.ComplementoCEP = "218:3:A:V:0:218-220::Erro - Compl. CEP:";
            cdObjectPgtoTrib1.Estado = "221:2:A:V:0:221-222::Erro - Estado:";
            cdObjectPgtoTrib1.IndicativoFormaPagamento = "223:2:N:R:0:223-224:01:Erro - Forma Pagamento:"; // 01 = Débito em Conta
            cdObjectPgtoTrib1.UsoExclusivoFebraban2 = "225:6:A:V:0:225-230:      :Erro - Uso FEBRABAN:";
            cdObjectPgtoTrib1.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgTributos, cdObjectPgtoTrib1);
            #endregion

            #region TRAILER DE LOTE
            cdObjectPgtoTrib5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectPgtoTrib5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectPgtoTrib5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro:";
            cdObjectPgtoTrib5.UsoExclusivoFebraban1 = "9:9:A:V:0:9-17:         :Erro - Uso FEBRABAN/CNAB:"; // 9 espaços
            cdObjectPgtoTrib5.QuantidadeRegistros = "18:6:N:R:0:18-23::Erro - Qtde Registros do Lote:";
            cdObjectPgtoTrib5.SomatoriaValores = "24:16:N:R:0:24-41::Erro - Somatória de Valores (2 decimais):";
            cdObjectPgtoTrib5.SomatoriaQuantidadeMoedas = "42:13:N:V:0:42-59::Erro - Somatória Qtde Moedas (5 decimais):";
            cdObjectPgtoTrib5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Nº Aviso de Débito:";
            cdObjectPgtoTrib5.UsoExclusivoFebraban2 = "66:165:A:V:0:66-230:" + new string(' ', 165) + ":Erro - Uso FEBRABAN:";
            cdObjectPgtoTrib5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno:"; JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgTributos, cdObjectPgtoTrib5);
            #endregion

            #region SEGMENTO O
            cdObjectSegmentoPgtoTribO.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoTribO.LoteServico = "4:4:N:R:0:4-7:0001:Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoTribO.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoTribO.NumeroSequencialRegistro = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote:";
            cdObjectSegmentoPgtoTribO.CodigoSegmento = "14:1:A:R:0:14-14:O:Erro - Código Segmento:";
            cdObjectSegmentoPgtoTribO.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento (0=Inclusão):";
            cdObjectSegmentoPgtoTribO.CodigoInstrucaoMovimento = "16:2:N:R:0:16-17::Erro - Código Instrução:";
            cdObjectSegmentoPgtoTribO.CodigoBarras = "18:44:A:R:0:18-61::Erro - Código de Barras (44 dígitos):";
            cdObjectSegmentoPgtoTribO.NomeConcessionaria = "62:30:A:R:0:62-91::Erro - Nome Concessionária:";
            cdObjectSegmentoPgtoTribO.DataVencimento = "92:8:N:R:0:92-99::Erro - Data Vencimento (DDMMAAAA):D";
            cdObjectSegmentoPgtoTribO.DataPagamento = "100:8:N:R:0:100-107::Erro - Data Pagamento (DDMMAAAA):D";
            cdObjectSegmentoPgtoTribO.ValorPagamento = "108:13:N:R:0:108-122::Erro - Valor Pagamento (2 decimais):";
            cdObjectSegmentoPgtoTribO.SeuNumero = "123:20:A:R:0:123-142::Erro - Seu Número (Doc Empresa):";
            cdObjectSegmentoPgtoTribO.NossoNumero = "143:20:A:R:0:143-162::Erro - Nosso Número (Doc Banco):";
            cdObjectSegmentoPgtoTribO.UsoExclusivoFebraban = "163:68:A:V:0:163-230:" + new string(' ', 68) + ":Erro - Uso FEBRABAN:";
            cdObjectSegmentoPgtoTribO.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_O, cdObjectSegmentoPgtoTribO);
            #endregion

            #region SEGMENTO N
            cdObjectSegmentoPgtoTribN.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoTribN.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoTribN.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoTribN.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote:";
            cdObjectSegmentoPgtoTribN.CodigoSegmento = "14:1:A:R:0:14-14:N:Erro - Código Segmento:";
            cdObjectSegmentoPgtoTribN.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento (0=Inclusão/5=Alteração):";
            cdObjectSegmentoPgtoTribN.CodigoInstrucao = "16:2:N:R:0:16-17::Erro - Código Instrução:";
            cdObjectSegmentoPgtoTribN.SeuNumero = "18:20:A:R:0:18-37::Erro - Seu Número (Doc Empresa):";
            cdObjectSegmentoPgtoTribN.NossoNumero = "38:20:A:R:0:38-57::Erro - Nosso Número (Doc Banco):";
            cdObjectSegmentoPgtoTribN.NomeContribuinte = "58:30:A:R:0:58-87::Erro - Nome Contribuinte:";
            cdObjectSegmentoPgtoTribN.DataPagamento = "88:8:N:R:0:88-95::Erro - Data Pagamento (DDMMAAAA):D";
            cdObjectSegmentoPgtoTribN.ValorPagamento = "96:13:N:R:0:96-110::Erro - Valor Pagamento (2 decimais):";
            cdObjectSegmentoPgtoTribN.InformacoesComplementares = "111:120:A:V:0:111-230::Erro - Informações Complementares:";
            cdObjectSegmentoPgtoTribN.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N, cdObjectSegmentoPgtoTribN);
            #endregion

            #region SEGMENTO N1
            cdObjectSegmentoPgtoTribN1.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo:";
            cdObjectSegmentoPgtoTribN1.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ):";
            cdObjectSegmentoPgtoTribN1.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação):";
            cdObjectSegmentoPgtoTribN1.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo:";
            cdObjectSegmentoPgtoTribN1.Competencia = "135:6:N:R:0:135-140::Erro - Competência (MMAAAA):";
            cdObjectSegmentoPgtoTribN1.ValorTributo = "141:13:N:R:0:141-155::Erro - Valor Tributo (2 decimais):";
            cdObjectSegmentoPgtoTribN1.ValorOutrasEntidades = "156:13:N:V:0:156-170::Erro - Valor Outras Entidades (2 decimais):";
            cdObjectSegmentoPgtoTribN1.AtualizacaoMonetaria = "171:13:N:V:0:171-185::Erro - Atualização Monetária (2 decimais):";
            cdObjectSegmentoPgtoTribN1.UsoExclusivoFebraban = "186:45:A:V:0:186-230:" + new string(' ', 45) + ":Erro - Uso FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N1, cdObjectSegmentoPgtoTribN1);
            #endregion

            #region SEGMENTO N2
            cdObjectSegmentoPgtoTribN2.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo:";
            cdObjectSegmentoPgtoTribN2.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ):";
            cdObjectSegmentoPgtoTribN2.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação):";
            cdObjectSegmentoPgtoTribN2.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo:";
            cdObjectSegmentoPgtoTribN2.PeriodoApuracao = "135:8:N:R:0:135-142::Erro - Período Apuração (AAAAMMDD):";
            cdObjectSegmentoPgtoTribN2.NumeroReferencia = "143:17:N:R:0:143-159::Erro - Número Referência:";
            cdObjectSegmentoPgtoTribN2.ValorPrincipal = "160:13:N:R:0:160-174::Erro - Valor Principal (2 decimais):";
            cdObjectSegmentoPgtoTribN2.ValorMulta = "175:13:N:V:0:175-189::Erro - Valor Multa (2 decimais):";
            cdObjectSegmentoPgtoTribN2.ValorJurosEncargos = "190:13:N:V:0:190-204::Erro - Juros/Encargos (2 decimais):";
            cdObjectSegmentoPgtoTribN2.DataVencimento = "205:8:N:R:0:205-212::Erro - Data Vencimento (DDMMAAAA):D";
            cdObjectSegmentoPgtoTribN2.UsoExclusivoFebraban = "213:18:A:V:0:213-230:" + new string(' ', 18) + ":Erro - Uso FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N2, cdObjectSegmentoPgtoTribN2);
            #endregion

            #region SEGMENTO N3
            cdObjectSegmentoPgtoTribN3.CodigoReceitaTributo = "111:6:A:R:0:111-116:6106:Erro - Código da Receita do Tributo (6106=INSS Autônomo):";
            cdObjectSegmentoPgtoTribN3.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ):";
            cdObjectSegmentoPgtoTribN3.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação):";
            cdObjectSegmentoPgtoTribN3.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo:";
            cdObjectSegmentoPgtoTribN3.PeriodoApuracao = "135:8:N:R:0:135-142::Erro - Período Apuração (AAAAMMDD):";
            cdObjectSegmentoPgtoTribN3.ReceitaBruta = "143:13:N:R:0:143-157::Erro - Receita Bruta (2 decimais):";
            cdObjectSegmentoPgtoTribN3.Percentual = "158:5:N:R:0:158-164::Erro - Percentual (2 decimais):"; // Ex: 5,25% = 0525
            cdObjectSegmentoPgtoTribN3.ValorPrincipal = "165:13:N:R:0:165-179::Erro - Valor Principal (2 decimais):";
            cdObjectSegmentoPgtoTribN3.ValorMulta = "180:13:N:V:0:180-194::Erro - Valor Multa (2 decimais):";
            cdObjectSegmentoPgtoTribN3.ValorJurosEncargos = "195:13:N:V:0:195-209::Erro - Juros/Encargos (2 decimais):";
            cdObjectSegmentoPgtoTribN3.UsoExclusivoFebraban = "210:21:A:V:0:210-230:" + new string(' ', 21) + ":Erro - Uso FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N3, cdObjectSegmentoPgtoTribN3);
            #endregion

            #region SEGMENTO N4
            cdObjectSegmentoPgtoTribN4.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo:";
            cdObjectSegmentoPgtoTribN4.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ):";
            cdObjectSegmentoPgtoTribN4.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação):";
            cdObjectSegmentoPgtoTribN4.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo:";
            cdObjectSegmentoPgtoTribN4.DataVencimento = "135:8:N:R:0:135-142::Erro - Data Vencimento (DDMMAAAA):D";
            cdObjectSegmentoPgtoTribN4.InscricaoMunicipalDeclaracao = "143:12:N:R:0:143-154::Erro - IE/Município/Declaração:";
            cdObjectSegmentoPgtoTribN4.DividaAtivaEtiqueta = "155:13:N:R:0:155-167::Erro - Dívida Ativa/N.Etiqueta:";
            cdObjectSegmentoPgtoTribN4.PeriodoReferencia = "168:6:N:R:0:168-173::Erro - Período Referência (MMAAAA):";
            cdObjectSegmentoPgtoTribN4.NumeroParcelaNotificacao = "174:13:N:R:0:174-186::Erro - N.Parcela/Notificação:";
            cdObjectSegmentoPgtoTribN4.ValorReceita = "187:13:N:R:0:187-201::Erro - Valor Receita (2 decimais):";
            cdObjectSegmentoPgtoTribN4.ValorJuros = "202:12:N:V:0:202-215::Erro - Valor Juros (2 decimais):";
            cdObjectSegmentoPgtoTribN4.ValorMulta = "216:12:N:V:0:216-229::Erro - Valor Multa (2 decimais):";
            cdObjectSegmentoPgtoTribN4.UsoExclusivoFebraban = "230:1:A:V:0:230-230: :Erro - Uso FEBRABAN/CNAB:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N4, cdObjectSegmentoPgtoTribN4);
            #endregion

            #region SEGMENTO W
            cdObjectSegmentoPgtoTribW.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoTribW.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoTribW.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoTribW.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote:";
            cdObjectSegmentoPgtoTribW.CodigoSegmento = "14:1:A:R:0:14-14:W:Erro - Código Segmento:";
            cdObjectSegmentoPgtoTribW.NumeroComplementar = "15:1:N:R:0:15-15::Erro - Nº Registro Complementar:";
            cdObjectSegmentoPgtoTribW.IdentificadorUso = "16:1:A:R:0:16-16::Erro - Identificador Uso Info 1/2:";
            cdObjectSegmentoPgtoTribW.InformacaoComplementar1 = "17:80:A:V:0:17-96::Erro - Informação Complementar 1:";
            cdObjectSegmentoPgtoTribW.InformacaoComplementar2 = "97:80:A:V:0:97-176::Erro - Informação Complementar 2:";
            cdObjectSegmentoPgtoTribW.IdentificadorTributo = "177:2:A:V:0:177-178::Erro - Identificador Tributo:";
            cdObjectSegmentoPgtoTribW.InfoComplementarTributo = "179:48:A:V:0:179-228::Erro - Info Complementar Tributo:";
            cdObjectSegmentoPgtoTribW.UsoExclusivoFebraban = "229:2:A:V:0:229-230:  :Erro - Uso FEBRABAN/CNAB:"; // 2 espaços
            cdObjectSegmentoPgtoTribW.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_W, cdObjectSegmentoPgtoTribW);
            #endregion

            #region SEGMENTO W1
            cdObjectSegmentoPgtoTribW1.IdentificadorTributo = "177:2:A:R:0:177-178:FG:Erro - Identificador Tributo (FG=FGTS):";
            cdObjectSegmentoPgtoTribW1.CodigoReceitaTributo = "179:6:A:R:0:179-184::Erro - Código Receita Tributo:";
            cdObjectSegmentoPgtoTribW1.TipoIdentificacaoContribuinte = "185:2:A:R:0:185-186::Erro - Tipo Identificação (01-CPF/02-CNPJ):";
            cdObjectSegmentoPgtoTribW1.IdentificacaoContribuinte = "187:14:A:R:0:187-200::Erro - Identificação Contribuinte:";
            cdObjectSegmentoPgtoTribW1.IdentificadorFGTS = "201:16:A:R:0:201-216::Erro - Identificador FGTS (16 caracteres):";
            cdObjectSegmentoPgtoTribW1.LacreConectividade = "217:9:A:R:0:217-225::Erro - Lacre Conectividade (9 dígitos):";
            cdObjectSegmentoPgtoTribW1.DigitoVerificadorLacre = "226:2:A:R:0:226-227::Erro - Dígito Verificador Lacre:";
            cdObjectSegmentoPgtoTribW1.UsoExclusivoFebraban = "228:1:A:V:0:228-228: :Erro - Uso FEBRABAN/CNAB:"; JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_W1, cdObjectSegmentoPgtoTribW1);
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_W1, cdObjectSegmentoPgtoTribW1);
            #endregion

            #region SEGMENTO 5
            cdObjectSegmentoPgtoTrib5.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoTrib5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoTrib5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoTrib5.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote:";
            cdObjectSegmentoPgtoTrib5.CodigoSegmento = "14:1:A:R:0:14-14:5:Erro - Código Segmento:";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco1 = "15:3:A:V:0:15-17:   :Erro - Uso Bradesco (3 espaços):";
            cdObjectSegmentoPgtoTrib5.NumeroListaDebito = "18:9:N:R:0:18-26::Erro - Nº Lista Débito:";
            cdObjectSegmentoPgtoTrib5.HorarioDebito = "27:6:N:R:0:27-32::Erro - Horário Débito (HHMMSS):";
            cdObjectSegmentoPgtoTrib5.CodigoLancamento = "33:5:N:R:0:33-37::Erro - Código Lançamento:";
            cdObjectSegmentoPgtoTrib5.SegundaLinhaExtrato = "38:5:N:R:0:38-42::Erro - 2ª Linha Extrato:";
            cdObjectSegmentoPgtoTrib5.UsoEmpresa = "43:50:A:V:0:43-92::Erro - Uso Empresa:";
            cdObjectSegmentoPgtoTrib5.TipoDocumento = "93:3:N:R:0:93-95::Erro - Tipo Documento:";
            cdObjectSegmentoPgtoTrib5.NumeroDocumento = "96:15:N:R:0:96-110::Erro - Nº Documento:";
            cdObjectSegmentoPgtoTrib5.SerieDocumento = "111:2:A:R:0:111-112::Erro - Série Documento:";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco2 = "113:15:A:V:0:113-127:               :Erro - Uso Bradesco (15 espaços):";
            cdObjectSegmentoPgtoTrib5.DataEmissao = "128:8:N:R:0:128-135::Erro - Data Emissão (DDMMAAAA):D";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco3 = "136:95:A:V:0:136-230:" + new string(' ', 95) + ":Erro - Uso Bradesco:";
            cdObjectSegmentoPgtoTrib5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_5, cdObjectSegmentoPgtoTrib5);
            #endregion

            #region SEGMENTO Z
            cdObjectSegmentoPgtoTribZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
            cdObjectSegmentoPgtoTribZ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço:";
            cdObjectSegmentoPgtoTribZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro:";
            cdObjectSegmentoPgtoTribZ.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote:";
            cdObjectSegmentoPgtoTribZ.CodigoSegmento = "14:1:A:R:0:14-14:Z:Erro - Código Segmento:";
            cdObjectSegmentoPgtoTribZ.AutenticacaoLegislacao = "15:64:A:R:0:15-78::Erro - Autenticação (64 caracteres):";
            cdObjectSegmentoPgtoTribZ.ProtocoloAutenticacao = "79:25:A:R:0:79-103::Erro - Protocolo Autenticação:";
            cdObjectSegmentoPgtoTribZ.UsoExclusivoFebraban = "104:127:A:V:0:104-230:" + new string(' ', 127) + ":Erro - Uso FEBRABAN:";
            cdObjectSegmentoPgtoTribZ.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno:";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_Z, cdObjectSegmentoPgtoTribZ);
            #endregion

            #endregion

            #region BLOQUETOS ELETRONICOS

            #endregion


            return dynamicList;

        }
    }
}