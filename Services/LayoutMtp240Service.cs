using BRD_API_REGRAS.Services.Interfaces;
using System.Dynamic;

namespace BRD_API_REGRAS.Services
{
    public class LayoutMtp240Service: ILayoutMtp240Service
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
        public dynamic MontarJsonMtp240(dynamic dynamicList, string codigoArquivo) // MULTIPAG 240
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
            cdObject0.CodigoBancoCompensacao = "1:3:N:V:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject0.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject0.TipoRegistro = "8:1:N:R:0:8-8:0:Erro - Tipo de Registro::G003";
            cdObject0.UsoExclusivoFebrabanCnab1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject0.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObject0.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObject0.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObject0.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObject0.NumeroConta = "59:12:N:R:0:59-70::Erro - Número de Conta::G010";
            cdObject0.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - Digito Verificador da Conta::G011";
            cdObject0.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - Digito Verificador da Agência/Conta::G012";
            cdObject0.NomeEmpresa = "73:30:A:V:0:73-102::Erro - Nome da Empresa::G013";
            cdObject0.NomeBanco = "103:30:A:V:0:103-132::Erro - Nome do Banco::G014";
            cdObject0.UsoExclusivoFebrabanCnab2 = "133:10:A:V:0:133-142::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.CodigoRemessaRetorno = "143:1:N:V:0:143-143::Erro - Código Remessa/Retorno::G015";
            cdObject0.DataGeracaoArquivo = "144:8:N:V:0:144-151::Erro - Data de Geração do Arquivo:D:G016";
            cdObject0.HoraGeracaoArquivo = "152:6:N:V:0:152-157::Erro - Hora de Geração do Arquivo:D:G017";
            cdObject0.NumeroSequencialArquivo = "158:6:N:R:0:158-163::Erro - Número Sequencial do Arquivo::G018";
            cdObject0.VersaoLayoutArquivo = "164:3:N:R:0:164-166:089:Erro - Versão do Layout do Arquivo::G019";
            cdObject0.DensidadeGravacao = "167:5:N:V:0:167-171::Erro - Densidade de Gravação::G020";
            cdObject0.ReservadoBanco = "172:20:A:V:0:172-191::Erro - Reservado Banco::G021";
            cdObject0.ReservadoEmpresa = "192:20:A:V:0:192-211::Erro - Reservado Empresa::G022";
            cdObject0.UsoExclusivoFebrabanCnab3 = "212:29:A:V:0:212-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroHeaderArquivoZero, cdObject0);
            #endregion

            #region TRAILER ARQUIVO
            cdObject9.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject9.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject9.TipoRegistro = "8:1:N:R:0:8-8:9:Erro - Tipo de Registro::G003";
            cdObject9.UsoExclusivoFebrabanCnab1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject9.QuantidadeLotesArquivo = "18:6:N:R:0:18-23::Erro - Quantidade de Lotes do Arquivo::G049"; //<<<<<<<<<
            cdObject9.QuantidadeRegistrosArquivo = "24:6:N:R:0:24-29::Erro - Quantidade de Registros do Arquivo::G056"; //<<<<<
            cdObject9.QuantidadeContasConcilLotes = "30:6:N:R:0:30-35::Erro - Qtde de Contas p/ Conc. (Lotes)::G037"; //<<<<<
            cdObject9.UsoExclusivoFebrabanCnab2 = "36:205:A:V:0:36-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroHeaderArquivoNove, cdObject9);
            #endregion

            #region HEADER LOTE
            cdObject1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObject1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo da Operação::G028";
            cdObject1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço::G025";
            cdObject1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento::G029";
            cdObject1.VersaoLayoutLote = "14:3:N:R:0:14-16:045:Erro - Nº da Versão do Layout do Lote::G030";
            cdObject1.UsoExclusivoFebrabanCnab1 = "17:1:A:V:0:17-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObject1.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObject1.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObject1.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObject1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Número da Conta Corrente::G010";
            cdObject1.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObject1.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - Dígito Verificador da Agência/Conta::G012";
            cdObject1.NomeEmpresa = "73:30:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObject1.Mensagem = "103:40:A:V:0:103-142::Erro - Mensagem::G031";
            cdObject1.Logradouro = "143:30:A:V:0:143-172::Erro - Logradouro::G032";
            cdObject1.NumeroLocal = "173:5:N:V:0:173-177::Erro - Número do Local::G032";
            cdObject1.Complemento = "178:15:A:V:0:178-192::Erro - Complemento::G032";
            cdObject1.Cidade = "193:20:A:V:0:193-212::Erro - Cidade::G033";
            cdObject1.CEP = "213:5:N:V:0:213-217::Erro - CEP::G034";
            cdObject1.ComplementoCEP = "218:3:A:V:0:218-220::Erro - Complemento do CEP::G035";
            cdObject1.Estado = "221:2:A:V:0:221-222::Erro - Estado::G036";
            cdObject1.IndicativoFormaPagamento = "223:2:N:R:0:223-224::Erro - Indicativo de Forma de Pagamento::P014";
            cdObject1.UsoExclusivoFebrabanCnab2 = "225:6:A:V:0:225-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgVarios, cdObject1);
            #endregion

            #region TRAILER DE LOTE
            cdObject5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObject5.UsoExclusivoFebrabanCnab1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN-CNAB::G004";
            cdObject5.QuantidadeRegistrosLote = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote::G057";
            cdObject5.SomatoriaValores = "24:16:N:R:0:24-41::Erro - Somatória de Valores::P007";
            cdObject5.SomatoriaQuantidadeMoedas = "42:13:N:R:0:42-59::Erro - Somatória de Quantidade de Moedas::G058";
            cdObject5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Número Aviso de Débito::G066";
            cdObject5.UsoExclusivoFebrabanCnab2 = "66:165:A:V:0:66-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgVarios, cdObject5);
            #endregion

