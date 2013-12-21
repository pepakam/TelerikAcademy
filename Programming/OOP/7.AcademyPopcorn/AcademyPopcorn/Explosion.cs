namespace AcademyPopcorn
{
    public class Explosion : MovingObject
    {
     
        public Explosion(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { 'x' } }, speed)
        {
           
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        //public override void RespondToCollision(CollisionData collisionData)
        //{
        //    this.IsDestroyed = true;
        //}


        public override void Update()
        {
            this.UpdatePosition();
            int i = 1;
            i--;
            if (i == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
