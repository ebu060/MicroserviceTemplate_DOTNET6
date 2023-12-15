using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commands
{
    public class DeleteProductByIdCommand: IRequest<bool>
    {
        public string ProductId { get; set; }
        public DeleteProductByIdCommand(string productId)
        {
            ProductId = productId;
        }
    }
}
