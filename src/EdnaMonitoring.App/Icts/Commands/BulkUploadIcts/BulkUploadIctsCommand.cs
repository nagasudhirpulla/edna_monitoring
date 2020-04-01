using MediatR;
using System;
using System.Text;

namespace EdnaMonitoring.App.Icts.Commands.BulkUploadIcts
{
    public class BulkUploadIctsCommand : IRequest
    {
        public string UploadString { get; set; }
    }
}
