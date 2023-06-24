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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResult>
    {
        private readonly IBoilerplateDbContext _dbContext;

        public CreateProductCommandHandler(IBoilerplateDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class CreateProductCommandResult
    {
        public ProductDto Product { get; set; }
    }

    public class CreateProductCommand : IRequest<CreateProductCommandResult>
    {
        public ProductDto Product { get; set; }

    }
}
