using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PlacesApp.Mobile.Sections.Http
{
    sealed class HttpService
    {
        private static Lazy<HttpService> _Lazy
            = new Lazy<HttpService>(() => new HttpService());

        public static HttpService Current => _Lazy.Value;

        private HttpService()
        {
            _HttpClient = new HttpClient();
        }

        private HttpClient _HttpClient;
    }
}
