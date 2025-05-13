using BRD_API_REGRAS.Services.Interfaces;
using Microsoft.Win32;
using Swashbuckle.Swagger;
using System.Drawing;
using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using System.Web.Helpers;

namespace BRD_API_REGRAS.Services
{
    public class LayoutCob240Service : ILayoutCob240Service
    {
        #region CONSTANTES

        const string registroTipo0 = "REGISTRO_TIPO_0"; // Header de arquivo
        const string registroTipo9 = "REGISTRO_TIPO_9"; // Trailer de arquivo
        const string registroTipo1 = "REGISTRO_TIPO_1"; // Header de lote
        const string registroTipo3P = "REGISTRO_TIPO_3P"; // Detalhe
        const string registroTipo3R = "REGISTRO_TIPO_3R"; // Detalhe
        const string registroTipo3S = "REGISTRO_TIPO_3S"; // Detalhe
        const string registroTipo3Y01 = "REGISTRO_TIPO_3Y01"; // Detalhe
        const string registroTipo3Y03 = "REGISTRO_TIPO_3Y03"; // Detalhe
        const string registroTipo3Y50 = "REGISTRO_TIPO_3Y50"; // Detalhe
        const string registroTipo3T = "REGISTRO_TIPO_3T"; // Detalhe
        const string registroTipo3U = "REGISTRO_TIPO_3U"; // Detalhe
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
            dynamic cdObject3R = new ExpandoObject();
            dynamic cdObject3S = new ExpandoObject();
            dynamic cdObject3Y01 = new ExpandoObject();
            dynamic cdObject3Y03 = new ExpandoObject();
            dynamic cdObject3Y50 = new ExpandoObject();
            dynamic cdObject3T = new ExpandoObject();
            dynamic cdObject3U = new ExpandoObject();
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

