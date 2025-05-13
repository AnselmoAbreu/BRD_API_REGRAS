using BRD_API_REGRAS.Services.Interfaces;
using Microsoft.Win32;
using Swashbuckle.Swagger;
using System.Dynamic;

namespace BRD_API_REGRAS.Services
{
    public class LayoutCob240Service : ILayoutCob240Service
    {
        #region CONSTANTES

        const string registroTipo0 = "REGISTRO_TIPO_0"; // Header de arquivo
        const string registroTipo9 = "REGISTRO_TIPO_9"; // Trailer de arquivo
        const string registroTipo1 = "REGISTRO_TIPO_1"; // Header de lote
        const string registroTipo3P = "REGISTRO_TIPO_3P"; // Detalhe
        const string registroTipo5 = "REGISTRO_TIPO_5"; // Trailer de arquivo

        //const string registroTipo2 = "REGISTRO_TIPO_2";
        //const string registroTipo3 = "REGISTRO_TIPO_3";
        //const string registroTipo6 = "REGISTRO_TIPO_6";
        //const string registroTipo7 = "REGISTRO_TIPO_7";


        #endregion

        public dynamic MontarJsonCob240(dynamic dynamicList, string codigoArquivo) // COB400
        {
            dynamic cdObject0 = new ExpandoObject();
            dynamic cdObject1 = new ExpandoObject();
            dynamic cdObject3P = new ExpandoObject();
            dynamic cdObject5 = new ExpandoObject();
            dynamic cdObject9 = new ExpandoObject();

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
            // : Lista de opções do campo
            //-------------------------------------------------------

            // Header de arquivo

            cdObject0.Banco = "001:003:N:R:0:001-003::Erro - Código do Banco na Compensação::G001";
            cdObject0.Lote = "004:004:N:R:0:004-007::Erro - Lote de Serviço::G002";
            cdObject0.Registro = "008:001:N:R:0:008-008::Erro - Tipo de Registro::G003";
            cdObject0.Operacao = "009:001:A:R:0:009-009::Erro - Tipo de Operação::G028";
            cdObject0.Servico = "010:002:N:R:0:010-011::Erro - Tipo de Serviço::G025";
            cdObject0.CNAB1 = "012:002:A:R:0:012-013::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.LayoutLote = "014:003:N:R:0:014-016::Erro - Nº da Versão do Layout do Lote::G030";
            cdObject0.CNAB2 = "017:001:A:R:0:017-017::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.InscricaoTipo = "018:001:N:R:0:018-018::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject0.InscricaoNumero = "019:015:N:R:0:019-033::Erro - Número de Inscrição da Empresa::G006";
            cdObject0.Convenio = "034:020:N:R:0:034-053::Erro - Código do Convênio no Banco::G007";
            cdObject0.AgenciaCodigo = "054:005:N:R:0:054-058::Erro - Agência Mantenedora da Conta::G008";
            cdObject0.DVAgencia = "059:001:A:R:0:059-059::Erro - Dígito Verificador da Agência::G009";
            cdObject0.ContaNumero = "060:012:N:R:0:060-071::Erro - Número da Conta-Corrente::G010";
            cdObject0.DVConta = "072:001:A:R:0:072-072::Erro - Dígito Verificador da Conta::G011";
            cdObject0.DVAgenciaConta = "073:001:A:R:0:073-073::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject0.NomeEmpresa = "074:030:A:R:0:074-103::Erro - Nome da Empresa::G013";
            cdObject0.Mensagem1 = "104:040:A:R:0:104-143::Erro - Mensagem 1::C073";
            cdObject0.Mensagem2 = "144:040:A:R:0:144-183::Erro - Mensagem 2::C073";
            cdObject0.NumeroRemessa = "184:008:N:R:0:184-191::Erro - Número Sequencial Remessa/Retorno::G079";
            cdObject0.DataGravacao = "192:008:N:R:0:192-199::Erro - Data de Gravação Remessa/Retorno:D:G068";
            cdObject0.DataCredito = "200:008:N:R:0:200-207::Erro - Data do Crédito:D:C003";
            cdObject0.CNAB3 = "208:033:A:R:0:208-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo0, cdObject0);
            // ========================================================================

            // Trailer de arquivo
            cdObject9.Banco = "001:003:N:R:0:001-003::Erro - Código do Banco na Compensação::G001";
            cdObject9.Lote = "004:004:N:R:0:004-007::Erro - Lote de Serviço::G002";
            cdObject9.Registro = "008:001:N:R:0:008-008::Erro - Tipo de Registro::G003";
            cdObject9.CNAB1 = "009:009:A:R:0:009-017::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject9.QtdeLotes = "018:006:N:R:0:018-023::Erro - Quantidade de Lotes do Arquivo::G049";
            cdObject9.QtdeRegistros = "024:006:N:R:0:024-029::Erro - Quantidade de Registros do Arquivo::G056";
            cdObject9.QtdeContas = "030:006:N:R:0:030-035::Erro - Qtde. de Contas p/ Conc. (Lotes)::G037";
            cdObject9.CNAB2 = "036:205:A:R:0:036-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo9, cdObject9);
            // ========================================================================

            // Header de lote
            cdObject1.Banco = "001:003:N:R:0:001-003::Erro - Código do Banco na Compensação::G001";
            cdObject1.Lote = "004:004:N:R:0:004-007::Erro - Lote de Serviço::G002";
            cdObject1.Registro = "008:001:N:R:0:008-008::Erro - Tipo de Registro::G003";
            cdObject1.Operacao = "009:001:A:R:0:009-009::Erro - Tipo de Operação::G028";
            cdObject1.Servico = "010:002:N:R:0:010-011::Erro - Tipo de Serviço::G025";
            cdObject1.CNAB1 = "012:002:A:R:0:012-013::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.LayoutLote = "014:003:N:R:0:014-016::Erro - Nº da Versão do Layout do Lote::G030";
            cdObject1.CNAB2 = "017:001:A:R:0:017-017::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.InscricaoTipo = "018:001:N:R:0:018-018::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject1.InscricaoNumero = "019:015:N:R:0:019-033::Erro - Número de Inscrição da Empresa::G006";
            cdObject1.Convenio = "034:020:N:R:0:034-053::Erro - Código do Convênio no Banco::G007";
            cdObject1.AgenciaCodigo = "054:005:N:R:0:054-058::Erro - Agência Mantenedora da Conta::G008";
            cdObject1.DVAgencia = "059:001:A:R:0:059-059::Erro - Dígito Verificador da Agência::G009";
            cdObject1.ContaNumero = "060:012:N:R:0:060-071::Erro - Número da Conta-Corrente::G010";
            cdObject1.DVConta = "072:001:A:R:0:072-072::Erro - Dígito Verificador da Conta::G011";
            cdObject1.DVAgenciaConta = "073:001:A:R:0:073-073::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject1.NomeEmpresa = "074:030:A:R:0:074-103::Erro - Nome da Empresa::G013";
            cdObject1.Mensagem1 = "104:040:A:R:0:104-143::Erro - Mensagem 1::C073";
            cdObject1.Mensagem2 = "144:040:A:R:0:144-183::Erro - Mensagem 2::C073";
            cdObject1.NumeroRemessa = "184:008:N:R:0:184-191::Erro - Número Sequencial Remessa/Retorno::G079";
            cdObject1.DataGravacao = "192:008:N:R:0:192-199::Erro - Data de Gravação Remessa/Retorno:D:G068";
            cdObject1.DataCredito = "200:008:N:R:0:200-207::Erro - Data do Crédito:D:C003";
            cdObject1.CNAB3 = "208:033:A:R:0:208-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo1, cdObject1);
            // ========================================================================

            // Trailer de lote
            cdObject5.CodigoBanco = "001:003:N:R:0:001-003::Erro - Código do Banco na Compensação::Código do Banco na Compensação";
            cdObject5.LoteServico = "004:004:N:R:0:004-007::Erro - Lote de Serviço::Lote de Serviço";
            cdObject5.TipoRegistro = "008:001:N:R:0:008-008::Erro - Tipo de Registro::Tipo de Registro";
            cdObject5.UsoExclusivoCNAB1 = "009:009:A:R:0:009-017::Erro - Uso Exclusivo FEBRABAN/CNAB::Uso Exclusivo FEBRABAN/CNAB";
            cdObject5.QtdeRegistrosLote = "018:006:N:R:0:018-023::Erro - Quantidade de Registros no Lote::Quantidade de Registros no Lote";
            cdObject5.QtdeTitulosCobranca1 = "024:006:N:R:0:024-029::Erro - Quantidade de Títulos em Cobrança::Quantidade de Títulos em Cobrança";
            cdObject5.ValorTotalTitulosCarteira1 = "030:015:N:R:0:030-046::Erro - Valor Total dos Títulos em Carteiras::Valor Total dos Títulos em Carteiras";
            cdObject5.QtdeTitulosCobranca2 = "047:006:N:R:0:047-052::Erro - Quantidade de Títulos em Cobrança::Quantidade de Títulos em Cobrança";
            cdObject5.ValorTotalTitulosCarteira2 = "053:015:N:R:0:053-069::Erro - Valor Total dos Títulos em Carteiras::Valor Total dos Títulos em Carteiras";
            cdObject5.QtdeTitulosCobranca3 = "070:006:N:R:0:070-075::Erro - Quantidade de Títulos em Cobrança::Quantidade de Títulos em Cobrança";
            cdObject5.ValorTotalTitulosCarteira3 = "076:015:N:R:0:076-092::Erro - Valor Total dos Títulos em Carteiras::Valor Total dos Títulos em Carteiras";
            cdObject5.QtdeTitulosCobranca4 = "093:006:N:R:0:093-098::Erro - Quantidade de Títulos em Cobrança::Quantidade de Títulos em Cobrança";
            cdObject5.ValorTotalTitulosCarteira4 = "099:015:N:R:0:099-115::Erro - Valor Total dos Títulos em Carteiras::Valor Total dos Títulos em Carteiras";
            cdObject5.NumeroAvisoLancamento = "116:008:N:R:0:116-123::Erro - Número do Aviso de Lançamento::Número do Aviso de Lançamento";
            cdObject5.UsoExclusivoCNAB2 = "124:117:A:R:0:124-240::Erro - Uso Exclusivo FEBRABAN/CNAB::Uso Exclusivo FEBRABAN/CNAB";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo5, cdObject5);
            // ========================================================================

