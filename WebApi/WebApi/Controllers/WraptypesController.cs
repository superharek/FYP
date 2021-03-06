﻿using LibFYP.DTOs;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class WraptypesController : ApiController
    {
        private Order _wraptype;

        public WraptypesController(Order repo)
        {
            _wraptype = repo;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetWraptypes()
        {
            try
            {
                var repo = new WrapTypeRepo(new HttpClient());
                IQueryable<Types> results;
                results = await repo.GetAll();
                if (results.ToList().Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, results);
                }
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nothing found");
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetWraptype(int id)
        {
            try
            {
                var repo = new WrapTypeRepo(new HttpClient());
                Types results;
                results = await repo.GetById(id);
                if (results == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NoContent, "Nothing found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, results);
            }

            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Something went wrong");
            }
        }
    }
}