            // ========================================================================
            // Header de arquivo
            cdObject0.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject0.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject0.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject0.CNAB1 = "9:009:A:R:0:9-17::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.TipoInscrição = "18:001:N:R:0:18-18::Erro - Tipo de Inscrição da Empresa::G005";
            cdObject0.NúmeroInscrição = "19:014:N:R:0:19-32::Erro - Número de Inscrição da Empresa::G006";
            cdObject0.Convênio = "33:020:N:R:0:33-52::Erro - Código do Convênio no Banco::G007";
            cdObject0.Agência = "53:005:N:R:0:53-57::Erro - Agência Mantenedora da Conta::G008";
            cdObject0.AgênciaDV = "58:001:A:R:0:58-58::Erro - Dígito Verificador da Agência::G009";
            cdObject0.Conta = "59:012:N:R:0:59-70::Erro - Número da Conta-Corrente::G010";
            cdObject0.ContaDV = "71:001:A:R:0:71-71::Erro - Dígito Verificador da Conta::G011";
            cdObject0.AgContaDV = "72:001:A:R:0:72-72::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject0.NomeEmpresa = "73:030:A:R:0:73-102::Erro - Nome da Empresa::G013";
            cdObject0.NomeBanco = "103:030:A:R:0:103-132::Erro - Nome do Banco::G014";
            cdObject0.CNAB2 = "133:010:A:R:0:133-142::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject0.CódigoRemessa = "143:001:N:R:0:143-143::Erro - Código Remessa/Retorno::G015";
            cdObject0.DataGeração = "144:008:N:R:0:144-151::Erro - Data de Geração do Arquivo:D:G016";
            cdObject0.HoraGeração = "152:006:N:R:0:152-157::Erro - Hora de Geração do Arquivo::G017";
            cdObject0.NúmeroSequencial = "158:006:N:R:0:158-163::Erro - Número Sequencial do Arquivo::G018";
            cdObject0.VersãoLayout = "164:003:N:R:0:164-166::Erro - N° da Versão do Layout do Arquivo::G019";
            cdObject0.Densidade = "167:005:N:R:0:167-171::Erro - Densidade de Gravação do Arquivo::G020";
            cdObject0.ReservadoBanco = "172:020:A:R:0:172-191::Erro - Para Uso Reservado do Banco::G021";
            cdObject0.ReservadoEmpresa = "192:020:A:R:0:192-211::Erro - Para Uso Reservado da Empresa::G022";
            cdObject0.CNAB_Final = "212:029:A:R:0:212-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
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
            cdObject1.Registro = "008:001:N:R:0:008-008:1:Erro - Tipo de Registro::G003";
            cdObject1.Operacao = "009:001:A:R:0:009-009::Erro - Tipo de Operação::G028";
            cdObject1.Servico = "010:002:N:R:0:010-011:01:Erro - Tipo de Serviço::G025";
            cdObject1.CNAB1 = "012:002:A:R:0:012-013::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject1.LayoutLote = "014:003:N:R:0:014-016:042:Erro - Nº da Versão do Layout do Lote::G030";
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
            cdObject5.TipoRegistro = "008:001:N:R:0:008-008:5:Erro - Tipo de Registro::Tipo de Registro";
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
            cdObject3P.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::E003";
            cdObject3P.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::E038";
            cdObject3P.Segmento = "14:001:A:R:0:14-14:P:Erro - Cód. Segmento do Registro Detalhe::E039";
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
            cdObject3P.ValorTítulo = "86:015:N:R:0:86-100::Erro - Valor Nominal do Título::E070"; // Ajustado de 13 para 15 (13+2 decimais)
            cdObject3P.AgCobradora = "101:005:N:R:0:101-105::Erro - Agência Encarregada da Cobrança::E014";
            cdObject3P.AgCobradoraDV = "106:001:A:R:0:106-106::Erro - Digito Verificador da Agência::E009";
            cdObject3P.EspécieTítulo = "107:002:N:R:0:107-108::Erro - Espécie do Título::E015";
            cdObject3P.Aceite = "109:001:A:R:0:109-109::Erro - Identific. de Título Aceito/Não Aceito::E016";
            cdObject3P.DataEmissãoTítulo = "110:008:N:R:0:110-117::Erro - Data da Emissão do Título:D:E071";
            cdObject3P.CódJurosMora = "118:001:N:R:0:118-118::Erro - Código do Juros de Mora::E018";
            cdObject3P.DataJurosMora = "119:008:N:R:0:119-126::Erro - Data do Juros de Mora:D:E019";
            cdObject3P.JurosMora = "127:015:N:R:0:127-141::Erro - Juros de Mora por Dia/Taxa::E020"; // Ajustado de 13 para 15 (13+2 decimais)
            cdObject3P.CódDesc1 = "142:001:N:R:0:142-142::Erro - Código do Desconto 1::E021";
            cdObject3P.DataDesc1 = "143:008:N:R:0:143-150::Erro - Data do Desconto 1:D:E022";
            cdObject3P.Desconto1 = "151:015:N:R:0:151-165::Erro - Valor/Percentual a ser Concedido::E023"; // Ajustado de 13 para 15 (13+2 decimais)
            cdObject3P.ValorICF = "166:015:N:R:0:166-180::Erro - Valor do ICF a ser Recolhido::E024"; // Ajustado de 13 para 15 (13+2 decimais)
            cdObject3P.ValorAbatimento = "181:015:N:R:0:181-195::Erro - Valor do Abatimento::E045"; // Ajustado de 13 para 15 (13+2 decimais)
            cdObject3P.UsoEmpresaBeneficiario = "196:025:A:R:0:196-220::Erro - Identificação do Título na Empresa::5072";
            cdObject3P.CodigoProtesto = "221:001:N:R:0:221-221::Erro - Código para Protesto::C026";
            cdObject3P.PrazoProtesto = "222:002:N:R:0:222-223::Erro - Número de Dias para Protesto::C027";
            cdObject3P.CodigoBaixaDevolucao = "224:001:N:R:0:224-224::Erro - Código para Baixa/Devolução::C028";
            cdObject3P.PrazoBaixaDevolucao = "225:003:N:R:0:225-227::Erro - Número de Dias para Baixa/Devolução::C029";
            cdObject3P.CodigoMoeda = "228:002:N:R:0:228-229::Erro - Código da Moeda::G065";
            cdObject3P.NumeroContrato = "230:010:N:R:0:230-239::Erro - Nº do Contrato da Operação de Créd.::C030";
            cdObject3P.CNAB = "240:001:A:R:0:240-240::Erro - Uso Exclusivo FEBRABAN/CNAB::5004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3P, cdObject3P);
            // ========================================================================

