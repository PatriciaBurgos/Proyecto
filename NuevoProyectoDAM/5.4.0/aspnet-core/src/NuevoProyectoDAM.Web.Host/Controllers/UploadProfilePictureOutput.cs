using Abp.Web.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuevoProyectoDAM.Web.Host.Controllers
{
	public class UploadProfilePictureOutput
	{

        public string FileName { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
        public int Code { get; }
        public string Details { get; }
        public string Message { get; }
        public ValidationErrorInfo[] ValidationErrors { get; }

        public UploadProfilePictureOutput()
        {

        }

        public UploadProfilePictureOutput(ErrorInfo error)
        {
            Code = error.Code;
            Details = error.Details;
            Message = error.Message;
            ValidationErrors = error.ValidationErrors;
        }

    }
}
