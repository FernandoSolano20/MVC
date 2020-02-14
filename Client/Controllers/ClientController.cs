using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Client.Models;
using CoreApiService;
using POJOS;

namespace Client.Controllers
{
    public class ClientController : ApiController
    {
        ApiResponse apiResponse = new ApiResponse();

        public IHttpActionResult Get()
        {

            apiResponse = new ApiResponse();
            var mng = new ClientManager();
            apiResponse.Data = mng.RetrieveAll();

            return Ok(apiResponse);
        }

        public IHttpActionResult Get(int id)
        {
            var mng = new ClientManager();
            var client = new ClientType
            {
                Id = id
            };

            client = mng.RetrieveById(client);
            apiResponse = new ApiResponse();
            apiResponse.Data = client;
            return Ok(apiResponse);
        }

        public IHttpActionResult Post(ClientType client)
        {
            var mng = new ClientManager();
            mng.Create(client);

            apiResponse = new ApiResponse();
            apiResponse.Message = "Action was executed.";

            return Ok(apiResponse);
        }

        public IHttpActionResult Put(ClientType client)
        {
            var mng = new ClientManager();
            mng.Update(client);

            apiResponse = new ApiResponse();
            apiResponse.Message = "Action was executed.";

            return Ok(apiResponse);
        }

        // DELETE ==
        public IHttpActionResult Delete(ClientType client)
        {
            var mng = new ClientManager();
            mng.Delete(client);

            apiResponse = new ApiResponse();
            apiResponse.Message = "Action was executed.";

            return Ok(apiResponse);
        }
    }
}
