namespace BRD_API_REGRAS.Services.Interfaces
{
    public interface ILayoutCob400Service
    {
        dynamic MontarJsonCob400(dynamic dynamicList, string codigoArquivo);
    }
}
