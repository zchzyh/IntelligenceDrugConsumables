using Nancy;
using Nancy.TinyIoc;
using Nancy.Bootstrapper;
using LeaRun.Util;
using System.IO;

namespace LeaRun.Application.AppSerivce
{
    /// <summary>
    /// 版 本 6.1
    /// Admin Studio
    /// 创建人：Admin
    /// 日 期：2016.05.04 13:57
    /// 描 述:初始化
    /// </summary>
    public class Bootstraper : DefaultNancyBootstrapper
    {
        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            //CORS Enable
            pipelines.AfterRequest.AddItemToEndOfPipeline((ctx) =>
            {
                ctx.Response.WithHeader("Access-Control-Allow-Origin", "*")
                                .WithHeader("Access-Control-Allow-Methods", "POST,GET")
                                .WithHeader("Access-Control-Allow-Headers", "Accept, Origin, Content-type");

            }); 
        }
    }
}