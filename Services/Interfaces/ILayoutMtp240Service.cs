using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRD_API_REGRAS.Services.Interfaces
{
    public interface ILayoutMtp240Service
    {
        dynamic MontarJsonMtp240(dynamic dynamicList, string codigoArquivo);
    }
}
