using BRD_API_REGRAS.Services.Interfaces;
using System.Dynamic;

namespace BRD_API_REGRAS.Services
{
    public class LayoutCob400Service : ILayoutCob400Service
    {
        #region CONSTANTES

        const string registroTipoZero = "REGISTRO_TIPO_0"; // Header de arquivo
        const string registroTipoNove = "REGISTRO_TIPO_9"; // Trailer de arquivo
        const string registroTipo1 = "REGISTRO_TIPO_1";
        const string registroTipo2 = "REGISTRO_TIPO_2";
        const string registroTipo3 = "REGISTRO_TIPO_3";
        const string registroTipo6 = "REGISTRO_TIPO_6";
        const string registroTipo7 = "REGISTRO_TIPO_7";


        #endregion

        public dynamic MontarJsonCob400(dynamic dynamicList, string codigoArquivo) // COB400
        {
            dynamic cdObject0 = new ExpandoObject();
            dynamic cdObject1 = new ExpandoObject();
            dynamic cdObject2 = new ExpandoObject();
            dynamic cdObject3 = new ExpandoObject();
            dynamic cdObject6 = new ExpandoObject();
            dynamic cdObject7 = new ExpandoObject();
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

            cdObject0.IdentificacaoRegistro = "001:001:N:R:0:001-001:0:Erro - Identificação do Registro::";
            cdObject0.IdentificacaoArquivoRemessa = "002:001:N:R:0:002-002:1:Erro - Identificação do Arquivo-Remessa::";
            cdObject0.LiteralRemessa = "003:007:A:R:0:003-009:REMESSA:Erro - Literal Remessa::";
            cdObject0.CodigoServico = "010:002:N:R:0:010-011:01:Erro - CÓdigo de Serviço::";
            cdObject0.LiteralServico = "012:015:A:R:0:012-026:COBRANCA:Erro - Literal Serviço::";
            cdObject0.CodigoEmpresa = "027:020:N:R:0:027-046::Erro - CÓdigo da Empresa::";
            cdObject0.NomeEmpresa = "047:030:A:R:0:047-076::Erro - Nome da Empresa::";
            cdObject0.NumeroBradescoCompensacao = "077:003:N:R:0:077-079:237:Erro - Número do Bradesco na Câmara de Compensação::";
            cdObject0.NomeBancoExtenso = "080:015:A:R:0:080-094::Erro - Nome do Banco por Extenso::";
            cdObject0.DataGravacaoArquivo = "095:006:N:R:0:095-100::Erro - Data de Gravação do Arquivo:D:";
            cdObject0.Branco1 = "101:008:A:R:0:101-108::Erro - Branco1::";
            cdObject0.IdentificacaoSistema = "109:002:A:R:0:109-110:MX:Erro - Identificação do Sistema::";
            cdObject0.NumeroSequencialRemessa = "111:007:N:R:0:111-117::Erro - Número Sequencial de Remessa::";
            cdObject0.Branco2 = "118:277:A:R:0:118-394::Erro - Branco2::";
            cdObject0.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial do Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipoZero, cdObject0);
            // ========================================================================


            cdObject9.IdentificacaoRegistro = "001:001:N:R:0:001-001:9:Erro - Identificação Registro::";
            cdObject9.Branco = "002:393:A:R:0:002-394::Erro - Branco::";
            cdObject9.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial de Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipoNove, cdObject9);
            // ========================================================================

