using LibraryDataService;
using LibraryDataService.Models;
using LibraryDataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryMVC.Controllers.Api
{
    public class ChartsController : ApiController
    {
        private IUnitOfWork _unitOfWork;
        public ChartsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public HttpResponseMessage Hits(int id)
        {
            Book book = _unitOfWork.BookRepository.GetAll().FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The book is missing.");
            }
            var data = book.GoogleChartData;
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
