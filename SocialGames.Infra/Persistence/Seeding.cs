using SocialGames.Domain.Entities;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;
using System.Linq;

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

            if (_context.Players.Any() && _context.PlatForms.Any() && _context.Games.Any()
                && _context.MyGames.Any())
            {
                return;
            }

            var player1 = new Player(
                new Name("User1", "Teste1"),
                new Email("userteste1@teste.com.br"),
                new Password("123456"),
                PlayerStatus.Active);
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

            var game1 = new Game("Grand Theft Auto IV",
                "Uma breve descrição do jogo Grand Theft Auto IV",
                "Rockstar Games", "Action Adventure, Modern, Open-World", "Rockstar Games", platForm1.Id);

            var game2 = new Game("Grand Theft Auto IV",
               "Uma breve descrição do jogo Grand Theft Auto IV",
               "Rockstar Games", "Action Adventure, Modern, Open-World", "Rockstar Games", platForm4.Id);

            var game3 = new Game("Grand Theft Auto IV",
               "Uma breve descrição do jogo Grand Theft Auto IV",
               "Rockstar Games", "Action Adventure, Modern, Open-World", "Rockstar Games", platForm2.Id);

            var game4 = new Game("Red Dead Redemption 2", "Uma breve descrição do jogo Red Dead Redemption 2",
                "Rockstar Games", "Action Adventure, Open-World", "Rockstar Games", platForm2.Id);

            var game5 = new Game("Red Dead Redemption 2", "Uma breve descrição do jogo Red Dead Redemption 2",
               "Rockstar Games", "Action Adventure, Open-World", "Rockstar Games", platForm5.Id);

            var game6 = new Game("Half - Life 2", "Uma breve descrição do jogo Half - Life 2",
                "VU GAMES", " Action, Shooter, Shooter, First-Person, Sci-Fi, Sci-Fi, Arcade", "VU GAMES", platForm3.Id);

            var game7 = new Game("Half - Life 2", "Uma breve descrição do jogo Half - Life 2",
               "VU GAMES", " Action, Shooter, Shooter, First-Person, Sci-Fi, Sci-Fi, Arcade", "VU GAMES", platForm4.Id);

            var game8 = new Game("Resident Evil 4", "Uma breve descrição do jogo Resident Evil 4",
                "Capcom", "Action Adventure, Horror", "Capcom", platForm4.Id);

            var game9 = new Game("Batman: Arkham City", "Uma breve descrição do jogo Batman: Arkham City",
                "Warner Bros. Interactive Entertainments", "Action Adventure, Fantasy, Fantasy, Open-World",
                "Warner Bros. Interactive Entertainment", platForm5.Id);

            var game10 = new Game("Batman: Arkham City", "Uma breve descrição do jogo Batman: Arkham City",
                "Warner Bros. Interactive Entertainments", "Action Adventure, Fantasy, Fantasy, Open-World",
                "Warner Bros. Interactive Entertainment", platForm3.Id);

            var game11 = new Game("Gran Turismo" , "Uma breve descrição do jogo Gran Turismo",
                "SCEA", "Driving, Racing, GT / Street", "SCEA", platForm3.Id);

            var myGame1 = new MyGame(null,MyGameStatus.NewGame, player1.Id,game1.Id);
            var myGame2 = new MyGame(null,MyGameStatus.NewGame, player1.Id,game11.Id);
            var myGame3 = new MyGame(null,MyGameStatus.NewGame, player1.Id,game10.Id);
            var myGame4 = new MyGame(null,MyGameStatus.NewGame, player1.Id,game4.Id);
            var myGame5 = new MyGame(null,MyGameStatus.NewGame, player2.Id,game4.Id);
            var myGame6 = new MyGame(null,MyGameStatus.NewGame, player2.Id,game11.Id);
            var myGame7 = new MyGame(null,MyGameStatus.NewGame, player3.Id,game9.Id);
            var myGame8 = new MyGame(null,MyGameStatus.NewGame, player3.Id,game7.Id);

            _context.Players.Add(player1);
            _context.Players.Add(player2);
            _context.Players.Add(player3);
            _context.Players.Add(player4);
            _context.Players.Add(player5);

            _context.PlatForms.Add(platForm1);
            _context.PlatForms.Add(platForm2);
            _context.PlatForms.Add(platForm3);
            _context.PlatForms.Add(platForm4);
            _context.PlatForms.Add(platForm5);

            _context.Games.Add(game1);
            _context.Games.Add(game2);
            _context.Games.Add(game3);
            _context.Games.Add(game4);
            _context.Games.Add(game5);
            _context.Games.Add(game6);
            _context.Games.Add(game7);
            _context.Games.Add(game8);
            _context.Games.Add(game9);
            _context.Games.Add(game10);
            _context.Games.Add(game11);

            _context.MyGames.Add(myGame1);
            _context.MyGames.Add(myGame2);
            _context.MyGames.Add(myGame3);
            _context.MyGames.Add(myGame4);
            _context.MyGames.Add(myGame5);
            _context.MyGames.Add(myGame6);
            _context.MyGames.Add(myGame7);

            _context.SaveChangesAsync();
        }
    }

}