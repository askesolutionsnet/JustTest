using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Web.UI;
using System.Threading;
using BanquetSystem.Domain;
using System.Net.Http.Headers;
using System.Text;

namespace BanquetSystem.Services
{
      public class BanquetAPIService
    {
        
        readonly string apiurl = System.Configuration.ConfigurationManager.AppSettings["APIAbsoulteURL"];

        /// <summary>
        /// Get Banquets Record to displaying on listing page.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<CustomerBDO>> GetBanquestAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format("{0}{1}",apiurl, "api/BanquetAPI"));
                return (await response.Content.ReadAsAsync<IEnumerable<CustomerBDO>>());
            }
        }

        /// <summary>
        /// Get Banquet details by id Records to displaying on detail page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CustomerDetailBDO> GetBanquestDetailAsync(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(string.Format("{0}{1}{2}", apiurl, "api/BanquetDetailAPI/",id));
                return (await response.Content.ReadAsAsync<CustomerDetailBDO>());
            }
        }

        /// <summary>
        /// Post and save banquet new record into the database
        /// </summary>
        /// <param name="banquestdetails"></param>
        /// <returns></returns>
        public async Task<string> SaveBanquestAsync(CustomerDetailBDO banquestdetails)
        {
            string getSucessfullOperation = string.Empty;
            string savebanquesturlstr = string.Format("{0}{1}", apiurl, "api/BanquetDetailAPI/Post");
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(savebanquesturlstr);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                StringContent content = new StringContent(JsonConvert.SerializeObject(banquestdetails), Encoding.UTF8, "application/json");
                // HTTP POST
                HttpResponseMessage response = await httpClient.PostAsync(savebanquesturlstr, content);
                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    getSucessfullOperation = JsonConvert.DeserializeObject<string>(data);
                }
            }
            return getSucessfullOperation;
        }

    }
}