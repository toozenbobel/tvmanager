using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Interactivity
{
	public class DefaultResponse
	{
		public HttpStatusCode Code { get; private set; }
		public bool IsSuccessful { get; private set; }
		public string Message { get; private set; }

		public DefaultResponse(HttpStatusCode code, bool isSuccessful, string message)
		{
			Code = code;
			IsSuccessful = isSuccessful;
			Message = message;
		}
	}

	public class CommunicationService : ICommunicationService
	{
		private HttpClient _httpClient;
		private CookieContainer _cookieContainer;

		private string _targetHost;
		private int _targetPort;

		public void Initialize(string targetHost, int targetPort)
		{
			_targetHost = targetHost;
			_targetPort = targetPort;

			_cookieContainer = new CookieContainer();

			_httpClient = new HttpClient(new HttpClientHandler()
			{
				AllowAutoRedirect = true,
				UseCookies = true,
				CookieContainer = _cookieContainer
			}, false);
		}

		private bool EnsureInitialized()
		{
			return !string.IsNullOrWhiteSpace(_targetHost) && _targetPort > 0;
		}

		public async Task<DefaultResponse> PostCommand(int commandId)
		{
			if (!EnsureInitialized())
				return new DefaultResponse(HttpStatusCode.NotFound, false, "Service not initialized");

			string path = string.Format("http://{0}:{1}/command.html", _targetHost, _targetPort);

			// generate command parameter
			HttpContent content =
				new FormUrlEncodedContent(new[]
				{new KeyValuePair<string, string>("wm_command", commandId.ToString(CultureInfo.InvariantCulture))});

			var response = await _httpClient.PostAsync(path, content);
			if (response != null)
			{
				return new DefaultResponse(response.StatusCode, response.IsSuccessStatusCode, null);
			}

			return new DefaultResponse(HttpStatusCode.NotFound, false, "Response is null");
		}
	}
}