#region "imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using DeepIn.DataModel;

#endregion

namespace DeepIn.Controller
{
    public class ProductCsvFormatter :BufferedMediaTypeFormatter
    {
        public ProductCsvFormatter() 
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
            SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier:false));
            SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
        }

        public override bool CanReadType(Type type)
        {
            //throw new NotImplementedException();
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            //throw new NotImplementedException();
            if (type == typeof(ProductModel))
            {
                return true;
            }
            else 
            {
                Type enumerableType = typeof(IEnumerable<ProductModel>);

                return enumerableType.IsAssignableFrom(type);
            }
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            //base.WriteToStream(type, value, writeStream, content);
            Encoding effectiveEncoding = SelectCharacterEncoding(content.Headers);
            using (StreamWriter writer = new StreamWriter(writeStream,effectiveEncoding)) 
            {
                var products  = value as IEnumerable<ProductModel>;
                if(products !=null)
                {
                    foreach(var product in products)
                    {
                        WriteItem(product,writer);
                    }
                }else 
                {
                    var singleProduct = value as ProductModel;
                    if(singleProduct==null)
                    {
                        throw new InvalidOperationException("Cannot serialize type");
                    }
                    WriteItem(singleProduct,writer);
                }
            }
        }

        // Helper methods for serializing Products to CSV format. 
        private void WriteItem(ProductModel product, StreamWriter writer)
        {
            writer.WriteLine("{0},{1},{2},{3}", Escape(product.Id),
                Escape(product.Name), Escape(product.Category), Escape(product.Price));
        }

        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };

        private string Escape(object o)
        {
            if (o == null)
            {
                return "";
            }
            string field = o.ToString();
            if (field.IndexOfAny(_specialChars) != -1)
            {
                // Delimit the entire field with quotes and replace embedded quotes with "".
                return String.Format("\"{0}\"", field.Replace("\"", "\"\""));
            }
            else return field;
        }
    }
}