            // Segmento 3R
            cdObject3R.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3R.Controle = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3R.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObject3R.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3R.Serviço = "14:001:A:R:0:14-14:R:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3R.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3R.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";
            cdObject3R.CódDesc2 = "18:001:N:R:0:18-18::Erro - Código do Desconto 2::C021";
            cdObject3R.DataDesc2 = "19:008:N:R:0:19-26::Erro - Data do Desconto 2:D:C022";
            cdObject3R.Desconto2 = "27:015:N:R:0:27-41::Erro - Valor/Percentual a ser Concedido::C023"; // 13+2 decimais
            cdObject3R.CódDesc3 = "42:001:N:R:0:42-42::Erro - Código do Desconto 3::C021";
            cdObject3R.DataDesc3 = "43:008:N:R:0:43-50::Erro - Data do Desconto 3:D:C022";
            cdObject3R.Desconto3 = "51:015:N:R:0:51-65::Erro - Valor/Percentual a ser Concedido::C033"; // 13+2 decimais
            cdObject3R.CódMulta = "66:001:N:R:0:66-66::Erro - Código da Multa::G073";
            cdObject3R.DataMulta = "67:008:N:R:0:67-74::Erro - Data da Multa:D:G074";
            cdObject3R.ValorMulta = "75:015:N:R:0:75-89::Erro - Valor/Percentual a ser Aplicado::G075"; // 13+2 decimais
            cdObject3R.InfoPagador = "90:010:A:R:0:90-99::Erro - Informação ao Pagador::C036";
            cdObject3R.Mensagem3 = "100:040:A:R:0:100-139::Erro - Mensagem 3::C037";
            cdObject3R.TipoOperação = "100:001:A:R:0:100-100::Erro - Tipo de Operação::";
            cdObject3R.UsoChequeEspecial = "101:001:A:R:0:101-101::Erro - Utilização do Cheque Especial::";
            cdObject3R.ConsultaSaldo = "102:001:A:R:0:102-102::Erro - Consulta Saldo após o Vencimento::";
            cdObject3R.NúmeroContrato = "103:025:A:R:0:103-127::Erro - Número Cód. Identificação/Contrato::";
            cdObject3R.PrazoValidade = "128:008:N:R:0:128-135::Erro - Prazo de Validade do Contrato:D:";
            cdObject3R.Brancos1 = "136:004:A:R:0:136-139::Erro - Brancos::";
            cdObject3R.Mensagem4 = "140:040:A:R:0:140-179::Erro - Mensagem 4::C037";
            cdObject3R.CNAB2 = "180:020:A:R:0:180-199::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3R.CodOcorPagador = "200:008:N:R:0:200-207::Erro - Cód. Ocor. do Pagador::C038";
            cdObject3R.BancoDébito = "208:003:N:R:0:208-210::Erro - Cód. do Banco na Conta do Débito::G001";
            cdObject3R.AgênciaDébito = "211:005:N:R:0:211-215::Erro - Código da Agência do Débito::G008";
            cdObject3R.AgênciaDébitoDV = "216:001:A:R:0:216-216::Erro - Digito Verificador da Agência::G009";
            cdObject3R.ContaDébito = "217:012:N:R:0:217-228::Erro - Conta-Corrente para Débito::G010";
            cdObject3R.ContaDébitoDV = "229:001:A:R:0:229-229::Erro - Digito Verificador da Conta::G011";
            cdObject3R.AgContaDébitoDV = "230:001:A:R:0:230-230::Erro - Digito Verificador Ag/Conta::G012";
            cdObject3R.AvisoDébito = "231:001:N:R:0:231-231::Erro - Aviso para Débito Automático::C039";
            cdObject3R.CNAB3 = "232:009:A:R:0:232-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3R, cdObject3R);

