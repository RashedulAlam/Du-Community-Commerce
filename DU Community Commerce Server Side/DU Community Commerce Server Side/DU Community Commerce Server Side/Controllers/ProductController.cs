using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using DU_Community_Commerce_Server_Side.Application_Context;
using DU_Community_Commerce_Server_Side.Models;
using DU_Community_Commerce_Server_Side.Repositories;
using DU_Community_Commerce_Server_Side.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DU_Community_Commerce_Server_Side.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        private readonly string _workingFolder = HttpRuntime.AppDomainAppPath + @"\Uploads";
         private  readonly ApplicationContext _applicationContext = new ApplicationContext();
        private ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository(_applicationContext);
        }

        [HttpPost]
        [Route("Get-All-Product")]
        public string GetAllProduct(Product product)
        {
            
            _applicationContext.Products.Add(product);
            _applicationContext.SaveChanges();
            return "Get-ALL-Products-Controller";
        }

        [HttpPost]
        [Route("Post-Product")]
        public async Task<IHttpActionResult> PostProduct()
        {
            
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var request = HttpContext.Current.Request;
                var productId = request.Params["ProductId"];
                var provider = new CustomMultipartFormDataStreamProvider(_workingFolder);

                await Request.Content.ReadAsMultipartAsync(provider);
                var productImages =
                    provider.FileData
                        .Select(file => new FileInfo(file.LocalFileName))
                        .Select(fileInfo => new ProductImage
                        {
                            ImageName = fileInfo.Name,
                            ProductId= productId
                        }).ToList();

                foreach (var VARIABLE in productImages)
                {
                    _applicationContext.ProductImages.Add(VARIABLE);
                }
                _applicationContext.SaveChanges();

                return Ok(new {Message = Guid.NewGuid(), Photos = productImages});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }

        [Route("Get")]
        public  IHttpActionResult GetJsonResult()
        {
            var listofproducts=_productRepository.GetProducts();
            return Json(listofproducts);
        }

    }

  

    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string rootPath) : base(rootPath)
        {
        }

        public CustomMultipartFormDataStreamProvider(string rootPath, int bufferSize) : base(rootPath, bufferSize)
        {
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            //Make the file name URL safe and then use it & is the only disallowed url character allowed in a windows filename
            //var name = !string.IsNullOrWhiteSpace(headers.ContentDisposition.FileName)
            //    ? headers.ContentDisposition.FileName
            //    : "NoName";
            //name = new Guid().ToString() + ".PNG";
            //return name;

            string oldfileName = headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(oldfileName);

            return newFileName;
        }
    }
}
