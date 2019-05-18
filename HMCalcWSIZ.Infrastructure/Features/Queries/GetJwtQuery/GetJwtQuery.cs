using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using HMCalcWSIZ.Core.Domain;
using MediatR;

namespace HMCalcWSIZ.Infrastructure.Features.Queries.GetJwtQuery
{
    public class GetJwtQuery : IRequest<AuthData>
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