            // ========================================================================
            // Segmento 3S
            cdObject3S.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3S.Controle = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3S.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObject3S.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3S.Segmento = "14:001:A:R:0:14-14:S:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3S.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3S.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";

            // Mensagem - Tipo de Impressão 1 ou 2
            cdObject3S.TipoImpressão = "18:001:N:R:0:18-18::Erro - Identificação da Impressão::C040";
            cdObject3S.NºLinha = "19:002:N:R:0:19-20::Erro - Número da Linha a ser Impressa::C041";
            cdObject3S.Mensagem = "21:140:A:R:0:21-160::Erro - Mensagem a ser Impressa::C042";
            cdObject3S.TipoFonte = "161:002:N:R:0:161-162::Erro - Tipo do Caractere a ser Impresso::C043";
            cdObject3S.CNAB_Impressão = "163:078:A:R:0:163-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";

            // Mensagem - Tipo de Impressão 3 (alternativa)
            cdObject3S.TipoImpressão_Alt = "18:001:N:R:0:18-18::Erro - Identificação da Impressão::C040";
            cdObject3S.Informação5 = "19:040:A:R:0:19-58::Erro - Mensagem 5::C037";
            cdObject3S.Informação6 = "59:040:A:R:0:59-98::Erro - Mensagem 6::C037";
            cdObject3S.Informação7 = "99:040:A:R:0:99-138::Erro - Mensagem 7::C037";
            cdObject3S.Informação8 = "139:040:A:R:0:139-178::Erro - Mensagem 8::C037";
            cdObject3S.Informação9 = "179:040:A:R:0:179-218::Erro - Mensagem 9::C037";
            cdObject3S.CNAB_Impressão_Alt = "219:022:A:R:0:219-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3S, cdObject3S);

            // ========================================================================
            // Segmento 3Y01
            cdObject3Y01.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3Y01.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3Y01.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObject3Y01.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3Y01.Segmento = "14:001:A:R:0:14-14:Y:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3Y01.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3Y01.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";
            cdObject3Y01.CodRegOpcional = "18:002:N:R:0:18-19:01:Erro - Identificação Registro Opcional::G067";
            cdObject3Y01.TipoInscrição = "20:001:N:R:0:20-20::Erro - Tipo de Inscrição::G005";
            cdObject3Y01.NúmeroInscrição = "21:015:N:R:0:21-35::Erro - Número de Inscrição::G006";
            cdObject3Y01.Nome = "36:040:A:R:0:36-75::Erro - Nome do Beneficiário Final::C060";
            cdObject3Y01.Endereço = "76:040:A:R:0:76-115::Erro - Endereço::G032";
            cdObject3Y01.Bairro = "116:015:A:R:0:116-130::Erro - Bairro::G032";
            cdObject3Y01.CEP = "131:005:N:R:0:131-135::Erro - CEP::G034";
            cdObject3Y01.SuffixoCEP = "136:003:N:R:0:136-138::Erro - Suffixo do CEP::G035";
            cdObject3Y01.Cidade = "139:015:A:R:0:139-153::Erro - Cidade::G033";
            cdObject3Y01.UF = "154:002:A:R:0:154-155::Erro - Unidade da Federação::G036";
            cdObject3Y01.CNAB_Final = "156:085:A:R:0:156-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3Y01, cdObject3Y01);