            cdObject1.IdentificacaoDoRegistro = "001:001:N:R:0:001-001:1:Erro - Identificação do Registro::";
            cdObject1.AgenciaDebitoOpcional = "002:005:N:R:0:002-006::Erro - Agência de Débito (opcional)::";
            cdObject1.DigitoAgenciaDebitoOpcional = "007:001:A:R:0:007-007::Erro - Dígito da Agência de Débito (opcional)::";
            cdObject1.RazaoContaCorrenteOpcional = "008:005:N:R:0:008-012::Erro - Razão da Conta-Corrente (opcional)::";
            cdObject1.ContaCorrenteOpcional = "013:007:N:R:0:013-019::Erro - Conta-Corrente (opcional)::";
            cdObject1.DigitoContaCorrenteOpcional = "020:001:A:R:0:020-020::Erro - Dígito da Conta-Corrente (opcional)::";
            cdObject1.IdentificacaoEmpresaBeneficiaria = "021:017:A:R:0:021-037::Erro - Identificação da Empresa Beneficiária no Banco::";
            cdObject1.NumeroControleParticipante = "038:025:A:R:0:038-062::Erro - Nº Controle do Participante::";
            cdObject1.CodigoBancoDebito = "063:003:N:R:0:063-065:237:Erro - Código do Banco a ser debitado na Câmara de Compensação::";
            cdObject1.CampoMulta = "066:001:N:R:0:066-066::Erro - Campo de Multa::0,2";
            cdObject1.PercentualMulta = "067:004:N:R:0:067-070::Erro - Percentual de Multa::";
            cdObject1.IdentificacaoTituloBanco = "071:011:N:R:0:071-081::Erro - Identificação do Título no Banco::";
            cdObject1.DigitoAutoconferencia = "082:001:A:R:0:082-082::Erro - Dígito de Autoconferência do Número Bancário::";
            cdObject1.DescontoBonificacao = "083:010:N:R:0:083-092::Erro - Desconto Bonificação por dia::";
            cdObject1.CondicaoEmissaoPapeleta = "093:001:N:R:0:093-093::Erro - Condição para Emissão da Papeleta de Cobrança::1,2";
            cdObject1.EmiteBoletoDebito = "094:001:A:R:0:094-094::Erro - Ident. se emite Boleto para Débito Automático::";
            cdObject1.IdentificacaoOperacaoBanco = "095:010:A:R:0:095-104::Erro - Identificação da Operação do Banco::";
            cdObject1.IndicadorRateio = "105:001:A:R:0:105-105:R:Erro - Indicador Rateio Crédito (opcional)::";
            cdObject1.EnderecamentoAviso = "106:001:N:R:0:106-106::Erro - Endereçamento para Aviso do Débito Automático em Conta-Corrente (opcional)::";
            cdObject1.QuantidadePagamentos = "107:002:A:R:0:107-108::Erro - Quantidade de Pagamentos::";
            cdObject1.IdentificacaoOcorrencia = "109:002:N:R:0:109-110::Erro - Identificação da Ocorrência::17,21,24,38,39,43,45,46,47,48,50,53,54";
            cdObject1.NumeroDocumento = "111:010:A:R:0:111-120::Erro - Nº do Documento::";
            cdObject1.DataVencimento = "121:006:N:R:0:121-126::Erro - Data do Vencimento do Título:D:"; // :D para campo de data
            cdObject1.ValorTitulo = "127:013:N:R:0:127-139::Erro - Valor do Título::";
            cdObject1.BancoEncarregado = "140:003:N:R:0:140-142::Erro - Banco Encarregado da Cobrança::";
            cdObject1.AgenciaDepositaria = "143:005:N:R:0:143-147::Erro - Agência Depositária::";
            cdObject1.EspecieTitulo = "148:002:N:R:0:148-149::Erro - Espécie de Título::01,02,03,05,10,11,12,31,32,33,99";
            cdObject1.Identificacao = "150:001:A:R:0:150-150:N:Erro - Identificação::";
            cdObject1.DataEmissaoTitulo = "151:006:N:R:0:151-156::Erro - Data da Emissão do Título:D:";
            cdObject1.PrimeiraInstrucao = "157:002:N:R:0:157-158::Erro - 1ª Instrução::";
            cdObject1.SegundaInstrucao = "159:002:N:R:0:159-160::Erro - 2ª Instrução::";
            cdObject1.ValorDiaAtraso = "161:013:N:R:0:161-173::Erro - Valor a ser Cobrado por Dia de Atraso::";
            cdObject1.DataLimiteDesconto = "174:006:N:R:0:174-179::Erro - Data Limite P/Concessão de Desconto:D:";
            cdObject1.ValorDesconto = "180:013:N:R:0:180-192::Erro - Valor do Desconto::";
            cdObject1.ValorIOF = "193:013:N:R:0:193-205::Erro - Valor do IOF::";
            cdObject1.ValorAbatimento = "206:013:N:R:0:206-218::Erro - Valor do Abatimento a ser Concedido ou Cancelado::";
            cdObject1.TipoInscricaoPagador = "219:002:N:R:0:219-220::Erro - Identificação do Tipo de Inscrição do Pagador::01,02";
            cdObject1.NumeroInscricaoPagador = "221:014:N:R:0:221-234::Erro - Nº Inscrição do Pagador::";
            cdObject1.NomePagador = "235:040:A:R:0:235-274::Erro - Nome do Pagador::";
            cdObject1.EnderecoCompleto = "275:040:A:R:0:275-314::Erro - Endereço Completo::";
            cdObject1.PrimeiraMensagem = "315:012:A:R:0:315-326::Erro - 1ª Mensagem::";
            cdObject1.CEP = "327:005:N:R:0:327-331::Erro - CEP::";
            cdObject1.SufixoCEP = "332:003:N:R:0:332-334::Erro - Sufixo do CEP::";
            cdObject1.BeneficiarioFinal = "335:060:A:R:0:335-394::Erro - Beneficiário Final ou 2ª Mensagem::";
            cdObject1.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial do Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo1, cdObject1);
            // ========================================================================

            cdObject2.TipoRegistro = "001:001:N:R:0:001-001:2:Erro - Tipo Registro::";
            cdObject2.Mensagem1 = "002:080:A:R:0:002-081::Erro - Mensagem 1::";
            cdObject2.Mensagem2 = "082:080:A:R:0:082-161::Erro - Mensagem 2::";
            cdObject2.Mensagem3 = "162:080:A:R:0:162-241::Erro - Mensagem 3::";
            cdObject2.Mensagem4 = "242:080:A:R:0:242-321::Erro - Mensagem 4::";
            cdObject2.DataLimiteDesconto2 = "322:006:N:R:0:322-327::Erro - Data-Limite para Concessão de Desconto 2:D:";
            cdObject2.ValorDesconto2 = "328:013:N:R:0:328-340::Erro - Valor do Desconto::";
            cdObject2.DataLimiteDesconto3 = "341:006:N:R:0:341-346::Erro - Data-Limite para Concessão de Desconto 3:D:";
            cdObject2.ValorDesconto3 = "347:013:N:R:0:347-359::Erro - Valor do Desconto::";
            cdObject2.Reserva = "360:007:A:R:0:360-366::Erro - Reserva::";
            cdObject2.Carteira = "367:003:N:R:0:367-369::Erro - Carteira::";
            cdObject2.Agencia = "370:005:N:R:0:370-374::Erro - Agência::";
            cdObject2.ContaCorrente = "375:007:N:R:0:375-381::Erro - Conta-Corrente::";
            cdObject2.DigitoCC = "382:001:A:R:0:382-382::Erro - Dígito C/C::";
            cdObject2.NossoNumero = "383:011:N:R:0:383-393::Erro - Nosso Número::";
            cdObject2.DACNossoNumero = "394:001:A:R:0:394-394::Erro - DAC Nosso Número::";
            cdObject2.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial de Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo2, cdObject2);
            // ========================================================================

            cdObject3.IdentificacaoRegistro = "001:001:N:R:0:001-001:3:Erro - Identificação do Registro::";
            cdObject3.IdentificacaoEmpresaBanco = "002:016:A:R:0:002-017::Erro - Identificação da Empresa no Banco::";
            cdObject3.IdentificacaoTituloBanco = "018:012:A:R:0:018-029::Erro - Identificação Título no Banco::";
            cdObject3.CodigoCalculoRateio = "030:001:N:R:0:030-030::Erro - Código Para Cálculo do Rateio::1,2,3";
            cdObject3.TipoValorInformado = "031:001:N:R:0:031-031::Erro - Tipo de Valor Informado::1,2";
            cdObject3.Filler1 = "032:012:A:R:0:032-043::Erro - Filler::";
            cdObject3.CodigoBancoCredito1 = "044:003:N:R:0:044-046:237:Erro - Código do Banco para Crédito do 1º Beneficiário::";
            cdObject3.CodigoAgenciaCredito1 = "047:005:N:R:0:047-051::Erro - Código da Agência para Crédito do 1º Beneficiário::";
            cdObject3.DigitoAgenciaCredito1 = "052:001:A:R:0:052-052::Erro - Dígito da Agência para Crédito do 1º Beneficiário::";
            cdObject3.ContaCorrenteCredito1 = "053:012:N:R:0:053-064::Erro - Número da Conta-Corrente para Crédito do 1º Beneficiário::";
            cdObject3.DigitoContaCredito1 = "065:002:A:R:0:065-066::Erro - Dígito da Conta-Corrente para Crédito do 1º Beneficiário::";
            cdObject3.ValorPercentualRateio1 = "066:015:N:R:0:066-080::Erro - Valor, ou Percentual para Rateio::";
            cdObject3.NomeBeneficiario1 = "081:040:A:R:0:081-120::Erro - Nome do 1º Beneficiário::";
            cdObject3.Filler2 = "121:031:A:R:0:121-151::Erro - Filler::";
            cdObject3.Parcela1 = "152:006:A:R:0:152-157::Erro - Parcela::";
            cdObject3.FloatingBeneficiario1 = "158:003:N:R:0:158-160::Erro - Floating para o 1º Beneficiário::";
            cdObject3.CodigoBancoCredito2 = "161:003:N:R:0:161-163:237:Erro - Código do Banco para Crédito do 2º Beneficiário::";
            cdObject3.CodigoAgenciaCredito2 = "164:005:N:R:0:164-168::Erro - Código da Agência para Crédito do 2º Beneficiário::";
            cdObject3.DigitoAgenciaCredito2 = "169:001:A:R:0:169-169::Erro - Dígito da Agência para Crédito do 2º Beneficiário::";
            cdObject3.ContaCorrenteCredito2 = "170:012:N:R:0:170-181::Erro - Número da Conta-Corrente para Crédito do 2º Beneficiário::";
            cdObject3.DigitoContaCredito2 = "182:001:A:R:0:182-182::Erro - Dígito da Conta-Corrente para Crédito do 2º Beneficiário::";
            cdObject3.ValorPercentualRateio2 = "183:015:N:R:0:183-197::Erro - Valor, ou Percentual para Rateio::";
            cdObject3.NomeBeneficiario2 = "198:040:A:R:0:198-237::Erro - Nome do 2º Beneficiário::";
            cdObject3.Filler3 = "238:031:A:R:0:238-268::Erro - Filler::";
            cdObject3.Parcela2 = "269:006:A:R:0:269-274::Erro - Parcela::";
            cdObject3.FloatingBeneficiario2 = "275:003:N:R:0:275-277::Erro - Floating para o 2º Beneficiário::";
            cdObject3.CodigoBancoCredito3 = "278:003:N:R:0:278-280:237:Erro - Código do Banco para Crédito do 3º Beneficiário::";
            cdObject3.CodigoAgenciaCredito3 = "281:005:N:R:0:281-285::Erro - Código da Agência para Crédito do 3º Beneficiário::";
            cdObject3.DigitoAgenciaCredito3 = "286:001:A:R:0:286-286::Erro - Dígito da Agência para Crédito do 3º Beneficiário::";
            cdObject3.ContaCorrenteCredito3 = "287:012:N:R:0:287-298::Erro - Número da Conta-Corrente para Crédito do 3º Beneficiário::";
            cdObject3.DigitoContaCredito3 = "299:001:A:R:0:299-299::Erro - Dígito da Conta-Corrente para Crédito do 3º Beneficiário::";
            cdObject3.ValorPercentualRateio3 = "300:015:N:R:0:300-314::Erro - Valor ou Percentual para Rateio::";
            cdObject3.NomeBeneficiario3 = "315:040:A:R:0:315-354::Erro - Nome do 3º Beneficiário::";
            cdObject3.Filler4 = "355:031:A:R:0:355-385::Erro - Filler::";
            cdObject3.Parcela3 = "386:006:A:R:0:386-391::Erro - Quantidade de Dias para Crédito do Beneficiário::";
            cdObject3.FloatingBeneficiario3 = "392:003:N:R:0:392-394::Erro - Floating para 3º Beneficiário::";
            cdObject3.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial do Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3, cdObject3);
            // ========================================================================

            cdObject6.IdentificacaoRegistro = "001:001:N:R:0:001-001:6:Erro - Identificação do Registro::";
            cdObject6.Carteira = "002:003:N:R:0:002-004::Erro - Carteira::";
            cdObject6.Agencia = "005:005:N:R:0:005-009::Erro - Agência::";
            cdObject6.ContaCorrente = "010:007:N:R:0:010-016::Erro - Conta-Corrente::";
            cdObject6.NossoNumero = "017:011:N:R:0:017-027::Erro - Nosso Número::";
            cdObject6.DigitoNossoNumero = "028:001:A:R:0:028-028::Erro - Dígito do Nosso Número::";
            cdObject6.TipoOperacao = "029:001:N:R:0:029-029::Erro - Tipo de Operação::1,2,3";
            cdObject6.UtilizacaoChequeEspecial = "030:001:A:R:0:030-030::Erro - Utilização do Cheque Especial::S,N";
            cdObject6.ConsultaSaldoAposVencimento = "031:001:A:R:0:031-031::Erro - Consulta Saldo Após o Vencimento::S,N";
            cdObject6.NumeroCodigoIdentificacaoContrato = "032:025:A:R:0:032-056::Erro - Número Cód.Identificação/Contrato::";
            cdObject6.PrazoValidadeContrato = "057:008:N:R:0:057-064::Erro - Prazo de Validade do Contrato/Autorização:D:";
            cdObject6.Brancos = "065:330:A:R:0:065-394::Erro - Brancos::";
            cdObject6.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial do Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo6, cdObject6);
            // ========================================================================

            cdObject7.TipoRegistro = "001:001:N:R:0:001-001:7:Erro - Tipo Registro::";
            cdObject7.EnderecoBeneficiarioFinal = "002:045:A:R:0:002-046::Erro - Endereço Beneficiário Final::";
            cdObject7.CEP = "047:005:N:R:0:047-051::Erro - CEP::";
            cdObject7.SufixoCEP = "052:003:N:R:0:052-054::Erro - Suffixo CEP::";
            cdObject7.Cidade = "055:020:A:R:0:055-074::Erro - Cidade::";
            cdObject7.UF = "075:002:A:R:0:075-076::Erro - UF::";
            cdObject7.Reserva = "077:290:A:R:0:077-366::Erro - Reserva::";
            cdObject7.Carteira = "367:003:N:R:0:367-369::Erro - Carteira::";
            cdObject7.Agencia = "370:005:N:R:0:370-374::Erro - Agência::";
            cdObject7.ContaCorrente = "375:007:N:R:0:375-381::Erro - Conta-Corrente::";
            cdObject7.DigitoCC = "382:001:A:R:0:382-382::Erro - Dígito C/C::";
            cdObject7.NossoNumero = "383:011:N:R:0:383-393::Erro - Nosso Número::";
            cdObject7.DACNossoNumero = "394:001:A:R:0:394-394::Erro - DAC Nosso Número::";
            cdObject7.NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial de Registro::";
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo7, cdObject7);
            // ========================================================================

            return dynamicList;

        }
    }
}