            // Segmento 3P
            cdObject3P.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::E001";
            cdObject3P.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::E002";
            cdObject3P.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::E003";
            cdObject3P.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::E038";
            cdObject3P.Segmento = "14:001:A:R:0:14-14::Erro - Cód. Segmento do Registro Detalhe::E039";
            cdObject3P.Serviço = "15:001:A:R:0:15-15::Erro - CNAB::E004";
            cdObject3P.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Remessa::E004";
            cdObject3P.Agência = "18:005:N:R:0:18-22::Erro - Agência Mantenedora da Conta::E008";
            cdObject3P.AgênciaDV = "23:001:A:R:0:23-23::Erro - Digito Verificador da Agência::E009";
            cdObject3P.Conta = "24:012:N:R:0:24-35::Erro - Número da Conta-Corrente::E010";
            cdObject3P.ContaDV = "36:001:A:R:0:36-36::Erro - Digito Verificador da Conta::E011";
            cdObject3P.AgContaDV = "37:001:A:R:0:37-37::Erro - Digito Verificador da Ag/Conta::E012";
            cdObject3P.IdentificaçãoProduto = "38:003:N:R:0:38-40::Erro - Identificação do Produto::E069";
            cdObject3P.Zeros = "41:005:N:R:0:41-45::Erro - Zeros::E069";
            cdObject3P.NossoNúmero = "46:011:N:R:0:46-56::Erro - Nosso Número::E069";
            cdObject3P.DigitoNossoNúmero = "57:001:A:R:0:57-57::Erro - Digito do Nosso Número::E069";
            cdObject3P.Carteira = "58:001:N:R:0:58-58::Erro - Código da Carteira::E006";
            cdObject3P.Cadastro = "59:001:N:R:0:59-59::Erro - Forma de Cadastr. do Título no Banco::E007";
            cdObject3P.TipoDocumento = "60:001:N:R:0:60-60::Erro - Tipo de Documento::E008";
            cdObject3P.EmissãoBoleto = "61:001:N:R:0:61-61::Erro - Identificação da Emissão do Boleto::E009";
            cdObject3P.DistribuiçãoBoleto = "62:001:N:R:0:62-62::Erro - Identificação da Distribuição::E010";
            cdObject3P.NºDocumento = "63:015:A:R:0:63-77::Erro - Número do Documento de Cobrança::E011";
            cdObject3P.Vencimento = "78:008:N:R:0:78-85::Erro - Data de Vencimento do Título:D:E012";
            cdObject3P.ValorTítulo = "86:013:N:R:0:86-98::Erro - Valor Nominal do Título::E070";
            cdObject3P.AgCobradora = "101:005:N:R:0:101-105::Erro - Agência Encarregada da Cobrança::E014";
            cdObject3P.AgCobradoraDV = "106:001:A:R:0:106-106::Erro - Digito Verificador da Agência::E009";
            cdObject3P.EspécieTítulo = "107:002:N:R:0:107-108::Erro - Espécie do Título::E015";
            cdObject3P.Aceite = "109:001:A:R:0:109-109::Erro - Identific. de Título Aceito/Não Aceito::E016";
            cdObject3P.DataEmissãoTítulo = "110:008:N:R:0:110-117::Erro - Data da Emissão do Título:D:E071";
            cdObject3P.CódJurosMora = "118:001:N:R:0:118-118::Erro - Código do Juros de Mora::E018";
            cdObject3P.DataJurosMora = "119:008:N:R:0:119-126::Erro - Data do Juros de Mora:D:E019";
            cdObject3P.JurosMora = "127:013:N:R:0:127-139::Erro - Juros de Mora por Dia/Taxa::E020";
            cdObject3P.CódDesc1 = "142:001:N:R:0:142-142::Erro - Código do Desconto 1::E021";
            cdObject3P.DataDesc1 = "143:008:N:R:0:143-150::Erro - Data do Desconto 1:D:E022";
            cdObject3P.Desconto1 = "151:013:N:R:0:151-163::Erro - Valor/Percentual a ser Concedido::E023";
            cdObject3P.ValorICF = "166:013:N:R:0:166-178::Erro - Valor do ICF a ser Recolhido::E024";
            cdObject3P.ValorAbatimento = "181:013:N:R:0:181-193::Erro - Valor do Abatimento::E045";
            cdObject3P.UsoEmpresaBeneficiario = "196:025:A:R:0:196-220::Erro - Identificação do Título na Empresa::5072";
            cdObject3P.CodigoProtesto = "221:001:N:R:0:221-221::Erro - Código para Protesto::C026";
            cdObject3P.PrazoProtesto = "222:002:N:R:0:222-223::Erro - Número de Dias para Protesto::C027";
            cdObject3P.CodigoBaixaDevolucao = "224:001:N:R:0:224-224::Erro - Código para Baixa/Devolução::C028";
            cdObject3P.PrazoBaixaDevolucao = "225:003:N:R:0:225-227::Erro - Número de Dias para Baixa/Devolução::C029";
            cdObject3P.CodigoMoeda = "228:002:N:R:0:228-229::Erro - Código da Moeda::G065";
            cdObject3P.NumeroContrato = "230:010:N:R:0:230-239::Erro - Nº do Contrato da Operação de Créd.::C030";
            cdObject3P.CNAB = "240:001:A:R:0:240-240::Erro - Uso Exclusivo FEBRABAN/CNAB::5004";

            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3P, cdObject3P);


            return dynamicList;

        }
    }
}