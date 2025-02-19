using System;
using System.Collections.Generic;
using System.Dynamic;

namespace BRD_API_REGRAS
{
    public static class JsonCdProdutoGenerator
    {
        public static void AddProperty(dynamic expando, string propertyName, object value)
        {
            if (expando is ExpandoObject)
            {
                var expandoDict = expando as IDictionary<string, object>;
                expandoDict[propertyName] = value;
            }
            else
            {
                throw new ArgumentException("O objeto fornecido não é um ExpandoObject.");
            }
        }
    }
}