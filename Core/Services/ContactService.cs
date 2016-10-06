using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Core.Models;
using Newtonsoft.Json;

namespace Core.Services
{
	public class ContactService
	{
		public async Task<List<ContactModel>> Get()
		{
			HttpClient client = new HttpClient();
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://ionixjuniorcontactapi.azurewebsites.net/tables/contact?ZUMO-API-VERSION=2.0.0");
			request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			HttpResponseMessage response = await  client.SendAsync(request);
			string result = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<List<ContactModel>>(result);
		}
	}
}