            #region SEGMENTO A 
            cdObjectSegmentoA.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoA.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoA.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoA.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoA.CodigoSegmento = "14:1:A:R:0:14-14:A:Erro - Código de Segmento::G039";
            cdObjectSegmentoA.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento::G060";
            cdObjectSegmentoA.CodigoInstrucaoMovimento = "16:2:N:V:0:16-17::Erro - Código da Instrução::G061";
            cdObjectSegmentoA.CodigoCamaraCentralizadora = "18:3:N:R:0:18-20::Erro - Código da Câmara Centralizadora::P001";
            cdObjectSegmentoA.CodigoBancoFavorecido = "21:3:N:R:0:21-23::Erro - Código do Banco do Favorecido::P002";
            cdObjectSegmentoA.AgenciaFavorecido = "24:5:N:R:0:24-28::Erro - Agência do Favorecido::G008";
            cdObjectSegmentoA.DVAgenciaFavorecido = "29:1:A:R:0:29-29::Erro - DV Agência::G009";
            cdObjectSegmentoA.ContaCorrenteFavorecido = "30:12:N:R:0:30-41::Erro - Conta Corrente::G010";
            cdObjectSegmentoA.DVContaFavorecido = "42:1:A:R:0:42-42::Erro - DV Conta::G011";
            cdObjectSegmentoA.DVAgenciaContaFavorecido = "43:1:A:R:0:43-43::Erro - DV Agência/Conta::G012";
            cdObjectSegmentoA.NomeFavorecido = "44:30:A:R:0:44-73::Erro - Nome do Favorecido::G013";
            cdObjectSegmentoA.NumeroDocumentoEmpresa = "74:20:A:V:0:74-93::Erro - Nº Documento Empresa::G064";
            cdObjectSegmentoA.DataPagamento = "94:8:N:R:0:94-101::Erro - Data Pagamento:D:P009";
            cdObjectSegmentoA.TipoMoeda = "102:3:A:R:0:102-104::Erro - Tipo Moeda::G040";
            cdObjectSegmentoA.QuantidadeMoeda = "105:15:N:V:0:105-119::Erro - Quantidade Moeda::G041";
            cdObjectSegmentoA.ValorPagamento = "120:15:N:R:0:120-134::Erro - Valor Pagamento::P010";
            cdObjectSegmentoA.NossoNumero = "135:20:A:V:0:135-154::Erro - Nosso Número::G043";
            cdObjectSegmentoA.DataRealPagamento = "155:8:N:V:0:155-162::Erro - Data Real Pagamento:D:P003";
            cdObjectSegmentoA.ValorRealPagamento = "163:15:N:V:0:163-177::Erro - Valor Real Pagamento::P004";
            cdObjectSegmentoA.InformacoesAdicionais = "178:40:A:V:0:178-217::Erro - Informações Adicionais::G031";
            cdObjectSegmentoA.CodigoFinalidadeDoc = "218:2:A:V:0:218-219::Erro - Finalidade Doc::P005";
            cdObjectSegmentoA.CodigoFinalidadeTED = "220:5:A:R:0:220-224::Erro - Finalidade TED::P011";
            cdObjectSegmentoA.ComplementoFinalidade = "225:2:A:V:0:225-226::Erro - Complemento Finalidade::P003";
            cdObjectSegmentoA.UsoExclusivoFebraban1 = "227:3:A:V:0:227-229::Erro - Uso FEBRABAN::G004";
            cdObjectSegmentoA.AvisoFavorecido = "230:1:N:V:0:230-230::Erro - Aviso Favorecido::P006";
            cdObjectSegmentoA.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosA, cdObjectSegmentoA);
            #endregion

            #region SEGMENTO B 
            cdObjectSegmentoB.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco::G001";
            cdObjectSegmentoB.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoB.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo Registro::G003";
            cdObjectSegmentoB.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote::G038";
            cdObjectSegmentoB.CodigoSegmento = "14:1:A:R:0:14-14:B:Erro - Segmento::G039";
            cdObjectSegmentoB.UsoExclusivoFebraban1 = "15:3:A:V:0:15-17:   :Erro - Uso FEBRABAN 1::G004";
            cdObjectSegmentoB.TipoInscricaoFavorecido = "18:1:N:R:0:18-18::Erro - Tipo Inscrição::G005";
            cdObjectSegmentoB.NumeroInscricaoFavorecido = "19:14:N:R:0:19-32::Erro - Nº Inscrição::G006";
            cdObjectSegmentoB.Logradouro = "33:30:A:V:0:33-62::Erro - Logradouro::G032";
            cdObjectSegmentoB.NumeroLocal = "63:5:N:V:0:63-67::Erro - Número Local::G032";
            cdObjectSegmentoB.Complemento = "68:15:A:V:0:68-82::Erro - Complemento::G032";
            cdObjectSegmentoB.Bairro = "83:15:A:V:0:83-97::Erro - Bairro::G032";
            cdObjectSegmentoB.Cidade = "98:20:A:V:0:98-117::Erro - Cidade::G033";
            cdObjectSegmentoB.CEP = "118:5:N:V:0:118-122::Erro - CEP::G034";
            cdObjectSegmentoB.ComplementoCEP = "123:3:A:V:0:123-125::Erro - Compl. CEP::G035";
            cdObjectSegmentoB.Estado = "126:2:A:V:0:126-127::Erro - Estado::G036";
            cdObjectSegmentoB.DataVencimento = "128:8:N:V:0:128-135::Erro - Vencimento:D:G044";
            cdObjectSegmentoB.ValorDocumento = "136:15:N:V:0:136-150::Erro - Valor Documento::G042";
            cdObjectSegmentoB.ValorAbatimento = "151:15:N:V:0:151-165::Erro - Abatimento::G045";
            cdObjectSegmentoB.ValorDesconto = "166:15:N:V:0:166-180::Erro - Desconto::G046";
            cdObjectSegmentoB.ValorMora = "181:15:N:V:0:181-195::Erro - Mora::G047";
            cdObjectSegmentoB.ValorMulta = "196:15:N:V:0:196-210::Erro - Multa::G048";
            cdObjectSegmentoB.CodigoDocumentoFavorecido = "211:15:A:V:0:211-225::Erro - Cód. Documento::P008";
            cdObjectSegmentoB.AvisoFavorecido = "226:1:N:V:0:226-226::Erro - Aviso::P006";
            cdObjectSegmentoB.CodigoUGCentralizadora = "227:6:N:V:0:227-232::Erro - Cód. UG::P012";
            cdObjectSegmentoB.CodigoISPB = "233:8:N:V:0:233-240::Erro - Cód. ISPB::P015";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosB, cdObjectSegmentoB);
            #endregion

            #region SEGMENTO C 
            cdObjectSegmentoC.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco::G001";
            cdObjectSegmentoC.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoC.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoC.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote::G038";
            cdObjectSegmentoC.CodigoSegmento = "14:1:A:R:0:14-14:C:Erro - Segmento::G039";
            cdObjectSegmentoC.UsoExclusivoFebraban1 = "15:3:A:V:0:15-17:" + new string(' ', 3) + ":Erro - Uso FEBRABAN 1::G004";
            cdObjectSegmentoC.ValorIR = "18:15:N:V:0:18-32::Erro - Valor IR::G050";
            cdObjectSegmentoC.ValorISS = "33:15:N:V:0:33-47::Erro - Valor ISS::G051";
            cdObjectSegmentoC.ValorIOF = "48:15:N:V:0:48-62::Erro - Valor IOF::G052";
            cdObjectSegmentoC.OutrasDeducoes = "63:15:N:V:0:63-77::Erro - Outras Deduções::G053";
            cdObjectSegmentoC.OutrosAcrescimos = "78:15:N:V:0:78-92::Erro - Outros Acréscimos::G054";
            cdObjectSegmentoC.AgenciaFavorecido = "93:5:N:R:0:93-97::Erro - Agência Favorecido::G008";
            cdObjectSegmentoC.DVAgenciaFavorecido = "98:1:A:R:0:98-98::Erro - DV Agência::G009";
            cdObjectSegmentoC.NumeroContaCorrente = "99:12:N:R:0:99-110::Erro - Conta Corrente::G010";
            cdObjectSegmentoC.DVContaFavorecido = "111:1:A:R:0:111-111::Erro - DV Conta::G011";
            cdObjectSegmentoC.DVAgenciaContaFavorecido = "112:1:A:R:0:112-112::Erro - DV Agência/Conta::G012";
            cdObjectSegmentoC.ValorINSS = "113:15:N:V:0:113-127::Erro - Valor INSS::G055";
            cdObjectSegmentoC.UsoExclusivoFebraban2 = "128:113:A:V:0:128-240::Erro - Uso FEBRABAN 2::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosC, cdObjectSegmentoC);
            #endregion

            #region SEGMENTO 5 
            cdObjectSegmento5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco::G001";
            cdObjectSegmento5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmento5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmento5.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote::G038";
            cdObjectSegmento5.CodigoSegmento = "14:1:A:R:0:14-14:5:Erro - Segmento::G039";
            cdObjectSegmento5.UsoExclusivoBradesco1 = "15:3:A:V:0:15-17::Erro - Uso Bradesco 1::G004";
            cdObjectSegmento5.ListaDebito = "18:9:N:V:0:18-26::Erro - Lista Débito::5001";
            cdObjectSegmento5.HorarioDebito = "27:6:N:V:0:27-32::Erro - Horário Débito::5002";
            cdObjectSegmento5.CodigoLancamentoEspecifico = "33:5:N:V:0:33-37::Erro - Cód. Lançamento::5003";
            cdObjectSegmento5.SegundaLinhaExtrato = "38:5:N:V:0:38-42::Erro - 2ª Linha Extrato::5004";
            cdObjectSegmento5.UsoEmpresa = "43:50:A:V:0:43-92::Erro - Uso Empresa::5005";
            cdObjectSegmento5.TipoDocumento = "93:3:N:V:0:93-95::Erro - Tipo Documento::5006";
            cdObjectSegmento5.NumeroDocumento = "96:15:N:V:0:96-110::Erro - Nº Documento::5007";
            cdObjectSegmento5.SerieDocumento = "111:2:A:V:0:111-112::Erro - Série Documento::5008";
            cdObjectSegmento5.UsoExclusivoBradesco2 = "113:15:A:V:0:113-127::Erro - Uso Bradesco 2::G004";
            cdObjectSegmento5.DataEmissaoDocumento = "128:8:N:V:0:128-135:D:Erro - Emissão Documento:D:5010";
            cdObjectSegmento5.NomeReclamanteTED = "136:30:A:V:0:136-165::Erro - Nome Reclamante::5011";
            cdObjectSegmento5.NumeroProcessoTED = "166:25:A:V:0:166-190::Erro - Nº Processo::5011";
            cdObjectSegmento5.PISPASEPTED = "191:15:A:V:0:191-205::Erro - PIS/PASEP::5011";
            cdObjectSegmento5.UsoExclusivoBradesco3 = "206:25:A:V:0:206-230::Erro - Uso Bradesco 3::G004";
            cdObjectSegmento5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVarios5, cdObjectSegmento5);
            #endregion

            #region SEGMENTO Z 
            cdObjectSegmentoZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco::G001";
            cdObjectSegmentoZ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoZ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Registro Lote::G038";
            cdObjectSegmentoZ.CodigoSegmento = "14:1:A:R:0:14-14:Z:Erro - Segmento::G039";
            cdObjectSegmentoZ.AutenticacaoLegislacao = "15:64:A:V:0:15-78::Erro - Autenticação Legislativa::Z001";
            cdObjectSegmentoZ.ControleBancario = "79:25:A:V:0:79-103::Erro - Controle Bancário::Z002";
            cdObjectSegmentoZ.UsoCnabFebraban = "104:127:A:V:0:104-230::Erro - Uso CNAB/FEBRABAN::G004";
            cdObjectSegmentoZ.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoVariosZ, cdObjectSegmentoZ);

            //------------------------------------------------------------------------------
            #endregion
            #endregion

            #region PGTO DE TÍTULOS DE COBRANÇA
            // SEGMENTOS : J , J52, 5 , Z

            #region Objetos
            dynamic cdObjectHeaderLotePgto1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectTrailerLotePgto5 = new ExpandoObject(); // Trailer de lote

            dynamic cdObjectSegmentoPgtoJ = new ExpandoObject();   //  Tipo 3
            dynamic cdObjectSegmentoPgtoJ52 = new ExpandoObject(); //  Tipo 3
            dynamic cdObjectSegmentoPgto5 = new ExpandoObject();   //  Tipo 3
            dynamic cdObjectSegmentoPgtoZ = new ExpandoObject();   //  Tipo 3
            #endregion

            #region Header Lote
            cdObjectHeaderLotePgto1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectHeaderLotePgto1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectHeaderLotePgto1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObjectHeaderLotePgto1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo da Operação::G028";
            cdObjectHeaderLotePgto1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço::G025";
            cdObjectHeaderLotePgto1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento::G029";
            cdObjectHeaderLotePgto1.VersaoLayoutLote = "14:3:N:R:0:14-16:040:Erro - Nº da Versão do Layout do Lote::G030";
            cdObjectHeaderLotePgto1.UsoExclusivoFebrabanCnab1 = "17:1:A:V:0:17-17: :Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectHeaderLotePgto1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObjectHeaderLotePgto1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObjectHeaderLotePgto1.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObjectHeaderLotePgto1.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObjectHeaderLotePgto1.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObjectHeaderLotePgto1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Número da Conta Corrente::G010";
            cdObjectHeaderLotePgto1.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObjectHeaderLotePgto1.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - Dígito Verificador da Agência/Conta::G012";
            cdObjectHeaderLotePgto1.NomeEmpresa = "73:30:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObjectHeaderLotePgto1.Mensagem = "103:40:A:V:0:103-142::Erro - Mensagem::G031";
            cdObjectHeaderLotePgto1.Logradouro = "143:30:A:V:0:143-172::Erro - Logradouro::G032";
            cdObjectHeaderLotePgto1.NumeroLocal = "173:5:N:V:0:173-177::Erro - Número do Local::G032";
            cdObjectHeaderLotePgto1.Complemento = "178:15:A:V:0:178-192::Erro - Complemento::G032";
            cdObjectHeaderLotePgto1.Cidade = "193:20:A:V:0:193-212::Erro - Cidade::G033";
            cdObjectHeaderLotePgto1.CEP = "213:5:N:V:0:213-217::Erro - CEP::G034";
            cdObjectHeaderLotePgto1.ComplementoCEP = "218:3:A:V:0:218-220::Erro - Complemento do CEP::G035";
            cdObjectHeaderLotePgto1.Estado = "221:2:A:V:0:221-222::Erro - Estado::G036";
            cdObjectHeaderLotePgto1.UsoExclusivoFebrabanCnab2 = "223:8:A:V:0:223-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectHeaderLotePgto1.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgTitulos, cdObjectHeaderLotePgto1);

            #endregion

            #region TRAILER DE LOTE
            cdObjectTrailerLotePgto5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectTrailerLotePgto5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectTrailerLotePgto5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObjectTrailerLotePgto5.UsoExclusivoFebrabanCnab1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004"; // 9 espaços
            cdObjectTrailerLotePgto5.QuantidadeRegistrosLote = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote::G057";
            cdObjectTrailerLotePgto5.SomatoriaValores = "24:18:N:V:0:24-41::Erro - Somatória de Valores::P007"; // 16 inteiros + 2 decimais
            cdObjectTrailerLotePgto5.SomatoriaQuantidadeMoedas = "42:18:N:V:0:42-59::Erro - Somatória de Quantidade de Moedas::G058"; // 13 inteiros + 5 decimais
            cdObjectTrailerLotePgto5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Número Aviso de Débito::G066";
            cdObjectTrailerLotePgto5.UsoExclusivoFebrabanCnab2 = "66:165:A:V:0:66-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004"; // 165 espaços
            cdObjectTrailerLotePgto5.OcorrenciasRetorno = "231:10:A:R:0:231-240::Erro - Ocorrências para Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgTitulos, cdObjectTrailerLotePgto5);
            #endregion

            #region Segmento J (Detalhe)
            cdObjectSegmentoPgtoJ.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco da Compensação::G001";
            cdObjectSegmentoPgtoJ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoJ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoJ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoPgtoJ.CodigoSegmento = "14:1:A:R:0:14-14:J:Erro - Código de Segmento::G039";
            cdObjectSegmentoPgtoJ.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento::G060";
            cdObjectSegmentoPgtoJ.CodigoInstrucao = "16:2:N:R:0:16-17::Erro - Código da Instrução p/ Movimento::G061";
            cdObjectSegmentoPgtoJ.CodigoBarras = "18:44:N:R:0:18-61::Erro - Código de Barras::G063";
            cdObjectSegmentoPgtoJ.NomeCedente = "62:30:A:R:0:62-91::Erro - Nome do Cedente::G013";
            cdObjectSegmentoPgtoJ.DataVencimento = "92:8:N:R:0:92-99::Erro - Data do Vencimento:D:G044";
            cdObjectSegmentoPgtoJ.ValorTitulo = "100:15:N:R:0:100-114::Erro - Valor do Título::G042";
            cdObjectSegmentoPgtoJ.ValorDescontoAbatimento = "115:15:N:R:0:115-129::Erro - Valor do Desconto + Abatimento::L002";
            cdObjectSegmentoPgtoJ.ValorMoraMulta = "130:15:N:R:0:130-144::Erro - Valor da Mora + Multa::L003";
            cdObjectSegmentoPgtoJ.DataPagamento = "145:8:N:R:0:145-152::Erro - Data do Pagamento:D:P009";
            cdObjectSegmentoPgtoJ.ValorPagamento = "153:15:N:R:0:153-167::Erro - Valor do Pagamento::P010";
            cdObjectSegmentoPgtoJ.QuantidadeMoeda = "168:15:N:R:0:168-182::Erro - Quantidade da Moeda::G041";
            cdObjectSegmentoPgtoJ.ReferenciaSacado = "183:20:A:R:0:183-202::Erro - Referência do Sacado::G064";
            cdObjectSegmentoPgtoJ.NossoNumero = "203:20:A:R:0:203-222::Erro - Nosso Número::G043";
            cdObjectSegmentoPgtoJ.CodigoMoeda = "223:2:N:R:0:223-224:09:Erro - Código de Moeda::G065";
            cdObjectSegmentoPgtoJ.UsoExclusivoFebraban = "225:6:A:V:0:225-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectSegmentoPgtoJ.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_J, cdObjectSegmentoPgtoJ);
            #endregion

            #region Segmento J-52 (Detalhe - Registro Opcional)
            cdObjectSegmentoPgtoJ52.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoJ52.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoJ52.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoJ52.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoPgtoJ52.CodigoSegmento = "14:1:A:R:0:14-14:J:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObjectSegmentoPgtoJ52.CNAB1 = "15:1:A:V:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectSegmentoPgtoJ52.CodigoMovimento = "16:2:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";
            
            // A linha abaixo está com erro estava G067 , vide e-mail da Vanessa do Bradesco
            cdObjectSegmentoPgtoJ52.CodigoRegistroOpcional = "18:2:A:R:0:18-19::Erro - Código Reg. Opcional::BRCO";
            
            cdObjectSegmentoPgtoJ52.TipoInscricaoSacado = "20:1:N:R:0:20-20::Erro - Tipo de Inscrição (Sacado)::G005";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoSacado = "21:15:N:R:0:21-35::Erro - Nº de Inscrição (Sacado)::G006";
            cdObjectSegmentoPgtoJ52.NomeSacado = "36:40:A:R:0:36-75::Erro - Nome do Sacado::G013";
            cdObjectSegmentoPgtoJ52.TipoInscricaoCedente = "76:1:N:R:0:76-76::Erro - Tipo de Inscrição (Cedente)::G005";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoCedente = "77:15:N:R:0:77-91::Erro - Nº de Inscrição (Cedente)::G006";
            cdObjectSegmentoPgtoJ52.NomeCedente = "92:40:A:R:0:92-131::Erro - Nome do Cedente::G013";
            cdObjectSegmentoPgtoJ52.TipoInscricaoSacador = "132:1:N:R:0:132-132::Erro - Tipo de Inscrição (Sacador)::G005";
            cdObjectSegmentoPgtoJ52.NumeroInscricaoSacador = "133:15:N:R:0:133-147::Erro - Nº de Inscrição (Sacador)::G006";
            cdObjectSegmentoPgtoJ52.NomeSacador = "148:40:A:R:0:148-187::Erro - Nome do Sacador::G013";
            cdObjectSegmentoPgtoJ52.CNAB2 = "188:53:A:V:0:188-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_J52, cdObjectSegmentoPgtoJ52);
            #endregion

            #region Segmento 5 (Detalhe - Registro Opcional)
            cdObjectSegmentoPgto5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgto5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgto5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgto5.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoPgto5.CodigoSegmento = "14:1:A:R:0:14-14:5:Erro - Código de Segmento::G039";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco1 = "15:3:A:V:0:15-17::Erro - Uso Exclusivo BRADESCO/CNAB::G004";
            cdObjectSegmentoPgto5.NumeroListaDebito = "18:9:N:R:0:18-26:5001:Erro - Número da Lista de Débito::5001";
            cdObjectSegmentoPgto5.HorarioDebito = "27:6:N:R:0:27-32:5002:Erro - Horário do Débito do Pagamento::5002";
            cdObjectSegmentoPgto5.CodigoLancamentoEspecifico = "33:5:N:R:0:33-37:5003:Erro - Mensagem da Primeira Linha de Extrato::5003";
            cdObjectSegmentoPgto5.SegundaLinhaExtrato = "38:5:N:R:0:38-42:5004:Erro - Mensagem de Segunda Linha de Extrato::5004";
            cdObjectSegmentoPgto5.UsoEmpresa = "43:50:A:R:0:43-92:5005:Erro - Uso da Empresa::5005";
            cdObjectSegmentoPgto5.TipoDocumento = "93:3:N:R:0:93-95:5006:Erro - Tipo de Documento::5006";
            cdObjectSegmentoPgto5.NumeroDocumento = "96:15:N:R:0:96-110:5007:Erro - Número do documento::5007";
            cdObjectSegmentoPgto5.SerieDocumento = "111:2:A:R:0:111-112:5008:Erro - Série do Documento::5008";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco2 = "113:15:A:V:0:113-127::Erro - Uso Exclusivo BRADESCO/CNAB::G004";
            cdObjectSegmentoPgto5.DataEmissaoDocumento = "128:8:N:R:0:128-135::Erro - Data de Emissão do Documento:D:5010";
            cdObjectSegmentoPgto5.UsoExclusivoBradesco3 = "136:95:A:V:0:136-230::Erro - Uso Exclusivo BRADESCO/CNAB::G004";
            cdObjectSegmentoPgto5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_5, cdObjectSegmentoPgto5);
            #endregion

            #region Segmento Z 
            cdObjectSegmentoPgtoZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco da Compensação::G001";
            cdObjectSegmentoPgtoZ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Registro Detalhe de Lote::G003";
            cdObjectSegmentoPgtoZ.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectSegmentoPgtoZ.CodigoSegmento = "14:1:A:R:0:14-14:Z:Erro - Código de Segmento::G039";
            cdObjectSegmentoPgtoZ.AutenticacaoLegislacao = "15:64:A:R:0:15-78::Erro - Autenticação para atender Legislação::Z001";
            cdObjectSegmentoPgtoZ.AutenticacaoBancaria = "79:25:A:R:0:79-103::Erro - Autenticação Bancária/Protocolo::Z002";
            cdObjectSegmentoPgtoZ.UsoExclusivoFebraban = "104:127:A:V:0:104-230::Erro - Uso CNAB/FEBRABAN::G004";
            cdObjectSegmentoPgtoZ.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTit_Z, cdObjectSegmentoPgtoZ);
            #endregion
            #endregion

            #region PGTO DE TRIBUTOS
            // SEGMENTOS : O , N, N1 GPS , N2 DARF , N3 DARF SIMPLES , N4 GARE SP , W , W1 , 5 , Z

            #region Objetos
            dynamic cdObjectPgtoTribHeader1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectPgtoTribTrailer5 = new ExpandoObject(); // Trailer de lote
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
            cdObjectPgtoTribHeader1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectPgtoTribHeader1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectPgtoTribHeader1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObjectPgtoTribHeader1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo da Operação::G028";
            cdObjectPgtoTribHeader1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço::G025"; // 20 = Pagamento a Fornecedores/Tributos
            cdObjectPgtoTribHeader1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento::G029"; // 41 = DOC/TED
            cdObjectPgtoTribHeader1.VersaoLayoutLote = "14:3:N:R:0:14-16:012:Erro - Versão do Layout do Lote::G030";
            cdObjectPgtoTribHeader1.UsoExclusivoFebraban1 = "17:1:A:V:0:17-17::Erro - Uso FEBRABAN/CNAB::G004";
            cdObjectPgtoTribHeader1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo Inscrição (1-CPF/2-CNPJ)::G005";
            cdObjectPgtoTribHeader1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - CNPJ/CPF da Empresa::G006";
            cdObjectPgtoTribHeader1.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio::G007";
            cdObjectPgtoTribHeader1.AgenciaMantenedora = "53:5:N:R:0:53-57::Erro - Agência Mantenedora::G008";
            cdObjectPgtoTribHeader1.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - DV Agência::G009";
            cdObjectPgtoTribHeader1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Conta Corrente::G010";
            cdObjectPgtoTribHeader1.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - DV Conta::G011";
            cdObjectPgtoTribHeader1.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - DV Ag/Conta::G012";
            cdObjectPgtoTribHeader1.NomeEmpresa = "73:30:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObjectPgtoTribHeader1.Mensagem1 = "103:40:A:V:0:103-142::Erro - Mensagem::G031";
            cdObjectPgtoTribHeader1.Logradouro = "143:30:A:V:0:143-172::Erro - Logradouro::G032";
            cdObjectPgtoTribHeader1.Numero = "173:5:N:V:0:173-177::Erro - Número::G032";
            cdObjectPgtoTribHeader1.Complemento = "178:15:A:V:0:178-192::Erro - Complemento::G032";
            cdObjectPgtoTribHeader1.Cidade = "193:20:A:V:0:193-212::Erro - Cidade::G033";
            cdObjectPgtoTribHeader1.CEP = "213:5:N:V:0:213-217::Erro - CEP::G034";
            cdObjectPgtoTribHeader1.ComplementoCEP = "218:3:A:V:0:218-220::Erro - Compl. CEP::G035";
            cdObjectPgtoTribHeader1.Estado = "221:2:A:V:0:221-222::Erro - Estado::G036";
            cdObjectPgtoTribHeader1.IndicativoFormaPagamento = "223:2:N:R:0:223-224::Erro - Forma Pagamento::P014"; // 01 = Débito em Conta
            cdObjectPgtoTribHeader1.UsoExclusivoFebraban2 = "225:6:A:V:0:225-230::Erro - Uso FEBRABAN::G004";
            cdObjectPgtoTribHeader1.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_PgTributos, cdObjectPgtoTribHeader1);
            #endregion

            #region TRAILER DE LOTE
            cdObjectPgtoTribTrailer5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectPgtoTribTrailer5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectPgtoTribTrailer5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObjectPgtoTribTrailer5.UsoExclusivoFebraban1 = "9:9:A:V:0:9-17::Erro - Uso FEBRABAN/CNAB::G004";
            cdObjectPgtoTribTrailer5.QuantidadeRegistros = "18:6:N:R:0:18-23::Erro - Qtde Registros do Lote::G057";
            cdObjectPgtoTribTrailer5.SomatoriaValores = "24:16:N:R:0:24-41::Erro - Somatória de Valores (2 decimais)::P007";
            cdObjectPgtoTribTrailer5.SomatoriaQuantidadeMoedas = "42:13:N:V:0:42-59::Erro - Somatória Qtde Moedas (5 decimais)::G058";
            cdObjectPgtoTribTrailer5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Nº Aviso de Débito::G066";
            cdObjectPgtoTribTrailer5.UsoExclusivoFebraban2 = "66:165:A:V:0:66-230::Erro - Uso FEBRABAN::G004";
            cdObjectPgtoTribTrailer5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_PgTributos, cdObjectPgtoTribTrailer5);
            #endregion

            #region SEGMENTO O
            cdObjectSegmentoPgtoTribO.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoTribO.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoTribO.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoTribO.NumeroSequencialRegistro = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectSegmentoPgtoTribO.CodigoSegmento = "14:1:A:R:0:14-14:O:Erro - Código Segmento::G039";
            cdObjectSegmentoPgtoTribO.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento (0=Inclusão)::G060";
            cdObjectSegmentoPgtoTribO.CodigoInstrucaoMovimento = "16:2:N:R:0:16-17::Erro - Código Instrução::G061";
            cdObjectSegmentoPgtoTribO.CodigoBarras = "18:44:A:R:0:18-61::Erro - Código de Barras (44 dígitos)::N001";
            cdObjectSegmentoPgtoTribO.NomeConcessionaria = "62:30:A:R:0:62-91::Erro - Nome Concessionária::G013";
            cdObjectSegmentoPgtoTribO.DataVencimento = "92:8:N:R:0:92-99::Erro - Data Vencimento (DDMMAAAA):D:G044";
            cdObjectSegmentoPgtoTribO.DataPagamento = "100:8:N:R:0:100-107::Erro - Data Pagamento (DDMMAAAA):D:P009";
            cdObjectSegmentoPgtoTribO.ValorPagamento = "108:13:N:R:0:108-122::Erro - Valor Pagamento (2 decimais)::P004";
            cdObjectSegmentoPgtoTribO.SeuNumero = "123:20:A:R:0:123-142::Erro - Seu Número (Doc Empresa)::G064";
            cdObjectSegmentoPgtoTribO.NossoNumero = "143:20:A:R:0:143-162::Erro - Nosso Número (Doc Banco)::G043";
            cdObjectSegmentoPgtoTribO.UsoExclusivoFebraban = "163:68:A:V:0:163-230::Erro - Uso FEBRABAN::G004";
            cdObjectSegmentoPgtoTribO.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_O, cdObjectSegmentoPgtoTribO);
            #endregion

            #region SEGMENTO N
            cdObjectSegmentoPgtoTribN.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoTribN.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoTribN.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoTribN.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectSegmentoPgtoTribN.CodigoSegmento = "14:1:A:R:0:14-14:N:Erro - Código Segmento::G039";
            cdObjectSegmentoPgtoTribN.TipoMovimento = "15:1:N:R:0:15-15::Erro - Tipo de Movimento (0=Inclusão/5=Alteração)::G060";
            cdObjectSegmentoPgtoTribN.CodigoInstrucao = "16:2:N:R:0:16-17::Erro - Código Instrução::G061";
            cdObjectSegmentoPgtoTribN.SeuNumero = "18:20:A:R:0:18-37::Erro - Seu Número (Doc Empresa)::G064";
            cdObjectSegmentoPgtoTribN.NossoNumero = "38:20:A:R:0:38-57::Erro - Nosso Número (Doc Banco)::G043";
            cdObjectSegmentoPgtoTribN.NomeContribuinte = "58:30:A:R:0:58-87::Erro - Nome Contribuinte::G013";
            cdObjectSegmentoPgtoTribN.DataPagamento = "88:8:N:R:0:88-95::Erro - Data Pagamento (DDMMAAAA):D:P009";
            cdObjectSegmentoPgtoTribN.ValorPagamento = "96:13:N:R:0:96-110::Erro - Valor Pagamento (2 decimais)::P010";
            // Na linha abaixo , o manual está "*" estou usando BRCO para não dar erro
            cdObjectSegmentoPgtoTribN.InformacoesComplementares = "111:120:A:V:0:111-230::Erro - Informações Complementares::BRCO"; 
            cdObjectSegmentoPgtoTribN.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N, cdObjectSegmentoPgtoTribN);
            #endregion

            #region SEGMENTO N1
            cdObjectSegmentoPgtoTribN1.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo::N002";
            cdObjectSegmentoPgtoTribN1.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ...)::N003";
            cdObjectSegmentoPgtoTribN1.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação)::N004";
            cdObjectSegmentoPgtoTribN1.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo::N005";
            cdObjectSegmentoPgtoTribN1.Competencia = "135:6:N:R:0:135-140::Erro - Competência (MMAAAA)::N006";
            cdObjectSegmentoPgtoTribN1.ValorTributo = "141:13:N:R:0:141-155::Erro - Valor Tributo (2 decimais)::G055";
            cdObjectSegmentoPgtoTribN1.ValorOutrasEntidades = "156:13:N:V:0:156-170::Erro - Valor Outras Entidades (2 decimais)::G054";
            cdObjectSegmentoPgtoTribN1.AtualizacaoMonetaria = "171:13:N:V:0:171-185::Erro - Atualização Monetária (2 decimais)::N007";
            cdObjectSegmentoPgtoTribN1.UsoExclusivoFebraban = "186:45:A:V:0:186-230::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N1, cdObjectSegmentoPgtoTribN1);
            #endregion

            #region SEGMENTO N2
            cdObjectSegmentoPgtoTribN2.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo::N002";
            cdObjectSegmentoPgtoTribN2.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ)::N003";
            cdObjectSegmentoPgtoTribN2.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação)::N004";
            cdObjectSegmentoPgtoTribN2.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo::N005";
            cdObjectSegmentoPgtoTribN2.PeriodoApuracao = "135:8:N:R:0:135-142::Erro - Período Apuração (AAAAMMDD)::N008";
            cdObjectSegmentoPgtoTribN2.NumeroReferencia = "143:17:N:R:0:143-159::Erro - Número Referência::N009";
            cdObjectSegmentoPgtoTribN2.ValorPrincipal = "160:13:N:R:0:160-174::Erro - Valor Principal (2 decimais)::G042";
            cdObjectSegmentoPgtoTribN2.ValorMulta = "175:13:N:V:0:175-189::Erro - Valor Multa (2 decimais)::G048";
            cdObjectSegmentoPgtoTribN2.ValorJurosEncargos = "190:13:N:V:0:190-204::Erro - Juros/Encargos (2 decimais)::G047";
            cdObjectSegmentoPgtoTribN2.DataVencimento = "205:8:N:R:0:205-212::Erro - Data Vencimento (DDMMAAAA):D:G044";
            cdObjectSegmentoPgtoTribN2.UsoExclusivoFebraban = "213:18:A:V:0:213-230::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N2, cdObjectSegmentoPgtoTribN2);
            #endregion

            #region SEGMENTO N3
            cdObjectSegmentoPgtoTribN3.CodigoReceitaTributo = "111:6:A:R:0:111-116:6106:Erro - Código da Receita do Tributo (6106=INSS Autônomo)::N002";
            cdObjectSegmentoPgtoTribN3.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ)::N003";
            cdObjectSegmentoPgtoTribN3.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação)::N004";
            cdObjectSegmentoPgtoTribN3.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo::N005";
            cdObjectSegmentoPgtoTribN3.PeriodoApuracao = "135:8:N:R:0:135-142::Erro - Período Apuração (AAAAMMDD)::N006";
            cdObjectSegmentoPgtoTribN3.ReceitaBruta = "143:13:N:R:0:143-157::Erro - Receita Bruta (2 decimais)::N010";
            cdObjectSegmentoPgtoTribN3.Percentual = "158:5:N:R:0:158-164::Erro - Percentual (2 decimais)::N011"; // Ex: 5,25% = 0525
            cdObjectSegmentoPgtoTribN3.ValorPrincipal = "165:13:N:R:0:165-179::Erro - Valor Principal (2 decimais)::G042";
            cdObjectSegmentoPgtoTribN3.ValorMulta = "180:13:N:V:0:180-194::Erro - Valor Multa (2 decimais)::G048";
            cdObjectSegmentoPgtoTribN3.ValorJurosEncargos = "195:13:N:V:0:195-209::Erro - Juros/Encargos (2 decimais)::G047";
            cdObjectSegmentoPgtoTribN3.UsoExclusivoFebraban = "210:21:A:V:0:210-230::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N3, cdObjectSegmentoPgtoTribN3);
            #endregion

            #region SEGMENTO N4
            cdObjectSegmentoPgtoTribN4.CodigoReceitaTributo = "111:6:A:R:0:111-116::Erro - Código da Receita do Tributo::N002";
            cdObjectSegmentoPgtoTribN4.TipoIdentificacaoContribuinte = "117:2:N:R:0:117-118::Erro - Tipo Identificação (01-CPF/02-CNPJ)::N003";
            cdObjectSegmentoPgtoTribN4.IdentificacaoContribuinte = "119:14:N:R:0:119-132::Erro - CPF/CNPJ (sem formatação)::N004";
            cdObjectSegmentoPgtoTribN4.CodigoIdentificacaoTributo = "133:2:A:R:0:133-134::Erro - Código Identificação Tributo::N005";
            cdObjectSegmentoPgtoTribN4.DataVencimento = "135:8:N:R:0:135-142::Erro - Data Vencimento (DDMMAAAA):D:G044";
            cdObjectSegmentoPgtoTribN4.InscricaoMunicipalDeclaracao = "143:12:N:R:0:143-154::Erro - IE/Município/Declaração::N012";
            cdObjectSegmentoPgtoTribN4.DividaAtivaEtiqueta = "155:13:N:R:0:155-167::Erro - Dívida Ativa/N.Etiqueta::N013";
            cdObjectSegmentoPgtoTribN4.PeriodoReferencia = "168:6:N:R:0:168-173::Erro - Período Referência (MMAAAA)::N006";
            cdObjectSegmentoPgtoTribN4.NumeroParcelaNotificacao = "174:13:N:R:0:174-186::Erro - N.Parcela/Notificação::N014";
            cdObjectSegmentoPgtoTribN4.ValorReceita = "187:13:N:R:0:187-201::Erro - Valor Receita (2 decimais)::G042";
            cdObjectSegmentoPgtoTribN4.ValorJuros = "202:12:N:V:0:202-215::Erro - Valor Juros (2 decimais)::G047";
            cdObjectSegmentoPgtoTribN4.ValorMulta = "216:12:N:V:0:216-229::Erro - Valor Multa (2 decimais)::G048";
            cdObjectSegmentoPgtoTribN4.UsoExclusivoFebraban = "230:1:A:V:0:230-230::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_N4, cdObjectSegmentoPgtoTribN4);
            #endregion

            #region SEGMENTO W
            cdObjectSegmentoPgtoTribW.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoTribW.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoTribW.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoTribW.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectSegmentoPgtoTribW.CodigoSegmento = "14:1:A:R:0:14-14:W:Erro - Código Segmento::G039";
            cdObjectSegmentoPgtoTribW.NumeroComplementar = "15:1:N:R:0:15-15::Erro - Nº Registro Complementar::N023";
            cdObjectSegmentoPgtoTribW.IdentificadorUso = "16:1:A:R:0:16-16::Erro - Identificador Uso Info 1/2::N024";
            cdObjectSegmentoPgtoTribW.InformacaoComplementar1 = "17:80:A:V:0:17-96::Erro - Informação Complementar 1::N025";
            cdObjectSegmentoPgtoTribW.InformacaoComplementar2 = "97:80:A:V:0:97-176::Erro - Informação Complementar 2::N025";
            cdObjectSegmentoPgtoTribW.IdentificadorTributo = "177:2:A:V:0:177-178::Erro - Identificador Tributo::N027";
            cdObjectSegmentoPgtoTribW.InfoComplementarTributo = "179:48:A:V:0:179-228::Erro - Info Complementar Tributo::N026";
            cdObjectSegmentoPgtoTribW.UsoExclusivoFebraban = "229:2:A:V:0:229-230::Erro - Uso FEBRABAN/CNAB::G004"; // 2 espaços
            cdObjectSegmentoPgtoTribW.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_W, cdObjectSegmentoPgtoTribW);
            #endregion

            #region SEGMENTO W1
            cdObjectSegmentoPgtoTribW1.IdentificadorTributo = "177:2:A:R:0:177-178::Erro - Identificador Tributo (FG=FGTS)::N027";
            cdObjectSegmentoPgtoTribW1.CodigoReceitaTributo = "179:6:A:R:0:179-184::Erro - Código Receita Tributo::N002";
            cdObjectSegmentoPgtoTribW1.TipoIdentificacaoContribuinte = "185:2:A:R:0:185-186::Erro - Tipo Identificação (01-CPF/02-CNPJ)::N003";
            cdObjectSegmentoPgtoTribW1.IdentificacaoContribuinte = "187:14:A:R:0:187-200::Erro - Identificação Contribuinte::N004";
            cdObjectSegmentoPgtoTribW1.IdentificadorFGTS = "201:16:A:R:0:201-216::Erro - Identificador FGTS (16 caracteres)::N021";
            cdObjectSegmentoPgtoTribW1.LacreConectividade = "217:9:A:R:0:217-225::Erro - Lacre Conectividade (9 dígitos)::N028";
            cdObjectSegmentoPgtoTribW1.DigitoVerificadorLacre = "226:2:A:R:0:226-227::Erro - Dígito Verificador Lacre::N029";
            cdObjectSegmentoPgtoTribW1.UsoExclusivoFebraban = "228:1:A:V:0:228-228::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_W1, cdObjectSegmentoPgtoTribW1);
            #endregion

            #region SEGMENTO 5
            cdObjectSegmentoPgtoTrib5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoTrib5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoTrib5.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoTrib5.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectSegmentoPgtoTrib5.CodigoSegmento = "14:1:A:R:0:14-14:5:Erro - Código Segmento::G039";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco1 = "15:3:A:V:0:15-17:" + new string(' ', 3) + ":Erro - Uso Bradesco (3 espaços)::G004";
            cdObjectSegmentoPgtoTrib5.NumeroListaDebito = "18:9:N:R:0:18-26::Erro - Nº Lista Débito::5001";
            cdObjectSegmentoPgtoTrib5.HorarioDebito = "27:6:N:R:0:27-32::Erro - Horário Débito (HHMMSS)::5002";
            cdObjectSegmentoPgtoTrib5.CodigoLancamento = "33:5:N:R:0:33-37::Erro - Código Lançamento::5003";
            cdObjectSegmentoPgtoTrib5.SegundaLinhaExtrato = "38:5:N:R:0:38-42::Erro - 2ª Linha Extrato::5004";
            cdObjectSegmentoPgtoTrib5.UsoEmpresa = "43:50:A:V:0:43-92::Erro - Uso Empresa::5005";
            cdObjectSegmentoPgtoTrib5.TipoDocumento = "93:3:N:R:0:93-95::Erro - Tipo Documento::5006";
            cdObjectSegmentoPgtoTrib5.NumeroDocumento = "96:15:N:R:0:96-110::Erro - Nº Documento::5007";
            cdObjectSegmentoPgtoTrib5.SerieDocumento = "111:2:A:R:0:111-112::Erro - Série Documento::5008";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco2 = "113:15:A:V:0:113-127::Erro - Uso Bradesco (15 espaços)::G004";
            cdObjectSegmentoPgtoTrib5.DataEmissao = "128:8:N:R:0:128-135::Erro - Data Emissão (DDMMAAAA):D:5010";
            cdObjectSegmentoPgtoTrib5.UsoExclusivoBradesco3 = "136:95:A:V:0:136-230::Erro - Uso Bradesco::G004";
            cdObjectSegmentoPgtoTrib5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_5, cdObjectSegmentoPgtoTrib5);
            #endregion

            #region SEGMENTO Z
            cdObjectSegmentoPgtoTribZ.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectSegmentoPgtoTribZ.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectSegmentoPgtoTribZ.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectSegmentoPgtoTribZ.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectSegmentoPgtoTribZ.CodigoSegmento = "14:1:A:R:0:14-14:Z:Erro - Código Segmento::G039";
            cdObjectSegmentoPgtoTribZ.AutenticacaoLegislacao = "15:64:A:R:0:15-78::Erro - Autenticação (64 caracteres)::Z001";
            cdObjectSegmentoPgtoTribZ.ProtocoloAutenticacao = "79:25:A:R:0:79-103::Erro - Protocolo Autenticação::Z002";
            cdObjectSegmentoPgtoTribZ.UsoExclusivoFebraban = "104:127:A:V:0:104-230::Erro - Uso FEBRABAN::G004";
            cdObjectSegmentoPgtoTribZ.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoPgTrib_Z, cdObjectSegmentoPgtoTribZ);
            #endregion

            #endregion

            #region BLOQUETO ELETRONICO
            // G / H / Y03 / Y51 
            #region Objetos
            dynamic cdObjectBloquetoEletronicoHeader1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectBloquetoEletronicoTrailer5 = new ExpandoObject(); // Trailer de lote
            dynamic cdObjectBloquetoEletronicoSegmentoG = new ExpandoObject();
            dynamic cdObjectBloquetoEletronicoSegmentoH = new ExpandoObject();
            dynamic cdObjectBloquetoEletronicoSegmentoY03 = new ExpandoObject();
            dynamic cdObjectBloquetoEletronicoSegmentoY51 = new ExpandoObject();
            #endregion

            #region HEADER DE LOTE
            cdObjectBloquetoEletronicoHeader1.CodigoBanco = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectBloquetoEletronicoHeader1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoHeader1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoHeader1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo de Operação::G028";
            cdObjectBloquetoEletronicoHeader1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo de Serviço::G025";
            cdObjectBloquetoEletronicoHeader1.CNAB1 = "12:2:A:V:0:12-13::Erro - Uso FEBRABAN/CNAB::G004"; // 2 espaços
            cdObjectBloquetoEletronicoHeader1.VersaoLayout = "14:3:N:R:0:14-16:022:Erro - Versão do Layout::G030";
            cdObjectBloquetoEletronicoHeader1.CNAB2 = "17:1:A:V:0:17-17::Erro - Uso FEBRABAN/CNAB::G004";
            cdObjectBloquetoEletronicoHeader1.TipoInscricao = "18:1:N:R:0:18-18::Erro - Tipo Inscrição (1-CPF/2-CNPJ)::G005";
            cdObjectBloquetoEletronicoHeader1.NumeroInscricao = "19:15:N:R:0:19-33::Erro - CNPJ/CPF da Empresa::G006";
            cdObjectBloquetoEletronicoHeader1.CodigoConvenio = "34:20:A:R:0:34-53::Erro - Código do Convênio::G007";
            cdObjectBloquetoEletronicoHeader1.Agencia = "54:5:N:R:0:54-58::Erro - Agência Mantenedora::G008";
            cdObjectBloquetoEletronicoHeader1.DigitoAgencia = "59:1:A:R:0:59-59::Erro - Dígito Agência::G009";
            cdObjectBloquetoEletronicoHeader1.ContaCorrente = "60:12:N:R:0:60-71::Erro - Conta Corrente::G010";
            cdObjectBloquetoEletronicoHeader1.DigitoConta = "72:1:A:R:0:72-72::Erro - Dígito Conta::G011";
            cdObjectBloquetoEletronicoHeader1.DigitoAgenciaConta = "73:1:A:R:0:73-73::Erro - Dígito Ag/Conta::G012";
            cdObjectBloquetoEletronicoHeader1.NomeEmpresa = "74:30:A:R:0:74-103::Erro - Nome da Empresa::G013";
            cdObjectBloquetoEletronicoHeader1.CNAB3 = "104:137:A:V:0:104-240::Erro - Uso FEBRABAN::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_BloquetoEletronico, cdObjectBloquetoEletronicoHeader1);
            #endregion

            #region TRAILER DE LOTE
            cdObjectBloquetoEletronicoTrailer5.CodigoBanco = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectBloquetoEletronicoTrailer5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoTrailer5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoTrailer5.UsoExclusivoFebraban1 = "9:9:A:V:0:9-17::Erro - Uso FEBRABAN/CNAB::G004";
            cdObjectBloquetoEletronicoTrailer5.QuantidadeRegistros = "18:6:N:R:0:18-23::Erro - Qtde Registros do Lote::G057";
            cdObjectBloquetoEletronicoTrailer5.SomatoriaValores = "24:16:N:R:0:24-41::Erro - Somatória de Valores (2 decimais)::P007";
            cdObjectBloquetoEletronicoTrailer5.SomatoriaQuantidadeMoedas = "42:13:N:V:0:42-59::Erro - Somatória Qtde Moedas (5 decimais)::G058";
            cdObjectBloquetoEletronicoTrailer5.NumeroAvisoDebito = "60:6:N:V:0:60-65::Erro - Nº Aviso de Débito::G066";
            cdObjectBloquetoEletronicoTrailer5.UsoExclusivoFebraban2 = "66:165:A:V:0:66-230::Erro - Uso FEBRABAN::G004";
            cdObjectBloquetoEletronicoTrailer5.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_BloquetoEletronico, cdObjectBloquetoEletronicoTrailer5);
            #endregion

            #region SEGMENTO G
            cdObjectBloquetoEletronicoSegmentoG.CodigoBanco = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectBloquetoEletronicoSegmentoG.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoSegmentoG.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoSegmentoG.NumeroSequencial = "9:5:N:R:0:9-13::Erro - Nº Sequencial no Lote::G038";
            cdObjectBloquetoEletronicoSegmentoG.CodigoSegmento = "14:1:A:R:0:14-14:G:Erro - Código Segmento::G039";
            cdObjectBloquetoEletronicoSegmentoG.UsoExclusivoFebraban1 = "15:1:A:V:0:15-15::Erro - Uso FEBRABAN/CNAB::G004";
            cdObjectBloquetoEletronicoSegmentoG.CodigoMovimento = "16:2:N:R:0:16-17::Erro - Código de Movimento::C004";
            cdObjectBloquetoEletronicoSegmentoG.CodigoBarras = "18:44:N:R:0:18-61::Erro - Código de Barras::G063";
            cdObjectBloquetoEletronicoSegmentoG.TipoInscricaoCedente = "62:1:N:R:0:62-62::Erro - Tipo Inscrição Cedente (1-CPF/2-CNPJ)::G005";
            cdObjectBloquetoEletronicoSegmentoG.NumeroInscricaoCedente = "63:15:N:R:0:63-77::Erro - Nº Inscrição Cedente::G006";
            cdObjectBloquetoEletronicoSegmentoG.NomeCedente = "78:30:A:R:0:78-107::Erro - Nome Cedente::G013";
            cdObjectBloquetoEletronicoSegmentoG.DataVencimento = "108:8:N:R:0:108-115::Erro - Data Vencimento (DDMMAAAA):D:C012";
            cdObjectBloquetoEletronicoSegmentoG.ValorTitulo = "116:13:N:R:0:116-130::Erro - Valor Título (2 decimais)::G070";
            cdObjectBloquetoEletronicoSegmentoG.QuantidadeMoeda = "131:10:N:V:0:131-145::Erro - Qtde. Moeda (5 decimais)::G041";
            cdObjectBloquetoEletronicoSegmentoG.CodigoMoeda = "146:2:N:R:0:146-147::Erro - Código Moeda::G065";
            cdObjectBloquetoEletronicoSegmentoG.NumeroDocumento = "148:15:A:R:0:148-162::Erro - Nº Documento Cobrança::C011";
            cdObjectBloquetoEletronicoSegmentoG.AgenciaCobradora = "163:5:N:R:0:163-167::Erro - Agência Cobradora::C014";
            cdObjectBloquetoEletronicoSegmentoG.DigitoAgencia = "168:1:A:R:0:168-168::Erro - DV Agência::G009";
            cdObjectBloquetoEletronicoSegmentoG.PracaCobradora = "169:10:A:V:0:169-178::Erro - Praça Cobradora::B001";
            cdObjectBloquetoEletronicoSegmentoG.CodigoCarteira = "179:1:A:R:0:179-179::Erro - Código Carteira::C006";
            cdObjectBloquetoEletronicoSegmentoG.EspecieTitulo = "180:2:N:R:0:180-181::Erro - Espécie Título::C015";
            cdObjectBloquetoEletronicoSegmentoG.DataEmissaoTitulo = "182:8:N:R:0:182-189::Erro - Data Emissão Título (DDMMAAAA):D:G071";
            cdObjectBloquetoEletronicoSegmentoG.JurosMora = "190:13:N:V:0:190-204::Erro - Juros por Dia (2 decimais)::C020";
            cdObjectBloquetoEletronicoSegmentoG.CodigoDesconto1 = "205:1:N:V:0:205-205::Erro - Cód. Desconto 1::C021";
            cdObjectBloquetoEletronicoSegmentoG.DataDesconto1 = "206:8:N:V:0:206-213::Erro - Data Desconto 1:D:C022";
            cdObjectBloquetoEletronicoSegmentoG.ValorDesconto1 = "214:13:N:V:0:214-228::Erro - Valor Desconto 1 (2 decimais)::C023"; // C023 não existe no manual
            cdObjectBloquetoEletronicoSegmentoG.CodigoProtesto = "229:1:N:V:0:229-229::Erro - Código Protesto::C026";
            cdObjectBloquetoEletronicoSegmentoG.PrazoProtesto = "230:2:N:V:0:230-231::Erro - Prazo Protesto::C027";
            cdObjectBloquetoEletronicoSegmentoG.DataLimitePagamento = "232:8:N:V:0:232-239::Erro - Data Limite Pagamento (DDMMAAAA):D:C075";
            cdObjectBloquetoEletronicoSegmentoG.UsoExclusivoFebraban2 = "240:1:A:V:0:240-240::Erro - Uso FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoBloquetoEletronico_G, cdObjectBloquetoEletronicoSegmentoG);
            #endregion

            #region SEGMENTO H
            cdObjectBloquetoEletronicoSegmentoH.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco na compensação::G001";
            cdObjectBloquetoEletronicoSegmentoH.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoSegmentoH.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoSegmentoH.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBloquetoEletronicoSegmentoH.CodigoSegmento = "14:1:A:R:0:14-14:H:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObjectBloquetoEletronicoSegmentoH.CNAB = "15:1:A:V:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectBloquetoEletronicoSegmentoH.CodigoMovimento = "16:2:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";
            cdObjectBloquetoEletronicoSegmentoH.TipoInscricao = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição::G005";
            cdObjectBloquetoEletronicoSegmentoH.NumeroInscricao = "19:15:N:R:0:19-33::Erro - Número de Inscrição::G006";
            cdObjectBloquetoEletronicoSegmentoH.NomeSacador = "34:40:A:R:0:34-73::Erro - Nome do Sacador / Avalista::G013";
            cdObjectBloquetoEletronicoSegmentoH.CodigoDesconto2 = "74:1:N:R:0:74-74::Erro - Código do Desconto 2::C021";
            cdObjectBloquetoEletronicoSegmentoH.DataDesconto2 = "75:8:N:V:0:75-82::Erro - Data do Desconto 2:D:C022";
            cdObjectBloquetoEletronicoSegmentoH.ValorDesconto2 = "83:13:N:V:0:83-97::Erro - Valor / Percentual a ser Concedido::C023";// C023 não existe no manual
            cdObjectBloquetoEletronicoSegmentoH.CodigoDesconto3 = "98:1:N:R:0:98-98::Erro - Código do Desconto 3::C021";
            cdObjectBloquetoEletronicoSegmentoH.DataDesconto3 = "99:8:N:V:0:99-106::Erro - Data do Desconto 3:D:C022";
            cdObjectBloquetoEletronicoSegmentoH.ValorDesconto3 = "107:13:N:V:0:107-121::Erro - Valor / Percentual a ser Concedido::C023";// C023 não existe no manual
            cdObjectBloquetoEletronicoSegmentoH.CodigoMulta = "122:1:N:R:0:122-122::Erro - Código da Multa::G073";
            cdObjectBloquetoEletronicoSegmentoH.DataMulta = "123:8:N:V:0:123-130::Erro - Data da Multa:D:G074";
            cdObjectBloquetoEletronicoSegmentoH.ValorMulta = "131:13:N:V:0:131-145::Erro - Valor/Percentual a Ser Concedido::G075";
            cdObjectBloquetoEletronicoSegmentoH.ValorAbatimento = "146:13:N:V:0:146-160::Erro - Valor do Abatimento::G045";
            cdObjectBloquetoEletronicoSegmentoH.NossoNumero = "161:20:A:R:0:161-180::Erro - Número do Documento atribuído pelo Banco::G043";
            cdObjectBloquetoEletronicoSegmentoH.ReservadoBradesco = "181:20:A:V:0:181-200::Erro - Uso Exclusivo Bradesco::G004";
            cdObjectBloquetoEletronicoSegmentoH.Mensagem = "201:40:A:V:0:201-240::Erro - Mensagem::C073";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoBloquetoEletronico_H, cdObjectBloquetoEletronicoSegmentoH);
            #endregion

            #region SEGMENTO Y03
            cdObjectBloquetoEletronicoSegmentoY03.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco na compensação::G001";
            cdObjectBloquetoEletronicoSegmentoY03.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoSegmentoY03.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoSegmentoY03.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBloquetoEletronicoSegmentoY03.CodigoSegmento = "14:1:A:R:0:14-14:Y:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObjectBloquetoEletronicoSegmentoY03.CNAB1 = "15:1:A:V:0:15-15: :Erro - Uso Exclusivo FEBRABAN/CNAB::G004"; // 1 espaço (Nº Dig = 1)
            cdObjectBloquetoEletronicoSegmentoY03.CodigoMovimento = "16:2:N:R:0:16-17:01:Erro - Código de Movimento Remessa::C004";
            cdObjectBloquetoEletronicoSegmentoY03.CodigoRegistroOpcional = "18:2:N:R:0:18-19:03:Erro - Identificação Registro Opcional::G067";
            cdObjectBloquetoEletronicoSegmentoY03.TipoInscricao = "20:1:N:R:0:20-20::Erro - Tipo de Inscrição::G005";
            cdObjectBloquetoEletronicoSegmentoY03.NumeroInscricao = "21:15:N:R:0:21-35::Erro - Número de Inscrição::G006";
            cdObjectBloquetoEletronicoSegmentoY03.NomeSacado = "36:40:A:R:0:36-75::Erro - Nome do Sacado::G013";
            cdObjectBloquetoEletronicoSegmentoY03.EnderecoSacado = "76:40:A:R:0:76-115::Erro - Endereço do Sacado::G032";
            cdObjectBloquetoEletronicoSegmentoY03.BairroSacado = "116:15:A:R:0:116-130::Erro - Bairro::G032";
            cdObjectBloquetoEletronicoSegmentoY03.CEP = "131:5:N:R:0:131-135::Erro - CEP::G034";
            cdObjectBloquetoEletronicoSegmentoY03.SufixoCEP = "136:3:N:R:0:136-138::Erro - Sufixo do CEP::G035";
            cdObjectBloquetoEletronicoSegmentoY03.Cidade = "139:15:A:R:0:139-153::Erro - Cidade::G033";
            cdObjectBloquetoEletronicoSegmentoY03.UF = "154:2:A:R:0:154-155::Erro - Unidade da Federação::G036";
            cdObjectBloquetoEletronicoSegmentoY03.CNAB2 = "156:85:A:V:0:156-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoBloquetoEletronico_Y03, cdObjectBloquetoEletronicoSegmentoY03);
            #endregion

            #region SEGMENTO Y51
            cdObjectBloquetoEletronicoSegmentoY51.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco na compensação::G001";
            cdObjectBloquetoEletronicoSegmentoY51.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBloquetoEletronicoSegmentoY51.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectBloquetoEletronicoSegmentoY51.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBloquetoEletronicoSegmentoY51.CodigoSegmento = "14:1:A:R:0:14-14:Y:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObjectBloquetoEletronicoSegmentoY51.CNAB = "15:1:A:V:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004"; // 1 espaço (Nº Dig = 1)
            cdObjectBloquetoEletronicoSegmentoY51.CodigoMovimento = "16:2:N:R:0:16-17:01:Erro - Código de Movimento Remessa::C004";
            cdObjectBloquetoEletronicoSegmentoY51.CodigoRegistroOpcional = "18:2:N:R:0:18-19:51:Erro - Identificação Registro Opcional::G067";
            cdObjectBloquetoEletronicoSegmentoY51.NotaFiscal1 = "20:15:A:R:0:20-34::Erro - Número da Nota Fiscal::C067";
            cdObjectBloquetoEletronicoSegmentoY51.ValorNotaFiscal1 = "35:13:N:R:0:35-48::Erro - Valor da Nota Fiscal::C068";
            cdObjectBloquetoEletronicoSegmentoY51.DataEmissao1 = "50:8:N:R:0:50-57::Erro - Data Emissão Nota Fiscal:D:C069";
            cdObjectBloquetoEletronicoSegmentoY51.NotaFiscal2 = "58:15:A:R:0:58-72::Erro - Número da Nota Fiscal::C067";
            cdObjectBloquetoEletronicoSegmentoY51.ValorNotaFiscal2 = "73:13:N:R:0:73-87::Erro - Valor da Nota Fiscal::C068";
            cdObjectBloquetoEletronicoSegmentoY51.DataEmissao2 = "88:8:A:R:0:88-95::Erro - Data Emissão Nota Fiscal:D:C069";
            cdObjectBloquetoEletronicoSegmentoY51.NotaFiscal3 = "96:15:N:R:0:96-110::Erro - Número da Nota Fiscal::C067";
            cdObjectBloquetoEletronicoSegmentoY51.ValorNotaFiscal3 = "111:13:N:R:0:111-125::Erro - Valor da Nota Fiscal::C068";
            cdObjectBloquetoEletronicoSegmentoY51.DataEmissao3 = "125:8:N:R:0:125-133::Erro - Data Emissão Nota Fiscal:D:C069"; // Aviso: Sobreposição (125-133 vs 111-125)
            cdObjectBloquetoEletronicoSegmentoY51.NotaFiscal4 = "134:15:A:R:0:134-148::Erro - Número da Nota Fiscal::C067";
            cdObjectBloquetoEletronicoSegmentoY51.ValorNotaFiscal4 = "149:13:N:R:0:149-163::Erro - Valor da Nota Fiscal::C068";
            cdObjectBloquetoEletronicoSegmentoY51.DataEmissao4 = "164:8:N:R:0:164-171::Erro - Data Emissão Nota Fiscal:D:C069";
            cdObjectBloquetoEletronicoSegmentoY51.NotaFiscal5 = "172:15:A:R:0:172-186::Erro - Número da Nota Fiscal::C067";
            cdObjectBloquetoEletronicoSegmentoY51.ValorNotaFiscal5 = "187:13:N:R:0:187-201::Erro - Valor da Nota Fiscal::C068";
            cdObjectBloquetoEletronicoSegmentoY51.DataEmissao5 = "202:8:N:R:0:202-209::Erro - Data Emissão Nota Fiscal:D:C069";
            cdObjectBloquetoEletronicoSegmentoY51.UsoExclusivoFebraban5 = "210:31:A:V:0:210-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";


            JsonObjectsGenerator.AddProperty(dynamicList, segmentoBloquetoEletronico_Y51, cdObjectBloquetoEletronicoSegmentoY51);
            #endregion

            #endregion

            #region ALEGAÇÃO SACADO
            // G/H/Y03/Y51/
            #region Objetos
            dynamic cdObjectAlegacaoSacadoHeader1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectAlegacaoSacadoTrailer5 = new ExpandoObject(); // Trailer de lote
            dynamic cdObjectAlegacaoSacadoSegmentoY2 = new ExpandoObject();
            #endregion

            #region HEADER DE LOTE
            cdObjectAlegacaoSacadoHeader1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectAlegacaoSacadoHeader1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectAlegacaoSacadoHeader1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObjectAlegacaoSacadoHeader1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo de Operação::G028";
            cdObjectAlegacaoSacadoHeader1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo de Serviço::G025";
            cdObjectAlegacaoSacadoHeader1.CNAB1 = "12:2:A:V:0:12-13::Erro - Uso Exclusivo da FEBRABAN/CNAB::G004"; // 2 espaços
            cdObjectAlegacaoSacadoHeader1.VersaoLayoutLote = "14:3:N:R:0:14-16:010:Erro - Nº da Versão do Layout do Lote::G030";
            cdObjectAlegacaoSacadoHeader1.CNAB2 = "17:1:A:V:0:17-17::Erro - Uso Exclusivo da FEBRABAN/CNAB::G004";
            cdObjectAlegacaoSacadoHeader1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObjectAlegacaoSacadoHeader1.NumeroInscricaoEmpresa = "19:15:N:R:0:19-33::Erro - Número de Inscrição da Empresa::G006";
            cdObjectAlegacaoSacadoHeader1.CodigoConvenioBanco = "34:20:A:R:0:34-53::Erro - Código do Convênio no Banco::G007";
            cdObjectAlegacaoSacadoHeader1.AgenciaMantenedora = "54:5:N:R:0:54-58::Erro - Agência Mantenedora da Conta::G008";
            cdObjectAlegacaoSacadoHeader1.DigitoVerificadorAgencia = "59:1:A:R:0:59-59::Erro - Dígito Verificador da Agência::G009";
            cdObjectAlegacaoSacadoHeader1.NumeroContaCorrente = "60:12:N:R:0:60-71::Erro - Número da Conta Corrente::G010";
            cdObjectAlegacaoSacadoHeader1.DigitoVerificadorConta = "72:1:A:R:0:72-72::Erro - Dígito Verificador da Conta::G011";
            cdObjectAlegacaoSacadoHeader1.DigitoVerificadorAgenciaConta = "73:1:A:R:0:73-73::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObjectAlegacaoSacadoHeader1.NomeEmpresa = "74:30:A:R:0:74-103::Erro - Nome da Empresa::G013";
            cdObjectAlegacaoSacadoHeader1.CNAB3 = "104:137:A:V:0:104-240::Erro - Uso Exclusivo da FEBRABAN/CNAB::G004"; // 137 espaços
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_AlegacaoSacado, cdObjectAlegacaoSacadoHeader1);
            #endregion

            #region TRAILER DE LOTE
            cdObjectAlegacaoSacadoTrailer5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectAlegacaoSacadoTrailer5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectAlegacaoSacadoTrailer5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObjectAlegacaoSacadoTrailer5.CNAB1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectAlegacaoSacadoTrailer5.QuantidadeRegistros = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote::G057";
            cdObjectAlegacaoSacadoTrailer5.CNAB2 = "60:181:A:V:0:60-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004"; // 181 espaços
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_AlegacaoSacado, cdObjectAlegacaoSacadoTrailer5);
            #endregion

            #region SEGMENTO Y2
            // Segmento Y2
            cdObjectAlegacaoSacadoSegmentoY2.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco na compensação::G001";
            cdObjectAlegacaoSacadoSegmentoY2.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectAlegacaoSacadoSegmentoY2.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObjectAlegacaoSacadoSegmentoY2.NumeroSequencialRegistro = "9:5:N:R:0:9-13::Erro - N° Sequencial do Registro no Lote::G038";
            cdObjectAlegacaoSacadoSegmentoY2.CodigoSegmento = "14:1:A:R:0:14-14:Y:Erro - Código do Segmento do Registro Detalhe::G039";
            cdObjectAlegacaoSacadoSegmentoY2.UsoExclusivoFebrabanCnab1 = "15:1:A:V:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectAlegacaoSacadoSegmentoY2.CodigoMovimentoRemessa = "16:2:N:R:0:16-17:40:Erro - Código de Movimento Remessa::G061";
            cdObjectAlegacaoSacadoSegmentoY2.IdentificacaoRegistroOpcional = "18:2:N:R:0:18-19:02:Erro - Identificação do Registro Opcional::G067";
            cdObjectAlegacaoSacadoSegmentoY2.CodigoBarras = "20:44:N:R:0:20-63::Erro - Código de Barras::G063";
            cdObjectAlegacaoSacadoSegmentoY2.CodigoPadrao = "64:2:N:R:0:64-65::Erro - Código Padrão::G062";
            cdObjectAlegacaoSacadoSegmentoY2.CodigoOcorrencia = "66:4:N:R:0:66-69::Erro - Código de Ocorrência::A001";
            cdObjectAlegacaoSacadoSegmentoY2.ComplementoOcorrencia = "70:150:A:V:0:70-219::Erro - Complemento de Ocorrência::A002";
            cdObjectAlegacaoSacadoSegmentoY2.UsoExclusivoFebrabanCnab2 = "220:11:A:V:0:220-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectAlegacaoSacadoSegmentoY2.CodigosOcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Código de Ocorrência Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, segmentoAlegacaoSacado_Y2, cdObjectAlegacaoSacadoSegmentoY2);
            #endregion

            #endregion

            #region BASES DOS SISTEMAS
            // Segmento 1/2/3
            #region Objetos
            dynamic cdObjectBasesSistemasHeader1 = new ExpandoObject(); // Header de lote
            dynamic cdObjectBasesSistemasTrailer5 = new ExpandoObject(); // Trailer de lote
            dynamic cdObjectBasesSistemasSegmento1 = new ExpandoObject();
            dynamic cdObjectBasesSistemasSegmento2 = new ExpandoObject();
            dynamic cdObjectBasesSistemasSegmento3 = new ExpandoObject();
            #endregion

            #region HEADER DE LOTE
            cdObjectBasesSistemasHeader1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectBasesSistemasHeader1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBasesSistemasHeader1.TipoRegistro = "8:1:N:R:0:8-8:1:Erro - Tipo de Registro::G003";
            cdObjectBasesSistemasHeader1.TipoOperacao = "9:1:A:R:0:9-9::Erro - Tipo da Operação::G028";
            cdObjectBasesSistemasHeader1.TipoServico = "10:2:N:R:0:10-11::Erro - Tipo do Serviço::G025";
            cdObjectBasesSistemasHeader1.FormaLancamento = "12:2:N:R:0:12-13::Erro - Forma de Lançamento::G029";
            cdObjectBasesSistemasHeader1.VersaoLayoutLote = "14:3:N:R:0:14-16:010:Erro - Nº da Versão do Layout do Lote::G030";
            cdObjectBasesSistemasHeader1.UsoExclusivoFebrabanCnab1 = "17:1:A:V:0:17-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectBasesSistemasHeader1.TipoInscricaoEmpresa = "18:1:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObjectBasesSistemasHeader1.NumeroInscricaoEmpresa = "19:14:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObjectBasesSistemasHeader1.CodigoConvenioBanco = "33:20:A:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObjectBasesSistemasHeader1.AgenciaMantenedoraConta = "53:5:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObjectBasesSistemasHeader1.DigitoVerificadorAgencia = "58:1:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObjectBasesSistemasHeader1.NumeroContaCorrente = "59:12:N:R:0:59-70::Erro - Número da Conta Corrente::G010";
            cdObjectBasesSistemasHeader1.DigitoVerificadorConta = "71:1:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObjectBasesSistemasHeader1.DigitoVerificadorAgenciaConta = "72:1:A:R:0:72-72::Erro - Dígito Verificador da Agência/Conta::G012";
            cdObjectBasesSistemasHeader1.NomeEmpresa = "73:30:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObjectBasesSistemasHeader1.Mensagem = "103:40:A:V:0:103-142::Erro - Mensagem::G031";
            cdObjectBasesSistemasHeader1.Logradouro = "143:30:A:V:0:143-172::Erro - Nome da Rua, Av, Pça, Etc::G032";
            cdObjectBasesSistemasHeader1.NumeroLocal = "173:5:N:V:0:173-177::Erro - Número do Local::G032";
            cdObjectBasesSistemasHeader1.Complemento = "178:15:A:V:0:178-192::Erro - Casa, Apto, Sala, Etc::G032";
            cdObjectBasesSistemasHeader1.Cidade = "193:20:A:V:0:193-212::Erro - Nome da Cidade::G033";
            cdObjectBasesSistemasHeader1.CEP = "213:5:N:V:0:213-217::Erro - CEP::G034";
            cdObjectBasesSistemasHeader1.ComplementoCEP = "218:3:A:V:0:218-220::Erro - Complemento do CEP::G035";
            cdObjectBasesSistemasHeader1.Estado = "221:2:A:V:0:221-222::Erro - Sigla do Estado::G036";
            cdObjectBasesSistemasHeader1.IndicativoFormaPagamento = "223:2:N:R:0:223-224::Erro - Indicativo de Forma de Pagamento do Serviço::P014";
            cdObjectBasesSistemasHeader1.UsoExclusivoFebrabanCnab2 = "225:6:A:V:0:225-230::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectBasesSistemasHeader1.OcorrenciasRetorno = "231:10:A:V:0:231-240::Erro - Códigos das Ocorrências p/ Retorno::G059";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroUm_BasesSistemas, cdObjectBasesSistemasHeader1);
            #endregion

            #region TRAILER DE LOTE
            // Trailer de Lote
            cdObjectBasesSistemasTrailer5.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObjectBasesSistemasTrailer5.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBasesSistemasTrailer5.TipoRegistro = "8:1:N:R:0:8-8:5:Erro - Tipo de Registro::G003";
            cdObjectBasesSistemasTrailer5.UsoExclusivoFebrabanCnab1 = "9:9:A:V:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObjectBasesSistemasTrailer5.QuantidadeRegistrosLote = "18:6:N:R:0:18-23::Erro - Quantidade de Registros do Lote::G057";
            cdObjectBasesSistemasTrailer5.UsoExclusivoFebrabanCnab2 = "60:181:A:V:0:60-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, descricaoRegistroCinco_BasesSistemas, cdObjectBasesSistemasTrailer5);
            #endregion

            #region SEGMENTO 1
            // Detalhe de Lote (Segmento 1)
            cdObjectBasesSistemasSegmento1.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco da Compensação::G001";
            cdObjectBasesSistemasSegmento1.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBasesSistemasSegmento1.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Registro Detalhe de Lote::G003";
            cdObjectBasesSistemasSegmento1.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBasesSistemasSegmento1.CodigoSegmento = "14:1:A:R:0:14-14:1:Erro - Código de Segmento no Reg. Detalhe::G039";
            cdObjectBasesSistemasSegmento1.UsoExclusivoFebrabanCnab1 = "15:3:A:V:0:15-17::Erro - Uso CNAB/FEBRABAN::G004";
            cdObjectBasesSistemasSegmento1.CodigoMensagem = "18:4:N:V:0:18-21::Erro - Código da Mensagem::1001";
            cdObjectBasesSistemasSegmento1.DescricaoMensagem = "22:120:A:V:0:22-141::Erro - Descrição da Mensagem::1002";
            cdObjectBasesSistemasSegmento1.NivelMensagem = "142:5:N:V:0:142-146::Erro - Nível da Mensagem::1003";
            cdObjectBasesSistemasSegmento1.UsoExclusivoFebrabanCnab2 = "147:94:A:V:0:147-240::Erro - Uso CNAB/FEBRABAN::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmento1_BasesSistemas, cdObjectBasesSistemasSegmento1);
            #endregion

            #region SEGMENTO 2
            // Detalhe de Lote (Segmento 2)
            cdObjectBasesSistemasSegmento2.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco da Compensação::G001";
            cdObjectBasesSistemasSegmento2.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBasesSistemasSegmento2.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Registro Detalhe de Lote::G003";
            cdObjectBasesSistemasSegmento2.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBasesSistemasSegmento2.CodigoSegmento = "14:1:A:R:0:14-14:2:Erro - Código de Segmento no Reg. Detalhe::G039";
            cdObjectBasesSistemasSegmento2.UsoExclusivoFebrabanCnab1 = "15:3:A:V:0:15-17::Erro - Uso CNAB/FEBRABAN::G004";
            cdObjectBasesSistemasSegmento2.CodigoBanco = "18:3:N:V:0:18-20::Erro - Código do Banco::2001";
            cdObjectBasesSistemasSegmento2.NomeBanco = "21:20:A:V:0:21-40::Erro - Descrição Nome do Banco::2002";
            cdObjectBasesSistemasSegmento2.CodigoAgencia = "41:5:N:V:0:41-45::Erro - Código da Agência::2003";
            cdObjectBasesSistemasSegmento2.NomeAgencia = "46:30:A:V:0:46-75::Erro - Descrição do nome da Agência::2004";
            cdObjectBasesSistemasSegmento2.SegmentoAgencia = "76:30:A:V:0:76-105::Erro - Descrição do Segmento da Agência::2005";
            cdObjectBasesSistemasSegmento2.Logradouro = "106:30:A:V:0:106-135::Erro - Nome da Rua, Av. Pça, Etc::G032";
            cdObjectBasesSistemasSegmento2.NumeroLocal = "136:5:N:V:0:136-140::Erro - Número do Local::G032";
            cdObjectBasesSistemasSegmento2.Complemento = "141:15:A:V:0:141-155::Erro - Casa, Apto, etc.::G032";
            cdObjectBasesSistemasSegmento2.Bairro = "156:15:A:V:0:156-170::Erro - Nome do Bairro::G032";
            cdObjectBasesSistemasSegmento2.Cidade = "171:20:A:V:0:171-190::Erro - Nome da Cidade::G033";
            cdObjectBasesSistemasSegmento2.CEP = "191:5:N:V:0:191-195::Erro - CEP::G034";
            cdObjectBasesSistemasSegmento2.ComplementoCEP = "196:3:A:V:0:196-198::Erro - Complemento do CEP::G035";
            cdObjectBasesSistemasSegmento2.Estado = "199:2:A:V:0:199-200::Erro - Nome do Estado::G036";
            cdObjectBasesSistemasSegmento2.UsoExclusivoFebrabanCnab2 = "201:40:A:V:0:201-240::Erro - Uso CNAB/FEBRABAN::G004";


            JsonObjectsGenerator.AddProperty(dynamicList, segmento2_BasesSistemas, cdObjectBasesSistemasSegmento2);

            #endregion

            #region SEGMENTO 3
            // Detalhe de Lote (Segmento 3)
            cdObjectBasesSistemasSegmento3.CodigoBancoCompensacao = "1:3:N:R:0:1-3::Erro - Código no Banco da Compensação::G001";
            cdObjectBasesSistemasSegmento3.LoteServico = "4:4:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObjectBasesSistemasSegmento3.TipoRegistro = "8:1:N:R:0:8-8:3:Erro - Registro Detalhe de Lote::G003";
            cdObjectBasesSistemasSegmento3.NumeroRegistroLote = "9:5:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObjectBasesSistemasSegmento3.CodigoSegmento = "14:1:A:R:0:14-14:2:Erro - Código de Segmento no Reg. Detalhe::G039";
            cdObjectBasesSistemasSegmento3.UsoExclusivoFebrabanCnab1 = "15:3:A:V:0:15-17::Erro - Uso CNAB/FEBRABAN::G004";
            cdObjectBasesSistemasSegmento3.DataPagamentoTarifa = "18:8:N:V:0:18-25::Erro - Data do Pagamento da Tarifa:D:3001";
            cdObjectBasesSistemasSegmento3.TipoServicoPagamento = "26:8:N:V:0:26-33::Erro - Tipo de Serviço de Pagamento::G025";
            cdObjectBasesSistemasSegmento3.ModalidadePagamento = "34:8:N:V:0:34-41::Erro - Modalidade de Pagamento::3002";
            cdObjectBasesSistemasSegmento3.OperacaoGeradoraTarifa = "42:5:N:V:0:42-46::Erro - Operação que gera Cobrança de Tarifa::3003";
            cdObjectBasesSistemasSegmento3.QuantidadeTarifasData = "47:6:N:V:0:47-52::Erro - Quantidade de Tarifas cobradas na Data::3004";
            cdObjectBasesSistemasSegmento3.QuantidadeTarifasPeriodo = "53:6:N:V:0:53-58::Erro - Quantidade de Tarifas Acumuladas cobradas no Período::3005";
            cdObjectBasesSistemasSegmento3.ValorTarifaIndividual = "59:13:N:V:0:59-73::Erro - Valor da Tarifa Individual Contratada::3006";
            cdObjectBasesSistemasSegmento3.ValorTarifasAcumuladasData = "74:13:N:V:0:74-88::Erro - Valor das Tarifas Acumuladas cobradas na Data::3007";
            cdObjectBasesSistemasSegmento3.ValorTarifasAcumuladasPeriodo = "89:13:N:V:0:89-103::Erro - Valor das Tarifas Acumuladas cobradas no Período::3008";
            cdObjectBasesSistemasSegmento3.UsoExclusivoFebrabanCnab2 = "104:137:A:V:0:104-240::Erro - Uso CNAB/FEBRABAN::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, segmento3_BasesSistemas, cdObjectBasesSistemasSegmento3);
            #endregion


            #endregion

            return dynamicList;

        }
    }
}