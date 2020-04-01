using MediatR;
using System;
using System.Text;

namespace EdnaMonitoring.App.Icts.Commands.BulkUploadTransLines
{
    public class BulkUploadTransLinesCommand : IRequest
    {
        public string UploadString { get; set; }
    }
}
