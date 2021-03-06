﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using LibFYP.DTOs;
using System.Net;

namespace WebStore.Facades
{
    public class SelectionboxFacade : ApiController
    {
        private readonly HttpClient _client;
        private JsonSerializerSettings _serializerSettings;
        private readonly string _baseUrl = "webapi link"; // add link later

        public SelectionboxFacade()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
            _serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
        }

        //public SelectionBoxFacade(HttpClient client)
        //{
        //    this._client = client;
        //    _serializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };
        //}


        public async Task<HttpResponseMessage> GetSelectionBoxes()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();

                response = await _client.GetAsync(_baseUrl + "selectionbox");
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<Giftbox>>().Result;
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error message");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<HttpResponseMessage> GetSelectionBox(int id)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await _client.GetAsync(_baseUrl + "selectionbox/" + id);
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<HttpResponseMessage> PostSelectionBox(Giftbox giftbox)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await _client.PostAsJsonAsync(_baseUrl + "selectionbox/", giftbox);
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        public async Task<HttpResponseMessage> UpdateSelectionBox(Giftbox giftbox)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await _client.PostAsJsonAsync(_baseUrl + "selectionbox/", giftbox);
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async Task<HttpResponseMessage> RemoveSelectionBox(int id)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response = await _client.PostAsJsonAsync(_baseUrl + "selectionbox/delete", +id);
                return response;
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}