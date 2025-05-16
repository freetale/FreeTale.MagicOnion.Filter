#if UNITY_2017_1_OR_NEWER
using MagicOnion.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FreeTale.MagicOnion.Filter.Client
{
    public class UnityLoggerServiceClientFilter : IClientFilter
    {
        public async ValueTask<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, ValueTask<ResponseContext>> next)
        {
            ResponseContext response;
            try
            {
                response = await next.Invoke(context);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                throw;
            }
            var status = response.GetStatus();
            Debug.Log($"{context.MethodPath} {context.MethodPath} -- [{status.StatusCode}] {status}");
            return response;
        }
    }
}
#endif