            // ========================================================================
            // Segmento 3Y03
            cdObject3Y03.Banco = "1:003:N:R:0:1-3::Erro - Código no Banco na Compensação::G001";
            cdObject3Y03.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3Y03.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject3Y03.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3Y03.Segmento = "14:001:A:R:0:14-14::Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3Y03.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CMAB::G004";
            cdObject3Y03.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento::C004";
            cdObject3Y03.CodRegOpcional = "18:002:N:R:0:18-19::Erro - Identificação Registro Opcional::G067";
            cdObject3Y03.Email = "20:050:A:R:0:20-69::Erro - E-mail para envio da informação::G032";
            cdObject3Y03.DDD = "70:002:N:R:0:70-71::Erro - Código DDD::G032";
            cdObject3Y03.Celular = "72:009:N:R:0:72-80::Erro - Número do celular (para envio de SMS)::G032";
            cdObject3Y03.TipoChavePIX = "81:001:N:R:0:81-81::Erro - Tipo de Chave PIX::G103";
            cdObject3Y03.ChavePIX_URL = "82:077:A:R:0:82-158::Erro - Chave PIX / URL do QRCode::G102";
            cdObject3Y03.TXID = "159:035:A:R:0:159-193::Erro - Código de Identificação do QR Code::G102";
            cdObject3Y03.CNAB_Final = "194:047:A:R:0:194-240::Erro - Uso Exclusivo FEBRABAN/CMAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3Y03, cdObject3Y03);

            // ========================================================================
            // Segmento 3Y50
            cdObject3Y50.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3Y50.Controle = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3Y50.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObject3Y50.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3Y50.Segmento = "14:001:A:R:0:14-14:Y:Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3Y50.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3Y50.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Remessa::C004";
            cdObject3Y50.CodRegOpcional = "18:002:N:R:0:18-19:50:Erro - Identificação Registro Opcional::G067";
            cdObject3Y50.Agência = "20:005:N:R:0:20-24::Erro - Agência Mantenedora da Conta::G008";
            cdObject3Y50.AgênciaDV = "25:001:A:R:0:25-25::Erro - Digito Verificador da Agência::G009";
            cdObject3Y50.Conta = "26:012:N:R:0:26-37::Erro - Número da Conta-Corrente::G010";
            cdObject3Y50.ContaDV = "38:001:A:R:0:38-38::Erro - Digito Verificador da Conta::G011";
            cdObject3Y50.AgContaDV = "39:001:A:R:0:39-39::Erro - Digito Verificador da Ag/Conta::G012";
            cdObject3Y50.IdentificaçãoProduto = "40:003:A:R:0:40-42::Erro - Identificação do Produto::G069";
            cdObject3Y50.Zeros = "43:005:N:R:0:43-47::Erro - Zeros::G069";
            cdObject3Y50.NossoNúmero = "48:011:N:R:0:48-58::Erro - Nosso Número::G069";
            cdObject3Y50.DigitoNossoNúmero = "59:001:A:R:0:59-59::Erro - Digito do Nosso Número::G069";
            cdObject3Y50.CódRateio = "60:001:N:R:0:60-60::Erro - Cód. Cálc. Rateio p/ Beneficiário::C061";
            cdObject3Y50.TipoValor = "61:001:N:R:0:61-61::Erro - Tipo de Valor Inform.::C062";
            cdObject3Y50.ValorPercentual = "62:015:N:R:0:62-76::Erro - Valor ou % (Percentual)::C074";
            cdObject3Y50.BancoBeneficiário = "77:003:N:R:0:77-79::Erro - Código Banco p/ Créd. Benef.::G001";
            cdObject3Y50.AgênciaBeneficiário = "80:005:N:R:0:80-84::Erro - Código Agência p/ Créd. Benef.::G008";
            cdObject3Y50.AgênciaBeneficiárioDV = "85:001:A:R:0:85-85::Erro - Digito Agência p/ Créd. Benef.::G009";
            cdObject3Y50.ContaBeneficiário = "86:012:N:R:0:86-97::Erro - C/C p/ Créd. Beneficiário::G010";
            cdObject3Y50.ContaBeneficiárioDV = "98:001:A:R:0:98-98::Erro - Digito C/C p/ Créd. Beneficiário::G011";
            cdObject3Y50.AgContaBeneficiárioDV = "99:001:A:R:0:99-99::Erro - Digito Ag/Conta Beneficiário::G012";
            cdObject3Y50.NomeBeneficiário = "100:040:A:R:0:100-139::Erro - Nome do Beneficiário::G013";
            cdObject3Y50.Parcela = "140:006:A:R:0:140-145::Erro - Ident. Parcela do Rateio::C063";
            cdObject3Y50.DiasCrédito = "146:003:N:R:0:146-148::Erro - Qtde. Dias p/ Créd. Beneficiário::C064";
            cdObject3Y50.DataCrédito = "149:008:N:R:0:149-156::Erro - Data Crédito Beneficiário:D:C065";
            cdObject3Y50.MotivoOcorrência = "157:010:N:R:0:157-166::Erro - Ident. das Rejeições::C066";
            cdObject3Y50.CNAB_Final = "167:074:A:R:0:167-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3Y50, cdObject3Y50);

