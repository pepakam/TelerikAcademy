namespace AcademyPopcorn
{
    public class ShootingPlayerEngine : Engine
    {

        public ShootingPlayerEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {

        }


        public override void ShootPlayerRacket()
        {
            if (this.playerRacket is ShoothingRacket)
            {
                (this.playerRacket as ShoothingRacket).Shoot();
            }
        }
    }
}
