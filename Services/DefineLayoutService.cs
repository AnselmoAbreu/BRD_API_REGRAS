using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Web.Script.Serialization;

namespace BRD_API_REGRAS.Services
{
    public class DefineLayoutService
    {
        #region Constantes para nome de registro de arquivo
        const string registroZero = "RECORD0";
        const string registroUm = "RECORD1";
        //const string registroDois = "RECORD2";
        //const string registroTres = "RECORD3";
        //const string registroQuatro = "RECORD4";
        const string registroCinco = "RECORD5";
        //const string registroSeis = "RECORD6";
        //const string registroSete = "RECORD7";
        //const string registroOito = "RECORD8";
        const string registroNove = "RECORD9";

        const string segmentoA = "SEGMENTOA";
        const string segmentoB = "SEGMENTOB";
        const string segmentoC = "SEGMENTOC";
        const string segmento5 = "SEGMENTO5";
        const string segmentoZ = "SEGMENTOZ";

        #endregion

        public string MontarJson(string codigoArquivo)
        {
            dynamic dynamicList = new ExpandoObject();

            #region COB400
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
                // : Obrigatório (R = REQUERIDO / V = VAZIO / Z = ZERADO)
                // : Parentesco (0 = PAI / 1 = FILHO)
                // : Posição no manual do bradesco
                // : Valor fixo
                // : Mensagem própria
                // : Campo Data (D)
                //-------------------------------------------------------

                cdObject.IdentificacaoRegistro = "0:1:N:R:0:001-001:0:Campo deve conter [0]:";
                cdObject.IdentificacaoArquivoRemessa = "1:1:N:R:0:002-002:1:Campo deve conter [1]:";
                cdObject.LiteralRemessa = "2:7:C:R:0:003-009:REMESSA:Campo deve conter [REMESSA]:";
                cdObject.CodigoServico = "9:2:N:R:0:010-011:01:Campo deve conter [01]:";
                cdObject.LiteralServico = "11:15:C:R:0:012-026:COBRANCA:Campo deve conter [COBRANCA]:";
                cdObject.CodigoEmpresa = "26:20:N:R:0:027-046::Campo não pode ser igual a zero:";
                cdObject.NomeEmpresa = "46:30:C:R:0:047-076::Campo não pode estar em branco:";
                cdObject.NumeroBradescoCompensacao = "76:3:N:R:0:077-079:237:Campo deve conter [237]:";
                cdObject.NomeBancoExtenso = "79:15:C:R:0:080-094:BRADESCO:Campo deve conter [BRADESCO]:";
                cdObject.DataGravacaoArquivo = "94:6:N:R:0:095-100::Campo deve conter uma data válida:D";
                cdObject.Branco1 = "100:8:C:V:0:101-108::Campo deve estar em branco:";
                cdObject.IdentificacaoSistema = "108:2:C:R:0:109-110:MX:Campo deve conter [MX]:";
                cdObject.NumeroSequencialRemessa = "110:7:N:R:0:111-117::Campo deve conter um número:";
                cdObject.Branco2 = "117:277:C:V:0:118-394::Campo deve estar em branco:";
                cdObject.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número:";

                JsonCdProdutoGenerator.AddProperty(dynamicList, registroZero, cdObject);

                // ========================================================================

                cdObject1.IdentificacaoRegistro = "0:1:N:R:0:001-001:1:Campo deve conter [1]:";
                cdObject1.AgenciaDebito = "1:5:N:R:0:002-006::Campo não pode ser igual a zero:";
                cdObject1.DigitoAgencia = "6:1:C:V:0:007-007:::";
                cdObject1.RazaoContaCorrente = "7:5:N:Z:0:008-012:::";
                cdObject1.ContaCorrente = "12:7:N:Z:0:013-019:::";
                cdObject1.DigitoContaCorrente = "19:1:C:V:0:020-020::Erro genérico:";
                cdObject1.IdEmpresaBeneficiariaBanco = "20:17:C:R:0:021-037::Campo não deve estar em branco:";
                cdObject1.NumeroControlePaticipante = "37:25:C:R:0:038-062::Campo não deve estar em branco:";
                cdObject1.CodigoBancoDebitadoCamaraCompensacao = "62:3:N:R:0:063-065:237:Campo deve conter [237]:";
                cdObject1.CampoMulta = "65:1:N:R:0:066-066:0,2:Campo deve conter [0 ou 2]:";
                cdObject1.PercentualMulta = "66:4:N:R:1:067-070::Campo não deve estar em branco:";
                cdObject1.IdentificacaoTituloBanco = "70:11:N:R:0:071-081::Campo não deve ser preenchido com zeros:";
                cdObject1.DigitoAutoconferenciaNumeroBancario = "81:1:C:R:0:082-082::Campo não deve estar em branco:";
                cdObject1.DescontoBonificacaoDia = "82:10:N:Z:0:083-092:::";
                cdObject1.CondicaoEmissaoPapeletaCobranca = "92:1:N:R:0:093-093:0,1,2:Campo deve conter [0,1,2]:";
                cdObject1.IdentEmiteBoletoDebitoAutomaticao = "93:1:C:R:0:094-094:::";
                cdObject1.IdentificacaoOperacaoBanco = "94:10:C:V:0:095-104::Campo deve estar em branco:";
                cdObject1.IndicadorRateioCredito = "104:1:C:R:0:105-105:R:Campo deve conter [R]:";
                cdObject1.EnderecamentoAvisoDebitoAutomaticoContaCorrente = "105:1:N:R:0:106-106::Campo não deve estar em branco:";
                cdObject1.QuantidadePagamentos = "106:2:C:R:0:107-108::Campo não deve estar em branco:";
                cdObject1.IdentificacaoOcorrencia = "108:2:N:R:0:109-110::Campo não deve ser preenchido com zeros:";
                cdObject1.NumeroDocumento = "110:10:C:R:0:111-120::Campo não deve estar em branco:";
                cdObject1.DataVencimentoTitulo = "120:6:N:R:0:121-126::Campo deve conter uma data válida:D";
                cdObject1.ValorTitulo = "126:13:N:R:0:127-139::Campo não pode ser igual a zero:";
                cdObject1.BancoEncarregadoCobranca = "139:3:N:R:0:140-142:000:Campo deve conter [000]:";
                cdObject1.AgenciaDepositaria = "142:5:N:R:0:143-147:00000:Erro genérico:";
                cdObject1.EspecieTitulo = "147:2:N:R:0:148-149:01,02,03,05,10,11,12,31,32,33,99:Campo deve conter [01,02,03,05,10,11,12,31,32,33,99]:";
                cdObject1.Identificacao = "149:1:C:R:0:150-150:N:Campo deve conter [N]:";
                cdObject1.DataEmissaoTitulo = "150:6:N:R:0:151-156::Campo deve conter uma data válida:D";
                cdObject1.PrimeiraInstrucao = "156:2:N:R:0:157-158::Campo não deve estar em branco:";
                cdObject1.SegundaInstrucao = "158:2:N:R:0:159-160::Campo não deve estar em branco:";
                cdObject1.ValorCobradoDiaAtraso = "160:13:N:R:0:161-173::Campo não deve estar em branco:";
                cdObject1.DataLimiteConcessaoDesconto = "173:6:N:R:0:174-179::Campo deve conter uma data válida:D";
                cdObject1.ValorDesconto = "179:13:N:R:0:180-192::Campo não deve estar em branco:";
                cdObject1.ValorIof = "192:13:N:R:0:193-205::Campo não deve estar em branco:";
                cdObject1.ValorAbatimentoConcedidoOuCancelado = "205:13:N:R:0:206-218::Campo não deve estar em branco:";
                cdObject1.IdentificacaoTipoInscricaoPagador = "218:2:N:R:0:219-220:01,02:Campo deve conter [01,02]:";
                cdObject1.NumeroInscricaoPagador = "220:14:N:R:0:221-234::Campo não deve estar em branco:";
                cdObject1.NomeDoPagador = "234:40:C:R:0:235-274::Campo não deve estar em branco:";
                cdObject1.EnderecoCompleto = "274:40:C:R:0:275-314::Campo não deve estar em branco:";
                cdObject1.PrimeiraMensagem = "314:12:C:R:0:315-326::Campo não deve estar em branco:";
                cdObject1.Cep = "326:5:N:R:0:327-331::Campo não deve estar em branco:";
                cdObject1.SufixoCep = "331:3:N:R:0:332-334::Campo não deve estar em branco:";
                cdObject1.BeneficiarioFinalSegundaMensagem = "334:60:C:R:0:335-394:DECOMPOSIÇÃO:Campo deve conter [DECOMPOSIÇÃO]:";
                cdObject1.NumeroSequencialRegistro = "394:6:N:R:0:395-400::Campo deve conter um número:";

                JsonCdProdutoGenerator.AddProperty(dynamicList, registroUm, cdObject1);

                // ========================================================================
            }
            #endregion

