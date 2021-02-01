using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Api.Consume {
    public class Consume {

        /// <summary>
        /// HttpCliente com as configurações básicas
        /// </summary>
        /// <returns></returns>
        private HttpClient GetClient() {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Configurations.URL_ENDPOINT_CONSUME_BASE);
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        /// <summary>
        /// Retorna ulr para buscar informações dos casos de covid
        /// </summary>
        /// <param name="from">data inicial para buscar informações</param>
        /// <param name="to">data final para buscar informações</param>
        /// <param name="country">país para buscar informações</param>
        /// <returns></returns>
        private string GetUrlAllDataByCountry(DateTime from, DateTime to, string country) {
            return $"{Configurations.URL_ENDPOINT_CONSUME_BY_COUNTRY}{country}?from={from.Date.ToShortDateString()}&to={from.Date.ToShortDateString()}";
        }

        /// <summary>
        /// Busca informações de casos 
        /// </summary>
        /// <param name="from">data inicial para buscar informações</param>
        /// <param name="to">data final para buscar informações</param>
        /// <param name="country">país para buscar informações</param>
        /// <returns></returns>
        public IEnumerable<ResultConsumeApiExternal> GetAllDataByCountry(DateTime from, DateTime to, string country) {
            using (HttpClient client = GetClient()) {
                var response = client.GetAsync(GetUrlAllDataByCountry(from, to, country)).Result;
                if (response.IsSuccessStatusCode) {
                    return response.Content.ReadAsAsync<IEnumerable<ResultConsumeApiExternal>>().Result;
                }
            }

            throw new Exception("Falha ao buscar dados!");
        }
      
    }
}
