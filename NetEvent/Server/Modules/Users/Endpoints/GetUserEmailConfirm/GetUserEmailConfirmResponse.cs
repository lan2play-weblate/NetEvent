﻿using Microsoft.AspNetCore.Http;
using NetEvent.Shared.Dto;

namespace NetEvent.Server.Modules.Users.Endpoints.GetUser
{
    public class GetUserEmailConfirmResponse : ResponseBase<IResult>
    {
        public GetUserEmailConfirmResponse(IResult result) : base(result)
        {
        }

        public GetUserEmailConfirmResponse(ReturnType returnType, string error) : base(returnType, error)
        {
        }
    }
}