            // ========================================================================
            // Segmento 3T
            cdObject3T.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3T.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3T.Registro = "8:001:N:R:0:8-8:3:Erro - Tipo de Registro::G003";
            cdObject3T.NºRegistro = "9:005:N:R:0:9-13::Erro - Número Sequencial Registro no Lote::G038";
            cdObject3T.Segmento = "14:001:A:R:0:14-14:T:Erro - Código Segmento do Registro Detalhe::G039";
            cdObject3T.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";
            cdObject3T.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Retorno::C044";
            cdObject3T.Agência = "18:005:N:R:0:18-22::Erro - Agência Mantenedora da Conta::G008";
            cdObject3T.AgênciaDV = "23:001:N:R:0:23-23::Erro - Dígito Verificador da Agência::G009";
            cdObject3T.Conta = "24:012:N:R:0:24-35::Erro - Número da Conta-Corrente::G010";
            cdObject3T.ContaDV = "36:001:A:R:0:36-36::Erro - Dígito Verificador da Conta::G011";
            cdObject3T.AgContaDV = "37:001:A:R:0:37-37::Erro - Dígito Verificador da Ag/Conta::G012";
            cdObject3T.NossoNúmero = "38:020:N:R:0:38-57::Erro - Identificação do Título::G069";
            cdObject3T.Carteira = "58:001:N:R:0:58-58::Erro - Código da Carteira::C006";
            cdObject3T.NºDocumento = "59:015:A:R:0:59-73::Erro - Número do Documento de Cobrança::C011";
            cdObject3T.Vencimento = "74:008:N:R:0:74-81::Erro - Data do Vencimento do Título:D:C012";
            cdObject3T.ValorTítulo = "82:015:N:R:0:82-96::Erro - Valor Nominal do Título::G070"; // 13+2 decimais
            cdObject3T.BancoCobrador = "97:003:N:R:0:97-99::Erro - Número do Banco::C045";
            cdObject3T.AgênciaCobradora = "100:005:N:R:0:100-104::Erro - Agência Cobradora/Recebedora::C008";
            cdObject3T.AgênciaCobradoraDV = "105:001:A:R:0:105-105::Erro - Dígito Verificador da Agência::G009";
            cdObject3T.UsoEmpresa = "106:025:A:R:0:106-130::Erro - Identificação do Título na Empresa::G072";
            cdObject3T.CódMoeda = "131:002:N:R:0:131-132::Erro - Código da Moeda::G065";
            cdObject3T.TipoInscrição = "133:001:N:R:0:133-133::Erro - Tipo de Inscrição::G005";
            cdObject3T.NúmeroInscrição = "134:015:N:R:0:134-148::Erro - Número de Inscrição::G006";
            cdObject3T.Nome = "149:040:A:R:0:149-188::Erro - Nome::G013";
            cdObject3T.NºContrato = "189:010:N:R:0:189-198::Erro - Nº do Contr. da Operação de Crédito::C030";
            cdObject3T.ValorTarifa = "199:015:N:R:0:199-213::Erro - Valor da Tarifa / Custas::G076"; // 13+2 decimais
            cdObject3T.MotivoOcorrência = "214:010:A:R:0:214-223::Erro - Identificação para Rejeições, Tarifas, Custas, Liquidação e Baixas::C047";
            cdObject3T.CNAB_Final = "224:017:A:R:0:224-240::Erro - Uso Exclusivo FEBRABAN/CNAB::6004";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3T, cdObject3T);

