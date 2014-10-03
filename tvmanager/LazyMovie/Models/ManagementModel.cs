using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;
using LazyMovie.Models.Interfaces;
using LazyMovie.TvManagementService;

namespace LazyMovie.Models
{
	internal class ManagementModel : IManagementModel
	{
		private readonly TimeSpan _timeout = TimeSpan.FromSeconds(30);

		ManagementServiceClient _client;

		public Task<TCallbackResultType> Call<TCallbackResultType>(string actionName, object[] parameters = null)
		{
			Type client = typeof (ManagementServiceClient);
			var taskCompletionSource = new TaskCompletionSource<TCallbackResultType>();

			var method = client.GetMethod(actionName + "Async", new Type[] {});
			var callbackEvent = client.GetEvent(actionName + "Completed");

			Delegate delegateToExecute =
				new EventHandler<TCallbackResultType>((sender, result) => taskCompletionSource.SetResult(result));
			
			callbackEvent.AddEventHandler(_client, delegateToExecute);

			method.Invoke(_client, parameters);

			return taskCompletionSource.Task;
		}

		public async Task<TCallbackResultType> CallSafe<TCallbackResultType>(string actionName, object[] parameters = null) where TCallbackResultType : class 
		{
			try
			{
				return await Call<TCallbackResultType>(actionName, parameters);
			}
			catch (Exception)
			{
				return default(TCallbackResultType);
			}
		}

		public async Task<Exception> Connect(string hostAddress)
		{
			var httpBinding = new BasicHttpBinding();
			httpBinding.OpenTimeout = _timeout;
			httpBinding.SendTimeout = _timeout;

			_client = new ManagementServiceClient(httpBinding, new EndpointAddress(hostAddress));

			try
			{
				var result = await CallSafe<AsyncCompletedEventArgs>("Open");
				if (result != null)
				{
					return result.Error;
				}

				return new CommunicationException("Unable to connect");
			}
			catch (Exception e)
			{
				return e;
			}
		}


		public async Task<string> Ping()
		{
			var result = await CallSafe<PingCompletedEventArgs>("Ping");
			if (result.IsOk())
			{
				return result.Result;
			}

			return null;
		}
	}
}