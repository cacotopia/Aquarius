#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DeepIn.DataModel;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Web.Http.Controllers;
using DeepIn.Common;
using System.Web.Http.ModelBinding;

#endregion

namespace DeepIn.Controller
{
    /// <summary>
    /// 模型绑定实例
    /// </summary>    
    [RoutePrefix("api/v10/Binder")]
    public class BinderController :ApiController
    {
        [HttpGet] 
        [Route("action1/{x}/{y}/{z}")]
        public DemoModel Action1(int x, int y, int z) 
        {
            return new DemoModel() 
            {
                X=x,Y=y,Z=z
            };
        }

        [HttpGet]
        [Route("action2/{x}/{y}/{z}")]
        public DemoModel Action2(DemoModel model) 
        {
            return model;
        }

        [HttpGet]
        [Route("action3/{x}/{y}/{z}")]
        public IEnumerable<DemoModel> Action3(DemoModel model1, DemoModel model2) 
        {
            yield return model1;
            yield return model2;
        }

        [HttpGet]
        [Route("action4/{model1.x}/{model1.y}/{model1.z}/{model2.x}/{model2.y}/{model2.z}")]
        public IEnumerable<DemoModel> Action4(DemoModel model1, DemoModel model2) 
        {
            yield return model1;
            yield return model2;
        }

        [HttpGet]
        [Route("action5/{foo}/{bar}/{baz}")]
        public Tuple<string, int, int?> Action5(string foo, int bar, int? baz) 
        {
            return new Tuple<string, int, int?>(foo,bar,baz);
        }

        [HttpGet]
        [Route("action6")]
        public ContractModel Action6([ModelBinder]ContractModel contract)
        {
            return contract;
        }

        [HttpGet]
        [Route("action7")]
        public IEnumerable<ContractModel> Action7([ModelBinder]IEnumerable<ContractModel> contracts) 
        {
            return contracts;
        }

        [HttpGet]
        [Route("action8")]
        public IDictionary<string, ContractModel> Action8([ModelBinder]IDictionary<string, ContractModel> contracts) 
        {
            return contracts;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            StaticValueProviderFactory.Clear();
           
            //复杂类型的模型绑定
            StaticValueProviderFactory.Add("Name","张三");
            StaticValueProviderFactory.Add("PhoneNo","13888888");
            StaticValueProviderFactory.Add("EmailAddress","sinotopia@gmail.com");
            StaticValueProviderFactory.Add("Address.Province","浙江省");
            StaticValueProviderFactory.Add("Address.City","杭州市");
            StaticValueProviderFactory.Add("Address.District","滨江区");
            StaticValueProviderFactory.Add("Address.Street","浦沿街道");

            //集合类型的模型绑定(一)
            StaticValueProviderFactory.Add("[0].Name","张三");
            StaticValueProviderFactory.Add("[0].PhoneNo","666666");
            StaticValueProviderFactory.Add("[0].EmailAddress","zhangsan@gmail.com");
            StaticValueProviderFactory.Add("[0].Name", "李四");
            StaticValueProviderFactory.Add("[0].PhoneNo", "7777777");
            StaticValueProviderFactory.Add("[0].EmailAddress", "lisi@gmail.com");
            StaticValueProviderFactory.Add("[0].Name", "王五");
            StaticValueProviderFactory.Add("[0].PhoneNo", "88888888");
            StaticValueProviderFactory.Add("[0].EmailAddress", "王五@gmail.com");

            //集合类型的模型绑定(二)
            StaticValueProviderFactory.Add("contracts.index", "foo");
            StaticValueProviderFactory.Add("contracts.index", "bar");
            StaticValueProviderFactory.Add("contracts.index", "baz");
            StaticValueProviderFactory.Add("contracts[foo].Name", "张三");
            StaticValueProviderFactory.Add("contracts[foo].PhoneNo", "666666");
            StaticValueProviderFactory.Add("contracts[foo].EmailAddress", "zhangsan@gmail.com");
            StaticValueProviderFactory.Add("contracts[bar].Name", "李四");
            StaticValueProviderFactory.Add("contracts[bar].PhoneNo", "7777777");
            StaticValueProviderFactory.Add("contracts[bar].EmailAddress", "lisi@gmail.com");
            StaticValueProviderFactory.Add("contracts[baz].Name", "王五");
            StaticValueProviderFactory.Add("contracts[baz]", "88888888");
            StaticValueProviderFactory.Add("contracts[baz].EmailAddress", "王五@gmail.com");

            //字典字典类型的Model绑定
            StaticValueProviderFactory.Add("[0].Key","张三");
            StaticValueProviderFactory.Add("[0].Value.Name","张三");
            StaticValueProviderFactory.Add("[0].Value.PhoneNo","666666");
            StaticValueProviderFactory.Add("[0].Value.EmailAddress", "zhangsan@gmail.com");
            StaticValueProviderFactory.Add("[1].Key", "李四");
            StaticValueProviderFactory.Add("[1].Value.Name", "李四");
            StaticValueProviderFactory.Add("[1].Value.PhoneNo", "7777777");
            StaticValueProviderFactory.Add("[1].Value.EmailAddress", "lisi@gmail.com");
            StaticValueProviderFactory.Add("[2].Key", "王五");
            StaticValueProviderFactory.Add("[2].Value.Name", "王五");
            StaticValueProviderFactory.Add("[2].Value.PhoneNo", "88888888");
            StaticValueProviderFactory.Add("[2].Value.EmailAddress", "wangwu@gmail.com");
        }
    }
}