            // ========================================================================
            // Segmento 3U
            cdObject3U.Banco = "1:003:N:R:0:1-3::Erro - Código do Banco na Compensação::G001";
            cdObject3U.Lote = "4:004:N:R:0:4-7::Erro - Lote de Serviço::G002";
            cdObject3U.Registro = "8:001:N:R:0:8-8::Erro - Tipo de Registro::G003";
            cdObject3U.NºRegistro = "9:005:N:R:0:9-13::Erro - Nº Sequencial do Registro no Lote::G038";
            cdObject3U.Segmento = "14:001:A:R:0:14-14::Erro - Cód. Segmento do Registro Detalhe::G039";
            cdObject3U.CNAB = "15:001:A:R:0:15-15::Erro - Uso Exclusivo FEBRABAN/CMAB::G004";
            cdObject3U.CódMov = "16:002:N:R:0:16-17::Erro - Código de Movimento Retorno::C044";
            cdObject3U.Acréscimos = "18:015:N:R:0:18-32::Erro - Juros / Multa / Encargos::C048";
            cdObject3U.ValorDesconto = "33:015:N:R:0:33-47::Erro - Valor do Desconto Concedido::C049";
            cdObject3U.ValorAbatimento = "48:015:N:R:0:48-62::Erro - Valor do Abat. Concedido/Cancel.::C050";
            cdObject3U.ValorIOF = "63:015:N:R:0:63-77::Erro - Valor do IOF Recolhido::G077";
            cdObject3U.ValorPago = "78:015:N:R:0:78-92::Erro - Valor Pago pelo Pagador::C052";
            cdObject3U.ValorLíquido = "93:015:N:R:0:93-107::Erro - Valor Líquido a ser Creditado::G078";
            cdObject3U.OutrasDespesas = "108:015:N:R:0:108-122::Erro - Valor de Outras Despesas::C054";
            cdObject3U.OutrosCréditos = "123:015:N:R:0:123-137::Erro - Valor de Outros Créditos::C055";
            cdObject3U.DataOcorrência = "138:008:N:R:0:138-145::Erro - Data da Ocorrência:D:C056";
            cdObject3U.DataCrédito = "146:008:N:R:0:146-153::Erro - Data da Efetivação do Crédito:D:C057";

            cdObject3U.CódOcorrência = "154:004:A:R:0:154-157::Erro - Código da Ocorrência::A001";
            cdObject3U.DataOcorrênciaPagador = "158:008:N:R:0:158-165::Erro - Data da Ocorrência:D:C058";
            cdObject3U.ValorOcorrência = "166:015:N:R:0:166-180::Erro - Valor da Ocorrência::C059"; // 13+2 decimais
            cdObject3U.ComplementoOcorrência = "181:030:A:R:0:181-210::Erro - Complemento da Ocorrência::A002";
            cdObject3U.CódBancoCorrespondente = "211:003:N:R:0:211-213::Erro - Cód. Banco Correspondente Compens.::C031";
            cdObject3U.NossoNúmeroBancoCorresp = "214:020:N:R:0:214-233::Erro - Nosso Nº Banco Correspondente::C032";
            cdObject3U.CNAB_Final = "234:007:A:R:0:234-240::Erro - Uso Exclusivo FEBRABAN/CNAB::G004";

            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3U, cdObject3U);
            return dynamicList;

        }
    }
}