            #region MTP240
            if (codigoArquivo == "MTP240")
            {

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
                // Pgto Através de Crédito em Conta,Cheque,OP,DOC,TED,Pgto. com Autenticação
                // Segmentos : A , B, C , 5 , Z
                //------------------------------------------------------------------------------

                dynamic cdObject0 = new ExpandoObject(); // Header de arquivo
                dynamic cdObject9 = new ExpandoObject(); // Trailer de arquivo

                dynamic cdObject1 = new ExpandoObject(); // Header de lote
                dynamic cdObject5 = new ExpandoObject(); // Trailer de lote

                dynamic cdObjectSegmentoA = new ExpandoObject(); //  Tipo 3
                dynamic cdObjectSegmentoB = new ExpandoObject(); //  Tipo 3
                dynamic cdObjectSegmentoC = new ExpandoObject(); //  Tipo 3
                dynamic cdObjectSegmento5 = new ExpandoObject(); //  Tipo 3
                dynamic cdObjectSegmentoZ = new ExpandoObject(); //  Tipo 3


                // Arquivo -------------------------------------------------------
                //----------------------------------------------------------------
                // Header
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroZero, cdObject0);

                // Trailer
                cdObject9.CodigoBancoCompensacao = "1:3:N:R:0:1-3:237:Erro - Código do Banco na Compensação:";
                cdObject9.LoteServico = "4:4:N:R:0:4-7:9999:Erro - Lote de Serviço:";
                cdObject9.TipoRegistro = "8:1:N:R:0:8-8:9:Erro - Tipo de Registro:";
                cdObject9.UsoExclusivoFebrabanCnab1 = "9:9:C:V:0:9-17:         :Erro - Uso Exclusivo FEBRABAN/CNAB:";
                cdObject9.QuantidadeLotesArquivo = "18:6:N:R:0:18-23::Erro - Quantidade de Lotes do Arquivo:"; //<<<<<<<<<
                cdObject9.QuantidadeRegistrosArquivo = "24:6:N:R:0:24-29::Erro - Quantidade de Registros do Arquivo:"; //<<<<<
                cdObject9.QuantidadeContasConcilLotes = "30:6:N:R:0:30-35::Erro - Qtde de Contas p/ Conc. (Lotes):"; //<<<<<
                cdObject9.UsoExclusivoFebrabanCnab2 = "36:205:C:V:0:36-240:" + new string(' ', 205) + ":Erro - Uso Exclusivo FEBRABAN/CNAB:";
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroNove, cdObject9);

                // Lote ----------------------------------------------------------
                //----------------------------------------------------------------

                // Header
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroUm, cdObject1);

                // Trailer
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, registroCinco, cdObject5);

                // Segmento A ----------------------------------------------------
                //----------------------------------------------------------------
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, segmentoA, cdObjectSegmentoA);

                // Segmento B ----------------------------------------------------
                //----------------------------------------------------------------
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, segmentoB, cdObjectSegmentoB);

                // Segmento C ----------------------------------------------------
                //----------------------------------------------------------------
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
                JsonCdProdutoGenerator.AddProperty(dynamicList, segmentoC, cdObjectSegmentoC);

                // ========================================================================
            }
            #endregion
            // Serializando para JSON
            var serializer = new JavaScriptSerializer();
            string jsonResult = serializer.Serialize(dynamicList);

            // Retornando o JSON como resposta
            return jsonResult;
        }
    }
}