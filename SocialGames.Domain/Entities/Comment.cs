using SocialGames.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace SocialGames.Domain.Entities
{
    public class Comment : EntityBase
    {
        public DateTime DateTime { get; private set; }
        public string Description { get; private set; }
        public Guid GameId { get; private set; }
        public Game Game { get; private set; }
        public Guid PlayerId { get; private set; }
        public Player Player { get; private set; }
        protected Comment()
        {
        }
        public Comment(string description, Guid gameId, Guid playerId)
        {
            DateTime = DateTime.Now;
            Description = description;
            if (gameId == Guid.Empty) throw new ValidationException("MyGameId not empty!");
            GameId = gameId;
            if (playerId == Guid.Empty) throw new ValidationException("PlayerId not empty!");
            PlayerId = playerId;
        }
        public void Update(string description)
        {
            if (description == null || description.Length == 0) throw new ValidationException("Description cannot be empty");
            Description = description;

        }
    }
}
