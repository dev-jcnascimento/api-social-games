using SocialGames.Domain.Entities;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialGames.Infra.Persistence
{
    public class Seeding
    {
        private readonly SocialGamesContext _context;

        public Seeding(SocialGamesContext context)
        {
            _context = context;
        }
        public void Seed()
        {

            if (_context.Players.Any())
            {
                return;
            }

            var player1 = new Player(
                new Name("User1", "Teste1"),
                new Email("userteste1@teste.com.br"),
                new Password("123456"),
                PlayerStatus.Active) ;
            var player2 = new Player(
                new Name("User2", "Teste2"),
                new Email("userteste2@teste.com.br"),
                new Password("123456"),
                PlayerStatus.Active);
            var player3 = new Player(
                new Name("User3", "Teste3"),
                new Email("userteste3@teste.com.br"),
                new Password("123456"),
                PlayerStatus.Active);
            var player4 = new Player(
               new Name("User4", "Teste4"),
               new Email("userteste4@teste.com.br"),
               new Password("123456"),
               PlayerStatus.Blocked);
            var player5 = new Player(
               new Name("User5", "Teste5"),
               new Email("userteste5@teste.com.br"),
               new Password("123456"),
               PlayerStatus.In_Analysis);

            var platForm1 = new PlatForm("Xbox 360");
            var platForm2 = new PlatForm("Xbox ONE");
            var platForm3 = new PlatForm("Nintendo Switch");
            var platForm4 = new PlatForm("PlayStation 4");
            var platForm5 = new PlatForm("PlayStation 5");

            var game1 = new Game("Grand Theft Auto IV");
            var game2 = new Game("Red Dead Redemption 2");
            var game3 = new Game("Half - Life 2");
            var game4 = new Game("Resident Evil 4");
            var game5 = new Game("Batman: Arkham City");
            var game6 = new Game("Gran Turismo");


        }
    }

}