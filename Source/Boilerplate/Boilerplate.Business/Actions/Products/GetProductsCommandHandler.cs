using Boilerplate.Common.Repository;
using Boilerplate.Shared.Common.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boilerplate.Business.Actions.Products
{
    public class GetProductsCommandHandler : IRequestHandler<GetProductCommand, GetProductCommandResult>
    {
        private readonly IBoilerplateDbContext _dbContext;

        public GetProductsCommandHandler(IBoilerplateDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetProductCommandResult> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            var products = await _dbContext.GetProducts(request.ProductName);

            //todo configure automapper
            return new GetProductCommandResult
            {
                Product = new List<ProductDto>
                {
                    new ProductDto
                    {
                        Description="asd",
                        Name="asd",
                        Price=1,
                        Quantity=1
                    }
                }
            };
            
        }
    }

    public class GetProductCommandResult
    {
        public List<ProductDto> Product { get; set; }
    }

    public class GetProductCommand : IRequest<GetProductCommandResult>
    {
        public string? ProductName { get; set; }
    }
}
