using SocialGames.Domain.Entities;
using SocialGames.Domain.Enum;
using SocialGames.Domain.ValueObject;
using System.Linq;

namespace SocialGames.Infra.Persistence
{
    public static class Seeding
    {
        public static void Seed()
        {
            using (var _context = new SocialGamesContext())
            {

                if (_context.Player.Any() || _context.PlatForm.Any() || _context.Game.Any()
                    || _context.MyGame.Any())
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
                    "VU GAMES", "Action, Shooter, Shooter, First-Person, Sci-Fi, Sci-Fi, Arcade", "VU GAMES", platForm3.Id);

                var game7 = new Game("Half - Life 2", "Uma breve descrição do jogo Half - Life 2",
                   "VU GAMES", "Action, Shooter, Shooter, First-Person", "VU GAMES", platForm4.Id);

                var game8 = new Game("Resident Evil 4", "Uma breve descrição do jogo Resident Evil 4",
                    "Capcom", "Action Adventure, Horror", "Capcom", platForm4.Id);

                var game9 = new Game("Batman: Arkham City", "Uma breve descrição: Batman - Arkham City",
                    "Warner Bros. Interactive Entertainments", "Action Adventure, Fantasy, Fantasy",
                    "Warner Bros. Interactive Entertainment", platForm5.Id);

                var game10 = new Game("Batman: Arkham City", "Uma breve descrição: Batman - Arkham City",
                    "Warner Bros. Interactive Entertainments", "Action Adventure, Fantasy, Fantasy",
                    "Warner Bros. Interactive Entertainment", platForm3.Id);

                var game11 = new Game("Gran Turismo", "Uma breve descrição do jogo Gran Turismo",
                    "SCEA", "Driving, Racing, GT / Street", "SCEA", platForm3.Id);

                var comment1 = new Comment("Where it goes beyond a typical first person shooter is in its story " +
                    "telling. The graphics engine is so realistic that you feel like you are participating in a movie." +
                    " The character's facial animation is incredible. It's done so well, you can get a sense of how " +
                    "the characters are feeling.", game6.Id, player2.Id);

                var comment2 = new Comment("We can talk hours and hours about it, but it won't change the fact that " +
                    "Grand Theft Auto IV is a very good game. The brand new video editor will offer tons and tons of " +
                    "extra gameplay and makes up for a lot of the waiting time the PC-gamers had to endure. Gamers" +
                    " that still aren't satisfied can wait for the hundreds or so mods that will appear after the " +
                    "release. And with that enough gaming material to last at least until Grand Theft Auto V shows" +
                    " up.", game1.Id, player1.Id);

                var comment3 = new Comment("Half-Life 2 has astonished us from start to finish. Valve has done to the " +
                    "FPS genre what restaurants in Chinatown do to ducks; shredded it, smothered it in a delicious " +
                    "sauce of their own devising, and served it up in a way which you simply couldn't have imagined " +
                    "when looking at them in the pond.", game7.Id, player3.Id);


                var myGame1 = new MyGame(player1.Id, game1.Id);
                var myGame2 = new MyGame(player1.Id, game11.Id);
                var myGame3 = new MyGame(player1.Id, game10.Id);
                var myGame4 = new MyGame(player1.Id, game4.Id);
                var myGame5 = new MyGame(player2.Id, game4.Id);
                var myGame6 = new MyGame(player2.Id, game6.Id);
                var myGame7 = new MyGame(player3.Id, game9.Id);
                var myGame8 = new MyGame(player3.Id, game7.Id);

                _context.Player.Add(player1);
                _context.Player.Add(player2);
                _context.Player.Add(player3);
                _context.Player.Add(player4);
                _context.Player.Add(player5);



                _context.PlatForm.Add(platForm1);
                _context.PlatForm.Add(platForm2);
                _context.PlatForm.Add(platForm3);
                _context.PlatForm.Add(platForm4);
                _context.PlatForm.Add(platForm5);



                _context.Game.Add(game1);
                _context.Game.Add(game2);
                _context.Game.Add(game3);
                _context.Game.Add(game4);
                _context.Game.Add(game5);
                _context.Game.Add(game6);
                _context.Game.Add(game7);
                _context.Game.Add(game8);
                _context.Game.Add(game9);
                _context.Game.Add(game10);
                _context.Game.Add(game11);



                _context.MyGame.Add(myGame1);
                _context.MyGame.Add(myGame2);
                _context.MyGame.Add(myGame3);
                _context.MyGame.Add(myGame4);
                _context.MyGame.Add(myGame5);
                _context.MyGame.Add(myGame6);
                _context.MyGame.Add(myGame7);
                _context.MyGame.Add(myGame8);

               
                _context.Comment.Add(comment1);
                _context.Comment.Add(comment2);
                _context.Comment.Add(comment3);

                _context.SaveChanges();
            }
        }
    }

}