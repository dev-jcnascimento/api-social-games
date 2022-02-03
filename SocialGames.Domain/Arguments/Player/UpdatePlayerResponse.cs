﻿using SocialGames.Domain.Arguments.Base;
using SocialGames.Domain.Interfaces.Arguments;
using System;

namespace SocialGames.Domain.Arguments.Player
{
    public class UpdatePlayerResponse : ResponseBase , IResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public static explicit operator UpdatePlayerResponse(Entities.Player entity)
        {
            return new UpdatePlayerResponse()
            {
                Id = entity.Id,
                FirstName = entity.Name.FirstName,
                Email = entity.Email.Address,
                Status = entity.Status.ToString()
            };
        }
    }
}
