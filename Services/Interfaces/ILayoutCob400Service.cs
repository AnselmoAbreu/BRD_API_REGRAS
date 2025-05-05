using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRD_API_REGRAS.Services.Interfaces
{
    public interface ILayoutCob400Service
    {
        dynamic MontarJsonCob400(dynamic dynamicList, string codigoArquivo);
    }
}
