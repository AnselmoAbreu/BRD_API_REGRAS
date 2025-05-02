using System.Dynamic;

namespace BRD_API_REGRAS.Services
{
    public class LayoutCob400Service
    {
        #region CONSTANTES

        const string registroZero = "REGISTRO_TIPO_0"; // Header de arquivo
        const string registroNove = "REGISTRO_TIPO_9"; // Trailer de arquivo
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

            cdObject0 = new
            {
                IdentificacaoRegistro = "001:001:N:R:0:001-001:0:Erro - Identificação do Registro::",
                IdentificacaoArquivoRemessa = "002:001:N:R:0:002-002:1:Erro - Identificação do Arquivo-Remessa::",
                LiteralRemessa = "003:007:N:R:0:003-009:REMESSA:Erro - Literal Remessa::",
                CodigoServico = "010:002:N:R:0:010-011:01:Erro - CÓdigo de Serviço::",
                LiteralServico = "012:015:N:R:0:012-026:COBRANCA:Erro - Literal Serviço::",
                CodigoEmpresa = "027:020:N:R:0:027-046::Erro - CÓdigo da Empresa::",
                NomeEmpresa = "047:030:N:R:0:047-076::Erro - Nome da Empresa::",
                NumeroBradescoCompensacao = "077:003:N:R:0:077-079:237:Erro - Número do Bradesco na Câmara de Compensação::",
                NomeBancoExtenso = "080:015:N:R:0:080-094::Erro - Nome do Banco por Extenso::",
                DataGravacaoArquivo = "095:006:N:R:0:095-100::Erro - Data de Gravação do Arquivo:D:",
                Branco1 = "101:008:N:R:0:101-108::Erro - Branco1::",
                IdentificacaoSistema = "109:002:N:R:0:109-110:MX:Erro - Identificação do Sistema::",
                NumeroSequencialRemessa = "111:007:N:R:0:111-117::Erro - Número Sequencial de Remessa::",
                Branco2 = "118:277:N:R:0:118-394::Erro - Branco2::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial do Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroZero, cdObject0);
            // ========================================================================

            cdObject9 = new
            {
                IdentificacaoRegistro = "001:001:N:R:0:001-001:9:Erro - Identificação Registro::",
                Branco = "002:393:N:R:0:002-394::Erro - Branco::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial de Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroNove, cdObject9);
            // ========================================================================

            cdObject1 = new
            {
                IdentificacaoDoRegistro = "001:001:N:R:0:001-001:1:Erro - Identificação do Registro::",
                AgenciaDebitoOpcional = "002:005:N:R:0:002-006::Erro - Agência de Débito (opcional)::",
                DigitoAgenciaDebitoOpcional = "007:001:N:R:0:007-007::Erro - Dígito da Agência de Débito (opcional)::",
                RazaoContaCorrenteOpcional = "008:005:N:R:0:008-012::Erro - Razão da Conta-Corrente (opcional)::",
                ContaCorrenteOpcional = "013:007:N:R:0:013-019::Erro - Conta-Corrente (opcional)::",
                DigitoContaCorrenteOpcional = "020:001:N:R:0:020-020::Erro - Dígito da Conta-Corrente (opcional)::",
                IdentificacaoEmpresaBeneficiaria = "021:017:N:R:0:021-037::Erro - Identificação da Empresa Beneficiária no Banco::",
                NumeroControleParticipante = "038:025:N:R:0:038-062::Erro - Nº Controle do Participante::",
                CodigoBancoDebito = "063:003:N:R:0:063-065:237:Erro - Código do Banco a ser debitado na Câmara de Compensação::",
                CampoMulta = "066:001:N:R:0:066-066::Erro - Campo de Multa::",
                PercentualMulta = "067:004:N:R:0:067-070::Erro - Percentual de Multa::",
                IdentificacaoTituloBanco = "071:011:N:R:0:071-081::Erro - Identificação do Título no Banco::",
                DigitoAutoconferencia = "082:001:N:R:0:082-082::Erro - Dígito de Autoconferência do Número Bancário::",
                DescontoBonificacao = "083:010:N:R:0:083-092::Erro - Desconto Bonificação por dia::",
                CondicaoEmissaoPapeleta = "093:001:N:R:0:093-093::Erro - Condição para Emissão da Papeleta de Cobrança::",
                EmiteBoletoDebito = "094:001:N:R:0:094-094::Erro - Ident. se emite Boleto para Débito Automático::",
                IdentificacaoOperacaoBanco = "095:010:N:R:0:095-104::Erro - Identificação da Operação do Banco::",
                IndicadorRateio = "105:001:N:R:0:105-105:R:Erro - Indicador Rateio Crédito (opcional)::",
                EnderecamentoAviso = "106:001:N:R:0:106-106::Erro - Endereçamento para Aviso do Débito Automático em Conta-Corrente (opcional)::",
                QuantidadePagamentos = "107:002:N:R:0:107-108::Erro - Quantidade de Pagamentos::",
                IdentificacaoOcorrencia = "109:002:N:R:0:109-110::Erro - Identificação da Ocorrência::",
                NumeroDocumento = "111:010:N:R:0:111-120::Erro - Nº do Documento::",
                DataVencimento = "121:006:N:R:0:121-126::Erro - Data do Vencimento do Título:D:", // :D para campo de data
                ValorTitulo = "127:013:N:R:0:127-139::Erro - Valor do Título::",
                BancoEncarregado = "140:003:N:R:0:140-142::Erro - Banco Encarregado da Cobrança::",
                AgenciaDepositaria = "143:005:N:R:0:143-147::Erro - Agência Depositária::",
                EspecieTitulo = "148:002:N:R:0:148-149::Erro - Espécie de Título::",
                Identificacao = "150:001:N:R:0:150-150::Erro - Identificação::",
                DataEmissaoTitulo = "151:006:N:R:0:151-156::Erro - Data da Emissão do Título:D:",
                PrimeiraInstrucao = "157:002:N:R:0:157-158::Erro - 1ª Instrução::",
                SegundaInstrucao = "159:002:N:R:0:159-160::Erro - 2ª Instrução::",
                ValorDiaAtraso = "161:013:N:R:0:161-173::Erro - Valor a ser Cobrado por Dia de Atraso::",
                DataLimiteDesconto = "174:006:N:R:0:174-179::Erro - Data Limite P/Concessão de Desconto:D:",
                ValorDesconto = "180:013:N:R:0:180-192::Erro - Valor do Desconto::",
                ValorIOF = "193:013:N:R:0:193-205::Erro - Valor do IOF::",
                ValorAbatimento = "206:013:N:R:0:206-218::Erro - Valor do Abatimento a ser Concedido ou Cancelado::",
                TipoInscricaoPagador = "219:002:N:R:0:219-220::Erro - Identificação do Tipo de Inscrição do Pagador::",
                NumeroInscricaoPagador = "221:014:N:R:0:221-234::Erro - Nº Inscrição do Pagador::",
                NomePagador = "235:040:N:R:0:235-274::Erro - Nome do Pagador::",
                EnderecoCompleto = "275:040:N:R:0:275-314::Erro - Endereço Completo::",
                PrimeiraMensagem = "315:012:N:R:0:315-326::Erro - 1ª Mensagem::",
                CEP = "327:005:N:R:0:327-331::Erro - CEP::",
                SufixoCEP = "332:003:N:R:0:332-334::Erro - Sufixo do CEP::",
                BeneficiarioFinal = "335:060:N:R:0:335-394::Erro - Beneficiário Final ou 2ª Mensagem::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial do Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo1, cdObject1);
            // ========================================================================

            cdObject2 = new
            {
                TipoRegistro = "001:001:N:R:0:001-001:2:Erro - Tipo Registro::",
                Mensagem1 = "002:080:N:R:0:002-081::Erro - Mensagem 1::",
                Mensagem2 = "082:080:N:R:0:082-161::Erro - Mensagem 2::",
                Mensagem3 = "162:080:N:R:0:162-241::Erro - Mensagem 3::",
                Mensagem4 = "242:080:N:R:0:242-321::Erro - Mensagem 4::",
                DataLimiteDesconto2 = "322:006:N:R:0:322-327::Erro - Data-Limite para Concessão de Desconto 2:D:",
                ValorDesconto2 = "328:013:N:R:0:328-340::Erro - Valor do Desconto::",
                DataLimiteDesconto3 = "341:006:N:R:0:341-346::Erro - Data-Limite para Concessão de Desconto 3:D:",
                ValorDesconto3 = "347:013:N:R:0:347-359::Erro - Valor do Desconto::",
                Reserva = "360:007:N:R:0:360-366::Erro - Reserva::",
                Carteira = "367:003:N:R:0:367-369::Erro - Carteira::",
                Agencia = "370:005:N:R:0:370-374::Erro - Agência::",
                ContaCorrente = "375:007:N:R:0:375-381::Erro - Conta-Corrente::",
                DigitoCC = "382:001:N:R:0:382-382::Erro - Dígito C/C::",
                NossoNumero = "383:011:N:R:0:383-393::Erro - Nosso Número::",
                DACNossoNumero = "394:001:N:R:0:394-394::Erro - DAC Nosso Número::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial de Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo2, cdObject2);
            // ========================================================================

            cdObject3 = new
            {
                IdentificacaoRegistro = "001:001:N:R:0:001-001:3:Erro - Identificação do Registro::",
                IdentificacaoEmpresaBanco = "002:016:N:R:0:002-017::Erro - Identificação da Empresa no Banco::",
                IdentificacaoTituloBanco = "018:012:N:R:0:018-029::Erro - Identificação Título no Banco::",
                CodigoCalculoRateio = "030:001:N:R:0:030-030::Erro - Código Para Cálculo do Rateio::",
                TipoValorInformado = "031:001:N:R:0:031-031::Erro - Tipo de Valor Informado::",
                Filler1 = "032:012:N:R:0:032-043::Erro - Filler::",
                CodigoBancoCredito1 = "044:003:N:R:0:044-046::Erro - Código do Banco para Crédito do 1º Beneficiário::",
                CodigoAgenciaCredito1 = "047:005:N:R:0:047-051::Erro - Código da Agência para Crédito do 1º Beneficiário::",
                DigitoAgenciaCredito1 = "052:001:N:R:0:052-052::Erro - Dígito da Agência para Crédito do 1º Beneficiário::",
                ContaCorrenteCredito1 = "053:012:N:R:0:053-064::Erro - Número da Conta-Corrente para Crédito do 1º Beneficiário::",
                DigitoContaCredito1 = "065:002:N:R:0:065-066::Erro - Dígito da Conta-Corrente para Crédito do 1º Beneficiário::",
                ValorPercentualRateio1 = "066:015:N:R:0:066-080::Erro - Valor, ou Percentual para Rateio::",
                NomeBeneficiario1 = "081:040:N:R:0:081-120::Erro - Nome do 1º Beneficiário::",
                Filler2 = "121:031:N:R:0:121-151::Erro - Filler::",
                Parcela1 = "152:006:N:R:0:152-157::Erro - Parcela::",
                FloatingBeneficiario1 = "158:003:N:R:0:158-160::Erro - Floating para o 1º Beneficiário::",
                CodigoBancoCredito2 = "161:003:N:R:0:161-163::Erro - Código do Banco para Crédito do 2º Beneficiário::",
                CodigoAgenciaCredito2 = "164:005:N:R:0:164-168::Erro - Código da Agência para Crédito do 2º Beneficiário::",
                DigitoAgenciaCredito2 = "169:001:N:R:0:169-169::Erro - Dígito da Agência para Crédito do 2º Beneficiário::",
                ContaCorrenteCredito2 = "170:012:N:R:0:170-181::Erro - Número da Conta-Corrente para Crédito do 2º Beneficiário::",
                DigitoContaCredito2 = "182:001:N:R:0:182-182::Erro - Dígito da Conta-Corrente para Crédito do 2º Beneficiário::",
                ValorPercentualRateio2 = "183:015:N:R:0:183-197::Erro - Valor, ou Percentual para Rateio::",
                NomeBeneficiario2 = "198:040:N:R:0:198-237::Erro - Nome do 2º Beneficiário::",
                Filler3 = "238:031:N:R:0:238-268::Erro - Filler::",
                Parcela2 = "269:006:N:R:0:269-274::Erro - Parcela::",
                FloatingBeneficiario2 = "275:003:N:R:0:275-277::Erro - Floating para o 2º Beneficiário::",
                CodigoBancoCredito3 = "278:003:N:R:0:278-280::Erro - Código do Banco para Crédito do 3º Beneficiário::",
                CodigoAgenciaCredito3 = "281:005:N:R:0:281-285::Erro - Código da Agência para Crédito do 3º Beneficiário::",
                DigitoAgenciaCredito3 = "286:001:N:R:0:286-286::Erro - Dígito da Agência para Crédito do 3º Beneficiário::",
                ContaCorrenteCredito3 = "287:012:N:R:0:287-298::Erro - Número da Conta-Corrente para Crédito do 3º Beneficiário::",
                DigitoContaCredito3 = "299:001:N:R:0:299-299::Erro - Dígito da Conta-Corrente para Crédito do 3º Beneficiário::",
                ValorPercentualRateio3 = "300:015:N:R:0:300-314::Erro - Valor ou Percentual para Rateio::",
                NomeBeneficiario3 = "315:040:N:R:0:315-354::Erro - Nome do 3º Beneficiário::",
                Filler4 = "355:031:N:R:0:355-385::Erro - Filler::",
                Parcela3 = "386:006:N:R:0:386-391::Erro - Quantidade de Dias para Crédito do Beneficiário::",
                FloatingBeneficiario3 = "392:003:N:R:0:392-394::Erro - Floating para 3º Beneficiário::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Número Sequencial do Registro::"


            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo3, cdObject3);
            // ========================================================================

            cdObject6 = new
            {
                IdentificacaoRegistro = "001:001:A:R:0:001-001:6:Erro - Identificação do Registro::",
                Carteira = "002:003:A:R:0:002-004::Erro - Carteira::",
                Agencia = "005:005:A:R:0:005-009::Erro - Agência::",
                ContaCorrente = "010:007:A:R:0:010-016::Erro - Conta-Corrente::",
                NossoNumero = "017:011:A:R:0:017-027::Erro - Nosso Número::",
                DigitoNossoNumero = "028:001:A:R:0:028-028::Erro - Dígito do Nosso Número::",
                TipoOperacao = "029:001:A:R:0:029-029::Erro - Tipo de Operação::",
                UtilizacaoChequeEspecial = "030:001:A:R:0:030-030::Erro - Utilização do Cheque Especial::",
                ConsultaSaldoAposVencimento = "031:001:A:R:0:031-031::Erro - Consulta Saldo Após o Vencimento::",
                NumeroCodigoIdentificacaoContrato = "032:025:A:R:0:032-056::Erro - Número Cód.Identificação/Contrato::",
                PrazoValidadeContrato = "057:008:A:R:0:057-064::Erro - Prazo de Validade do Contrato/Autorização:D:",
                Brancos = "065:330:N:R:0:065-394::Erro - Brancos::",
                NumeroSequencialRegistro = "395:006:A:R:0:395-400::Erro - Número Sequencial do Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo6, cdObject6);
            // ========================================================================

            cdObject7 = new
            {
                TipoRegistro = "001:001:N:R:0:001-001:7:Erro - Tipo Registro::",
                EnderecoBeneficiarioFinal = "002:045:A:R:0:002-046::Erro - Endereço Beneficiário Final::",
                CEP = "047:005:A:R:0:047-051::Erro - CEP::",
                SufixoCEP = "052:003:A:R:0:052-054::Erro - Suffixo CEP::",
                Cidade = "055:020:A:R:0:055-074::Erro - Cidade::",
                UF = "075:002:A:R:0:075-076::Erro - UF::",
                Reserva = "077:290:A:R:0:077-366::Erro - Reserva::",
                Carteira = "367:003:A:R:0:367-369::Erro - Carteira::",
                Agencia = "370:005:A:R:0:370-374::Erro - Agência::",
                ContaCorrente = "375:007:A:R:0:375-381::Erro - Conta-Corrente::",
                DigitoCC = "382:001:A:R:0:382-382::Erro - Dígito C/C::",
                NossoNumero = "383:011:A:R:0:383-393::Erro - Nosso Número::",
                DACNossoNumero = "394:001:A:R:0:394-394::Erro - DAC Nosso Número::",
                NumeroSequencialRegistro = "395:006:N:R:0:395-400::Erro - Nº Sequencial de Registro::"
            };
            JsonObjectsGenerator.AddProperty(dynamicList, registroTipo7, cdObject7);
            // ========================================================================

            return dynamicList;

        }
    }
}